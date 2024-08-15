using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Requests;
using ObsWebSocketSharp.Objs.Responses;
using ObsWebSocketSharp.Utils;

namespace ObsWebSocketSharp;

public partial class ObsWebSocketSharp
{
    private readonly Dictionary<string, Semaphore> _locks = [];
    private readonly Dictionary<string, object> _data = [];

    /// <summary>
    /// Gets data about the current plugin and RPC version.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetVersion?> GetVersion()
    {
        CheckConnected();
        return await LockWait(new Request.GetVersion()) as Response.GetVersion;
    }

    /// <summary>
    /// Gets statistics about OBS, obs-websocket, and the current session.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetStats?> GetStats()
    {
        CheckConnected();
        return await LockWait(new Request.GetStats()) as Response.GetStats;
    }

    /// <summary>
    /// Broadcasts a <see cref="Objs.Events.CustomEvent"/> to all WebSocket clients. Receivers are clients which are identified and subscribed.
    /// </summary>
    /// <param name="data">Data payload to emit to all receivers</param>
    /// <returns></returns>
    public async Task<Response.BroadcastCustomEvent?> BroadcastCustomEvent(object data)
    {
        CheckConnected();
        return await LockWait(new Request.BroadcastCustomEvent()
        { 
            EventData = data
        }) as Response.BroadcastCustomEvent;
    }

    /// <summary>
    /// Call a request registered to a vendor.
    /// 
    /// A vendor is a unique name registered by a third-party plugin or script, which allows for custom requests and events to be added to obs-websocket. If a plugin or script implements vendor requests or events, documentation is expected to be provided with them.
    /// </summary>
    /// <param name="vendorName">Name of the vendor to use</param>
    /// <param name="requestType">The request type to call</param>
    /// <param name="requestData">Object containing appropriate request data</param>
    /// <returns></returns>
    public async Task<Response.CallVendorRequest?> CallVendorRequest(string vendorName, string requestType, object requestData)
    {
        CheckConnected();
        return await LockWait(new Request.CallVendorRequest()
        {
            VendorName = vendorName,
            RequestType = requestType,
            RequestData = requestData
        }) as Response.CallVendorRequest;
    }

    /// <summary>
    /// Gets an array of all hotkey names in OBS.
    /// 
    /// Note: Hotkey functionality in obs-websocket comes as-is, and we do not guarantee support if things are broken. In 9/10 usages of hotkey requests, there exists a better, more reliable method via other requests.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetHotkeyList?> GetHotkeyList()
    {
        CheckConnected();
        return await LockWait(new Request.GetHotkeyList()) as Response.GetHotkeyList;
    }

    /// <summary>
    /// Triggers a hotkey using its name. See <see cref="GetHotkeyList"/>.
    /// 
    /// Note: Hotkey functionality in obs-websocket comes as-is, and we do not guarantee support if things are broken. In 9/10 usages of hotkey requests, there exists a better, more reliable method via other requests.
    /// </summary>
    /// <param name="hotkeyName">Name of the hotkey to trigger</param>
    /// <param name="contextName">Name of context of the hotkey to trigger</param>
    /// <returns></returns>
    public async Task<Response.TriggerHotkeyByName?> TriggerHotkeyByName(string hotkeyName, string? contextName)
    {
        CheckConnected();
        return await LockWait(new Request.TriggerHotkeyByName()
        { 
            HotkeyName = hotkeyName,
            ContextName = contextName
        }) as Response.TriggerHotkeyByName;
    }

    /// <summary>
    /// Triggers a hotkey using a sequence of keys.
    /// 
    /// Note: Hotkey functionality in obs-websocket comes as-is, and we do not guarantee support if things are broken. In 9/10 usages of hotkey requests, there exists a better, more reliable method via other requests.
    /// </summary>
    /// <param name="keyId">The OBS key ID to use. See https://github.com/obsproject/obs-studio/blob/master/libobs/obs-hotkeys.h</param>
    /// <param name="shift">Press Shift</param>
    /// <param name="control">Press CTRL</param>
    /// <param name="alt">Press ALT</param>
    /// <param name="command">Press CMD (Mac)</param>
    /// <returns></returns>
    public async Task<Response.TriggerHotkeyByKeySequence?> TriggerHotkeyByKeySequence(string? keyId, bool shift = false, bool control = false, bool alt = false, bool command = false)
    {
        CheckConnected();
        return await LockWait(new Request.TriggerHotkeyByKeySequence()
        {
            KeyId = keyId,
            KeyModifiers = new()
            { 
                Shift = shift,
                Control = control,
                Alt = alt,
                Command = command
            }
        }) as Response.TriggerHotkeyByKeySequence;
    }

    /// <summary>
    /// Sleeps for a time duration or number of frames. Only available in request batches with types SERIAL_REALTIME or SERIAL_FRAME.
    /// </summary>
    /// <param name="sleepMillis">Number of milliseconds to sleep for (if SERIAL_REALTIME mode) <para></para> >= 0, <= 50000</param>
    /// <param name="sleepFrames">Number of frames to sleep for (if SERIAL_FRAME mode) <para></para> >= 0, <= 10000</param>
    /// <returns></returns>
    public async Task<Response.Sleep?> Sleep(long? sleepMillis, long? sleepFrames)
    {
        CheckConnected();
        return await LockWait(new Request.Sleep()
        {
            SleepMillis = sleepMillis,
            SleepFrames = sleepFrames
        }) as Response.Sleep;
    }

    private async Task<object?> LockWait(BaseRequest request)
    {
        var uuid = GenUuid();
        using var sem = new Semaphore(0, 2);
        _locks.Add(uuid, sem);
        _client.Send(request.MakeData(uuid));
        await Task.Run(() =>
        {
            sem.WaitOne();
        });
        _locks.Remove(uuid);
        _data.Remove(uuid, out var data);
        return data;
    }

    private void Unlock(string uuid, object? data)
    {
        if (data != null)
        {
            _data.Add(uuid, data);
        }
        _locks[uuid].Release();
    }

    private void CheckConnected()
    {
        if (State != ClientState.Connected)
        { 
            throw new Exception("Websocket is not connected");  
        }
        if (Identified == false)
        {
            throw new Exception("Client is not identified");
        }
    }

    private string GenUuid()
    {
        string uuid;
        lock (_locks)
        {
            do
            {
                uuid = Guid.NewGuid().ToString().Replace("-", "").ToLower();
            }
            while (_locks.ContainsKey(uuid));
        }

        return uuid;
    }
}
