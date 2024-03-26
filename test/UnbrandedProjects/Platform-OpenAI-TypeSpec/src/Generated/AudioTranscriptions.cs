// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Models;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary> The AudioTranscriptions sub-client. </summary>
    public partial class AudioTranscriptions
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of AudioTranscriptions for mocking. </summary>
        protected AudioTranscriptions()
        {
        }

        /// <summary> Initializes a new instance of AudioTranscriptions. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal AudioTranscriptions(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary> Transcribes audio into the input language. </summary>
        /// <param name="audio"> The <see cref="CreateTranscriptionRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="audio"/> is null. </exception>
        public virtual async Task<ClientResult<CreateTranscriptionResponse>> CreateAsync(CreateTranscriptionRequest audio, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(audio, nameof(audio));

            RequestOptions context = FromCancellationToken(cancellationToken);
            using BinaryContent content = audio.ToBinaryBody();
            ClientResult result = await CreateAsync(content, context).ConfigureAwait(false);
            return ClientResult.FromValue(CreateTranscriptionResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Transcribes audio into the input language. </summary>
        /// <param name="audio"> The <see cref="CreateTranscriptionRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="audio"/> is null. </exception>
        public virtual ClientResult<CreateTranscriptionResponse> Create(CreateTranscriptionRequest audio, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(audio, nameof(audio));

            RequestOptions context = FromCancellationToken(cancellationToken);
            using BinaryContent content = audio.ToBinaryBody();
            ClientResult result = Create(content, context);
            return ClientResult.FromValue(CreateTranscriptionResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Transcribes audio into the input language.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAsync(CreateTranscriptionRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> CreateAsync(BinaryContent content, RequestOptions context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateRequest(content, context);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Transcribes audio into the input language.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(CreateTranscriptionRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Create(BinaryContent content, RequestOptions context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateRequest(content, context);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, context));
        }

        internal PipelineMessage CreateCreateRequest(BinaryContent content, RequestOptions context)
        {
            var message = _pipeline.CreateMessage();
            if (context != null)
            {
                message.Apply(context);
            }
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/audio/transcriptions", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("content-type", "multipart/form-data");
            request.Content = content;
            return message;
        }

        private static RequestOptions DefaultRequestContext = new RequestOptions();
        internal static RequestOptions FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestOptions() { CancellationToken = cancellationToken };
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
    }
}
