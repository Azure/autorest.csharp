// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The ChatCompletionFunctions. </summary>
    public partial class ChatCompletionFunctions
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

        /// <summary> Initializes a new instance of <see cref="ChatCompletionFunctions"/>. </summary>
        /// <param name="name">
        /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and
        /// dashes, with a maximum length of 64.
        /// </param>
        /// <param name="parameters">
        /// The parameters the functions accepts, described as a JSON Schema object. See the
        /// [guide](/docs/guides/gpt/function-calling) for examples, and the
        /// [JSON Schema reference](https://json-schema.org/understanding-json-schema/) for documentation
        /// about the format.\n\nTo describe a function that accepts no parameters, provide the value
        /// `{\"type\": \"object\", \"properties\": {}}`.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public ChatCompletionFunctions(string name, ChatCompletionFunctionParameters parameters)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            Name = name;
            Parameters = parameters;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionFunctions"/>. </summary>
        /// <param name="name">
        /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and
        /// dashes, with a maximum length of 64.
        /// </param>
        /// <param name="description">
        /// A description of what the function does, used by the model to choose when and how to call the
        /// function.
        /// </param>
        /// <param name="parameters">
        /// The parameters the functions accepts, described as a JSON Schema object. See the
        /// [guide](/docs/guides/gpt/function-calling) for examples, and the
        /// [JSON Schema reference](https://json-schema.org/understanding-json-schema/) for documentation
        /// about the format.\n\nTo describe a function that accepts no parameters, provide the value
        /// `{\"type\": \"object\", \"properties\": {}}`.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatCompletionFunctions(string name, string description, ChatCompletionFunctionParameters parameters, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Description = description;
            Parameters = parameters;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionFunctions"/> for deserialization. </summary>
        internal ChatCompletionFunctions()
        {
        }

        /// <summary>
        /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and
        /// dashes, with a maximum length of 64.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// A description of what the function does, used by the model to choose when and how to call the
        /// function.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The parameters the functions accepts, described as a JSON Schema object. See the
        /// [guide](/docs/guides/gpt/function-calling) for examples, and the
        /// [JSON Schema reference](https://json-schema.org/understanding-json-schema/) for documentation
        /// about the format.\n\nTo describe a function that accepts no parameters, provide the value
        /// `{\"type\": \"object\", \"properties\": {}}`.
        /// </summary>
        public ChatCompletionFunctionParameters Parameters { get; }
    }
}
