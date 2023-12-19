// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The SubResourceReadOnly.
    /// Serialized Name: SubResourceReadOnly
    /// </summary>
    public partial class SubResourceReadOnly
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
        private protected IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SubResourceReadOnly"/>. </summary>
        public SubResourceReadOnly()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SubResourceReadOnly"/>. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResourceReadOnly.id
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SubResourceReadOnly(string id, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Resource Id
        /// Serialized Name: SubResourceReadOnly.id
        /// </summary>
        public string Id { get; }
    }
}
