// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI;

namespace OpenAI.Models
{
    /// <summary> The CreateEmbeddingResponse. </summary>
    public partial class CreateEmbeddingResponse
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

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingResponse"/>. </summary>
        /// <param name="model"> The name of the model used to generate the embedding. </param>
        /// <param name="data"> The list of embeddings generated by the model. </param>
        /// <param name="usage"> The usage information for the request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/>, <paramref name="data"/> or <paramref name="usage"/> is null. </exception>
        internal CreateEmbeddingResponse(string model, IEnumerable<Embedding> data, CreateEmbeddingResponseUsage usage)
        {
            Argument.AssertNotNull(model, nameof(model));
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(usage, nameof(usage));

            Model = model;
            Data = data.ToList();
            Usage = usage;
        }

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingResponse"/>. </summary>
        /// <param name="object"> The object type, which is always "embedding". </param>
        /// <param name="model"> The name of the model used to generate the embedding. </param>
        /// <param name="data"> The list of embeddings generated by the model. </param>
        /// <param name="usage"> The usage information for the request. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateEmbeddingResponse(CreateEmbeddingResponseObject @object, string model, IReadOnlyList<Embedding> data, CreateEmbeddingResponseUsage usage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Object = @object;
            Model = model;
            Data = data;
            Usage = usage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingResponse"/> for deserialization. </summary>
        internal CreateEmbeddingResponse()
        {
        }

        /// <summary> The object type, which is always "embedding". </summary>
        public CreateEmbeddingResponseObject Object { get; } = CreateEmbeddingResponseObject.Embedding;

        /// <summary> The name of the model used to generate the embedding. </summary>
        public string Model { get; }
        /// <summary> The list of embeddings generated by the model. </summary>
        public IReadOnlyList<Embedding> Data { get; }
        /// <summary> The usage information for the request. </summary>
        public CreateEmbeddingResponseUsage Usage { get; }
    }
}
