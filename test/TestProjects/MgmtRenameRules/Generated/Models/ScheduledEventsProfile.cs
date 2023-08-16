// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The ScheduledEventsProfile.
    /// Serialized Name: ScheduledEventsProfile
    /// </summary>
    internal partial class ScheduledEventsProfile
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.ScheduledEventsProfile
        ///
        /// </summary>
        public ScheduledEventsProfile()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.ScheduledEventsProfile
        ///
        /// </summary>
        /// <param name="terminateNotificationProfile">
        /// Specifies Terminate Scheduled Event related configurations.
        /// Serialized Name: ScheduledEventsProfile.terminateNotificationProfile
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ScheduledEventsProfile(TerminateNotificationProfile terminateNotificationProfile, Dictionary<string, BinaryData> rawData)
        {
            TerminateNotificationProfile = terminateNotificationProfile;
            _rawData = rawData;
        }

        /// <summary>
        /// Specifies Terminate Scheduled Event related configurations.
        /// Serialized Name: ScheduledEventsProfile.terminateNotificationProfile
        /// </summary>
        public TerminateNotificationProfile TerminateNotificationProfile { get; set; }
    }
}
