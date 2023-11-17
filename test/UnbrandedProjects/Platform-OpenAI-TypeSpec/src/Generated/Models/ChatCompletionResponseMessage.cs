// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The ChatCompletionResponseMessage. </summary>
    public partial class ChatCompletionResponseMessage
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

        /// <summary> Initializes a new instance of <see cref="ChatCompletionResponseMessage"/>. </summary>
        /// <param name="role"> The role of the author of this message. </param>
        /// <param name="content"> The contents of the message. </param>
        internal ChatCompletionResponseMessage(ChatCompletionResponseMessageRole role, string content)
        {
            Role = role;
            Content = content;
            _serializedAdditionalRawData = new OptionalDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionResponseMessage"/>. </summary>
        /// <param name="role"> The role of the author of this message. </param>
        /// <param name="content"> The contents of the message. </param>
        /// <param name="functionCall"> The name and arguments of a function that should be called, as generated by the model. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatCompletionResponseMessage(ChatCompletionResponseMessageRole role, string content, CreateChatCompletionResponseFunctionCall functionCall, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Role = role;
            Content = content;
            FunctionCall = functionCall;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionResponseMessage"/> for deserialization. </summary>
        internal ChatCompletionResponseMessage()
        {
        }

        /// <summary> The role of the author of this message. </summary>
        public ChatCompletionResponseMessageRole Role { get; }
        /// <summary> The contents of the message. </summary>
        public string Content { get; }
        /// <summary> The name and arguments of a function that should be called, as generated by the model. </summary>
        public CreateChatCompletionResponseFunctionCall FunctionCall { get; }
    }
}
