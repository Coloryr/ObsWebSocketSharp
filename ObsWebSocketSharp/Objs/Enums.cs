using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsWebSocketSharp.Objs;

public enum ClientState
{
    Init, Connecting, Connected, Disconnect, Reconnect
}

public enum DataType
{ 
    Json, MsgPack
}

public enum WebSocketOpCode : int
{
    /// <summary>
    /// The initial message sent by obs-websocket to newly connected clients.
    /// </summary>
    Hello = 0,
    /// <summary>
    /// The message sent by a newly connected client to obs-websocket in response to a Hello.
    /// </summary>
    Identify = 1,
    /// <summary>
    /// The response sent by obs-websocket to a client after it has successfully identified with obs-websocket.
    /// </summary>
    Identified = 2,
    /// <summary>
    /// The message sent by an already-identified client to update identification parameters.
    /// </summary>
    Reidentify = 3,
    /// <summary>
    /// The message sent by obs-websocket containing an event payload.
    /// </summary>
    Event = 5,
    /// <summary>
    /// The message sent by a client to obs-websocket to perform a request.
    /// </summary>
    Request = 6,
    /// <summary>
    /// The message sent by obs-websocket in response to a particular request from a client.
    /// </summary>
    RequestResponse = 7,
    /// <summary>
    /// The message sent by a client to obs-websocket to perform a batch of requests.
    /// </summary>
    RequestBatch = 8,
    /// <summary>
    /// The message sent by obs-websocket in response to a particular batch of requests from a client.
    /// </summary>
    RequestBatchResponse = 9
}

public enum WebSocketCloseCode : int 
{
    /// <summary>
    /// For internal use only to tell the request handler not to perform any close action.
    /// </summary>
    DontClose = 0,
    /// <summary>
    /// Unknown reason, should never be used.
    /// </summary>
    UnknownReason = 4000,
    /// <summary>
    /// The server was unable to decode the incoming websocket message.
    /// </summary>
    MessageDecodeError = 4002,
    /// <summary>
    /// A data field is required but missing from the payload.
    /// </summary>
    MissingDataField = 4003,
    /// <summary>
    /// A data field's value type is invalid.
    /// </summary>
    InvalidDataFieldType = 4004,
    /// <summary>
    /// A data field's value is invalid.
    /// </summary>
    InvalidDataFieldValue = 4005,
    /// <summary>
    /// The specified op was invalid or missing.
    /// </summary>
    UnknownOpCode = 4006,
    /// <summary>
    /// The client sent a websocket message without first sending Identify message.
    /// </summary>
    NotIdentified = 4007,
    /// <summary>
    /// The client sent an Identify message while already identified.
    /// Note: Once a client has identified, only Reidentify may be used to change session parameters.
    /// </summary>
    AlreadyIdentified = 4008,
    /// <summary>
    /// The authentication attempt (via Identify) failed.
    /// </summary>
    AuthenticationFailed = 4009,
    /// <summary>
    /// The server detected the usage of an old version of the obs-websocket RPC protocol.
    /// </summary>
    UnsupportedRpcVersion = 4010,
    /// <summary>
    /// The websocket session has been invalidated by the obs-websocket server.
    /// Note: This is the code used by the Kick button in the UI Session List. If you receive this code, you must not automatically reconnect.
    /// </summary>
    SessionInvalidated = 4011,
    /// <summary>
    /// A requested feature is not supported due to hardware/software limitations.
    /// </summary>
    UnsupportedFeature = 4012,
}

public enum RequestBatchExecutionType : int
{
    /// <summary>
    /// Not a request batch.
    /// </summary>
    None = -1,
    /// <summary>
    /// A request batch which processes all requests serially, as fast as possible.
    /// Note: To introduce artificial delay, use the Sleep request and the sleepMillis request field.
    /// </summary>
    SerialRealtime = 0,
    /// <summary>
    /// A request batch type which processes all requests serially, in sync with the graphics thread. Designed to provide high accuracy for animations.
    /// Note: To introduce artificial delay, use the Sleep request and the sleepFrames request field.
    /// </summary>
    SerialFrame = 1,
    /// <summary>
    /// A request batch type which processes all requests using all available threads in the thread pool.
    /// Note: This is mainly experimental, and only really shows its colors during requests which require lots of active processing, like GetSourceScreenshot.
    /// </summary>
    Parallel = 2,
}

public enum RequestStatus : int
{
    /// <summary>
    /// Unknown status, should never be used.
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// For internal use to signify a successful field check.
    /// </summary>
    NoError = 10,
    /// <summary>
    /// The request has succeeded.
    /// </summary>
    Success = 100,
    /// <summary>
    /// The requestType field is missing from the request data.
    /// </summary>
    MissingRequestType = 203,
    /// <summary>
    /// The request type is invalid or does not exist.
    /// </summary>
    UnknownRequestType = 204,
    /// <summary>
    /// Generic error code.
    /// Note: A comment is required to be provided by obs-websocket.
    /// </summary>
    GenericError = 205,
    /// <summary>
    /// The request batch execution type is not supported.
    /// </summary>
    UnsupportedRequestBatchExecutionType = 206,
    /// <summary>
    /// The server is not ready to handle the request.
    /// Note: This usually occurs during OBS scene collection change or exit. Requests may be tried again after a delay if this code is given.
    /// </summary>
    NotReady = 207,
    /// <summary>
    /// A required request field is missing.
    /// </summary>
    MissingRequestField = 300,
    /// <summary>
    /// The request does not have a valid requestData object.
    /// </summary>
    MissingRequestData = 301,
    /// <summary>
    /// Generic invalid request field message.
    /// Note: A comment is required to be provided by obs-websocket.
    /// </summary>
    InvalidRequestField = 400,
    /// <summary>
    /// A request field has the wrong data type.
    /// </summary>
    InvalidRequestFieldType = 401,
    /// <summary>
    /// A request field (number) is outside of the allowed range.
    /// </summary>
    RequestFieldOutOfRange = 402,
    /// <summary>
    /// A request field (string or array) is empty and cannot be.
    /// </summary>
    RequestFieldEmpty = 403,
    /// <summary>
    /// There are too many request fields (eg. a request takes two optionals, where only one is allowed at a time).
    /// </summary>
    TooManyRequestFields = 404,
    /// <summary>
    /// An output is running and cannot be in order to perform the request.
    /// </summary>
    OutputRunning = 500,
    /// <summary>
    /// An output is not running and should be.
    /// </summary>
    OutputNotRunning = 501,
    /// <summary>
    /// An output is paused and should not be.
    /// </summary>
    OutputPaused = 502,
    /// <summary>
    /// An output is not paused and should be.
    /// </summary>
    OutputNotPaused = 503,
    /// <summary>
    /// An output is disabled and should not be.
    /// </summary>
    OutputDisabled = 504,
    /// <summary>
    /// Studio mode is active and cannot be.
    /// </summary>
    StudioModeActive = 505,
    /// <summary>
    /// Studio mode is not active and should be.
    /// </summary>
    StudioModeNotActive = 506,
    /// <summary>
    /// The resource was not found.
    /// Note: Resources are any kind of object in obs-websocket, like inputs, profiles, outputs, etc.
    /// </summary>
    ResourceNotFound = 600,
    /// <summary>
    /// The resource already exists.
    /// </summary>
    ResourceAlreadyExists = 601,
    /// <summary>
    /// The type of resource found is invalid.
    /// </summary>
    InvalidResourceType = 602,
    /// <summary>
    /// There are not enough instances of the resource in order to perform the request.
    /// </summary>
    NotEnoughResources = 603,
    /// <summary>
    /// The state of the resource is invalid. For example, if the resource is blocked from being accessed.
    /// </summary>
    InvalidResourceState = 604,
    /// <summary>
    /// The specified input (obs_source_t-OBS_SOURCE_TYPE_INPUT) had the wrong kind.
    /// </summary>
    InvalidInputKind = 605,
    /// <summary>
    /// The resource does not support being configured.
    /// This is particularly relevant to transitions, where they do not always have changeable settings.
    /// </summary>
    ResourceNotConfigurable = 606,
    /// <summary>
    /// The specified filter (obs_source_t-OBS_SOURCE_TYPE_FILTER) had the wrong kind.
    /// </summary>
    InvalidFilterKind = 607,
    /// <summary>
    /// Creating the resource failed.
    /// </summary>
    ResourceCreationFailed = 700,
    /// <summary>
    /// Performing an action on the resource failed.
    /// </summary>
    ResourceActionFailed = 701,
    /// <summary>
    /// Processing the request failed unexpectedly.
    /// Note: A comment is required to be provided by obs-websocket.
    /// </summary>
    RequestProcessingFailed = 702,
    /// <summary>
    /// The combination of request fields cannot be used to perform an action.
    /// </summary>
    CannotAct = 703,
}

public enum EventSubscription : int
{
    /// <summary>
    /// Subcription value used to disable all events.
    /// </summary>
    None = 0,
    /// <summary>
    /// Subscription value to receive events in the General category.
    /// </summary>
    General = 1 << 0,
    /// <summary>
    /// Subscription value to receive events in the Config category.
    /// </summary>
    Config = 1 << 1,
    /// <summary>
    /// Subscription value to receive events in the Scenes category.
    /// </summary>
    Scenes = 1 << 2,
    /// <summary>
    /// Subscription value to receive events in the Inputs category.
    /// </summary>
    Inputs = 1 << 3,
    /// <summary>
    /// Subscription value to receive events in the Transitions category.
    /// </summary>
    Transitions = 1 << 4,
    /// <summary>
    /// Subscription value to receive events in the Filters category.
    /// </summary>
    Filters = 1 << 5,
    /// <summary>
    /// Subscription value to receive events in the Outputs category.
    /// </summary>
    Outputs = 1 << 6,
    /// <summary>
    /// Subscription value to receive events in the SceneItems category.
    /// </summary>
    SceneItems = 1 << 7,
    /// <summary>
    /// Subscription value to receive events in the MediaInputs category.
    /// </summary>
    MediaInputs = 1 << 8,
    /// <summary>
    /// Subscription value to receive the VendorEvent event
    /// </summary>
    Vendors = 1 << 9,
    /// <summary>
    /// Subscription value to receive events in the Ui category.
    /// </summary>
    Ui = 1 << 10,
    /// <summary>
    /// Helper to receive all non-high-volume events.
    /// </summary>
    All = General | Config | Scenes | Inputs | Transitions
        | Filters | Outputs | SceneItems | MediaInputs
        | Vendors | Ui,
    /// <summary>
    /// Subscription value to receive the InputVolumeMeters high-volume event.
    /// </summary>
    InputVolumeMeters = 1 << 16,
    /// <summary>
    /// Subscription value to receive the InputActiveStateChanged high-volume event.
    /// </summary>
    InputActiveStateChanged = 1 << 17,
    /// <summary>
    /// Subscription value to receive the InputShowStateChanged high-volume event.
    /// </summary>
    InputShowStateChanged = 1 << 18,
    /// <summary>
    /// Subscription value to receive the SceneItemTransformChanged high-volume event.
    /// </summary>
    SceneItemTransformChanged = 1 << 19,
}

public static class ObsMediaInputAction
{
    public const string None = "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_NONE";
    public const string Play = "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_PLAY";
    public const string Pause = "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_PAUSE";
    public const string Stop = "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_STOP";
    public const string Restart = "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_RESTART";
    public const string Next = "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_NEXT";
    public const string Previous = "OBS_WEBSOCKET_MEDIA_INPUT_ACTION_PREVIOUS";
}

public enum ObsOutputState : int
{
    OBS_WEBSOCKET_OUTPUT_UNKNOWN,
    OBS_WEBSOCKET_OUTPUT_STARTING,
    OBS_WEBSOCKET_OUTPUT_STARTED,
    OBS_WEBSOCKET_OUTPUT_STOPPING,
    OBS_WEBSOCKET_OUTPUT_STOPPED,
    OBS_WEBSOCKET_OUTPUT_RECONNECTING,
    OBS_WEBSOCKET_OUTPUT_RECONNECTED,
    OBS_WEBSOCKET_OUTPUT_PAUSED,
    OBS_WEBSOCKET_OUTPUT_RESUMED
}

public static class RequestName
{
    public const string GetVersion = "GetVersion";
    public const string GetStats = "GetStats";
    public const string BroadcastCustomEvent = "BroadcastCustomEvent";
    public const string CallVendorRequest = "CallVendorRequest";
    public const string GetHotkeyList = "GetHotkeyList";
    public const string TriggerHotkeyByName = "TriggerHotkeyByName";
    public const string TriggerHotkeyByKeySequence = "TriggerHotkeyByKeySequence";
    public const string Sleep = "Sleep";

    public const string GetPersistentData = "GetPersistentData";
    public const string SetPersistentData = "SetPersistentData";
    public const string GetSceneCollectionList = "GetSceneCollectionList";
    public const string SetCurrentSceneCollection = "SetCurrentSceneCollection";
    public const string CreateSceneCollection = "CreateSceneCollection";
    public const string GetProfileList = "GetProfileList";
    public const string SetCurrentProfile = "SetCurrentProfile";
    public const string CreateProfile = "CreateProfile";
    public const string RemoveProfile = "RemoveProfile";
    public const string GetProfileParameter = "GetProfileParameter";
    public const string SetProfileParameter = "SetProfileParameter";
    public const string GetVideoSettings = "GetVideoSettings";
    public const string SetVideoSettings = "SetVideoSettings";
    public const string GetStreamServiceSettings = "GetStreamServiceSettings";
    public const string SetStreamServiceSettings = "SetStreamServiceSettings";
    public const string GetRecordDirectory = "GetRecordDirectory";
    public const string SetRecordDirectory = "SetRecordDirectory";

    public const string GetSourceActive = "GetSourceActive";
    public const string GetSourceScreenshot = "GetSourceScreenshot";
    public const string SaveSourceScreenshot = "SaveSourceScreenshot";

    public const string GetSceneList = "GetSceneList";
    public const string GetGroupList = "GetGroupList";
    public const string GetCurrentProgramScene = "GetCurrentProgramScene";
    public const string SetCurrentProgramScene = "SetCurrentProgramScene";
    public const string GetCurrentPreviewScene = "GetCurrentPreviewScene";
    public const string SetCurrentPreviewScene = "SetCurrentPreviewScene";
    public const string CreateScene = "CreateScene";
    public const string RemoveScene = "RemoveScene";
    public const string SetSceneName = "SetSceneName";
    public const string GetSceneSceneTransitionOverride = "GetSceneSceneTransitionOverride";
    public const string SetSceneSceneTransitionOverride = "SetSceneSceneTransitionOverride";

    public const string GetInputList = "GetInputList";
    public const string GetInputKindList = "GetInputKindList";
    public const string GetSpecialInputs = "GetSpecialInputs";
    public const string CreateInput = "CreateInput";
    public const string RemoveInput = "RemoveInput";
    public const string SetInputName = "SetInputName";
    public const string GetInputDefaultSettings = "GetInputDefaultSettings";
    public const string GetInputSettings = "GetInputSettings";
    public const string SetInputSettings = "SetInputSettings";
    public const string GetInputMute = "GetInputMute";
    public const string SetInputMute = "SetInputMute";
    public const string ToggleInputMute = "ToggleInputMute";
    public const string GetInputVolume = "GetInputVolume";
    public const string SetInputVolume = "SetInputVolume";
    public const string GetInputAudioBalance = "GetInputAudioBalance";
    public const string SetInputAudioBalance = "SetInputAudioBalance";
    public const string GetInputAudioSyncOffset = "GetInputAudioSyncOffset";
    public const string SetInputAudioSyncOffset = "SetInputAudioSyncOffset";
    public const string GetInputAudioMonitorType = "GetInputAudioMonitorType";
    public const string SetInputAudioMonitorType = "SetInputAudioMonitorType";
    public const string GetInputAudioTracks = "GetInputAudioTracks";
}

public static class StreamServiceType
{
    public const string RtmpCommon = "rtmp_common";
    public const string RtmpCustom = "rtmp_custom";
}

public static class ObsMonitorTypeName
{
    public const string None = "OBS_MONITORING_TYPE_NONE";
    public const string MonitorOnly = "OBS_MONITORING_TYPE_MONITOR_ONLY";
    public const string MonitorAndOutput = "OBS_MONITORING_TYPE_MONITOR_AND_OUTPUT";
}

public static class EventName
{
    public static class General
    {
        public const string ExitStarted = "ExitStarted";
        public const string VendorEvent = "VendorEvent";
        public const string CustomEvent = "CustomEvent";
    }

    public static class Config
    {
        public const string CurrentSceneCollectionChanging = "CurrentSceneCollectionChanging";
        public const string CurrentSceneCollectionChanged = "CurrentSceneCollectionChanged";
        public const string SceneCollectionListChanged = "SceneCollectionListChanged";
        public const string CurrentProfileChanging = "CurrentProfileChanging";
        public const string CurrentProfileChanged = "CurrentProfileChanged";
        public const string ProfileListChanged = "ProfileListChanged";
    }

    public static class Scenes
    {
        public const string SceneCreated = "SceneCreated";
        public const string SceneRemoved = "SceneRemoved";
        public const string SceneNameChanged = "SceneNameChanged";
        public const string CurrentProgramSceneChanged = "CurrentProgramSceneChanged";
        public const string CurrentPreviewSceneChanged = "CurrentPreviewSceneChanged";
        public const string SceneListChanged = "SceneListChanged";
    }

    public static class Inputs
    {
        public const string InputCreated = "InputCreated";
        public const string InputRemoved = "InputRemoved";
        public const string InputNameChanged = "InputNameChanged";
        public const string InputSettingsChanged = "InputSettingsChanged";
        public const string InputActiveStateChanged = "InputActiveStateChanged";
        public const string InputShowStateChanged = "InputShowStateChanged";
        public const string InputMuteStateChanged = "InputMuteStateChanged";
        public const string InputVolumeChanged = "InputVolumeChanged";
        public const string InputAudioBalanceChanged = "InputAudioBalanceChanged";
        public const string InputAudioSyncOffsetChanged = "InputAudioSyncOffsetChanged";
        public const string InputAudioTracksChanged = "InputAudioTracksChanged";
        public const string InputAudioMonitorTypeChanged = "InputAudioMonitorTypeChanged";
        public const string InputVolumeMeters = "InputVolumeMeters";
    }

    public static class Transitions
    {
        public const string CurrentSceneTransitionChanged = "CurrentSceneTransitionChanged";
        public const string CurrentSceneTransitionDurationChanged = "CurrentSceneTransitionDurationChanged";
        public const string SceneTransitionStarted = "SceneTransitionStarted";
        public const string SceneTransitionEnded = "SceneTransitionEnded";
        public const string SceneTransitionVideoEnded = "SceneTransitionVideoEnded";
    }

    public static class Filters
    {
        public const string SourceFilterListReindexed = "SourceFilterListReindexed";
        public const string SourceFilterCreated = "SourceFilterCreated";
        public const string SourceFilterRemoved = "SourceFilterRemoved";
        public const string SourceFilterNameChanged = "SourceFilterNameChanged";
        public const string SourceFilterSettingsChanged = "SourceFilterSettingsChanged";
        public const string SourceFilterEnableStateChanged = "SourceFilterEnableStateChanged";
    }

    public static class SceneItems
    {
        public const string SceneItemCreated = "SceneItemCreated";
        public const string SceneItemRemoved = "SceneItemRemoved";
        public const string SceneItemListReindexed = "SceneItemListReindexed";
        public const string SceneItemEnableStateChanged = "SceneItemEnableStateChanged";
        public const string SceneItemLockStateChanged = "SceneItemLockStateChanged";
        public const string SceneItemSelected = "SceneItemSelected";
        public const string SceneItemTransformChanged = "SceneItemTransformChanged";
    }

    public static class Outputs
    {
        public const string StreamStateChanged = "StreamStateChanged";
        public const string RecordStateChanged = "RecordStateChanged";
        public const string RecordFileChanged = "RecordFileChanged";
        public const string ReplayBufferStateChanged = "ReplayBufferStateChanged";
        public const string VirtualcamStateChanged = "VirtualcamStateChanged";
        public const string ReplayBufferSaved = "ReplayBufferSaved";
    }

    public static class MediaInputs
    {
        public const string MediaInputPlaybackStarted = "MediaInputPlaybackStarted";
        public const string MediaInputPlaybackEnded = "MediaInputPlaybackEnded";
        public const string MediaInputActionTriggered = "MediaInputActionTriggered";
    }

    public static class Ui
    {
        public const string StudioModeStateChanged = "StudioModeStateChanged";
        public const string ScreenshotSaved = "ScreenshotSaved";
    }
}