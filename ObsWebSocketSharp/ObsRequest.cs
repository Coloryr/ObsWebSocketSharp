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
    /// <para></para>
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
    /// <para></para>
    /// Note: Hotkey functionality in obs-websocket comes as-is, and we do not guarantee support if things are broken. In 9/10 usages of hotkey requests, there exists a better, more reliable method via other requests.
    /// </summary>
    /// <param name="hotkeyName">Name of the hotkey to trigger</param>
    /// <param name="contextName">Name of context of the hotkey to trigger</param>
    /// <returns></returns>
    public async Task<Response.TriggerHotkeyByName?> TriggerHotkeyByName(string hotkeyName, string? contextName = null)
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
    /// <para></para>
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
    /// <param name="sleepMillis">Number of milliseconds to sleep for (if SERIAL_REALTIME mode) >= 0, &lt;= 50000</param>
    /// <param name="sleepFrames">Number of frames to sleep for (if SERIAL_FRAME mode) >= 0, &lt;= 10000</param>
    /// <returns></returns>
    public async Task<Response.Sleep?> Sleep(long? sleepMillis = null, long? sleepFrames = null)
    {
        CheckConnected();
        return await LockWait(new Request.Sleep()
        {
            SleepMillis = sleepMillis,
            SleepFrames = sleepFrames
        }) as Response.Sleep;
    }

    /// <summary>
    /// Gets the value of a "slot" from the selected persistent data realm.
    /// </summary>
    /// <param name="realm">The data realm to select. OBS_WEBSOCKET_DATA_REALM_GLOBAL or OBS_WEBSOCKET_DATA_REALM_PROFILE</param>
    /// <param name="slotName">The name of the slot to retrieve data from</param>
    /// <returns></returns>
    public async Task<Response.GetPersistentData?> GetPersistentData(string realm, string slotName)
    {
        CheckConnected();
        return await LockWait(new Request.GetPersistentData()
        {
            Realm = realm,
            SlotName = slotName
        }) as Response.GetPersistentData;
    }

    /// <summary>
    /// Sets the value of a "slot" from the selected persistent data realm.
    /// </summary>
    /// <param name="realm">The data realm to select. OBS_WEBSOCKET_DATA_REALM_GLOBAL or OBS_WEBSOCKET_DATA_REALM_PROFILE</param>
    /// <param name="slotName">The name of the slot to retrieve data from</param>
    /// <param name="slotValue">The value to apply to the slot</param>
    /// <returns></returns>
    public async Task<Response.SetPersistentData?> SetPersistentData(string realm, string slotName, object slotValue)
    {
        CheckConnected();
        return await LockWait(new Request.SetPersistentData()
        {
            Realm = realm,
            SlotName = slotName,
            SlotValue = slotValue
        }) as Response.SetPersistentData;
    }

    /// <summary>
    /// Gets an array of all scene collections
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetSceneCollectionList?> GetSceneCollectionList()
    {
        CheckConnected();
        return await LockWait(new Request.GetSceneCollectionList()
        {

        }) as Response.GetSceneCollectionList;
    }

    /// <summary>
    /// Switches to a scene collection.
    /// 
    /// Note: This will block until the collection has finished changing.
    /// </summary>
    /// <param name="sceneCollectionName">Name of the scene collection to switch to</param>
    /// <returns></returns>
    public async Task<Response.SetCurrentSceneCollection?> SetCurrentSceneCollection(string sceneCollectionName)
    {
        CheckConnected();
        return await LockWait(new Request.SetCurrentSceneCollection()
        {
            SceneCollectionName = sceneCollectionName
        }) as Response.SetCurrentSceneCollection;
    }

    /// <summary>
    /// Creates a new scene collection, switching to it in the process.
    /// <para></para>
    /// Note: This will block until the collection has finished changing.
    /// </summary>
    /// <param name="sceneCollectionName">Name for the new scene collection</param>
    /// <returns></returns>
    public async Task<Response.CreateSceneCollection?> CreateSceneCollection(string sceneCollectionName)
    {
        CheckConnected();
        return await LockWait(new Request.CreateSceneCollection()
        {
            SceneCollectionName = sceneCollectionName
        }) as Response.CreateSceneCollection;
    }

    /// <summary>
    /// Gets an array of all profiles
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetProfileList?> GetProfileList()
    {
        CheckConnected();
        return await LockWait(new Request.GetProfileList()
        {
            
        }) as Response.GetProfileList;
    }

    /// <summary>
    /// Switches to a profile.
    /// </summary>
    /// <param name="profileName">Name of the profile to switch to</param>
    /// <returns></returns>
    public async Task<Response.SetCurrentProfile?> SetCurrentProfile(string profileName)
    {
        CheckConnected();
        return await LockWait(new Request.SetCurrentProfile()
        {
            ProfileName = profileName
        }) as Response.SetCurrentProfile;
    }

    /// <summary>
    /// Creates a new profile, switching to it in the process
    /// </summary>
    /// <param name="profileName">Name for the new profile</param>
    /// <returns></returns>
    public async Task<Response.CreateProfile?> CreateProfile(string profileName)
    {
        CheckConnected();
        return await LockWait(new Request.CreateProfile()
        {
            ProfileName = profileName
        }) as Response.CreateProfile;
    }

    /// <summary>
    /// Removes a profile. If the current profile is chosen, it will change to a different profile first.
    /// </summary>
    /// <param name="profileName">Name of the profile to remove</param>
    /// <returns></returns>
    public async Task<Response.RemoveProfile?> RemoveProfile(string profileName)
    {
        CheckConnected();
        return await LockWait(new Request.RemoveProfile()
        {
            ProfileName = profileName
        }) as Response.RemoveProfile;
    }

    /// <summary>
    /// Gets a parameter from the current profile's configuration.
    /// </summary>
    /// <param name="parameterCategory">Category of the parameter to get</param>
    /// <param name="parameterName">Name of the parameter to get</param>
    /// <returns></returns>
    public async Task<Response.GetProfileParameter?> GetProfileParameter(string parameterCategory, string parameterName)
    {
        CheckConnected();
        return await LockWait(new Request.GetProfileParameter()
        {
            ParameterCategory = parameterCategory,
            ParameterName = parameterName
        }) as Response.GetProfileParameter;
    }

    /// <summary>
    /// Sets the value of a parameter in the current profile's configuration.
    /// </summary>
    /// <param name="parameterCategory">Category of the parameter to set</param>
    /// <param name="parameterName">Name of the parameter to set</param>
    /// <param name="parameterValue">Value of the parameter to set. Use `null` to delete</param>
    /// <returns></returns>
    public async Task<Response.SetProfileParameter?> SetProfileParameter(string parameterCategory, string parameterName, string parameterValue)
    {
        CheckConnected();
        return await LockWait(new Request.SetProfileParameter()
        {
            ParameterCategory = parameterCategory,
            ParameterName = parameterName,
            ParameterValue = parameterValue
        }) as Response.SetProfileParameter;
    }

    /// <summary>
    /// Gets the current video settings.
    /// 
    /// Note: To get the true FPS value, divide the FPS numerator by the FPS denominator. Example: 60000/1001
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetVideoSettings?> GetVideoSettings()
    {
        CheckConnected();
        return await LockWait(new Request.GetVideoSettings()
        {
            
        }) as Response.GetVideoSettings;
    }

    /// <summary>
    /// Sets the current video settings.
    /// <para></para>
    /// Note: Fields must be specified in pairs. For example, you cannot set only `baseWidth` without needing to specify `baseHeight`.
    /// </summary>
    /// <param name="fpsNumerator">Numerator of the fractional FPS value >= 1</param>
    /// <param name="fpsDenominator">Denominator of the fractional FPS value >= 1</param>
    /// <param name="baseWidth">Width of the base (canvas) resolution in pixels >= 1, &lt;= 4096</param>
    /// <param name="baseHeight">Height of the base (canvas) resolution in pixels >= 1, &lt;= 4096</param>
    /// <param name="outputWidth">Width of the output resolution in pixels >= 1, &lt;= 4096</param>
    /// <param name="outputHeight">Height of the output resolution in pixels >= 1, &lt;= 4096</param>
    /// <returns></returns>
    public async Task<Response.SetVideoSettings?> SetVideoSettings(ulong? fpsNumerator = null, ulong? fpsDenominator = null, ulong? baseWidth = null, ulong? baseHeight = null, ulong? outputWidth = null, ulong? outputHeight = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetVideoSettings()
        {
            FpsDenominator = fpsDenominator,
            FpsNumerator = fpsNumerator,
            BaseHeight = baseHeight,
            BaseWidth = baseWidth,
            OutputHeight = outputHeight,
            OutputWidth = outputWidth
        }) as Response.SetVideoSettings;
    }

    /// <summary>
    /// Gets the current stream service settings (stream destination).
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetStreamServiceSettings?> GetStreamServiceSettings()
    {
        CheckConnected();
        return await LockWait(new Request.GetStreamServiceSettings()
        {
            
        }) as Response.GetStreamServiceSettings;
    }

    /// <summary>
    /// Sets the current stream service settings (stream destination).
    /// </summary>
    /// <param name="streamServiceType">Type of stream service to apply. Example: rtmp_common or rtmp_custom see <see cref="StreamServiceType"/></param>
    /// <param name="streamServiceSettings">Settings to apply to the service</param>
    /// <returns></returns>
    public async Task<Response.SetStreamServiceSettings?> SetStreamServiceSettings(string streamServiceType, object streamServiceSettings)
    {
        CheckConnected();
        return await LockWait(new Request.SetStreamServiceSettings()
        {
            StreamServiceType = streamServiceType,
            StreamServiceSettings = streamServiceSettings
        }) as Response.SetStreamServiceSettings;
    }

    /// <summary>
    /// Gets the current directory that the record output is set to.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetRecordDirectory?> GetRecordDirectory()
    {
        CheckConnected();
        return await LockWait(new Request.GetRecordDirectory()
        {

        }) as Response.GetRecordDirectory;
    }

    /// <summary>
    /// Sets the current directory that the record output writes files to.
    /// </summary>
    /// <param name="recordDirectory">Output directory</param>
    /// <returns></returns>
    public async Task<Response.SetRecordDirectory?> SetRecordDirectory(string recordDirectory)
    {
        CheckConnected();
        return await LockWait(new Request.SetRecordDirectory()
        {
            RecordDirectory = recordDirectory
        }) as Response.SetRecordDirectory;
    }

    /// <summary>
    /// Gets the active and show state of a source.
    /// </summary>
    /// <param name="sourceName">Name of the source to get the active state of</param>
    /// <param name="sourceUuid">UUID of the source to get the active state of</param>
    /// <returns></returns>
    public async Task<Response.GetSourceActive?> GetSourceActive(string? sourceName = null, string? sourceUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetSourceActive()
        {
            SourceName = sourceName,
            SourceUuid = sourceUuid
        }) as Response.GetSourceActive;
    }

    /// <summary>
    /// Gets a Base64-encoded screenshot of a source.
    /// <para></para>
    /// The <paramref name="imageWidth"/> and <paramref name="imageHeight"/> parameters are treated as "scale to inner", meaning the smallest ratio will be used and the aspect ratio of the original resolution is kept.
    /// If <paramref name="imageWidth"/> and <paramref name="imageHeight"/> are not specified, the compressed image will use the full resolution of the source.
    /// </summary>
    /// <param name="imageFormat">Name of the source to take a screenshot of</param>
    /// <param name="sourceName">UUID of the source to take a screenshot of</param>
    /// <param name="sourceUuid">Image compression format to use. Use <see cref="GetVersion"/> to get compatible image formats</param>
    /// <param name="imageWidth">Width to scale the screenshot to >= 8, &lt;= 4096</param>
    /// <param name="imageHeight">Height to scale the screenshot to >= 8, &lt;= 4096</param>
    /// <param name="imageCompressionQuality">Compression quality to use. 0 for high compression, 100 for uncompressed. -1 to use "default" (whatever that means, idk) >= -1, &lt;= 100</param>
    /// <returns></returns>
    public async Task<Response.GetSourceScreenshot?> GetSourceScreenshot(string imageFormat, string? sourceName = null, string? sourceUuid = null, uint? imageWidth = null, uint? imageHeight = null, int? imageCompressionQuality = -1)
    {
        CheckConnected();
        return await LockWait(new Request.GetSourceScreenshot()
        {
            SourceName = sourceName,
            SourceUuid = sourceUuid,
            ImageFormat = imageFormat,
            ImageWidth = imageWidth,
            ImageHeight = imageHeight,
            ImageCompressionQuality = imageCompressionQuality
        }) as Response.GetSourceScreenshot;
    }

    /// <summary>
    /// Saves a screenshot of a source to the filesystem.
    /// <para></para>
    /// The <paramref name="imageWidth"/> and <paramref name="imageHeight"/> parameters are treated as "scale to inner", meaning the smallest ratio will be used and the aspect ratio of the original resolution is kept.
    /// If <paramref name="imageWidth"/> and <paramref name="imageHeight"/> are not specified, the compressed image will use the full resolution of the source.
    /// </summary>
    /// <param name="imageFormat">Image compression format to use. Use <see cref="GetVersion"/> to get compatible image formats</param>
    /// <param name="imageFilePath">Path to save the screenshot file to. Eg. C:\Users\user\Desktop\screenshot.png</param>
    /// <param name="sourceName">Name of the source to take a screenshot of</param>
    /// <param name="sourceUuid">UUID of the source to take a screenshot of</param>
    /// <param name="imageWidth">Width to scale the screenshot to >= 8, &lt;= 4096</param>
    /// <param name="imageHeight">Height to scale the screenshot to >= 8, &lt;= 4096</param>
    /// <param name="imageCompressionQuality">Compression quality to use. 0 for high compression, 100 for uncompressed. -1 to use "default" (whatever that means, idk) >= -1, &lt;= 100</param>
    /// <returns></returns>
    public async Task<Response.SaveSourceScreenshot?> SaveSourceScreenshot(string imageFormat, string imageFilePath, string? sourceName = null, string? sourceUuid = null, uint? imageWidth = null, uint? imageHeight = null, int? imageCompressionQuality = -1)
    {
        CheckConnected();
        return await LockWait(new Request.SaveSourceScreenshot()
        {
            SourceName = sourceName,
            SourceUuid = sourceUuid,
            ImageFilePath = imageFilePath,
            ImageFormat = imageFormat,
            ImageWidth = imageWidth,
            ImageHeight = imageHeight,
            ImageCompressionQuality = imageCompressionQuality
        }) as Response.SaveSourceScreenshot;
    }

    /// <summary>
    /// Gets an array of all scenes in OBS.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetSceneList?> GetSceneList()
    {
        CheckConnected();
        return await LockWait(new Request.GetSceneList()
        {
            
        }) as Response.GetSceneList;
    }

    /// <summary>
    /// Gets an array of all groups in OBS.
    /// <para></para>
    /// Groups in OBS are actually scenes, but renamed and modified. In obs-websocket, we treat them as scenes where we can.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetGroupList?> GetGroupList()
    {
        CheckConnected();
        return await LockWait(new Request.GetGroupList()
        {

        }) as Response.GetGroupList;
    }

    /// <summary>
    /// Gets the current program scene.
    /// 
    /// Note: This request is slated to have the `currentProgram`-prefixed fields removed from in an upcoming RPC version.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetCurrentProgramScene?> GetCurrentProgramScene()
    {
        CheckConnected();
        return await LockWait(new Request.GetCurrentProgramScene()
        {

        }) as Response.GetCurrentProgramScene;
    }

    /// <summary>
    /// Sets the current program scene.
    /// </summary>
    /// <param name="sceneName">Scene name to set as the current program scene</param>
    /// <param name="sceneUuid">Scene UUID to set as the current program scene</param>
    /// <returns></returns>
    public async Task<Response.SetCurrentProgramScene?> SetCurrentProgramScene(string? sceneName = null,string? sceneUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetCurrentProgramScene()
        {
            SceneName = sceneName,
            SceneUuid = sceneUuid
        }) as Response.SetCurrentProgramScene;
    }

    /// <summary>
    /// Gets the current preview scene.
    /// <para></para>
    /// Only available when studio mode is enabled.
    /// <para></para>
    /// Note: This request is slated to have the `currentPreview`-prefixed fields removed from in an upcoming RPC version.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetCurrentPreviewScene?> GetCurrentPreviewScene()
    {
        CheckConnected();
        return await LockWait(new Request.GetCurrentPreviewScene()
        {

        }) as Response.GetCurrentPreviewScene;
    }

    /// <summary>
    /// Sets the current preview scene.
    /// <para></para>
    /// Only available when studio mode is enabled.
    /// </summary>
    /// <param name="sceneName">Scene name to set as the current preview scene</param>
    /// <param name="sceneUuid">Scene UUID to set as the current preview scene</param>
    /// <returns></returns>
    public async Task<Response.SetCurrentPreviewScene?> SetCurrentPreviewScene(string? sceneName = null, string? sceneUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetCurrentPreviewScene()
        {
            SceneName = sceneName,
            SceneUuid = sceneUuid
        }) as Response.SetCurrentPreviewScene;
    }

    /// <summary>
    /// Creates a new scene in OBS.
    /// </summary>
    /// <param name="sceneName">Name for the new scene</param>
    /// <returns></returns>
    public async Task<Response.CreateScene?> CreateScene(string? sceneName = null)
    {
        CheckConnected();
        return await LockWait(new Request.CreateScene()
        {
            SceneName = sceneName
        }) as Response.CreateScene;
    }

    /// <summary>
    /// Removes a scene from OBS.
    /// </summary>
    /// <param name="sceneName">Name of the scene to remove</param>
    /// <param name="sceneUuid"UUID of the scene to remove></param>
    /// <returns></returns>
    public async Task<Response.RemoveScene?> RemoveScene(string? sceneName = null, string? sceneUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.RemoveScene()
        {
            SceneName = sceneName,
            SceneUuid = sceneUuid
        }) as Response.RemoveScene;
    }

    /// <summary>
    /// Sets the name of a scene (rename).
    /// </summary>
    /// <param name="newSceneName">New name for the scene</param>
    /// <param name="sceneName">Name of the scene to be renamed</param>
    /// <param name="sceneUuid">UUID of the scene to be renamed</param>
    /// <returns></returns>
    public async Task<Response.SetSceneName?> SetSceneName(string newSceneName, string? sceneName = null, string? sceneUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetSceneName()
        {
            SceneName = sceneName,
            SceneUuid = sceneUuid,
            NewSceneName = newSceneName
        }) as Response.SetSceneName;
    }

    /// <summary>
    /// Gets the scene transition overridden for a scene.
    /// <para></para>
    /// Note: A transition UUID response field is not currently able to be implemented as of 2024-1-18.
    /// </summary>
    /// <param name="sceneName">Name of the scene</param>
    /// <param name="sceneUuid">UUID of the scene</param>
    /// <returns></returns>
    public async Task<Response.GetSceneSceneTransitionOverride?> GetSceneSceneTransitionOverride(string? sceneName = null, string? sceneUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetSceneSceneTransitionOverride()
        {
            SceneName = sceneName,
            SceneUuid = sceneUuid
        }) as Response.GetSceneSceneTransitionOverride;
    }

    /// <summary>
    /// Sets the scene transition overridden for a scene.
    /// </summary>
    /// <param name="sceneName">Name of the scene</param>
    /// <param name="sceneUuid">UUID of the scene</param>
    /// <param name="transitionName">Name of the scene transition to use as override. Specify null to remove</param>
    /// <param name="transitionDuration">Duration to use for any overridden transition. Specify null to remove >= 50, &lt;= 20000</param>
    /// <returns></returns>
    public async Task<Response.SetSceneSceneTransitionOverride?> SetSceneSceneTransitionOverride(string? sceneName = null, string? sceneUuid = null, string? transitionName = null, long? transitionDuration = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetSceneSceneTransitionOverride()
        {
            SceneName = sceneName,
            SceneUuid = sceneUuid,
            TransitionName = transitionName,
            TransitionDuration = transitionDuration
        }) as Response.SetSceneSceneTransitionOverride;
    }

    /// <summary>
    /// Gets an array of all inputs in OBS.
    /// </summary>
    /// <param name="inputKind">Restrict the array to only inputs of the specified kind</param>
    /// <returns></returns>
    public async Task<Response.GetInputList?> GetInputList(string? inputKind = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputList()
        {
            InputKind = inputKind
        }) as Response.GetInputList;
    }

    /// <summary>
    /// Gets an array of all available input kinds in OBS.
    /// </summary>
    /// <param name="unversioned">True == Return all kinds as unversioned, False == Return with version suffixes (if available)</param>
    /// <returns></returns>
    public async Task<Response.GetInputKindList?> GetInputKindList(bool? unversioned = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputKindList()
        {
            Unversioned = unversioned
        }) as Response.GetInputKindList;
    }

    /// <summary>
    /// Gets the names of all special inputs.
    /// </summary>
    /// <returns></returns>
    public async Task<Response.GetSpecialInputs?> GetSpecialInputs()
    {
        CheckConnected();
        return await LockWait(new Request.GetSpecialInputs()
        {
            
        }) as Response.GetSpecialInputs;
    }

    /// <summary>
    /// Creates a new input, adding it as a scene item to the specified scene.
    /// </summary>
    /// <param name="inputName">Name of the scene to add the input to as a scene item</param>
    /// <param name="inputKind">UUID of the scene to add the input to as a scene item</param>
    /// <param name="sceneName">Name of the new input to created</param>
    /// <param name="sceneUuid">The kind of input to be created</param>
    /// <param name="inputSettings">Settings object to initialize the input with</param>
    /// <param name="sceneItemEnabled">Whether to set the created scene item to enabled or disabled</param>
    /// <returns></returns>
    public async Task<Response.CreateInput?> CreateInput(string inputName, string inputKind, string? sceneName = null, string? sceneUuid = null, object? inputSettings = null, bool? sceneItemEnabled = true)
    {
        CheckConnected();
        return await LockWait(new Request.CreateInput()
        {
            InputKind = inputKind,
            InputName = inputName,
            SceneName = sceneName,
            SceneUuid =sceneUuid,
            InputSettings = inputSettings,
            SceneItemEnabled = sceneItemEnabled
        }) as Response.CreateInput;
    }

    /// <summary>
    /// Removes an existing input.
    /// <para></para>
    /// Note: Will immediately remove all associated scene items.
    /// </summary>
    /// <param name="inputName">Name of the input to remove</param>
    /// <param name="inputUuid">UUID of the input to remove</param>
    /// <returns></returns>
    public async Task<Response.RemoveInput?> RemoveInput(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.RemoveInput()
        {
            InputName = inputName,
            InputUuid = inputUuid,
        }) as Response.RemoveInput;
    }

    /// <summary>
    /// Sets the name of an input (rename).
    /// </summary>
    /// <param name="newInputName">New name for the input</param>
    /// <param name="inputName">Current input name</param>
    /// <param name="inputUuid">Current input UUID</param>
    /// <returns></returns>
    public async Task<Response.SetInputName?> SetInputName(string newInputName, string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetInputName()
        {
            InputName = inputName,
            InputUuid = inputUuid,
            NewInputName = newInputName
        }) as Response.SetInputName;
    }

    /// <summary>
    /// Gets the default settings for an input kind.
    /// </summary>
    /// <param name="inputKind">Input kind to get the default settings for</param>
    /// <returns></returns>
    public async Task<Response.GetInputDefaultSettings?> GetInputDefaultSettings(string inputKind)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputDefaultSettings()
        {
            InputKind = inputKind
        }) as Response.GetInputDefaultSettings;
    }

    /// <summary>
    /// Gets the settings of an input.
    /// <para></para>
    /// Note: Does not include defaults. To create the entire settings object, overlay <see cref="Response.GetInputSettings.InputSettings"/> over the <see cref="Response.GetInputDefaultSettings.DefaultInputSettings"/> provided by <see cref="GetInputDefaultSettings"/>.
    /// </summary>
    /// <param name="inputName">Name of the input to get the settings of</param>
    /// <param name="inputUuid">UUID of the input to get the settings of</param>
    /// <returns></returns>
    public async Task<Response.GetInputSettings?> GetInputSettings(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputSettings()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.GetInputSettings;
    }

    /// <summary>
    /// Sets the settings of an input.
    /// </summary>
    /// <param name="inputSettings">Object of settings to apply</param>
    /// <param name="inputName">Name of the input to set the settings of</param>
    /// <param name="inputUuid">UUID of the input to set the settings of</param>
    /// <param name="overlay">True == apply the settings on top of existing ones, False == reset the input to its defaults, then apply settings.</param>
    /// <returns></returns>
    public async Task<Response.SetInputSettings?> SetInputSettings(object inputSettings, string? inputName = null, string? inputUuid = null, bool? overlay = true)
    {
        CheckConnected();
        return await LockWait(new Request.SetInputSettings()
        {
            InputName = inputName,
            InputUuid = inputUuid,
            InputSettings = inputSettings,
            Overlay = overlay
        }) as Response.SetInputSettings;
    }

    /// <summary>
    /// Gets the audio mute state of an input.
    /// </summary>
    /// <param name="inputName">Name of input to get the mute state of</param>
    /// <param name="inputUuid">UUID of input to get the mute state of</param>
    /// <returns></returns>
    public async Task<Response.GetInputMute?> GetInputMute(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputMute()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.GetInputMute;
    }

    /// <summary>
    /// Sets the audio mute state of an input.
    /// </summary>
    /// <param name="inputMuted">Whether to mute the input or not</param>
    /// <param name="inputName">Name of the input to set the mute state of</param>
    /// <param name="inputUuid">UUID of the input to set the mute state of</param>
    /// <returns></returns>
    public async Task<Response.SetInputMute?> SetInputMute(bool inputMuted, string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetInputMute()
        {
            InputName = inputName,
            InputUuid = inputUuid,
            InputMuted = inputMuted
        }) as Response.SetInputMute;
    }

    /// <summary>
    /// Toggles the audio mute state of an input.
    /// </summary>
    /// <param name="inputName">Name of the input to toggle the mute state of</param>
    /// <param name="inputUuid">UUID of the input to toggle the mute state of</param>
    /// <returns></returns>
    public async Task<Response.ToggleInputMute?> ToggleInputMute(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.ToggleInputMute()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.ToggleInputMute;
    }

    /// <summary>
    /// Gets the current volume setting of an input.
    /// </summary>
    /// <param name="inputName">Name of the input to get the volume of</param>
    /// <param name="inputUuid">UUID of the input to get the volume of</param>
    /// <returns></returns>
    public async Task<Response.GetInputVolume?> GetInputVolume(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputVolume()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.GetInputVolume;
    }

    /// <summary>
    /// Sets the volume setting of an input.
    /// </summary>
    /// <param name="inputName">Name of the input to set the volume of</param>
    /// <param name="inputUuid">UUID of the input to set the volume of</param>
    /// <param name="inputVolumeMul">Volume setting in mul >= 0, &lt;= 20</param>
    /// <param name="inputVolumeDb">Volume setting in dB >= -100, &lt;= 26</param>
    /// <returns></returns>
    public async Task<Response.SetInputVolume?> SetInputVolume(string? inputName = null, string? inputUuid = null, float? inputVolumeMul = null, float? inputVolumeDb = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetInputVolume()
        {
            InputName = inputName,
            InputUuid = inputUuid,
            InputVolumeMul = inputVolumeMul,
            InputVolumeDb = inputVolumeDb
        }) as Response.SetInputVolume;
    }

    /// <summary>
    /// Gets the audio balance of an input.
    /// </summary>
    /// <param name="inputName">Name of the input to get the audio balance of</param>
    /// <param name="inputUuid">UUID of the input to get the audio balance of</param>
    /// <returns></returns>
    public async Task<Response.GetInputAudioBalance?> GetInputAudioBalance(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputAudioBalance()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.GetInputAudioBalance;
    }

    /// <summary>
    /// Sets the audio balance of an input.
    /// </summary>
    /// <param name="inputAudioBalance">New audio balance value >= 0.0, &lt;= 1.0</param>
    /// <param name="inputName">Name of the input to set the audio balance of</param>
    /// <param name="inputUuid">UUID of the input to set the audio balance of</param>
    /// <returns></returns>
    public async Task<Response.SetInputAudioBalance?> SetInputAudioBalance(float inputAudioBalance, string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetInputAudioBalance()
        {
            InputName = inputName,
            InputUuid = inputUuid,
            InputAudioBalance = inputAudioBalance
        }) as Response.SetInputAudioBalance;
    }

    /// <summary>
    /// Gets the audio sync offset of an input.
    /// <para></para>
    /// Note: The audio sync offset can be negative too!
    /// </summary>
    /// <param name="inputName">Name of the input to get the audio sync offset of</param>
    /// <param name="inputUuid">UUID of the input to get the audio sync offset of</param>
    /// <returns></returns>
    public async Task<Response.GetInputAudioSyncOffset?> GetInputAudioSyncOffset(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputAudioSyncOffset()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.GetInputAudioSyncOffset;
    }

    /// <summary>
    /// Sets the audio sync offset of an input.
    /// </summary>
    /// <param name="inputAudioSyncOffset">New audio sync offset in milliseconds >= -950, &lt;= 20000</param>
    /// <param name="inputName">Name of the input to set the audio sync offset of</param>
    /// <param name="inputUuid">UUID of the input to set the audio sync offset of</param>
    /// <returns></returns>
    public async Task<Response.SetInputAudioSyncOffset?> SetInputAudioSyncOffset(long inputAudioSyncOffset, string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetInputAudioSyncOffset()
        {
            InputName = inputName,
            InputUuid = inputUuid,
            InputAudioSyncOffset = inputAudioSyncOffset
        }) as Response.SetInputAudioSyncOffset;
    }

    /// <summary>
    /// Gets the audio monitor type of an input.
    /// <para></para>
    /// The available audio monitor types are: <see cref="ObsMonitorTypeName"/>
    /// </summary>
    /// <param name="inputName">Name of the input to get the audio monitor type of</param>
    /// <param name="inputUuid">UUID of the input to get the audio monitor type of</param>
    /// <returns></returns>
    public async Task<Response.GetInputAudioMonitorType?> GetInputAudioMonitorType(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputAudioMonitorType()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.GetInputAudioMonitorType;
    }

    /// <summary>
    /// Sets the audio monitor type of an input.
    /// </summary>
    /// <param name="monitorType">Audio monitor type, see <see cref="ObsMonitorTypeName"/></param>
    /// <param name="inputName">Name of the input to set the audio monitor type of</param>
    /// <param name="inputUuid">UUID of the input to set the audio monitor type of</param>
    /// <returns></returns>
    public async Task<Response.SetInputAudioMonitorType?> SetInputAudioMonitorType(string monitorType, string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.SetInputAudioMonitorType()
        {
            InputName = inputName,
            InputUuid = inputUuid,
            MonitorType = monitorType
        }) as Response.SetInputAudioMonitorType;
    }

    /// <summary>
    /// Gets the enable state of all audio tracks of an input.
    /// </summary>
    /// <param name="inputName">Name of the input</param>
    /// <param name="inputUuid">UUID of the input</param>
    /// <returns></returns>
    public async Task<Response.GetInputAudioTracks?> GetInputAudioTracks(string? inputName = null, string? inputUuid = null)
    {
        CheckConnected();
        return await LockWait(new Request.GetInputAudioTracks()
        {
            InputName = inputName,
            InputUuid = inputUuid
        }) as Response.GetInputAudioTracks;
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
