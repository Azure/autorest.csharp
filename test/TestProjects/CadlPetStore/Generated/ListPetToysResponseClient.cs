// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace CadlPetStore
{
    /// <summary> The ListPetToysResponse service client. </summary>
    public partial class ListPetToysResponseClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ListPetToysResponseClient for mocking. </summary>
        protected ListPetToysResponseClient()
        {
        }

        /// <summary> Initializes a new instance of ListPetToysResponseClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public ListPetToysResponseClient(Uri endpoint, string apiVersion) : this(endpoint, apiVersion, new PetstoreClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ListPetToysResponseClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="apiVersion"> The String to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public ListPetToysResponseClient(Uri endpoint, string apiVersion, PetstoreClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            options ??= new PetstoreClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="petId"> The String to use. </param>
        /// <param name="nameFilter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="petId"/> or <paramref name="nameFilter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call ListAsync with required parameters and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new ListPetToysResponseClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = await client.ListAsync("<petId>", "<nameFilter>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("nextLink").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>ToyListResults</c>:
        /// <code>{
        ///   items: {
        ///   }, # Required.
        ///   nextLink: string, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> ListAsync(string petId, string nameFilter, RequestContext context = null)
        {
            Argument.AssertNotNull(petId, nameof(petId));
            Argument.AssertNotNull(nameFilter, nameof(nameFilter));

            using var scope = ClientDiagnostics.CreateScope("ListPetToysResponseClient.List");
            scope.Start();
            try
            {
                using HttpMessage message = CreateListRequest(petId, nameFilter, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="petId"> The String to use. </param>
        /// <param name="nameFilter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="petId"/> or <paramref name="nameFilter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call List with required parameters and parse the result.
        /// <code><![CDATA[
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new ListPetToysResponseClient(endpoint, "<apiVersion>");
        /// 
        /// Response response = client.List("<petId>", "<nameFilter>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("nextLink").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>ToyListResults</c>:
        /// <code>{
        ///   items: {
        ///   }, # Required.
        ///   nextLink: string, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response List(string petId, string nameFilter, RequestContext context = null)
        {
            Argument.AssertNotNull(petId, nameof(petId));
            Argument.AssertNotNull(nameFilter, nameof(nameFilter));

            using var scope = ClientDiagnostics.CreateScope("ListPetToysResponseClient.List");
            scope.Start();
            try
            {
                using HttpMessage message = CreateListRequest(petId, nameFilter, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateListRequest(string petId, string nameFilter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/", false);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(petId, false);
            uri.AppendPath("/toys", false);
            uri.AppendQuery("apiVersion", _apiVersion, true);
            uri.AppendQuery("nameFilter", nameFilter, false);
            request.Uri = uri;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
