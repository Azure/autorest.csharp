// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Models.Property.Optional
{
    // Data plane generated client. Test optional and required properties
    /// <summary> Test optional and required properties. </summary>
    public partial class RequiredAndOptionalClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of RequiredAndOptionalClient. </summary>
        public RequiredAndOptionalClient() : this(new Uri("http://localhost:3000"), new ModelsPropertyOptionalClientOptions())
        {
        }

        /// <summary> Initializes a new instance of RequiredAndOptionalClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public RequiredAndOptionalClient(Uri endpoint, ModelsPropertyOptionalClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ModelsPropertyOptionalClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call GetAllAsync and parse the result.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// Response response = await client.GetAllAsync();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("optionalProperty").ToString());
        /// Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetAllAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.GetAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call GetAll and parse the result.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// Response response = client.GetAll();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("optionalProperty").ToString());
        /// Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response GetAll(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.GetAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that will return only the required properties. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call GetRequiredOnlyAsync and parse the result.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// Response response = await client.GetRequiredOnlyAsync();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("optionalProperty").ToString());
        /// Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetRequiredOnlyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.GetRequiredOnly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequiredOnlyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that will return only the required properties. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call GetRequiredOnly and parse the result.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// Response response = client.GetRequiredOnly();
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("optionalProperty").ToString());
        /// Console.WriteLine(result.GetProperty("requiredProperty").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response GetRequiredOnly(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.GetRequiredOnly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequiredOnlyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with all properties present. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call PutAllAsync with required request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = await client.PutAllAsync(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call PutAllAsync with all request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     optionalProperty = "<optionalProperty>",
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = await client.PutAllAsync(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> PutAllAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.PutAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAllRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with all properties present. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call PutAll with required request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = client.PutAll(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call PutAll with all request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     optionalProperty = "<optionalProperty>",
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = client.PutAll(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response PutAll(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.PutAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAllRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with only required properties. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call PutRequiredOnlyAsync with required request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = await client.PutRequiredOnlyAsync(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call PutRequiredOnlyAsync with all request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     optionalProperty = "<optionalProperty>",
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = await client.PutRequiredOnlyAsync(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> PutRequiredOnlyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.PutRequiredOnly");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequiredOnlyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with only required properties. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call PutRequiredOnly with required request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = client.PutRequiredOnly(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call PutRequiredOnly with all request content.
        /// <code><![CDATA[
        /// var client = new RequiredAndOptionalClient();
        /// 
        /// var data = new {
        ///     optionalProperty = "<optionalProperty>",
        ///     requiredProperty = 1234,
        /// };
        /// 
        /// Response response = client.PutRequiredOnly(RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RequiredAndOptionalProperty</c>:
        /// <code>{
        ///   optionalProperty: string, # Optional.
        ///   requiredProperty: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response PutRequiredOnly(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("RequiredAndOptionalClient.PutRequiredOnly");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequiredOnlyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetAllRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/requiredAndOptional/all", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetRequiredOnlyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/requiredAndOptional/requiredOnly", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePutAllRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/requiredAndOptional/all", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePutRequiredOnlyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/requiredAndOptional/requiredOnly", false);
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
