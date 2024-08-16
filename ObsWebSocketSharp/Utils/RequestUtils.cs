using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Requests;

namespace ObsWebSocketSharp.Utils;

public static class RequestUtils
{
    public static string? GetRequestType(this BaseRequest request)
    {
        if (request is Request.GetVersion)
        {
            return RequestName.GetVersion;
        }
        else if (request is Request.GetStats)
        {
            return RequestName.GetStats;
        }
        else if (request is Request.BroadcastCustomEvent)
        {
            return RequestName.BroadcastCustomEvent;
        }
        else if (request is Request.CallVendorRequest)
        {
            return RequestName.CallVendorRequest;
        }
        else if (request is Request.GetHotkeyList)
        {
            return RequestName.GetHotkeyList;
        }
        else if (request is Request.TriggerHotkeyByName)
        {
            return RequestName.TriggerHotkeyByName;
        }
        else if (request is Request.TriggerHotkeyByKeySequence)
        {
            return RequestName.TriggerHotkeyByKeySequence;
        }
        else if (request is Request.Sleep)
        {
            return RequestName.Sleep;
        }
        else if (request is Request.GetPersistentData)
        {
            return RequestName.GetPersistentData;
        }
        else if (request is Request.SetPersistentData)
        {
            return RequestName.SetPersistentData;
        }
        else if (request is Request.GetSceneCollectionList)
        {
            return RequestName.GetSceneCollectionList;
        }
        else if (request is Request.SetCurrentSceneCollection)
        {
            return RequestName.SetCurrentSceneCollection;
        }
        else if (request is Request.CreateSceneCollection)
        {
            return RequestName.CreateSceneCollection;
        }
        else if (request is Request.GetProfileList)
        {
            return RequestName.GetProfileList;
        }
        else if (request is Request.SetCurrentProfile)
        {
            return RequestName.SetCurrentProfile;
        }
        else if (request is Request.CreateProfile)
        {
            return RequestName.CreateProfile;
        }
        else if (request is Request.RemoveProfile)
        {
            return RequestName.RemoveProfile;
        }
        else if (request is Request.GetProfileParameter)
        {
            return RequestName.GetProfileParameter;
        }
        else if (request is Request.SetProfileParameter)
        {
            return RequestName.SetProfileParameter;
        }
        else if (request is Request.GetVideoSettings)
        {
            return RequestName.GetVideoSettings;
        }
        else if (request is Request.SetVideoSettings)
        {
            return RequestName.SetVideoSettings;
        }
        else if (request is Request.GetStreamServiceSettings)
        {
            return RequestName.GetStreamServiceSettings;
        }
        else if (request is Request.SetStreamServiceSettings)
        {
            return RequestName.SetStreamServiceSettings;
        }
        else if (request is Request.GetRecordDirectory)
        {
            return RequestName.GetRecordDirectory;
        }
        else if (request is Request.SetRecordDirectory)
        {
            return RequestName.SetRecordDirectory;
        }
        else if (request is Request.GetSourceActive)
        {
            return RequestName.GetSourceActive;
        }
        else if (request is Request.GetSourceScreenshot)
        {
            return RequestName.GetSourceScreenshot;
        }
        else if (request is Request.SaveSourceScreenshot)
        {
            return RequestName.SaveSourceScreenshot;
        }
        else if (request is Request.GetSceneList)
        {
            return RequestName.GetSceneList;
        }
        else if (request is Request.GetGroupList)
        {
            return RequestName.GetGroupList;
        }
        else if (request is Request.GetCurrentProgramScene)
        {
            return RequestName.GetCurrentProgramScene;
        }
        else if (request is Request.SetCurrentProgramScene)
        {
            return RequestName.SetCurrentProgramScene;
        }
        else if (request is Request.GetCurrentPreviewScene)
        {
            return RequestName.GetCurrentPreviewScene;
        }
        else if (request is Request.SetCurrentPreviewScene)
        {
            return RequestName.SetCurrentPreviewScene;
        }
        else if (request is Request.CreateScene)
        {
            return RequestName.CreateScene;
        }
        else if (request is Request.RemoveScene)
        {
            return RequestName.RemoveScene;
        }
        else if (request is Request.SetSceneName)
        {
            return RequestName.SetSceneName;
        }
        else if (request is Request.GetSceneSceneTransitionOverride)
        {
            return RequestName.GetSceneSceneTransitionOverride;
        }
        else if (request is Request.SetSceneSceneTransitionOverride)
        {
            return RequestName.SetSceneSceneTransitionOverride;
        }
        else if (request is Request.GetInputList)
        {
            return RequestName.GetInputList;
        }
        else if (request is Request.GetInputKindList)
        {
            return RequestName.GetInputKindList;
        }
        else if (request is Request.GetSpecialInputs)
        {
            return RequestName.GetSpecialInputs;
        }
        else if (request is Request.CreateInput)
        {
            return RequestName.CreateInput;
        }
        else if (request is Request.RemoveInput)
        {
            return RequestName.RemoveInput;
        }
        else if (request is Request.SetInputName)
        {
            return RequestName.SetInputName;
        }
        else if (request is Request.GetInputDefaultSettings)
        {
            return RequestName.GetInputDefaultSettings;
        }
        else if (request is Request.GetInputSettings)
        {
            return RequestName.GetInputSettings;
        }
        else if (request is Request.SetInputSettings)
        {
            return RequestName.SetInputSettings;
        }
        else if (request is Request.GetInputMute)
        {
            return RequestName.GetInputMute;
        }
        else if (request is Request.SetInputMute)
        {
            return RequestName.SetInputMute;
        }
        else if (request is Request.ToggleInputMute)
        {
            return RequestName.ToggleInputMute;
        }
        else if (request is Request.GetInputVolume)
        {
            return RequestName.GetInputVolume;
        }
        else if (request is Request.SetInputVolume)
        {
            return RequestName.SetInputVolume;
        }
        else if (request is Request.GetInputAudioBalance)
        {
            return RequestName.GetInputAudioBalance;
        }
        else if (request is Request.SetInputAudioBalance)
        {
            return RequestName.SetInputAudioBalance;
        }
        else if (request is Request.GetInputAudioSyncOffset)
        {
            return RequestName.GetInputAudioSyncOffset;
        }
        else if (request is Request.SetInputAudioSyncOffset)
        {
            return RequestName.SetInputAudioSyncOffset;
        }
        else if (request is Request.GetInputAudioMonitorType)
        {
            return RequestName.GetInputAudioMonitorType;
        }
        else if (request is Request.SetInputAudioMonitorType)
        {
            return RequestName.SetInputAudioMonitorType;
        }
        else if (request is Request.GetInputAudioTracks)
        {
            return RequestName.GetInputAudioTracks;
        }

        return null;
    }
}
