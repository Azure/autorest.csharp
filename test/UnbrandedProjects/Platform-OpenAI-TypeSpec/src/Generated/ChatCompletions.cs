// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenAI.Models;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary> The ChatCompletions sub-client. </summary>
    public partial class ChatCompletions
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ChatCompletions for mocking. </summary>
        protected ChatCompletions()
        {
        }

        /// <summary> Initializes a new instance of ChatCompletions. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal ChatCompletions(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary> Create. </summary>
        /// <param name="model">
        /// ID of the model to use. See the [model endpoint compatibility](/docs/models/model-endpoint-compatibility)
        /// table for details on which models work with the Chat API.
        /// </param>
        /// <param name="messages">
        /// A list of messages comprising the conversation so far.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_format_inputs_to_ChatGPT_models.ipynb).
        /// </param>
        /// <param name="functions"> A list of functions the model may generate JSON inputs for. </param>
        /// <param name="functionCall">
        /// Controls how the model responds to function calls. `none` means the model does not call a
        /// function, and responds to the end-user. `auto` means the model can pick between an end-user or
        /// calling a function.  Specifying a particular function via `{\"name":\ \"my_function\"}` forces the
        /// model to call that function. `none` is the default when no functions are present. `auto` is the
        /// default if functions are present.
        /// </param>
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
        /// <exception cref="ArgumentNullException"> <paramref name="messages"/> is null. </exception>
        public virtual async Task<ClientResult<CreateChatCompletionResponse>> CreateAsync(CreateChatCompletionRequestModel model, IEnumerable<ChatCompletionRequestMessage> messages, IEnumerable<ChatCompletionFunctions> functions = null, BinaryData functionCall = null, double? temperature = null, double? topP = null, long? n = null, long? maxTokens = null, BinaryData stop = null, double? presencePenalty = null, double? frequencyPenalty = null, IDictionary<string, long> logitBias = null, string user = null, bool? stream = null)
        {
            Argument.AssertNotNull(messages, nameof(messages));

            CreateChatCompletionRequest createChatCompletionRequest = new CreateChatCompletionRequest(
                model,
                messages.ToList(),
                functions?.ToList() as IList<ChatCompletionFunctions> ?? new ChangeTrackingList<ChatCompletionFunctions>(),
                functionCall,
                temperature,
                topP,
                n,
                maxTokens,
                stop,
                presencePenalty,
                frequencyPenalty,
                logitBias ?? new ChangeTrackingDictionary<string, long>(),
                user,
                stream,
                null);
            ClientResult result = await CreateAsync(createChatCompletionRequest.ToBinaryContent(), null).ConfigureAwait(false);
            return ClientResult.FromValue(CreateChatCompletionResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Create. </summary>
        /// <param name="model">
        /// ID of the model to use. See the [model endpoint compatibility](/docs/models/model-endpoint-compatibility)
        /// table for details on which models work with the Chat API.
        /// </param>
        /// <param name="messages">
        /// A list of messages comprising the conversation so far.
        /// [Example Python code](https://github.com/openai/openai-cookbook/blob/main/examples/How_to_format_inputs_to_ChatGPT_models.ipynb).
        /// </param>
        /// <param name="functions"> A list of functions the model may generate JSON inputs for. </param>
        /// <param name="functionCall">
        /// Controls how the model responds to function calls. `none` means the model does not call a
        /// function, and responds to the end-user. `auto` means the model can pick between an end-user or
        /// calling a function.  Specifying a particular function via `{\"name":\ \"my_function\"}` forces the
        /// model to call that function. `none` is the default when no functions are present. `auto` is the
        /// default if functions are present.
        /// </param>
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
        /// <exception cref="ArgumentNullException"> <paramref name="messages"/> is null. </exception>
        public virtual ClientResult<CreateChatCompletionResponse> Create(CreateChatCompletionRequestModel model, IEnumerable<ChatCompletionRequestMessage> messages, IEnumerable<ChatCompletionFunctions> functions = null, BinaryData functionCall = null, double? temperature = null, double? topP = null, long? n = null, long? maxTokens = null, BinaryData stop = null, double? presencePenalty = null, double? frequencyPenalty = null, IDictionary<string, long> logitBias = null, string user = null, bool? stream = null)
        {
            Argument.AssertNotNull(messages, nameof(messages));

            CreateChatCompletionRequest createChatCompletionRequest = new CreateChatCompletionRequest(
                model,
                messages.ToList(),
                functions?.ToList() as IList<ChatCompletionFunctions> ?? new ChangeTrackingList<ChatCompletionFunctions>(),
                functionCall,
                temperature,
                topP,
                n,
                maxTokens,
                stop,
                presencePenalty,
                frequencyPenalty,
                logitBias ?? new ChangeTrackingDictionary<string, long>(),
                user,
                stream,
                null);
            ClientResult result = Create(createChatCompletionRequest.ToBinaryContent(), null);
            return ClientResult.FromValue(CreateChatCompletionResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Create.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAsync(CreateChatCompletionRequestModel,IEnumerable{ChatCompletionRequestMessage},IEnumerable{ChatCompletionFunctions},BinaryData,double?,double?,long?,long?,BinaryData,double?,double?,IDictionary{string,long},string,bool?)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> CreateAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateRequest(content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Create.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(CreateChatCompletionRequestModel,IEnumerable{ChatCompletionRequestMessage},IEnumerable{ChatCompletionFunctions},BinaryData,double?,double?,long?,long?,BinaryData,double?,double?,IDictionary{string,long},string,bool?)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Create(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateRequest(content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateCreateRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/chat/completions", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
    }
}
