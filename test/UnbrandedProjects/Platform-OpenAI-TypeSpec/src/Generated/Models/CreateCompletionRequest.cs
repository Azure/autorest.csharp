// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;

namespace OpenAI.Models
{
    /// <summary> The CreateCompletionRequest. </summary>
    public partial class CreateCompletionRequest
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

        /// <summary> Initializes a new instance of <see cref="CreateCompletionRequest"/>. </summary>
        /// <param name="model">
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
        /// see all of your available models, or see our [Model overview](/docs/models/overview) for
        /// descriptions of them.
        /// </param>
        /// <param name="prompt">
        /// The prompt(s) to generate completions for, encoded as a string, array of strings, array of
        /// tokens, or array of token arrays.
        ///
        /// Note that &lt;|endoftext|&gt; is the document separator that the model sees during training, so if a
        /// prompt is not specified the model will generate as if from the beginning of a new document.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prompt"/> is null. </exception>
        public CreateCompletionRequest(CreateCompletionRequestModel model, BinaryData prompt)
        {
            ClientUtilities.AssertNotNull(prompt, nameof(prompt));

            Model = model;
            Prompt = prompt;
            LogitBias = new OptionalDictionary<string, long>();
        }

        /// <summary> Initializes a new instance of <see cref="CreateCompletionRequest"/>. </summary>
        /// <param name="model">
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
        /// see all of your available models, or see our [Model overview](/docs/models/overview) for
        /// descriptions of them.
        /// </param>
        /// <param name="prompt">
        /// The prompt(s) to generate completions for, encoded as a string, array of strings, array of
        /// tokens, or array of token arrays.
        ///
        /// Note that &lt;|endoftext|&gt; is the document separator that the model sees during training, so if a
        /// prompt is not specified the model will generate as if from the beginning of a new document.
        /// </param>
        /// <param name="suffix"> The suffix that comes after a completion of inserted text. </param>
        /// <param name="temperature">
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        ///
        /// We generally recommend altering this or `top_p` but not both.
        /// </param>
        /// <param name="topP">
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers
        /// the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising
        /// the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or `temperature` but not both.
        /// </param>
        /// <param name="n">
        /// How many completions to generate for each prompt.
        /// **Note:** Because this parameter generates many completions, it can quickly consume your token
        /// quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.
        /// </param>
        /// <param name="maxTokens">
        /// The maximum number of [tokens](/tokenizer) to generate in the completion.
        ///
        /// The token count of your prompt plus `max_tokens` cannot exceed the model's context length.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_count_tokens_with_tiktoken.ipynb)
        /// for counting tokens.
        /// </param>
        /// <param name="stop"> Up to 4 sequences where the API will stop generating further tokens. </param>
        /// <param name="presencePenalty">
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear
        /// in the text so far, increasing the model's likelihood to talk about new topics.
        ///
        /// [See more information about frequency and presence penalties.](/docs/guides/gpt/parameter-details)
        /// </param>
        /// <param name="frequencyPenalty">
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing
        /// frequency in the text so far, decreasing the model's likelihood to repeat the same line
        /// verbatim.
        ///
        /// [See more information about frequency and presence penalties.](/docs/guides/gpt/parameter-details)
        /// </param>
        /// <param name="logitBias">
        /// Modify the likelihood of specified tokens appearing in the completion.
        /// Accepts a json object that maps tokens (specified by their token ID in the tokenizer) to an
        /// associated bias value from -100 to 100. Mathematically, the bias is added to the logits
        /// generated by the model prior to sampling. The exact effect will vary per model, but values
        /// between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100
        /// should result in a ban or exclusive selection of the relevant token.
        /// </param>
        /// <param name="user">
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect
        /// abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).
        /// </param>
        /// <param name="stream">
        /// If set, partial message deltas will be sent, like in ChatGPT. Tokens will be sent as data-only
        /// [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format)
        /// as they become available, with the stream terminated by a `data: [DONE]` message.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_stream_completions.ipynb).
        /// </param>
        /// <param name="logprobs">
        /// Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens.
        /// For example, if `logprobs` is 5, the API will return a list of the 5 most likely tokens. The
        /// API will always return the `logprob` of the sampled token, so there may be up to `logprobs+1`
        /// elements in the response.
        ///
        /// The maximum value for `logprobs` is 5.
        /// </param>
        /// <param name="echo"> Echo back the prompt in addition to the completion. </param>
        /// <param name="bestOf">
        /// Generates `best_of` completions server-side and returns the "best" (the one with the highest
        /// log probability per token). Results cannot be streamed.
        ///
        /// When used with `n`, `best_of` controls the number of candidate completions and `n` specifies
        /// how many to return – `best_of` must be greater than `n`.
        ///
        /// **Note:** Because this parameter generates many completions, it can quickly consume your token
        /// quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateCompletionRequest(CreateCompletionRequestModel model, BinaryData prompt, string suffix, double? temperature, double? topP, long? n, long? maxTokens, BinaryData stop, double? presencePenalty, double? frequencyPenalty, IDictionary<string, long> logitBias, string user, bool? stream, long? logprobs, bool? echo, long? bestOf, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Model = model;
            Prompt = prompt;
            Suffix = suffix;
            Temperature = temperature;
            TopP = topP;
            N = n;
            MaxTokens = maxTokens;
            Stop = stop;
            PresencePenalty = presencePenalty;
            FrequencyPenalty = frequencyPenalty;
            LogitBias = logitBias;
            User = user;
            Stream = stream;
            Logprobs = logprobs;
            Echo = echo;
            BestOf = bestOf;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateCompletionRequest"/> for deserialization. </summary>
        internal CreateCompletionRequest()
        {
        }

        /// <summary>
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
        /// see all of your available models, or see our [Model overview](/docs/models/overview) for
        /// descriptions of them.
        /// </summary>
        public CreateCompletionRequestModel Model { get; }
        /// <summary>
        /// The prompt(s) to generate completions for, encoded as a string, array of strings, array of
        /// tokens, or array of token arrays.
        ///
        /// Note that &lt;|endoftext|&gt; is the document separator that the model sees during training, so if a
        /// prompt is not specified the model will generate as if from the beginning of a new document.
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
        public BinaryData Prompt { get; }
        /// <summary> The suffix that comes after a completion of inserted text. </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output
        /// more random, while lower values like 0.2 will make it more focused and deterministic.
        ///
        /// We generally recommend altering this or `top_p` but not both.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers
        /// the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising
        /// the top 10% probability mass are considered.
        ///
        /// We generally recommend altering this or `temperature` but not both.
        /// </summary>
        public double? TopP { get; set; }
        /// <summary>
        /// How many completions to generate for each prompt.
        /// **Note:** Because this parameter generates many completions, it can quickly consume your token
        /// quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.
        /// </summary>
        public long? N { get; set; }
        /// <summary>
        /// The maximum number of [tokens](/tokenizer) to generate in the completion.
        ///
        /// The token count of your prompt plus `max_tokens` cannot exceed the model's context length.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_count_tokens_with_tiktoken.ipynb)
        /// for counting tokens.
        /// </summary>
        public long? MaxTokens { get; set; }
        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens.
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
        public BinaryData Stop { get; set; }
        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear
        /// in the text so far, increasing the model's likelihood to talk about new topics.
        ///
        /// [See more information about frequency and presence penalties.](/docs/guides/gpt/parameter-details)
        /// </summary>
        public double? PresencePenalty { get; set; }
        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing
        /// frequency in the text so far, decreasing the model's likelihood to repeat the same line
        /// verbatim.
        ///
        /// [See more information about frequency and presence penalties.](/docs/guides/gpt/parameter-details)
        /// </summary>
        public double? FrequencyPenalty { get; set; }
        /// <summary>
        /// Modify the likelihood of specified tokens appearing in the completion.
        /// Accepts a json object that maps tokens (specified by their token ID in the tokenizer) to an
        /// associated bias value from -100 to 100. Mathematically, the bias is added to the logits
        /// generated by the model prior to sampling. The exact effect will vary per model, but values
        /// between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100
        /// should result in a ban or exclusive selection of the relevant token.
        /// </summary>
        public IDictionary<string, long> LogitBias { get; set; }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect
        /// abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// If set, partial message deltas will be sent, like in ChatGPT. Tokens will be sent as data-only
        /// [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format)
        /// as they become available, with the stream terminated by a `data: [DONE]` message.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_stream_completions.ipynb).
        /// </summary>
        public bool? Stream { get; set; }
        /// <summary>
        /// Include the log probabilities on the `logprobs` most likely tokens, as well the chosen tokens.
        /// For example, if `logprobs` is 5, the API will return a list of the 5 most likely tokens. The
        /// API will always return the `logprob` of the sampled token, so there may be up to `logprobs+1`
        /// elements in the response.
        ///
        /// The maximum value for `logprobs` is 5.
        /// </summary>
        public long? Logprobs { get; set; }
        /// <summary> Echo back the prompt in addition to the completion. </summary>
        public bool? Echo { get; set; }
        /// <summary>
        /// Generates `best_of` completions server-side and returns the "best" (the one with the highest
        /// log probability per token). Results cannot be streamed.
        ///
        /// When used with `n`, `best_of` controls the number of candidate completions and `n` specifies
        /// how many to return – `best_of` must be greater than `n`.
        ///
        /// **Note:** Because this parameter generates many completions, it can quickly consume your token
        /// quota. Use carefully and ensure that you have reasonable settings for `max_tokens` and `stop`.
        /// </summary>
        public long? BestOf { get; set; }
    }
}
