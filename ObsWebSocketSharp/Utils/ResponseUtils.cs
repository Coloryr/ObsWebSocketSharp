using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Messages;
using ObsWebSocketSharp.Objs.Responses;

namespace ObsWebSocketSharp.Utils;

public static class ResponseUtils
{
    public static BaseResponse? DecodeResponse(this RequestResponseMessageObj message)
    {
        var obj = message.ResponseData as JObject;
        return message.RequestType switch
        {
            RequestName.GetVersion => obj?.ToObject<Response.GetVersion>(),
            RequestName.GetStats => obj?.ToObject<Response.GetStats>(),
            RequestName.BroadcastCustomEvent => obj?.ToObject<Response.BroadcastCustomEvent>(),
            RequestName.CallVendorRequest => obj?.ToObject<Response.CallVendorRequest>(),
            RequestName.GetHotkeyList => obj?.ToObject<Response.GetHotkeyList>(),
            RequestName.TriggerHotkeyByName => obj?.ToObject<Response.TriggerHotkeyByName>(),
            RequestName.TriggerHotkeyByKeySequence => obj?.ToObject<Response.TriggerHotkeyByKeySequence>(),
            RequestName.Sleep => obj?.ToObject<Response.Sleep>(),
            RequestName.GetPersistentData => obj?.ToObject<Response.GetPersistentData>(),
            RequestName.SetPersistentData => obj?.ToObject<Response.SetPersistentData>(),
            RequestName.GetSceneCollectionList => obj?.ToObject<Response.GetSceneCollectionList>(),
            RequestName.SetCurrentSceneCollection => obj?.ToObject<Response.SetCurrentSceneCollection>(),
            RequestName.CreateSceneCollection => obj?.ToObject<Response.CreateSceneCollection>(),
            RequestName.GetProfileList => obj?.ToObject<Response.GetProfileList>(),
            RequestName.SetCurrentProfile => obj?.ToObject<Response.SetCurrentProfile>(),
            RequestName.CreateProfile => obj?.ToObject<Response.CreateProfile>(),
            RequestName.RemoveProfile => obj?.ToObject<Response.RemoveProfile>(),
            RequestName.GetProfileParameter => obj?.ToObject<Response.GetProfileParameter>(),
            RequestName.SetProfileParameter => obj?.ToObject<Response.SetProfileParameter>(),
            RequestName.GetVideoSettings => obj?.ToObject<Response.GetVideoSettings>(),
            RequestName.SetVideoSettings => obj?.ToObject<Response.SetVideoSettings>(),
            RequestName.GetStreamServiceSettings => obj?.ToObject<Response.GetStreamServiceSettings>(),
            RequestName.SetStreamServiceSettings => obj?.ToObject<Response.SetStreamServiceSettings>(),
            RequestName.GetRecordDirectory => obj?.ToObject<Response.GetRecordDirectory>(),
            RequestName.SetRecordDirectory => obj?.ToObject<Response.SetRecordDirectory>(),
            RequestName.GetSourceActive => obj?.ToObject<Response.GetSourceActive>(),
            RequestName.GetSourceScreenshot => obj?.ToObject<Response.GetSourceScreenshot>(),
            RequestName.SaveSourceScreenshot => obj?.ToObject<Response.SaveSourceScreenshot>(),
            RequestName.GetSceneList => obj?.ToObject<Response.GetSceneList>(),
            RequestName.GetGroupList => obj?.ToObject<Response.GetGroupList>(),
            RequestName.GetCurrentProgramScene => obj?.ToObject<Response.GetCurrentProgramScene>(),
            RequestName.SetCurrentProgramScene => obj?.ToObject<Response.SetCurrentProgramScene>(),
            RequestName.GetCurrentPreviewScene => obj?.ToObject<Response.GetCurrentPreviewScene>(),
            RequestName.SetCurrentPreviewScene => obj?.ToObject<Response.SetCurrentPreviewScene>(),
            RequestName.CreateScene => obj?.ToObject<Response.CreateScene>(),
            RequestName.RemoveScene => obj?.ToObject<Response.RemoveScene>(),
            RequestName.SetSceneName => obj?.ToObject<Response.SetSceneName>(),
            RequestName.GetSceneSceneTransitionOverride => obj?.ToObject<Response.GetSceneSceneTransitionOverride>(),
            RequestName.SetSceneSceneTransitionOverride => obj?.ToObject<Response.SetSceneSceneTransitionOverride>(),
            RequestName.GetInputList => obj?.ToObject<Response.GetInputList>(),
            RequestName.GetInputKindList => obj?.ToObject<Response.GetInputKindList>(),
            RequestName.GetSpecialInputs => obj?.ToObject<Response.GetSpecialInputs>(),
            RequestName.CreateInput => obj?.ToObject<Response.CreateInput>(),
            RequestName.RemoveInput => obj?.ToObject<Response.RemoveInput>(),
            RequestName.SetInputName => obj?.ToObject<Response.SetInputName>(),
            RequestName.GetInputDefaultSettings => obj?.ToObject<Response.GetInputDefaultSettings>(),
            RequestName.GetInputSettings => obj?.ToObject<Response.GetInputSettings>(),
            RequestName.SetInputSettings => obj?.ToObject<Response.SetInputSettings>(),
            RequestName.GetInputMute => obj?.ToObject<Response.GetInputMute>(),
            RequestName.SetInputMute => obj?.ToObject<Response.SetInputMute>(),
            RequestName.ToggleInputMute => obj?.ToObject<Response.ToggleInputMute>(),
            RequestName.GetInputVolume => obj?.ToObject<Response.GetInputVolume>(),
            RequestName.SetInputVolume => obj?.ToObject<Response.SetInputVolume>(),
            RequestName.GetInputAudioBalance => obj?.ToObject<Response.GetInputAudioBalance>(),
            RequestName.SetInputAudioBalance => obj?.ToObject<Response.SetInputAudioBalance>(),
            RequestName.GetInputAudioSyncOffset => obj?.ToObject<Response.GetInputAudioSyncOffset>(),
            RequestName.SetInputAudioSyncOffset => obj?.ToObject<Response.SetInputAudioSyncOffset>(),
            RequestName.GetInputAudioMonitorType => obj?.ToObject<Response.GetInputAudioMonitorType>(),
            RequestName.SetInputAudioMonitorType => obj?.ToObject<Response.SetInputAudioMonitorType>(),
            RequestName.GetInputAudioTracks => obj?.ToObject<Response.GetInputAudioTracks>(),
            _ => null,
        };
    }
}
