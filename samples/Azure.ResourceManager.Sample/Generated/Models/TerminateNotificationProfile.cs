// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> The TerminateNotificationProfile. </summary>
    public partial class TerminateNotificationProfile
    {
        /// <summary> Initializes a new instance of TerminateNotificationProfile. </summary>
        public TerminateNotificationProfile()
        {
        }

        /// <summary> Initializes a new instance of TerminateNotificationProfile. </summary>
        /// <param name="notBeforeTimeout"> Configurable length of time a Virtual Machine being deleted will have to potentially approve the Terminate Scheduled Event before the event is auto approved (timed out). The configuration must be specified in ISO 8601 format, the default value is 5 minutes (PT5M). </param>
        /// <param name="enable"> Specifies whether the Terminate Scheduled event is enabled or disabled. </param>
        internal TerminateNotificationProfile(string notBeforeTimeout, bool? enable)
        {
            NotBeforeTimeout = notBeforeTimeout;
            Enable = enable;
        }

        /// <summary> Configurable length of time a Virtual Machine being deleted will have to potentially approve the Terminate Scheduled Event before the event is auto approved (timed out). The configuration must be specified in ISO 8601 format, the default value is 5 minutes (PT5M). </summary>
        public string NotBeforeTimeout { get; set; }
        /// <summary> Specifies whether the Terminate Scheduled event is enabled or disabled. </summary>
        public bool? Enable { get; set; }
    }
}
