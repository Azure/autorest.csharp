// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Models
{
    /// <summary> The ListFineTunesResponse. </summary>
    public partial class ListFineTunesResponse
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
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        /// <summary> Initializes a new instance of <see cref="ListFineTunesResponse"/>. </summary>
        /// <param name="object"></param>
        /// <param name="data"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="object"/> or <paramref name="data"/> is null. </exception>
        internal ListFineTunesResponse(string @object, IEnumerable<FineTune> data)
        {
            Argument.AssertNotNull(@object, nameof(@object));
            Argument.AssertNotNull(data, nameof(data));

            Object = @object;
            Data = data.ToList();
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="ListFineTunesResponse"/>. </summary>
        /// <param name="object"></param>
        /// <param name="data"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ListFineTunesResponse(string @object, IReadOnlyList<FineTune> data, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Object = @object;
            Data = data;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListFineTunesResponse"/> for deserialization. </summary>
        internal ListFineTunesResponse()
        {
        }

        /// <summary> Gets the object. </summary>
        public string Object { get; }
        /// <summary> Gets the data. </summary>
        public IReadOnlyList<FineTune> Data { get; }
    }
}
