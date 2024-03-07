// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI;

namespace OpenAI.Models
{
    /// <summary>
    /// Represents a completion response from the API. Note: both the streamed and non-streamed response
    /// objects share the same shape (unlike the chat endpoint).
    /// </summary>
    public partial class CreateCompletionResponse
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

        /// <summary> Initializes a new instance of <see cref="CreateCompletionResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the completion. </param>
        /// <param name="object"> The object type, which is always `text_completion`. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the completion was created. </param>
        /// <param name="model"> The model used for the completion. </param>
        /// <param name="choices"> The list of completion choices the model generated for the input. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="object"/>, <paramref name="model"/> or <paramref name="choices"/> is null. </exception>
        internal CreateCompletionResponse(string id, string @object, DateTimeOffset created, string model, IEnumerable<CreateCompletionResponseChoice> choices)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(@object, nameof(@object));
            Argument.AssertNotNull(model, nameof(model));
            Argument.AssertNotNull(choices, nameof(choices));

            Id = id;
            Object = @object;
            Created = created;
            Model = model;
            Choices = choices.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="CreateCompletionResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the completion. </param>
        /// <param name="object"> The object type, which is always `text_completion`. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the completion was created. </param>
        /// <param name="model"> The model used for the completion. </param>
        /// <param name="choices"> The list of completion choices the model generated for the input. </param>
        /// <param name="usage"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateCompletionResponse(string id, string @object, DateTimeOffset created, string model, IReadOnlyList<CreateCompletionResponseChoice> choices, CompletionUsage usage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Object = @object;
            Created = created;
            Model = model;
            Choices = choices;
            Usage = usage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateCompletionResponse"/> for deserialization. </summary>
        internal CreateCompletionResponse()
        {
        }

        /// <summary> A unique identifier for the completion. </summary>
        public string Id { get; }
        /// <summary> The object type, which is always `text_completion`. </summary>
        public string Object { get; }
        /// <summary> The Unix timestamp (in seconds) of when the completion was created. </summary>
        public DateTimeOffset Created { get; }
        /// <summary> The model used for the completion. </summary>
        public string Model { get; }
        /// <summary> The list of completion choices the model generated for the input. </summary>
        public IReadOnlyList<CreateCompletionResponseChoice> Choices { get; }
        /// <summary> Gets the usage. </summary>
        public CompletionUsage Usage { get; }
    }
}
