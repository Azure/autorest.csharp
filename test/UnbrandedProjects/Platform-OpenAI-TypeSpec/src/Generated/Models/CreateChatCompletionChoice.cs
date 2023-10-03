// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Experimental;

namespace OpenAI.Models
{
    /// <summary> The CreateChatCompletionChoice. </summary>
    public partial class CreateChatCompletionChoice
    {
        /// <summary> Initializes a new instance of CreateChatCompletionChoice. </summary>
        /// <param name="index"> The index of the choice in the list of choices. </param>
        /// <param name="message"></param>
        /// <param name="finishReason">
        /// The reason the model stopped generating tokens. This will be `stop` if the model hit a
        /// natural stop point or a provided stop sequence, `length` if the maximum number of tokens
        /// specified in the request was reached, `content_filter` if the content was omitted due to
        /// a flag from our content filters, or `function_call` if the model called a function.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        internal CreateChatCompletionChoice(long index, ChatCompletionResponseMessage message, CreateChatCompletionChoiceFinishReason finishReason)
        {
            ClientUtilities.AssertNotNull(message, nameof(message));

            Index = index;
            Message = message;
            FinishReason = finishReason;
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
        public CreateChatCompletionChoiceFinishReason FinishReason { get; }
    }
}
