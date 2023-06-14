// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Trusted Root certificates properties for tls. </summary>
    public partial class FirewallPolicyCertificateAuthority
    {
        /// <summary> Initializes a new instance of FirewallPolicyCertificateAuthority. </summary>
        public FirewallPolicyCertificateAuthority()
        {
        }

        /// <summary> Initializes a new instance of FirewallPolicyCertificateAuthority. </summary>
        /// <param name="keyVaultSecretId"> Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault. </param>
        /// <param name="name"> Name of the CA certificate. </param>
        internal FirewallPolicyCertificateAuthority(string keyVaultSecretId, string name)
        {
            KeyVaultSecretId = keyVaultSecretId;
            Name = name;
        }

        /// <summary> Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault. </summary>
        public string KeyVaultSecretId { get; set; }
        /// <summary> Name of the CA certificate. </summary>
        public string Name { get; set; }
    }
}
