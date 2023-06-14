// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The ScheduledEventsProfile.
    /// Serialized Name: ScheduledEventsProfile
    /// </summary>
    internal partial class ScheduledEventsProfile
    {
        /// <summary> Initializes a new instance of ScheduledEventsProfile. </summary>
        public ScheduledEventsProfile()
        {
        }

        /// <summary> Initializes a new instance of ScheduledEventsProfile. </summary>
        /// <param name="terminateNotificationProfile">
        /// Specifies Terminate Scheduled Event related configurations.
        /// Serialized Name: ScheduledEventsProfile.terminateNotificationProfile
        /// </param>
        internal ScheduledEventsProfile(TerminateNotificationProfile terminateNotificationProfile)
        {
            TerminateNotificationProfile = terminateNotificationProfile;
        }

        /// <summary>
        /// Specifies Terminate Scheduled Event related configurations.
        /// Serialized Name: ScheduledEventsProfile.terminateNotificationProfile
        /// </summary>
        public TerminateNotificationProfile TerminateNotificationProfile { get; set; }
    }
}
