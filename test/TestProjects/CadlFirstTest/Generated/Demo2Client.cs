// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace CadlFirstTest
{
    /// <summary> The Demo2 service client. </summary>
    public partial class Demo2Client
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Demo2Client for mocking. </summary>
        protected Demo2Client()
        {
        }

        /// <summary> Initializes a new instance of Demo2Client. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public Demo2Client(Uri endpoint, string apiVersion) : this(endpoint, apiVersion, new DemoHelloworldClientOptions())
        {
        }

        /// <summary> Initializes a new instance of Demo2Client. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public Demo2Client(Uri endpoint, string apiVersion, DemoHelloworldClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            options ??= new DemoHelloworldClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call HelloAgainAsync with required request content and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new Demo2Client(endpoint, "<apiVersion>");
        /// 
        /// var data = new {
        ///     requiredString = "<requiredString>",
        ///     requiredInt = 1234,
        /// };
        /// 
        /// Response response = await client.HelloAgainAsync(RequestContent.Create(data));
        /// 
        /// Console.WriteLine(response.ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RoundTripModel</c>:
        /// <code>{
        ///   requiredString: string, # Required. Required string, illustrating a reference type property.
        ///   requiredInt: number, # Required. Required int, illustrating a value type property.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> HelloAgainAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(content, context);
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
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call HelloAgain with required request content and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new Demo2Client(endpoint, "<apiVersion>");
        /// 
        /// var data = new {
        ///     requiredString = "<requiredString>",
        ///     requiredInt = 1234,
        /// };
        /// 
        /// Response response = client.HelloAgain(RequestContent.Create(data));
        /// 
        /// Console.WriteLine(response.ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RoundTripModel</c>:
        /// <code>{
        ///   requiredString: string, # Required. Required string, illustrating a reference type property.
        ///   requiredInt: number, # Required. Required int, illustrating a value type property.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response HelloAgain(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
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
        /// This sample shows how to call HelloDemo2Async and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new Demo2Client(endpoint, "<apiVersion>");
        /// 
        /// Response response = await client.HelloDemo2Async();
        /// 
        /// Console.WriteLine(response.ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> HelloDemo2Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
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
        /// This sample shows how to call HelloDemo2 and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new Demo2Client(endpoint, "<apiVersion>");
        /// 
        /// Response response = client.HelloDemo2();
        /// 
        /// Console.WriteLine(response.ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Thing</c>:
        /// <code>{
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response HelloDemo2(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateHelloAgainRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/partOfUri", false);
            uri.AppendPath("/againHi", false);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            request.Uri = uri;
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateHelloDemo2Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/partOfUri", false);
            uri.AppendPath("/demoHi", false);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            request.Uri = uri;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
