// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace property_types
{
    // Data plane generated client. The Datetime service client.
    /// <summary> The Datetime service client. </summary>
    public partial class DatetimeClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of DatetimeClient. </summary>
        public DatetimeClient() : this(new Uri("http://localhost:3000"), new ModelsPropertyTypesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of DatetimeClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public DatetimeClient(Uri endpoint, ModelsPropertyTypesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ModelsPropertyTypesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call GetAsync and parse the result.
        /// <code><![CDATA[
        /// var client = new DatetimeClient();
        /// 
        /// Response response = await client.GetAsync();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("property").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>DatetimeProperty</c>:
        /// <code>{
        ///   property: string (date &amp; time), # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DatetimeClient.Get");
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
        /// var client = new DatetimeClient();
        /// 
        /// Response response = client.Get();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("property").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>DatetimeProperty</c>:
        /// <code>{
        ///   property: string (date &amp; time), # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Get(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("DatetimeClient.Get");
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

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call PutAsync with required request content.
        /// <code><![CDATA[
        /// var client = new DatetimeClient();
        /// 
        /// var data = new {
        ///     property = "2022-05-10T14:57:31.2311892-04:00",
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
        /// Schema for <c>DatetimeProperty</c>:
        /// <code>{
        ///   property: string (date &amp; time), # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> PutAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DatetimeClient.Put");
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
        /// var client = new DatetimeClient();
        /// 
        /// var data = new {
        ///     property = "2022-05-10T14:57:31.2311892-04:00",
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
        /// Schema for <c>DatetimeProperty</c>:
        /// <code>{
        ///   property: string (date &amp; time), # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Put(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DatetimeClient.Put");
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
            uri.AppendPath("/models/properties/types/datetime", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePutRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/types/datetime", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
