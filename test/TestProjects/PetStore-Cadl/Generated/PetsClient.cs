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

namespace CadlPetStore
{
    /// <summary> Manage your pets. You can delete or get the Pet from pet store. </summary>
    public partial class PetsClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PetsClient for mocking. </summary>
        protected PetsClient()
        {
        }

        /// <summary> Initializes a new instance of PetsClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public PetsClient(Uri endpoint, string apiVersion) : this(endpoint, apiVersion, new PetsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PetsClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public PetsClient(Uri endpoint, string apiVersion, PetsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            options ??= new PetsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> delete. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Delete a pet. </remarks>
        public virtual async Task<Response> DeleteValueAsync(int petId, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.DeleteValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await DeleteAsync(petId, context).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> delete. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Delete a pet. </remarks>
        public virtual Response DeleteValue(int petId, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.DeleteValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = Delete(petId, context);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> delete. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call DeleteAsync with required parameters.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = await client.DeleteAsync(1234);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks> Delete a pet. </remarks>
        public virtual async Task<Response> DeleteAsync(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(petId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> delete. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Delete with required parameters.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = client.Delete(1234);
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks> Delete a pet. </remarks>
        public virtual Response Delete(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(petId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Pet>> ReadValueAsync(int petId, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.ReadValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ReadAsync(petId, context).ConfigureAwait(false);
                return Response.FromValue(Pet.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Pet> ReadValue(int petId, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.ReadValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = Read(petId, context);
                return Response.FromValue(Pet.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call ReadAsync with required parameters and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = await client.ReadAsync(1234);
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// Console.WriteLine(result.GetProperty("tag").ToString());
        /// Console.WriteLine(result.GetProperty("age").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Pet</c>:
        /// <code>{
        ///   name: string, # Required.
        ///   tag: string, # Optional.
        ///   age: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> ReadAsync(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.Read");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReadRequest(petId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call Read with required parameters and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = client.Read(1234);
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// Console.WriteLine(result.GetProperty("tag").ToString());
        /// Console.WriteLine(result.GetProperty("age").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Pet</c>:
        /// <code>{
        ///   name: string, # Required.
        ///   tag: string, # Optional.
        ///   age: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Read(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.Read");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReadRequest(petId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="pet"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pet"/> is null. </exception>
        public virtual async Task<Response<Pet>> CreateAsync(Pet pet, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pet, nameof(pet));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateAsync(pet.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="pet"> The Pet to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pet"/> is null. </exception>
        public virtual Response<Pet> Create(Pet pet, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pet, nameof(pet));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Create(pet.ToRequestContent(), context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call CreateAsync with required request content, and how to parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// var data = new {
        ///     name = "<name>",
        ///     age = 1234,
        /// };
        /// 
        /// Response response = await client.CreateAsync(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// Console.WriteLine(result.GetProperty("age").ToString());
        /// ]]></code>
        /// This sample shows how to call CreateAsync with all request content, and how to parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// var data = new {
        ///     name = "<name>",
        ///     tag = "<tag>",
        ///     age = 1234,
        /// };
        /// 
        /// Response response = await client.CreateAsync(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// Console.WriteLine(result.GetProperty("tag").ToString());
        /// Console.WriteLine(result.GetProperty("age").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>Pet</c>:
        /// <code>{
        ///   name: string, # Required.
        ///   tag: string, # Optional.
        ///   age: number, # Required.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Pet</c>:
        /// <code>{
        ///   name: string, # Required.
        ///   tag: string, # Optional.
        ///   age: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> CreateAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PetsClient.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
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
        /// This sample shows how to call Create with required request content, and how to parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// var data = new {
        ///     name = "<name>",
        ///     age = 1234,
        /// };
        /// 
        /// Response response = client.Create(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// Console.WriteLine(result.GetProperty("age").ToString());
        /// ]]></code>
        /// This sample shows how to call Create with all request content, and how to parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new PetsClient(endpoint, "<apiVersion>");
        /// 
        /// var data = new {
        ///     name = "<name>",
        ///     tag = "<tag>",
        ///     age = 1234,
        /// };
        /// 
        /// Response response = client.Create(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("name").ToString());
        /// Console.WriteLine(result.GetProperty("tag").ToString());
        /// Console.WriteLine(result.GetProperty("age").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>Pet</c>:
        /// <code>{
        ///   name: string, # Required.
        ///   tag: string, # Optional.
        ///   age: number, # Required.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Pet</c>:
        /// <code>{
        ///   name: string, # Required.
        ///   tag: string, # Optional.
        ///   age: number, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Create(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("PetsClient.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDeleteRequest(int petId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/", false);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(petId, false);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateReadRequest(int petId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200304);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/", false);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(petId, false);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateCreateRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/", false);
            uri.AppendPath("/pets", false);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            request.Uri = uri;
            request.Content = content;
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (cancellationToken == CancellationToken.None)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier200304;
        private static ResponseClassifier ResponseClassifier200304 => _responseClassifier200304 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 304 });
    }
}
