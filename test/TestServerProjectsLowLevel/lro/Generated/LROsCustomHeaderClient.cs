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
    /// <summary> The LROsCustomHeader service client. </summary>
    public partial class LROsCustomHeaderClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of LROsCustomHeaderClient for mocking. </summary>
        protected LROsCustomHeaderClient()
        {
        }

        /// <summary> Initializes a new instance of LROsCustomHeaderClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public LROsCustomHeaderClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestLongRunningOperationTestServiceClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            endpoint ??= new Uri("http://localhost:3000");
            options ??= new AutoRestLongRunningOperationTestServiceClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual async Task<Operation<BinaryData>> PutAsyncRetrySucceededAsync(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.PutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAsyncRetrySucceededRequest(content, context);
                return await LowLevelOperationHelpers.ProcessMessageAsync(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.PutAsyncRetrySucceeded", OperationFinalStateVia.Location, context, waitForCompletion).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual Operation<BinaryData> PutAsyncRetrySucceeded(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.PutAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAsyncRetrySucceededRequest(content, context);
                return LowLevelOperationHelpers.ProcessMessage(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.PutAsyncRetrySucceeded", OperationFinalStateVia.Location, context, waitForCompletion);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual async Task<Operation<BinaryData>> Put201CreatingSucceeded200Async(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut201CreatingSucceeded200Request(content, context);
                return await LowLevelOperationHelpers.ProcessMessageAsync(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.Put201CreatingSucceeded200", OperationFinalStateVia.Location, context, waitForCompletion).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running put request, service returns a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual Operation<BinaryData> Put201CreatingSucceeded200(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut201CreatingSucceeded200Request(content, context);
                return LowLevelOperationHelpers.ProcessMessage(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.Put201CreatingSucceeded200", OperationFinalStateVia.Location, context, waitForCompletion);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual async Task<Operation<BinaryData>> Post202Retry200Async(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.Post202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost202Retry200Request(content, context);
                return await LowLevelOperationHelpers.ProcessMessageAsync(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.Post202Retry200", OperationFinalStateVia.Location, context, waitForCompletion).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with &apos;Location&apos; and &apos;Retry-After&apos; headers, Polls return a 200 with a response body after success. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual Operation<BinaryData> Post202Retry200(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.Post202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost202Retry200Request(content, context);
                return LowLevelOperationHelpers.ProcessMessage(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.Post202Retry200", OperationFinalStateVia.Location, context, waitForCompletion);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual async Task<Operation<BinaryData>> PostAsyncRetrySucceededAsync(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.PostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostAsyncRetrySucceededRequest(content, context);
                return await LowLevelOperationHelpers.ProcessMessageAsync(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.PostAsyncRetrySucceeded", OperationFinalStateVia.Location, context, waitForCompletion).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> x-ms-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 is required message header for all requests. Long running post request, service returns a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
        /// <param name="waitForCompletion"> true if the method should wait to return until the long-running operation has completed on the service; false if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
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
        public virtual Operation<BinaryData> PostAsyncRetrySucceeded(bool waitForCompletion, RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("LROsCustomHeaderClient.PostAsyncRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostAsyncRetrySucceededRequest(content, context);
                return LowLevelOperationHelpers.ProcessMessage(_pipeline, message, _clientDiagnostics, "LROsCustomHeaderClient.PostAsyncRetrySucceeded", OperationFinalStateVia.Location, context, waitForCompletion);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreatePutAsyncRetrySucceededRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/customheader/putasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreatePut201CreatingSucceeded200Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/customheader/put/201/creating/succeeded/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200201.Instance;
            return message;
        }

        internal HttpMessage CreatePost202Retry200Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/customheader/post/202/retry/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier202.Instance;
            return message;
        }

        internal HttpMessage CreatePostAsyncRetrySucceededRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/customheader/postasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier202.Instance;
            return message;
        }

        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
        private sealed class ResponseClassifier200201 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200201();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    201 => false,
                    _ => true
                };
            }
        }
        private sealed class ResponseClassifier202 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier202();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    202 => false,
                    _ => true
                };
            }
        }
    }
}
