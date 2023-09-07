// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Contains the DDoS protection settings of the public IP. </summary>
    public partial class DdosSettings
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DdosSettings"/>. </summary>
        public DdosSettings()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DdosSettings"/>. </summary>
        /// <param name="ddosCustomPolicy"> The DDoS custom policy associated with the public IP. </param>
        /// <param name="protectionCoverage"> The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized. </param>
        /// <param name="protectedIP"> Enables DDoS protection on the public IP. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DdosSettings(SubResource ddosCustomPolicy, DdosSettingsProtectionCoverage? protectionCoverage, bool? protectedIP, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            DdosCustomPolicy = ddosCustomPolicy;
            ProtectionCoverage = protectionCoverage;
            ProtectedIP = protectedIP;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The DDoS custom policy associated with the public IP. </summary>
        public SubResource DdosCustomPolicy { get; set; }
        /// <summary> The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized. </summary>
        public DdosSettingsProtectionCoverage? ProtectionCoverage { get; set; }
        /// <summary> Enables DDoS protection on the public IP. </summary>
        public bool? ProtectedIP { get; set; }
    }
}
