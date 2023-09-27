// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace OpenAI.Models
{
    /// <summary> The ChatCompletionRequestMessage. </summary>
    public partial class ChatCompletionRequestMessage
    {
        /// <summary> Initializes a new instance of ChatCompletionRequestMessage. </summary>
        /// <param name="role"> The role of the messages author. One of `system`, `user`, `assistant`, or `function`. </param>
        /// <param name="content">
        /// The contents of the message. `content` is required for all messages, and may be null for
        /// assistant messages with function calls.
        /// </param>
        public ChatCompletionRequestMessage(MessageRole role, string content)
        {
            Role = role;
            Content = content;
        }

        /// <summary> Initializes a new instance of ChatCompletionRequestMessage. </summary>
        /// <param name="role"> The role of the messages author. One of `system`, `user`, `assistant`, or `function`. </param>
        /// <param name="content">
        /// The contents of the message. `content` is required for all messages, and may be null for
        /// assistant messages with function calls.
        /// </param>
        /// <param name="name">
        /// The name of the author of this message. `name` is required if role is `function`, and it
        /// should be the name of the function whose response is in the `content`. May contain a-z,
        /// A-Z, 0-9, and underscores, with a maximum length of 64 characters.
        /// </param>
        /// <param name="functionCall"> The name and arguments of a function that should be called, as generated by the model. </param>
        internal ChatCompletionRequestMessage(MessageRole role, string content, string name, FunctionCall functionCall)
        {
            Role = role;
            Content = content;
            Name = name;
            FunctionCall = functionCall;
        }

        /// <summary> The role of the messages author. One of `system`, `user`, `assistant`, or `function`. </summary>
        public MessageRole Role { get; }
        /// <summary>
        /// The contents of the message. `content` is required for all messages, and may be null for
        /// assistant messages with function calls.
        /// </summary>
        public string Content { get; }
        /// <summary>
        /// The name of the author of this message. `name` is required if role is `function`, and it
        /// should be the name of the function whose response is in the `content`. May contain a-z,
        /// A-Z, 0-9, and underscores, with a maximum length of 64 characters.
        /// </summary>
        public string Name { get; set; }
        /// <summary> The name and arguments of a function that should be called, as generated by the model. </summary>
        public FunctionCall FunctionCall { get; set; }
    }
}
