// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Intrusion detection signatures specification states. </summary>
    public partial class FirewallPolicyIntrusionDetectionSignatureSpecification
    {
        /// <summary> Initializes a new instance of FirewallPolicyIntrusionDetectionSignatureSpecification. </summary>
        public FirewallPolicyIntrusionDetectionSignatureSpecification()
        {
        }

        /// <summary> Initializes a new instance of FirewallPolicyIntrusionDetectionSignatureSpecification. </summary>
        /// <param name="id"> Signature id. </param>
        /// <param name="mode"> The signature state. </param>
        internal FirewallPolicyIntrusionDetectionSignatureSpecification(string id, FirewallPolicyIntrusionDetectionStateType? mode)
        {
            Id = id;
            Mode = mode;
        }

        /// <summary> Signature id. </summary>
        public string Id { get; set; }
        /// <summary> The signature state. </summary>
        public FirewallPolicyIntrusionDetectionStateType? Mode { get; set; }
    }
}
