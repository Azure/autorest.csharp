// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes Protocol and thumbprint of Windows Remote Management listener
    /// Serialized Name: WinRMListener
    /// </summary>
    public partial class WinRMListener
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="WinRMListener"/>. </summary>
        public WinRMListener()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WinRMListener"/>. </summary>
        /// <param name="protocol">
        /// Specifies the protocol of WinRM listener. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;**http** &lt;br&gt;&lt;br&gt; **https**
        /// Serialized Name: WinRMListener.protocol
        /// </param>
        /// <param name="certificateUri">
        /// This is the URL of a certificate that has been uploaded to Key Vault as a secret. For adding a secret to the Key Vault, see [Add a key or secret to the key vault](https://docs.microsoft.com/azure/key-vault/key-vault-get-started/#add). In this case, your certificate needs to be It is the Base64 encoding of the following JSON Object which is encoded in UTF-8: &lt;br&gt;&lt;br&gt; {&lt;br&gt;  "data":"&lt;Base64-encoded-certificate&gt;",&lt;br&gt;  "dataType":"pfx",&lt;br&gt;  "password":"&lt;pfx-file-password&gt;"&lt;br&gt;}
        /// Serialized Name: WinRMListener.certificateUrl
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal WinRMListener(ProtocolType? protocol, Uri certificateUri, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Protocol = protocol;
            CertificateUri = certificateUri;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
