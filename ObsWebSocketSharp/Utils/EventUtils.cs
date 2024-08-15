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
            case EventSubscription.Filters:
                return message.DecodeFiltersEvent();
            case EventSubscription.SceneItems:
                return message.DecodeSceneItemsEvent();
            case EventSubscription.Outputs:
                return message.DecodeOutputsEvent();
            case EventSubscription.MediaInputs:
                return message.DecodeMediaInputsEvent();
            case EventSubscription.Ui:
                return message.DecodeUiEvent();
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
            EventName.Transitions.CurrentSceneTransitionDurationChanged => obj?.ToObject<CurrentSceneTransitionDurationChanged>(),
            EventName.Transitions.SceneTransitionStarted => obj?.ToObject<SceneTransitionStarted>(),
            EventName.Transitions.SceneTransitionEnded => obj?.ToObject<SceneTransitionEnded>(),
            EventName.Transitions.SceneTransitionVideoEnded => obj?.ToObject<SceneTransitionVideoEnded>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeFiltersEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.Filters.SourceFilterListReindexed => obj?.ToObject<SourceFilterListReindexed>(),
            EventName.Filters.SourceFilterCreated => obj?.ToObject<SourceFilterCreated>(),
            EventName.Filters.SourceFilterRemoved => obj?.ToObject<SourceFilterRemoved>(),
            EventName.Filters.SourceFilterNameChanged => obj?.ToObject<SourceFilterNameChanged>(),
            EventName.Filters.SourceFilterSettingsChanged => obj?.ToObject<SourceFilterSettingsChanged>(),
            EventName.Filters.SourceFilterEnableStateChanged => obj?.ToObject<SourceFilterEnableStateChanged>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeSceneItemsEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.SceneItems.SceneItemCreated => obj?.ToObject<SceneItemCreated>(),
            EventName.SceneItems.SceneItemRemoved => obj?.ToObject<SceneItemRemoved>(),
            EventName.SceneItems.SceneItemListReindexed => obj?.ToObject<SceneItemListReindexed>(),
            EventName.SceneItems.SceneItemEnableStateChanged => obj?.ToObject<SceneItemEnableStateChanged>(),
            EventName.SceneItems.SceneItemLockStateChanged => obj?.ToObject<SceneItemLockStateChanged>(),
            EventName.SceneItems.SceneItemSelected => obj?.ToObject<SceneItemSelected>(),
            EventName.SceneItems.SceneItemTransformChanged => obj?.ToObject<SceneItemTransformChanged>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeOutputsEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.Outputs.StreamStateChanged => obj?.ToObject<StreamStateChanged>(),
            EventName.Outputs.RecordStateChanged => obj?.ToObject<RecordStateChanged>(),
            EventName.Outputs.RecordFileChanged => obj?.ToObject<RecordFileChanged>(),
            EventName.Outputs.ReplayBufferStateChanged => obj?.ToObject<ReplayBufferStateChanged>(),
            EventName.Outputs.VirtualcamStateChanged => obj?.ToObject<VirtualcamStateChanged>(),
            EventName.Outputs.ReplayBufferSaved => obj?.ToObject<ReplayBufferSaved>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeMediaInputsEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.MediaInputs.MediaInputPlaybackStarted => obj?.ToObject<MediaInputPlaybackStarted>(),
            EventName.MediaInputs.MediaInputPlaybackEnded => obj?.ToObject<MediaInputPlaybackEnded>(),
            EventName.MediaInputs.MediaInputActionTriggered => obj?.ToObject<MediaInputActionTriggered>(),
            _ => null,
        };
    }

    private static BaseEvent? DecodeUiEvent(this EventMessageObj message)
    {
        var obj = message.EventData as JObject;
        return message.EventType switch
        {
            EventName.Ui.StudioModeStateChanged => obj?.ToObject<StudioModeStateChanged>(),
            EventName.Ui.ScreenshotSaved => obj?.ToObject<ScreenshotSaved>(),
            _ => null,
        };
    }
}
