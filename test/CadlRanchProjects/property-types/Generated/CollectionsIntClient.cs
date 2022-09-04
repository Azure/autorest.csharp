// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Types;

namespace property_types
{
    /// <summary> The CollectionsInt service client. </summary>
    public partial class CollectionsIntClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of CollectionsIntClient. </summary>
        public CollectionsIntClient() : this(new Uri("http://localhost:3000"), new ModelsPropertyTypesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of CollectionsIntClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public CollectionsIntClient(Uri endpoint, ModelsPropertyTypesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ModelsPropertyTypesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CollectionsIntProperty>> GetValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsIntClient.GetValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await GetAsync(context).ConfigureAwait(false);
                return Response.FromValue(CollectionsIntProperty.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CollectionsIntProperty> GetValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsIntClient.GetValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = Get(context);
                return Response.FromValue(CollectionsIntProperty.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call GetAsync and parse the result.
        /// <code><![CDATA[
        /// var client = new CollectionsIntClient();
        /// 
        /// Response response = await client.GetAsync();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("property")[0].ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>CollectionsIntProperty</c>:
        /// <code>{
        ///   property: [number], # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsIntClient.Get");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call Get and parse the result.
        /// <code><![CDATA[
        /// var client = new CollectionsIntClient();
        /// 
        /// Response response = client.Get();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("property")[0].ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>CollectionsIntProperty</c>:
        /// <code>{
        ///   property: [number], # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Get(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsIntClient.Get");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The CollectionsIntProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Response> PutAsync(CollectionsIntProperty body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PutAsync(body.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="body"> The CollectionsIntProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Response Put(CollectionsIntProperty body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Put(body.ToRequestContent(), context);
            return response;
        }

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call PutAsync with required request content.
        /// <code><![CDATA[
        /// var client = new CollectionsIntClient();
        /// 
        /// var data = new {
        ///     property = new[] {
        ///         1234
        ///     },
        /// };
        /// 
        /// Response response = await client.PutAsync(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>CollectionsIntProperty</c>:
        /// <code>{
        ///   property: [number], # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> PutAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CollectionsIntClient.Put");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Put with required request content.
        /// <code><![CDATA[
        /// var client = new CollectionsIntClient();
        /// 
        /// var data = new {
        ///     property = new[] {
        ///         1234
        ///     },
        /// };
        /// 
        /// Response response = client.Put(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>CollectionsIntProperty</c>:
        /// <code>{
        ///   property: [number], # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Put(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CollectionsIntClient.Put");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/types/collections/int", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreatePutRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/types/collections/int", false);
            request.Uri = uri;
            request.Content = content;
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
