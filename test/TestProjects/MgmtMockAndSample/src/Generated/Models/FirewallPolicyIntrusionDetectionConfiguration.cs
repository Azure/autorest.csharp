// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> The operation for configuring intrusion detection. </summary>
    public partial class FirewallPolicyIntrusionDetectionConfiguration
    {
        /// <summary> Initializes a new instance of FirewallPolicyIntrusionDetectionConfiguration. </summary>
        public FirewallPolicyIntrusionDetectionConfiguration()
        {
            SignatureOverrides = new ChangeTrackingList<FirewallPolicyIntrusionDetectionSignatureSpecification>();
            BypassTrafficSettings = new ChangeTrackingList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications>();
        }

        /// <summary> Initializes a new instance of FirewallPolicyIntrusionDetectionConfiguration. </summary>
        /// <param name="signatureOverrides"> List of specific signatures states. </param>
        /// <param name="bypassTrafficSettings"> List of rules for traffic to bypass. </param>
        internal FirewallPolicyIntrusionDetectionConfiguration(IList<FirewallPolicyIntrusionDetectionSignatureSpecification> signatureOverrides, IList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> bypassTrafficSettings)
        {
            SignatureOverrides = signatureOverrides;
            BypassTrafficSettings = bypassTrafficSettings;
        }

        /// <summary> List of specific signatures states. </summary>
        public IList<FirewallPolicyIntrusionDetectionSignatureSpecification> SignatureOverrides { get; }
        /// <summary> List of rules for traffic to bypass. </summary>
        public IList<FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> BypassTrafficSettings { get; }
    }
}
