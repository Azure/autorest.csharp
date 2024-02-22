// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The CreateChatCompletionResponseChoice. </summary>
    public partial class CreateChatCompletionResponseChoice
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

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionResponseChoice"/>. </summary>
        /// <param name="index"> The index of the choice in the list of choices. </param>
        /// <param name="message"></param>
        /// <param name="finishReason">
        /// The reason the model stopped generating tokens. This will be `stop` if the model hit a
        /// natural stop point or a provided stop sequence, `length` if the maximum number of tokens
        /// specified in the request was reached, `content_filter` if the content was omitted due to
        /// a flag from our content filters, or `function_call` if the model called a function.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        internal CreateChatCompletionResponseChoice(long index, ChatCompletionResponseMessage message, CreateChatCompletionResponseChoiceFinishReason finishReason)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Index = index;
            Message = message;
            FinishReason = finishReason;
        }

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionResponseChoice"/>. </summary>
        /// <param name="index"> The index of the choice in the list of choices. </param>
        /// <param name="message"></param>
        /// <param name="finishReason">
        /// The reason the model stopped generating tokens. This will be `stop` if the model hit a
        /// natural stop point or a provided stop sequence, `length` if the maximum number of tokens
        /// specified in the request was reached, `content_filter` if the content was omitted due to
        /// a flag from our content filters, or `function_call` if the model called a function.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateChatCompletionResponseChoice(long index, ChatCompletionResponseMessage message, CreateChatCompletionResponseChoiceFinishReason finishReason, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Index = index;
            Message = message;
            FinishReason = finishReason;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionResponseChoice"/> for deserialization. </summary>
        internal CreateChatCompletionResponseChoice()
        {
        }

        /// <summary> The index of the choice in the list of choices. </summary>
        public long Index { get; }
        /// <summary> Gets the message. </summary>
        public ChatCompletionResponseMessage Message { get; }
        /// <summary>
        /// The reason the model stopped generating tokens. This will be `stop` if the model hit a
        /// natural stop point or a provided stop sequence, `length` if the maximum number of tokens
        /// specified in the request was reached, `content_filter` if the content was omitted due to
        /// a flag from our content filters, or `function_call` if the model called a function.
        /// </summary>
        public CreateChatCompletionResponseChoiceFinishReason FinishReason { get; }
    }
}
