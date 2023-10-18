// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.ClientModel.Internal;

namespace OpenAI.Models
{
    /// <summary> Represents a chat completion response returned by model, based on the provided input. </summary>
    public partial class CreateChatCompletionResponse
    {
        /// <summary> Initializes a new instance of CreateChatCompletionResponse. </summary>
        /// <param name="id"> A unique identifier for the chat completion. </param>
        /// <param name="object"> The object type, which is always `chat.completion`. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the chat completion was created. </param>
        /// <param name="model"> The model used for the chat completion. </param>
        /// <param name="choices"> A list of chat completion choices. Can be more than one if `n` is greater than 1. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="object"/>, <paramref name="model"/> or <paramref name="choices"/> is null. </exception>
        internal CreateChatCompletionResponse(string id, string @object, DateTimeOffset created, string model, IEnumerable<CreateChoice> choices)
        {
            ClientUtilities.AssertNotNull(id, nameof(id));
            ClientUtilities.AssertNotNull(@object, nameof(@object));
            ClientUtilities.AssertNotNull(model, nameof(model));
            ClientUtilities.AssertNotNull(choices, nameof(choices));

            Id = id;
            Object = @object;
            Created = created;
            Model = model;
            Choices = choices.ToList();
        }

        /// <summary> Initializes a new instance of CreateChatCompletionResponse. </summary>
        /// <param name="id"> A unique identifier for the chat completion. </param>
        /// <param name="object"> The object type, which is always `chat.completion`. </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the chat completion was created. </param>
        /// <param name="model"> The model used for the chat completion. </param>
        /// <param name="choices"> A list of chat completion choices. Can be more than one if `n` is greater than 1. </param>
        /// <param name="usage"></param>
        internal CreateChatCompletionResponse(string id, string @object, DateTimeOffset created, string model, IReadOnlyList<CreateChoice> choices, CompletionUsage usage)
        {
            Id = id;
            Object = @object;
            Created = created;
            Model = model;
            Choices = choices;
            Usage = usage;
        }

        /// <summary> A unique identifier for the chat completion. </summary>
        public string Id { get; }
        /// <summary> The object type, which is always `chat.completion`. </summary>
        public string Object { get; }
        /// <summary> The Unix timestamp (in seconds) of when the chat completion was created. </summary>
        public DateTimeOffset Created { get; }
        /// <summary> The model used for the chat completion. </summary>
        public string Model { get; }
        /// <summary> A list of chat completion choices. Can be more than one if `n` is greater than 1. </summary>
        public IReadOnlyList<CreateChoice> Choices { get; }
        /// <summary> Gets the usage. </summary>
        public CompletionUsage Usage { get; }
    }
}
