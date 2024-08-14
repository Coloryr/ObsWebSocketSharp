using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ObsWebSocketSharp.Objs;
using ObsWebSocketSharp.Objs.Events;
using ObsWebSocketSharp.Objs.Messages;

namespace ObsWebSocketSharp.Utils;

public static class EventUtils
{
    public static BaseEvent? DecodeEvent(this EventMessageObj message)
    {
        switch (message.EventIntent)
        {
            case EventSubscription.General:
                return message.DecodeGeneralEvent();
            case EventSubscription.Config:
                return message.DecodeConfigEvent();
            case EventSubscription.Scenes:
                return message.DecodeScenesEvent();
            case EventSubscription.Inputs:
                return message.DecodeInputsEvent();
            case EventSubscription.Transitions:
                return message.DecodeTransitionsEvent();
        }

        return null;
    }

    private static BaseEvent? DecodeGeneralEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.General.ExitStarted => new ExitStarted(),
            EventName.General.VendorEvent => obj?.ToObject<VendorEvent>(),
            EventName.General.CustomEvent => obj?.ToObject<CustomEvent>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeConfigEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.Config.CurrentSceneCollectionChanging => obj?.ToObject<CurrentSceneCollectionChanging>(),
            EventName.Config.CurrentSceneCollectionChanged => obj?.ToObject<CurrentSceneCollectionChanged>(),
            EventName.Config.SceneCollectionListChanged => obj?.ToObject<SceneCollectionListChanged>(),
            EventName.Config.CurrentProfileChanging => obj?.ToObject<CurrentProfileChanging>(),
            EventName.Config.CurrentProfileChanged => obj?.ToObject<CurrentProfileChanged>(),
            EventName.Config.ProfileListChanged => obj?.ToObject<ProfileListChanged>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeScenesEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.Scenes.SceneCreated => obj?.ToObject<SceneCreated>(),
            EventName.Scenes.SceneRemoved => obj?.ToObject<SceneRemoved>(),
            EventName.Scenes.SceneNameChanged => obj?.ToObject<SceneNameChanged>(),
            EventName.Scenes.CurrentProgramSceneChanged => obj?.ToObject<CurrentProgramSceneChanged>(),
            EventName.Scenes.CurrentPreviewSceneChanged => obj?.ToObject<CurrentPreviewSceneChanged>(),
            EventName.Scenes.SceneListChanged => obj?.ToObject<SceneListChanged>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeInputsEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.Inputs.InputCreated => obj?.ToObject<InputCreated>(),
            EventName.Inputs.InputRemoved => obj?.ToObject<InputRemoved>(),
            EventName.Inputs.InputNameChanged => obj?.ToObject<InputNameChanged>(),
            EventName.Inputs.InputSettingsChanged => obj?.ToObject<InputSettingsChanged>(),
            EventName.Inputs.InputActiveStateChanged => obj?.ToObject<InputActiveStateChanged>(),
            EventName.Inputs.InputShowStateChanged => obj?.ToObject<InputShowStateChanged>(),
            EventName.Inputs.InputMuteStateChanged => obj?.ToObject<InputMuteStateChanged>(),
            EventName.Inputs.InputVolumeChanged => obj?.ToObject<InputVolumeChanged>(),
            EventName.Inputs.InputAudioBalanceChanged => obj?.ToObject<InputAudioBalanceChanged>(),
            EventName.Inputs.InputAudioSyncOffsetChanged => obj?.ToObject<InputAudioSyncOffsetChanged>(),
            EventName.Inputs.InputAudioTracksChanged => obj?.ToObject<InputAudioTracksChanged>(),
            EventName.Inputs.InputAudioMonitorTypeChanged => obj?.ToObject<InputAudioMonitorTypeChanged>(),
            EventName.Inputs.InputVolumeMeters => obj?.ToObject<InputVolumeMeters>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeTransitionsEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.Transitions.CurrentSceneTransitionChanged => obj?.ToObject<CurrentSceneTransitionChanged>(),
            _ => null,
        };
    }
}
