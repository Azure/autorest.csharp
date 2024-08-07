// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The CreateEmbeddingResponseUsage. </summary>
    public partial class CreateEmbeddingResponseUsage
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
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingResponseUsage"/>. </summary>
        /// <param name="promptTokens"> The number of tokens used by the prompt. </param>
        /// <param name="totalTokens"> The total number of tokens used by the request. </param>
        internal CreateEmbeddingResponseUsage(long promptTokens, long totalTokens)
        {
            PromptTokens = promptTokens;
            TotalTokens = totalTokens;
        }

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingResponseUsage"/>. </summary>
        /// <param name="promptTokens"> The number of tokens used by the prompt. </param>
        /// <param name="totalTokens"> The total number of tokens used by the request. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateEmbeddingResponseUsage(long promptTokens, long totalTokens, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            PromptTokens = promptTokens;
            TotalTokens = totalTokens;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingResponseUsage"/> for deserialization. </summary>
        internal CreateEmbeddingResponseUsage()
        {
        }

        /// <summary> The number of tokens used by the prompt. </summary>
        public long PromptTokens { get; }
        /// <summary> The total number of tokens used by the request. </summary>
        public long TotalTokens { get; }
    }
}
