// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The TerminateNotificationProfile.
    /// Serialized Name: TerminateNotificationProfile
    /// </summary>
    public partial class TerminateNotificationProfile
    {
        /// <summary> Initializes a new instance of TerminateNotificationProfile. </summary>
        public TerminateNotificationProfile()
        {
        }

        /// <summary> Initializes a new instance of TerminateNotificationProfile. </summary>
        /// <param name="notBeforeTimeout">
        /// Configurable length of time a Virtual Machine being deleted will have to potentially approve the Terminate Scheduled Event before the event is auto approved (timed out). The configuration must be specified in ISO 8601 format, the default value is 5 minutes (PT5M)
        /// Serialized Name: TerminateNotificationProfile.notBeforeTimeout
        /// </param>
        /// <param name="enable">
        /// Specifies whether the Terminate Scheduled event is enabled or disabled.
        /// Serialized Name: TerminateNotificationProfile.enable
        /// </param>
        internal TerminateNotificationProfile(string notBeforeTimeout, bool? enable)
        {
            NotBeforeTimeout = notBeforeTimeout;
            Enable = enable;
        }

        /// <summary>
        /// Configurable length of time a Virtual Machine being deleted will have to potentially approve the Terminate Scheduled Event before the event is auto approved (timed out). The configuration must be specified in ISO 8601 format, the default value is 5 minutes (PT5M)
        /// Serialized Name: TerminateNotificationProfile.notBeforeTimeout
        /// </summary>
        public string NotBeforeTimeout { get; set; }
        /// <summary>
        /// Specifies whether the Terminate Scheduled event is enabled or disabled.
        /// Serialized Name: TerminateNotificationProfile.enable
        /// </summary>
        public bool? Enable { get; set; }
    }
}
