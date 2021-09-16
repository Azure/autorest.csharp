// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace lro_LowLevel
{
    /// <summary> The LRORetrys service client. </summary>
    public partial class LRORetrysClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }
        private HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly LRORetrysRestClient _restClient;
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;

        /// <summary> Initializes a new instance of LRORetrysClient for mocking. </summary>
        protected LRORetrysClient()
        {
        }

        /// <summary> Initializes a new instance of LRORetrysClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public LRORetrysClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestLongRunningOperationTestServiceClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestLongRunningOperationTestServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            var authPolicy = new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            _restClient = new LRORetrysRestClient(_clientDiagnostics, _pipeline, endpoint);
        }

        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> Put201CreatingSucceeded200Async(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePut201CreatingSucceeded200Request(content);
                Response response = await _restClient.Put201CreatingSucceeded200Async(content, options).ConfigureAwait(false);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.Put201CreatingSucceeded200");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> Put201CreatingSucceeded200(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePut201CreatingSucceeded200Request(content);
                Response response = _restClient.Put201CreatingSucceeded200(content, options);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.Put201CreatingSucceeded200");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> PutAsyncRelativeRetrySucceededAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.PutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePutAsyncRelativeRetrySucceededRequest(content);
                Response response = await _restClient.PutAsyncRelativeRetrySucceededAsync(content, options).ConfigureAwait(false);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.PutAsyncRelativeRetrySucceeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> PutAsyncRelativeRetrySucceeded(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.PutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePutAsyncRelativeRetrySucceededRequest(content);
                Response response = _restClient.PutAsyncRelativeRetrySucceeded(content, options);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.PutAsyncRelativeRetrySucceeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> DeleteProvisioning202Accepted200SucceededAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreateDeleteProvisioning202Accepted200SucceededRequest();
                Response response = await _restClient.DeleteProvisioning202Accepted200SucceededAsync(options).ConfigureAwait(false);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.DeleteProvisioning202Accepted200Succeeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> DeleteProvisioning202Accepted200Succeeded(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreateDeleteProvisioning202Accepted200SucceededRequest();
                Response response = _restClient.DeleteProvisioning202Accepted200Succeeded(options);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.DeleteProvisioning202Accepted200Succeeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> Delete202Retry200Async(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.Delete202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreateDelete202Retry200Request();
                Response response = await _restClient.Delete202Retry200Async(options).ConfigureAwait(false);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.Delete202Retry200");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> Delete202Retry200(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.Delete202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreateDelete202Retry200Request();
                Response response = _restClient.Delete202Retry200(options);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.Delete202Retry200");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> DeleteAsyncRelativeRetrySucceededAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.DeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreateDeleteAsyncRelativeRetrySucceededRequest();
                Response response = await _restClient.DeleteAsyncRelativeRetrySucceededAsync(options).ConfigureAwait(false);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.DeleteAsyncRelativeRetrySucceeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> DeleteAsyncRelativeRetrySucceeded(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.DeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreateDeleteAsyncRelativeRetrySucceededRequest();
                Response response = _restClient.DeleteAsyncRelativeRetrySucceeded(options);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.DeleteAsyncRelativeRetrySucceeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> Post202Retry200Async(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.Post202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePost202Retry200Request(content);
                Response response = await _restClient.Post202Retry200Async(content, options).ConfigureAwait(false);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.Post202Retry200");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> Post202Retry200(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.Post202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePost202Retry200Request(content);
                Response response = _restClient.Post202Retry200(content, options);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.Post202Retry200");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Operation<BinaryData>> PostAsyncRelativeRetrySucceededAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.PostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePostAsyncRelativeRetrySucceededRequest(content);
                Response response = await _restClient.PostAsyncRelativeRetrySucceededAsync(content, options).ConfigureAwait(false);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.PostAsyncRelativeRetrySucceeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   type: string,
        ///   tags: Dictionary&lt;string, string&gt;,
        ///   location: string,
        ///   name: string,
        ///   properties: {
        ///     provisioningState: string,
        ///     provisioningStateValues: &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;canceled&quot; | &quot;Accepted&quot; | &quot;Creating&quot; | &quot;Created&quot; | &quot;Updating&quot; | &quot;Updated&quot; | &quot;Deleting&quot; | &quot;Deleted&quot; | &quot;OK&quot;
        ///   }
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   code: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Operation<BinaryData> PostAsyncRelativeRetrySucceeded(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LRORetrysClient.PostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = _restClient.CreatePostAsyncRelativeRetrySucceededRequest(content);
                Response response = _restClient.PostAsyncRelativeRetrySucceeded(content, options);
                return new LowLevelBinaryDataOperation(_clientDiagnostics, _pipeline, message.Request, response, OperationFinalStateVia.Location, "LRORetrysClient.PostAsyncRelativeRetrySucceeded");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
