// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> The operation for configuring intrusion detection. </summary>
    public partial class FirewallPolicyIntrusionDetectionConfiguration
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyIntrusionDetectionConfiguration"/>. </summary>
        public FirewallPolicyIntrusionDetectionConfiguration()
        {
            SignatureOverrides = new ChangeTrackingList<FirewallPolicyIntrusionDetectionSignatureSpecification>();
            BypassTrafficSettings = new ChangeTrackingList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications>();
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyIntrusionDetectionConfiguration"/>. </summary>
        /// <param name="signatureOverrides"> List of specific signatures states. </param>
        /// <param name="bypassTrafficSettings"> List of rules for traffic to bypass. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicyIntrusionDetectionConfiguration(IList<FirewallPolicyIntrusionDetectionSignatureSpecification> signatureOverrides, IList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> bypassTrafficSettings, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            SignatureOverrides = signatureOverrides;
            BypassTrafficSettings = bypassTrafficSettings;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> List of specific signatures states. </summary>
        public IList<FirewallPolicyIntrusionDetectionSignatureSpecification> SignatureOverrides { get; }
        /// <summary> List of rules for traffic to bypass. </summary>
        public IList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> BypassTrafficSettings { get; }
    }
}
