// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Scm.Parameters.Spread.Models
{
    /// <summary> This is a model with non-body http request decorator. </summary>
    public partial class CompositeRequestMix
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

        /// <summary> Initializes a new instance of <see cref="CompositeRequestMix"/>. </summary>
        /// <param name="prop"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop"/> is null. </exception>
        public CompositeRequestMix(string prop)
        {
            Argument.AssertNotNull(prop, nameof(prop));

            Prop = prop;
        }

        /// <summary> Initializes a new instance of <see cref="CompositeRequestMix"/>. </summary>
        /// <param name="prop"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CompositeRequestMix(string prop, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Prop = prop;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CompositeRequestMix"/> for deserialization. </summary>
        internal CompositeRequestMix()
        {
        }

        /// <summary> Gets the prop. </summary>
        public string Prop { get; }
    }
}
