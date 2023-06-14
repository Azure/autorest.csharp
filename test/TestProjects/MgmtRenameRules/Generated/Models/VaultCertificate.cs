// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a single certificate reference in a Key Vault, and where the certificate should reside on the VM.
    /// Serialized Name: VaultCertificate
    /// </summary>
    public partial class VaultCertificate
    {
        /// <summary> Initializes a new instance of VaultCertificate. </summary>
        public VaultCertificate()
        {
        }

        /// <summary> Initializes a new instance of VaultCertificate. </summary>
        /// <param name="certificateUri">
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: &lt;br&gt;&lt;br&gt; {&lt;br&gt;  "data":"&lt;Base64-encoded-certificate&gt;",&lt;br&gt;  "dataType":"pfx",&lt;br&gt;  "password":"&lt;pfx-file-password&gt;"&lt;br&gt;}
        /// Serialized Name: VaultCertificate.certificateUrl
        /// </param>
        /// <param name="certificateStore">
        /// For Windows VMs, specifies the certificate store on the Virtual Machine to which the certificate should be added. The specified certificate store is implicitly in the LocalMachine account. &lt;br&gt;&lt;br&gt;For Linux VMs, the certificate file is placed under the /var/lib/waagent directory, with the file name &lt;UppercaseThumbprint&gt;.crt for the X509 certificate file and &lt;UppercaseThumbprint&gt;.prv for private key. Both of these files are .pem formatted.
        /// Serialized Name: VaultCertificate.certificateStore
        /// </param>
        internal VaultCertificate(Uri certificateUri, string certificateStore)
        {
            CertificateUri = certificateUri;
            CertificateStore = certificateStore;
        }

        /// <summary>
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: &lt;br&gt;&lt;br&gt; {&lt;br&gt;  "data":"&lt;Base64-encoded-certificate&gt;",&lt;br&gt;  "dataType":"pfx",&lt;br&gt;  "password":"&lt;pfx-file-password&gt;"&lt;br&gt;}
        /// Serialized Name: VaultCertificate.certificateUrl
        /// </summary>
        public Uri CertificateUri { get; set; }
        /// <summary>
        /// For Windows VMs, specifies the certificate store on the Virtual Machine to which the certificate should be added. The specified certificate store is implicitly in the LocalMachine account. &lt;br&gt;&lt;br&gt;For Linux VMs, the certificate file is placed under the /var/lib/waagent directory, with the file name &lt;UppercaseThumbprint&gt;.crt for the X509 certificate file and &lt;UppercaseThumbprint&gt;.prv for private key. Both of these files are .pem formatted.
        /// Serialized Name: VaultCertificate.certificateStore
        /// </summary>
        public string CertificateStore { get; set; }
    }
}
