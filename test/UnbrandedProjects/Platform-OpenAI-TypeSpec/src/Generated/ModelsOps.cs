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
    /// <summary> The ModelsOps sub-client. </summary>
    public partial class ModelsOps
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ModelsOps for mocking. </summary>
        protected ModelsOps()
        {
        }

        /// <summary> Initializes a new instance of ModelsOps. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal ModelsOps(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the
        /// owner and availability.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ClientResult<ListModelsResponse>> GetModelsAsync(CancellationToken cancellationToken = default)
        {
            RequestOptions context = FromCancellationToken(cancellationToken);
            ClientResult result = await GetModelsAsync(context).ConfigureAwait(false);
            return ClientResult.FromValue(ListModelsResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the
        /// owner and availability.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ClientResult<ListModelsResponse> GetModels(CancellationToken cancellationToken = default)
        {
            RequestOptions context = FromCancellationToken(cancellationToken);
            ClientResult result = GetModels(context);
            return ClientResult.FromValue(ListModelsResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Lists the currently available models, and provides basic information about each one such as the
        /// owner and availability.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetModelsAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> GetModelsAsync(RequestOptions context)
        {
            using PipelineMessage message = CreateGetModelsRequest(context);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Lists the currently available models, and provides basic information about each one such as the
        /// owner and availability.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetModels(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult GetModels(RequestOptions context)
        {
            using PipelineMessage message = CreateGetModelsRequest(context);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, context));
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and
        /// permissioning.
        /// </summary>
        /// <param name="model"> The ID of the model to use for this request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult<Model>> RetrieveAsync(string model, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            RequestOptions context = FromCancellationToken(cancellationToken);
            ClientResult result = await RetrieveAsync(model, context).ConfigureAwait(false);
            return ClientResult.FromValue(Model.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and
        /// permissioning.
        /// </summary>
        /// <param name="model"> The ID of the model to use for this request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult<Model> Retrieve(string model, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            RequestOptions context = FromCancellationToken(cancellationToken);
            ClientResult result = Retrieve(model, context);
            return ClientResult.FromValue(Model.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Retrieves a model instance, providing basic information about the model such as the owner and
        /// permissioning.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RetrieveAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model"> The ID of the model to use for this request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> RetrieveAsync(string model, RequestOptions context)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            using PipelineMessage message = CreateRetrieveRequest(model, context);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Retrieves a model instance, providing basic information about the model such as the owner and
        /// permissioning.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Retrieve(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model"> The ID of the model to use for this request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Retrieve(string model, RequestOptions context)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            using PipelineMessage message = CreateRetrieveRequest(model, context);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, context));
        }

        /// <summary> Delete a fine-tuned model. You must have the Owner role in your organization to delete a model. </summary>
        /// <param name="model"> The model to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult<DeleteModelResponse>> DeleteAsync(string model, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            RequestOptions context = FromCancellationToken(cancellationToken);
            ClientResult result = await DeleteAsync(model, context).ConfigureAwait(false);
            return ClientResult.FromValue(DeleteModelResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Delete a fine-tuned model. You must have the Owner role in your organization to delete a model. </summary>
        /// <param name="model"> The model to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult<DeleteModelResponse> Delete(string model, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            RequestOptions context = FromCancellationToken(cancellationToken);
            ClientResult result = Delete(model, context);
            return ClientResult.FromValue(DeleteModelResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Delete a fine-tuned model. You must have the Owner role in your organization to delete a model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeleteAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model"> The model to delete. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> DeleteAsync(string model, RequestOptions context)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            using PipelineMessage message = CreateDeleteRequest(model, context);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Delete a fine-tuned model. You must have the Owner role in your organization to delete a model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Delete(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="model"> The model to delete. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Delete(string model, RequestOptions context)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));

            using PipelineMessage message = CreateDeleteRequest(model, context);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, context));
        }

        internal PipelineMessage CreateGetModelsRequest(RequestOptions context)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (context != null)
            {
                message.Apply(context);
            }
            return message;
        }

        internal PipelineMessage CreateRetrieveRequest(string model, RequestOptions context)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/", false);
            uri.AppendPath(model, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (context != null)
            {
                message.Apply(context);
            }
            return message;
        }

        internal PipelineMessage CreateDeleteRequest(string model, RequestOptions context)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "DELETE";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/", false);
            uri.AppendPath(model, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (context != null)
            {
                message.Apply(context);
            }
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
