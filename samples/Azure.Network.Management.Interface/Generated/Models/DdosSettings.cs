// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Contains the DDoS protection settings of the public IP. </summary>
    public partial class DdosSettings
    {
        /// <summary> Initializes a new instance of DdosSettings. </summary>
        public DdosSettings()
        {
        }

        /// <summary> Initializes a new instance of DdosSettings. </summary>
        /// <param name="ddosCustomPolicy"> The DDoS custom policy associated with the public IP. </param>
        /// <param name="protectionCoverage"> The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized. </param>
        /// <param name="protectedIP"> Enables DDoS protection on the public IP. </param>
        internal DdosSettings(SubResource ddosCustomPolicy, DdosSettingsProtectionCoverage? protectionCoverage, bool? protectedIP)
        {
            DdosCustomPolicy = ddosCustomPolicy;
            ProtectionCoverage = protectionCoverage;
            ProtectedIP = protectedIP;
        }

        /// <summary> The DDoS custom policy associated with the public IP. </summary>
        public SubResource DdosCustomPolicy { get; set; }
        /// <summary> The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized. </summary>
        public DdosSettingsProtectionCoverage? ProtectionCoverage { get; set; }
        /// <summary> Enables DDoS protection on the public IP. </summary>
        public bool? ProtectedIP { get; set; }
    }
}
