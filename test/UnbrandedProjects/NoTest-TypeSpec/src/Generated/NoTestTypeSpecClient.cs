// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using NoTestTypeSpec.Models;

namespace NoTestTypeSpec
{
    // Data plane generated client.
    /// <summary> This is a sample typespec project. </summary>
    public partial class NoTestTypeSpecClient
    {
        private const string AuthorizationHeader = "my-api-key";
        private readonly ApiKeyCredential _keyCredential;
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of NoTestTypeSpecClient for mocking. </summary>
        protected NoTestTypeSpecClient()
        {
        }

        /// <summary> Initializes a new instance of NoTestTypeSpecClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public NoTestTypeSpecClient(Uri endpoint, ApiKeyCredential credential) : this(endpoint, credential, new NoTestTypeSpecClientOptions())
        {
        }

        /// <summary> Initializes a new instance of NoTestTypeSpecClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public NoTestTypeSpecClient(Uri endpoint, ApiKeyCredential credential, NoTestTypeSpecClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new NoTestTypeSpecClientOptions();

            _keyCredential = credential;
            _pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(_keyCredential, AuthorizationHeader) }, Array.Empty<PipelinePolicy>());
            _endpoint = endpoint;
        }

        /// <summary> Return hi. </summary>
        /// <param name="headParameter"> The <see cref="string"/> to use. </param>
        /// <param name="queryParameter"> The <see cref="string"/> to use. </param>
        /// <param name="optionalQuery"> The <see cref="string"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headParameter"/> or <paramref name="queryParameter"/> is null. </exception>
        public virtual async Task<ClientResult<Thing>> SayHiAsync(string headParameter, string queryParameter, string optionalQuery = null)
        {
            Argument.AssertNotNull(headParameter, nameof(headParameter));
            Argument.AssertNotNull(queryParameter, nameof(queryParameter));

            ClientResult result = await SayHiAsync(headParameter, queryParameter, optionalQuery, null).ConfigureAwait(false);
            return ClientResult.FromValue(Thing.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Return hi. </summary>
        /// <param name="headParameter"> The <see cref="string"/> to use. </param>
        /// <param name="queryParameter"> The <see cref="string"/> to use. </param>
        /// <param name="optionalQuery"> The <see cref="string"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headParameter"/> or <paramref name="queryParameter"/> is null. </exception>
        public virtual ClientResult<Thing> SayHi(string headParameter, string queryParameter, string optionalQuery = null)
        {
            Argument.AssertNotNull(headParameter, nameof(headParameter));
            Argument.AssertNotNull(queryParameter, nameof(queryParameter));

            ClientResult result = SayHi(headParameter, queryParameter, optionalQuery, null);
            return ClientResult.FromValue(Thing.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Return hi
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SayHiAsync(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="headParameter"> The <see cref="string"/> to use. </param>
        /// <param name="queryParameter"> The <see cref="string"/> to use. </param>
        /// <param name="optionalQuery"> The <see cref="string"/> to use. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headParameter"/> or <paramref name="queryParameter"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SayHiAsync(string headParameter, string queryParameter, string optionalQuery = null, RequestOptions options)
        {
            Argument.AssertNotNull(headParameter, nameof(headParameter));
            Argument.AssertNotNull(queryParameter, nameof(queryParameter));

            using PipelineMessage message = CreateSayHiRequest(headParameter, queryParameter, optionalQuery, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Return hi
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SayHi(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="headParameter"> The <see cref="string"/> to use. </param>
        /// <param name="queryParameter"> The <see cref="string"/> to use. </param>
        /// <param name="optionalQuery"> The <see cref="string"/> to use. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headParameter"/> or <paramref name="queryParameter"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SayHi(string headParameter, string queryParameter, string optionalQuery = null, RequestOptions options)
        {
            Argument.AssertNotNull(headParameter, nameof(headParameter));
            Argument.AssertNotNull(queryParameter, nameof(queryParameter));

            using PipelineMessage message = CreateSayHiRequest(headParameter, queryParameter, optionalQuery, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateSayHiRequest(string headParameter, string queryParameter, string optionalQuery, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/hello", false);
            uri.AppendQuery("queryParameter", queryParameter, true);
            if (optionalQuery != null)
            {
                uri.AppendQuery("optionalQuery", optionalQuery, true);
            }
            request.Uri = uri.ToUri();
            request.Headers.Set("head-parameter", headParameter);
            request.Headers.Set("Accept", "application/json");
            if (options != null)
            {
                message.Apply(options);
            }
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
    }
}
