// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace lro_LowLevel
{
    // Data plane generated client.
    /// <summary> The LRORetrys service client. </summary>
    public partial class LRORetrysClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of LRORetrysClient for mocking. </summary>
        protected LRORetrysClient()
        {
        }

        /// <summary> Initializes a new instance of LRORetrysClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public LRORetrysClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new AutoRestLongRunningOperationTestServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LRORetrysClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public LRORetrysClient(AzureKeyCredential credential, Uri endpoint, AutoRestLongRunningOperationTestServiceClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AutoRestLongRunningOperationTestServiceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='Put201CreatingSucceeded200Async(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> Put201CreatingSucceeded200Async(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut201CreatingSucceeded200Request(content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "LRORetrysClient.Put201CreatingSucceeded200", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running put request, service returns a 500, then a 201 to the initial request, with an entity that contains ProvisioningState=’Creating’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='Put201CreatingSucceeded200(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> Put201CreatingSucceeded200(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.Put201CreatingSucceeded200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePut201CreatingSucceeded200Request(content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "LRORetrysClient.Put201CreatingSucceeded200", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='PutAsyncRelativeRetrySucceededAsync(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> PutAsyncRelativeRetrySucceededAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.PutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAsyncRelativeRetrySucceededRequest(content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "LRORetrysClient.PutAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running put request, service returns a 500, then a 200 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='PutAsyncRelativeRetrySucceeded(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> PutAsyncRelativeRetrySucceeded(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.PutAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAsyncRelativeRetrySucceededRequest(content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "LRORetrysClient.PutAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='DeleteProvisioning202Accepted200SucceededAsync(WaitUntil,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> DeleteProvisioning202Accepted200SucceededAsync(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteProvisioning202Accepted200SucceededRequest(context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "LRORetrysClient.DeleteProvisioning202Accepted200Succeeded", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running delete request, service returns a 500, then a  202 to the initial request, with an entity that contains ProvisioningState=’Accepted’.  Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='DeleteProvisioning202Accepted200Succeeded(WaitUntil,RequestContext)']/*" />
        public virtual Operation<BinaryData> DeleteProvisioning202Accepted200Succeeded(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.DeleteProvisioning202Accepted200Succeeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteProvisioning202Accepted200SucceededRequest(context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "LRORetrysClient.DeleteProvisioning202Accepted200Succeeded", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='Delete202Retry200Async(WaitUntil,RequestContext)']/*" />
        public virtual async Task<Operation> Delete202Retry200Async(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.Delete202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDelete202Retry200Request(context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "LRORetrysClient.Delete202Retry200", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running delete request, service returns a 500, then a 202 to the initial request. Polls return this value until the last poll returns a ‘200’ with ProvisioningState=’Succeeded’
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='Delete202Retry200(WaitUntil,RequestContext)']/*" />
        public virtual Operation Delete202Retry200(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.Delete202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDelete202Retry200Request(context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "LRORetrysClient.Delete202Retry200", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='DeleteAsyncRelativeRetrySucceededAsync(WaitUntil,RequestContext)']/*" />
        public virtual async Task<Operation> DeleteAsyncRelativeRetrySucceededAsync(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.DeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteAsyncRelativeRetrySucceededRequest(context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "LRORetrysClient.DeleteAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running delete request, service returns a 500, then a 202 to the initial request. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='DeleteAsyncRelativeRetrySucceeded(WaitUntil,RequestContext)']/*" />
        public virtual Operation DeleteAsyncRelativeRetrySucceeded(WaitUntil waitUntil, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.DeleteAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteAsyncRelativeRetrySucceededRequest(context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "LRORetrysClient.DeleteAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running post request, service returns a 500, then a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='Post202Retry200Async(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> Post202Retry200Async(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.Post202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost202Retry200Request(content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "LRORetrysClient.Post202Retry200", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running post request, service returns a 500, then a 202 to the initial request, with 'Location' and 'Retry-After' headers, Polls return a 200 with a response body after success
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='Post202Retry200(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation Post202Retry200(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.Post202Retry200");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePost202Retry200Request(content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "LRORetrysClient.Post202Retry200", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='PostAsyncRelativeRetrySucceededAsync(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation> PostAsyncRelativeRetrySucceededAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.PostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostAsyncRelativeRetrySucceededRequest(content, context);
                return await ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync(_pipeline, message, ClientDiagnostics, "LRORetrysClient.PostAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long running post request, service returns a 500, then a 202 to the initial request, with an entity that contains ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LRORetrysClient.xml" path="doc/members/member[@name='PostAsyncRelativeRetrySucceeded(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation PostAsyncRelativeRetrySucceeded(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("LRORetrysClient.PostAsyncRelativeRetrySucceeded");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostAsyncRelativeRetrySucceededRequest(content, context);
                return ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(_pipeline, message, ClientDiagnostics, "LRORetrysClient.PostAsyncRelativeRetrySucceeded", OperationFinalStateVia.Location, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreatePut201CreatingSucceeded200Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/retryerror/put/201/creating/succeeded/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePutAsyncRelativeRetrySucceededRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/retryerror/putasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDeleteProvisioning202Accepted200SucceededRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200202);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/retryerror/delete/provisioning/202/accepted/200/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDelete202Retry200Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/retryerror/delete/202/retry/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeleteAsyncRelativeRetrySucceededRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/retryerror/deleteasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePost202Retry200Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/retryerror/post/202/retry/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePostAsyncRelativeRetrySucceededRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/lro/retryerror/postasync/retry/succeeded", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200201;
        private static ResponseClassifier ResponseClassifier200201 => _responseClassifier200201 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 201 });
        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier200202;
        private static ResponseClassifier ResponseClassifier200202 => _responseClassifier200202 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 202 });
        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
    }
}
