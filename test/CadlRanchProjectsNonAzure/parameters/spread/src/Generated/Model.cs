// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scm.Parameters.Spread.Models;

namespace Scm.Parameters.Spread
{
    // Data plane generated sub-client.
    /// <summary> The Model sub-client. </summary>
    public partial class Model
    {
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Model for mocking. </summary>
        protected Model()
        {
        }

        /// <summary> Initializes a new instance of Model. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        internal Model(ClientPipeline pipeline, Uri endpoint)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Spread as request body. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<ClientResult> SpreadAsRequestBodyAsync(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            SpreadAsRequestBodyRequest1 spreadAsRequestBodyRequest1 = new SpreadAsRequestBodyRequest1(name, null);
            ClientResult result = await SpreadAsRequestBodyAsync(spreadAsRequestBodyRequest1.ToBinaryContent(), null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread as request body. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual ClientResult SpreadAsRequestBody(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            SpreadAsRequestBodyRequest1 spreadAsRequestBodyRequest1 = new SpreadAsRequestBodyRequest1(name, null);
            ClientResult result = SpreadAsRequestBody(spreadAsRequestBodyRequest1.ToBinaryContent(), null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread as request body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBodyAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadAsRequestBodyAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsRequestBodyRequest(content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread as request body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBody(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadAsRequestBody(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadAsRequestBodyRequest(content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Spread composite request only with body. </summary>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<ClientResult> SpreadCompositeRequestOnlyWithBodyAsync(BodyParameter body)
        {
            Argument.AssertNotNull(body, nameof(body));

            using BinaryContent content = body.ToBinaryContent();
            ClientResult result = await SpreadCompositeRequestOnlyWithBodyAsync(content, null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread composite request only with body. </summary>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual ClientResult SpreadCompositeRequestOnlyWithBody(BodyParameter body)
        {
            Argument.AssertNotNull(body, nameof(body));

            using BinaryContent content = body.ToBinaryContent();
            ClientResult result = SpreadCompositeRequestOnlyWithBody(content, null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread composite request only with body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestOnlyWithBodyAsync(BodyParameter)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadCompositeRequestOnlyWithBodyAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadCompositeRequestOnlyWithBodyRequest(content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread composite request only with body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestOnlyWithBody(BodyParameter)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadCompositeRequestOnlyWithBody(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadCompositeRequestOnlyWithBodyRequest(content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Spread composite request without body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="testHeader"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadCompositeRequestWithoutBodyAsync(string name, string testHeader, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));

            using PipelineMessage message = CreateSpreadCompositeRequestWithoutBodyRequest(name, testHeader, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Spread composite request without body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="testHeader"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadCompositeRequestWithoutBody(string name, string testHeader, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));

            using PipelineMessage message = CreateSpreadCompositeRequestWithoutBodyRequest(name, testHeader, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Spread composite request. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="body"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult> SpreadCompositeRequestAsync(string name, string testHeader, BodyParameter body)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(body, nameof(body));

            using BinaryContent content = body.ToBinaryContent();
            ClientResult result = await SpreadCompositeRequestAsync(name, testHeader, content, null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread composite request. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="body"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult SpreadCompositeRequest(string name, string testHeader, BodyParameter body)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(body, nameof(body));

            using BinaryContent content = body.ToBinaryContent();
            ClientResult result = SpreadCompositeRequest(name, testHeader, content, null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread composite request.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestAsync(string,string,BodyParameter)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadCompositeRequestAsync(string name, string testHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadCompositeRequestRequest(name, testHeader, content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread composite request.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequest(string,string,BodyParameter)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadCompositeRequest(string name, string testHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadCompositeRequestRequest(name, testHeader, content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Spread composite request mix. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="prop"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="prop"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ClientResult> SpreadCompositeRequestMixAsync(string name, string testHeader, string prop)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(prop, nameof(prop));

            SpreadCompositeRequestMixRequest spreadCompositeRequestMixRequest = new SpreadCompositeRequestMixRequest(prop, null);
            ClientResult result = await SpreadCompositeRequestMixAsync(name, testHeader, spreadCompositeRequestMixRequest.ToBinaryContent(), null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Spread composite request mix. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="prop"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="prop"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ClientResult SpreadCompositeRequestMix(string name, string testHeader, string prop)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(prop, nameof(prop));

            SpreadCompositeRequestMixRequest spreadCompositeRequestMixRequest = new SpreadCompositeRequestMixRequest(prop, null);
            ClientResult result = SpreadCompositeRequestMix(name, testHeader, spreadCompositeRequestMixRequest.ToBinaryContent(), null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Spread composite request mix.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestMixAsync(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> SpreadCompositeRequestMixAsync(string name, string testHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadCompositeRequestMixRequest(name, testHeader, content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Spread composite request mix.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestMix(string,string,string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult SpreadCompositeRequestMix(string name, string testHeader, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateSpreadCompositeRequestMixRequest(name, testHeader, content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateSpreadAsRequestBodyRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/request-body", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadCompositeRequestOnlyWithBodyRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request-only-with-body", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadCompositeRequestWithoutBodyRequest(string name, string testHeader, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request-without-body/", false);
            uri.AppendPath(name, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("test-header", testHeader);
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadCompositeRequestRequest(string name, string testHeader, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request/", false);
            uri.AppendPath(name, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("test-header", testHeader);
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSpreadCompositeRequestMixRequest(string name, string testHeader, BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request-mix/", false);
            uri.AppendPath(name, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("test-header", testHeader);
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier204;
        private static PipelineMessageClassifier PipelineMessageClassifier204 => _pipelineMessageClassifier204 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }
}
