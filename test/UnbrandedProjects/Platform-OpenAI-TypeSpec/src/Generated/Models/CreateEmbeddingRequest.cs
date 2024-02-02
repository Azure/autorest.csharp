// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The CreateEmbeddingRequest. </summary>
    public partial class CreateEmbeddingRequest
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

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingRequest"/>. </summary>
        /// <param name="model"> ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them. </param>
        /// <param name="input">
        /// Input text to embed, encoded as a string or array of tokens. To embed multiple inputs in a
        /// single request, pass an array of strings or array of token arrays. Each input must not exceed
        /// the max input tokens for the model (8191 tokens for `text-embedding-ada-002`) and cannot be an empty string.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_count_tokens_with_tiktoken.ipynb)
        /// for counting tokens.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public CreateEmbeddingRequest(CreateEmbeddingRequestModel model, BinaryData input)
        {
            ClientUtilities.AssertNotNull(input, nameof(input));

            Model = model;
            Input = input;
        }

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingRequest"/>. </summary>
        /// <param name="model"> ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them. </param>
        /// <param name="input">
        /// Input text to embed, encoded as a string or array of tokens. To embed multiple inputs in a
        /// single request, pass an array of strings or array of token arrays. Each input must not exceed
        /// the max input tokens for the model (8191 tokens for `text-embedding-ada-002`) and cannot be an empty string.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_count_tokens_with_tiktoken.ipynb)
        /// for counting tokens.
        /// </param>
        /// <param name="user"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateEmbeddingRequest(CreateEmbeddingRequestModel model, BinaryData input, string user, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Model = model;
            Input = input;
            User = user;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateEmbeddingRequest"/> for deserialization. </summary>
        internal CreateEmbeddingRequest()
        {
        }

        /// <summary> ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them. </summary>
        public CreateEmbeddingRequestModel Model { get; }
        /// <summary>
        /// Input text to embed, encoded as a string or array of tokens. To embed multiple inputs in a
        /// single request, pass an array of strings or array of token arrays. Each input must not exceed
        /// the max input tokens for the model (8191 tokens for `text-embedding-ada-002`) and cannot be an empty string.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_count_tokens_with_tiktoken.ipynb)
        /// for counting tokens.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="string"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="IList{T}"/> where <c>T</c> is of type <see cref="string"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="IList{T}"/> where <c>T</c> is of type <see cref="long"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="IList{T}"/> where <c>T</c> is of type <c>IList{long}</c></description>
        /// </item>
        /// </list>
        /// </remarks>
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
        public BinaryData Input { get; }
        /// <summary> Gets or sets the user. </summary>
        public string User { get; set; }
    }
}
