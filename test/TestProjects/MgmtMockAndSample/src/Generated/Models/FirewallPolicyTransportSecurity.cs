// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Configuration needed to perform TLS termination &amp; initiation. </summary>
    internal partial class FirewallPolicyTransportSecurity
    {
        /// <summary> Initializes a new instance of FirewallPolicyTransportSecurity. </summary>
        public FirewallPolicyTransportSecurity()
        {
        }

        /// <summary> Initializes a new instance of FirewallPolicyTransportSecurity. </summary>
        /// <param name="certificateAuthority"> The CA used for intermediate CA generation. </param>
        internal FirewallPolicyTransportSecurity(FirewallPolicyCertificateAuthority certificateAuthority)
        {
            CertificateAuthority = certificateAuthority;
        }

        /// <summary> The CA used for intermediate CA generation. </summary>
        public FirewallPolicyCertificateAuthority CertificateAuthority { get; set; }
    }
}
