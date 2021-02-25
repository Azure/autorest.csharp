// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample
{
    /// <summary> Describes Protocol and thumbprint of Windows Remote Management listener. </summary>
    public partial class WinRMListener
    {
        /// <summary> Initializes a new instance of WinRMListener. </summary>
        public WinRMListener()
        {
        }

        /// <summary> Initializes a new instance of WinRMListener. </summary>
        /// <param name="protocol"> Specifies the protocol of WinRM listener. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;**http** &lt;br&gt;&lt;br&gt; **https**. </param>
        /// <param name="certificateUrl"> This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: &lt;br&gt;&lt;br&gt; {&lt;br&gt;  &quot;data&quot;:&quot;&lt;Base64-encoded-certificate&gt;&quot;,&lt;br&gt;  &quot;dataType&quot;:&quot;pfx&quot;,&lt;br&gt;  &quot;password&quot;:&quot;&lt;pfx-file-password&gt;&quot;&lt;br&gt;}. </param>
        internal WinRMListener(ProtocolTypes? protocol, string certificateUrl)
        {
            Protocol = protocol;
            CertificateUrl = certificateUrl;
        }

        /// <summary> Specifies the protocol of WinRM listener. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;**http** &lt;br&gt;&lt;br&gt; **https**. </summary>
        public ProtocolTypes? Protocol { get; set; }
        /// <summary> This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: &lt;br&gt;&lt;br&gt; {&lt;br&gt;  &quot;data&quot;:&quot;&lt;Base64-encoded-certificate&gt;&quot;,&lt;br&gt;  &quot;dataType&quot;:&quot;pfx&quot;,&lt;br&gt;  &quot;password&quot;:&quot;&lt;pfx-file-password&gt;&quot;&lt;br&gt;}. </summary>
        public string CertificateUrl { get; set; }
    }
}
