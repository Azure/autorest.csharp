// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Models;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary> The Embeddings sub-client. </summary>
    public partial class Embeddings
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly KeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly MessagePipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal TelemetrySource ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual MessagePipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Embeddings for mocking. </summary>
        protected Embeddings()
        {
        }

        /// <summary> Initializes a new instance of Embeddings. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal Embeddings(TelemetrySource clientDiagnostics, MessagePipeline pipeline, KeyCredential keyCredential, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary> Creates an embedding vector representing the input text. </summary>
        /// <param name="embedding"> The <see cref="CreateEmbeddingRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embedding"/> is null. </exception>
        public virtual async Task<Result<CreateEmbeddingResponse>> CreateAsync(CreateEmbeddingRequest embedding, CancellationToken cancellationToken = default)
        {
            if (embedding == null)
            {
                throw new ArgumentNullException(nameof(embedding));
            }

            RequestOptions context = FromCancellationToken(cancellationToken);
            using RequestBody content = embedding.ToRequestBody();
            Result result = await CreateAsync(content, context).ConfigureAwait(false);
            return Result.FromValue(CreateEmbeddingResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Creates an embedding vector representing the input text. </summary>
        /// <param name="embedding"> The <see cref="CreateEmbeddingRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embedding"/> is null. </exception>
        public virtual Result<CreateEmbeddingResponse> Create(CreateEmbeddingRequest embedding, CancellationToken cancellationToken = default)
        {
            if (embedding == null)
            {
                throw new ArgumentNullException(nameof(embedding));
            }

            RequestOptions context = FromCancellationToken(cancellationToken);
            using RequestBody content = embedding.ToRequestBody();
            Result result = Create(content, context);
            return Result.FromValue(CreateEmbeddingResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Creates an embedding vector representing the input text.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAsync(CreateEmbeddingRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Result> CreateAsync(RequestBody content, RequestOptions context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateSpan("Embeddings.Create");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCreateRequest(content, context);
                return Result.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates an embedding vector representing the input text.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(CreateEmbeddingRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Result Create(RequestBody content, RequestOptions context = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            using var scope = ClientDiagnostics.CreateSpan("Embeddings.Create");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCreateRequest(content, context);
                return Result.FromResponse(_pipeline.ProcessMessage(message, context));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal PipelineMessage CreateCreateRequest(RequestBody content, RequestOptions context)
        {
            var message = _pipeline.CreateMessage(context, ResponseErrorClassifier200);
            var request = message.Request;
            request.SetMethod("POST");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/embeddings", false);
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            request.SetHeaderValue("Content-Type", "application/json");
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

        private static ResponseErrorClassifier _responseErrorClassifier200;
        private static ResponseErrorClassifier ResponseErrorClassifier200 => _responseErrorClassifier200 ??= new StatusResponseClassifier(stackalloc ushort[] { 200 });
    }
}
