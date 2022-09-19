// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace GeneratedModels
{
    // Data plane generated client. CADL project to test various types of models.
    /// <summary> CADL project to test various types of models. </summary>
    public partial class CustomizationsInCadlClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of CustomizationsInCadlClient. </summary>
        public CustomizationsInCadlClient() : this(new CustomizationsInCadlClientOptions())
        {
        }

        /// <summary> Initializes a new instance of CustomizationsInCadlClient. </summary>
        /// <param name="options"> The options for configuring the client. </param>
        public CustomizationsInCadlClient(CustomizationsInCadlClientOptions options)
        {
            options ??= new CustomizationsInCadlClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _apiVersion = options.Version;
        }

        /// <summary> RoundTrip operation to make RootModel round-trip. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call RoundTripAsync and parse the result.
        /// <code><![CDATA[
        /// var client = new CustomizationsInCadlClient();
        /// 
        /// var data = new {};
        /// 
        /// Response response = await client.RoundTripAsync(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call RoundTripAsync with all request content, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new CustomizationsInCadlClient();
        /// 
        /// var data = new {
        ///     propertyModelToMakeInternal = new {
        ///         requiredInt = 1234,
        ///     },
        ///     propertyModelToRename = new {
        ///         requiredInt = 1234,
        ///     },
        ///     propertyModelToChangeNamespace = new {
        ///         requiredInt = 1234,
        ///     },
        ///     propertyModelWithCustomizedProperties = new {
        ///         propertyToMakeInternal = 1234,
        ///         propertyToRename = 1234,
        ///         propertyToMakeFloat = 1234,
        ///         propertyToMakeInt = 123.45f,
        ///         propertyToMakeDuration = "<propertyToMakeDuration>",
        ///         propertyToMakeString = PT1H23M45S,
        ///         propertyToMakeJsonElement = "<propertyToMakeJsonElement>",
        ///         propertyToField = "<propertyToField>",
        ///     },
        ///     propertyEnumToRename = "1",
        ///     propertyEnumWithValueToRename = "1",
        ///     propertyEnumToBeMadeExtensible = "1",
        /// };
        /// 
        /// Response response = await client.RoundTripAsync(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("propertyModelToMakeInternal").GetProperty("requiredInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("requiredInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelToChangeNamespace").GetProperty("requiredInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInternal").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToRename").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeFloat").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeDuration").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeString").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeJsonElement").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToField").ToString());
        /// Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
        /// Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
        /// Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RootModel</c>:
        /// <code>{
        ///   propertyModelToMakeInternal: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToRename: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToChangeNamespace: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelWithCustomizedProperties: {
        ///     propertyToMakeInternal: number, # Required.
        ///     propertyToRename: number, # Required.
        ///     propertyToMakeFloat: number, # Required.
        ///     propertyToMakeInt: number, # Required.
        ///     propertyToMakeDuration: string, # Required.
        ///     propertyToMakeString: string (duration ISO 8601 Format), # Required.
        ///     propertyToMakeJsonElement: string, # Required.
        ///     propertyToField: string, # Required.
        ///   }, # Optional.
        ///   propertyEnumToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumWithValueToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumToBeMadeExtensible: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RootModel</c>:
        /// <code>{
        ///   propertyModelToMakeInternal: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToRename: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToChangeNamespace: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelWithCustomizedProperties: {
        ///     propertyToMakeInternal: number, # Required.
        ///     propertyToRename: number, # Required.
        ///     propertyToMakeFloat: number, # Required.
        ///     propertyToMakeInt: number, # Required.
        ///     propertyToMakeDuration: string, # Required.
        ///     propertyToMakeString: string (duration ISO 8601 Format), # Required.
        ///     propertyToMakeJsonElement: string, # Required.
        ///     propertyToField: string, # Required.
        ///   }, # Optional.
        ///   propertyEnumToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumWithValueToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumToBeMadeExtensible: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> RoundTripAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CustomizationsInCadlClient.RoundTrip");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> RoundTrip operation to make RootModel round-trip. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call RoundTrip and parse the result.
        /// <code><![CDATA[
        /// var client = new CustomizationsInCadlClient();
        /// 
        /// var data = new {};
        /// 
        /// Response response = client.RoundTrip(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call RoundTrip with all request content, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new CustomizationsInCadlClient();
        /// 
        /// var data = new {
        ///     propertyModelToMakeInternal = new {
        ///         requiredInt = 1234,
        ///     },
        ///     propertyModelToRename = new {
        ///         requiredInt = 1234,
        ///     },
        ///     propertyModelToChangeNamespace = new {
        ///         requiredInt = 1234,
        ///     },
        ///     propertyModelWithCustomizedProperties = new {
        ///         propertyToMakeInternal = 1234,
        ///         propertyToRename = 1234,
        ///         propertyToMakeFloat = 1234,
        ///         propertyToMakeInt = 123.45f,
        ///         propertyToMakeDuration = "<propertyToMakeDuration>",
        ///         propertyToMakeString = PT1H23M45S,
        ///         propertyToMakeJsonElement = "<propertyToMakeJsonElement>",
        ///         propertyToField = "<propertyToField>",
        ///     },
        ///     propertyEnumToRename = "1",
        ///     propertyEnumWithValueToRename = "1",
        ///     propertyEnumToBeMadeExtensible = "1",
        /// };
        /// 
        /// Response response = client.RoundTrip(RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("propertyModelToMakeInternal").GetProperty("requiredInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelToRename").GetProperty("requiredInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelToChangeNamespace").GetProperty("requiredInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInternal").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToRename").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeFloat").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeInt").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeDuration").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeString").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToMakeJsonElement").ToString());
        /// Console.WriteLine(result.GetProperty("propertyModelWithCustomizedProperties").GetProperty("propertyToField").ToString());
        /// Console.WriteLine(result.GetProperty("propertyEnumToRename").ToString());
        /// Console.WriteLine(result.GetProperty("propertyEnumWithValueToRename").ToString());
        /// Console.WriteLine(result.GetProperty("propertyEnumToBeMadeExtensible").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>RootModel</c>:
        /// <code>{
        ///   propertyModelToMakeInternal: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToRename: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToChangeNamespace: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelWithCustomizedProperties: {
        ///     propertyToMakeInternal: number, # Required.
        ///     propertyToRename: number, # Required.
        ///     propertyToMakeFloat: number, # Required.
        ///     propertyToMakeInt: number, # Required.
        ///     propertyToMakeDuration: string, # Required.
        ///     propertyToMakeString: string (duration ISO 8601 Format), # Required.
        ///     propertyToMakeJsonElement: string, # Required.
        ///     propertyToField: string, # Required.
        ///   }, # Optional.
        ///   propertyEnumToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumWithValueToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumToBeMadeExtensible: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        /// }
        /// </code>
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RootModel</c>:
        /// <code>{
        ///   propertyModelToMakeInternal: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToRename: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelToChangeNamespace: {
        ///     requiredInt: number, # Required.
        ///   }, # Optional.
        ///   propertyModelWithCustomizedProperties: {
        ///     propertyToMakeInternal: number, # Required.
        ///     propertyToRename: number, # Required.
        ///     propertyToMakeFloat: number, # Required.
        ///     propertyToMakeInt: number, # Required.
        ///     propertyToMakeDuration: string, # Required.
        ///     propertyToMakeString: string (duration ISO 8601 Format), # Required.
        ///     propertyToMakeJsonElement: string, # Required.
        ///     propertyToField: string, # Required.
        ///   }, # Optional.
        ///   propertyEnumToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumWithValueToRename: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        ///   propertyEnumToBeMadeExtensible: &quot;1&quot; | &quot;2&quot; | &quot;3&quot;, # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response RoundTrip(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CustomizationsInCadlClient.RoundTrip");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRoundTripRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateRoundTripRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            message.BufferResponse = false;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/inputToRoundTrip", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
