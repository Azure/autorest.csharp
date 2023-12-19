// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// SSH configuration for Linux based VMs running on Azure
    /// Serialized Name: SshConfiguration
    /// </summary>
    internal partial class SshConfiguration
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

        /// <summary> Initializes a new instance of <see cref="SshConfiguration"/>. </summary>
        public SshConfiguration()
        {
            PublicKeys = new OptionalList<SshPublicKeyInfo>();
        }

        /// <summary> Initializes a new instance of <see cref="SshConfiguration"/>. </summary>
        /// <param name="publicKeys">
        /// The list of SSH public keys used to authenticate with linux based VMs.
        /// Serialized Name: SshConfiguration.publicKeys
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SshConfiguration(IList<SshPublicKeyInfo> publicKeys, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            PublicKeys = publicKeys;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The list of SSH public keys used to authenticate with linux based VMs.
        /// Serialized Name: SshConfiguration.publicKeys
        /// </summary>
        public IList<SshPublicKeyInfo> PublicKeys { get; }
    }
}
