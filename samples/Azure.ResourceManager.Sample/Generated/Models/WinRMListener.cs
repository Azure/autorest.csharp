// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes Protocol and thumbprint of Windows Remote Management listener
    /// Serialized Name: WinRMListener
    /// </summary>
    public partial class WinRMListener
    {
        /// <summary> Initializes a new instance of WinRMListener. </summary>
        public WinRMListener()
        {
        }

        /// <summary> Initializes a new instance of WinRMListener. </summary>
        /// <param name="protocol">
        /// Specifies the protocol of WinRM listener. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;**http** &lt;br&gt;&lt;br&gt; **https**
        /// Serialized Name: WinRMListener.protocol
        /// </param>
        /// <param name="certificateUri">
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: &lt;br&gt;&lt;br&gt; {&lt;br&gt;  "data":"&lt;Base64-encoded-certificate&gt;",&lt;br&gt;  "dataType":"pfx",&lt;br&gt;  "password":"&lt;pfx-file-password&gt;"&lt;br&gt;}
        /// Serialized Name: WinRMListener.certificateUrl
        /// </param>
        internal WinRMListener(ProtocolType? protocol, Uri certificateUri)
        {
            Protocol = protocol;
            CertificateUri = certificateUri;
        }

        /// <summary>
        /// Specifies the protocol of WinRM listener. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;**http** &lt;br&gt;&lt;br&gt; **https**
        /// Serialized Name: WinRMListener.protocol
        /// </summary>
        public ProtocolType? Protocol { get; set; }
        /// <summary>
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: &lt;br&gt;&lt;br&gt; {&lt;br&gt;  "data":"&lt;Base64-encoded-certificate&gt;",&lt;br&gt;  "dataType":"pfx",&lt;br&gt;  "password":"&lt;pfx-file-password&gt;"&lt;br&gt;}
        /// Serialized Name: WinRMListener.certificateUrl
        /// </summary>
        public Uri CertificateUri { get; set; }
    }
}
