// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtPartialResource.Models
{
    /// <summary> Automanage configuration profile assignment properties. </summary>
    public partial class ConfigurationProfileAssignmentProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ConfigurationProfileAssignmentProperties"/>. </summary>
        public ConfigurationProfileAssignmentProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ConfigurationProfileAssignmentProperties"/>. </summary>
        /// <param name="configurationProfile"> The Automanage configurationProfile ARM Resource URI. </param>
        /// <param name="targetId"> The target VM resource URI. </param>
        /// <param name="status"> The status of onboarding, which only appears in the response. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ConfigurationProfileAssignmentProperties(string configurationProfile, string targetId, string status, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ConfigurationProfile = configurationProfile;
            TargetId = targetId;
            Status = status;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The Automanage configurationProfile ARM Resource URI. </summary>
        public string ConfigurationProfile { get; set; }
        /// <summary> The target VM resource URI. </summary>
        public string TargetId { get; set; }
        /// <summary> The status of onboarding, which only appears in the response. </summary>
        public string Status { get; }
    }
}
