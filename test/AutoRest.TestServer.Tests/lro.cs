// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using lro;
using lro.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class LroTest: TestServerTestBase
    {
        public LroTest(TestServerVersion version) : base(version, "lros") { }

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPostAsyncSucceded() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetrySucceededOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPostAsyncSucceded_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetrySucceededOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPostSucceeded() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPost202Retry200OperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPostSucceeded_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPost202Retry200Operation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPutAsyncSucceded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetrySucceededOperationAsync(value);
            var result =  await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPutAsyncSucceded_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetrySucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPutSucceeded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingSucceeded200OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Needs to send x-ms-client-request-id: https://github.com/Azure/autorest.csharp/issues/446")]
        public Task CustomHeaderPutSucceeded_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsCustomHeaderOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingSucceeded200Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LRODelete200() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDelete202Retry200OperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LRODelete200_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDelete202Retry200Operation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LRODelete204() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDelete202NoRetry204OperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LRODelete204_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDelete202NoRetry204Operation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LRODeleteAsyncNoHeaderInRetry() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncNoHeaderInRetryOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LRODeleteAsyncNoHeaderInRetry_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncNoHeaderInRetryOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncNoRetrySucceededOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncNoRetrySucceededOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRetrycanceledOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRetrycanceledOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRetryFailedOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRetryFailedOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRetrySucceededOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRetrySucceededOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRODeleteInlineComplete() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDelete204SucceededOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteInlineComplete_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDelete204SucceededOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteNoHeaderInRetryOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteNoHeaderInRetryOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRODeleteProvisioningCanceled() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202Deletingcanceled200OperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRODeleteProvisioningCanceled_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202Deletingcanceled200Operation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRODeleteProvisioningFailed() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202DeletingFailed200OperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRODeleteProvisioningFailed_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202DeletingFailed200Operation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202Accepted200SucceededOperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202Accepted200SucceededOperation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDelete202RetryInvalidHeaderOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDelete202RetryInvalidHeaderOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetryInvalidHeaderOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetryInvalidHeaderOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetryInvalidJsonPollingOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetryInvalidJsonPollingOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetryNoStatusOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetryNoStatusOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorDeleteNoLocation() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDelete204SucceededOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDeleteNoLocation_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDelete204SucceededOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPost202RetryInvalidHeaderOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPost202RetryInvalidHeaderOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetryInvalidHeaderOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetryInvalidHeaderOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetryInvalidJsonPollingOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetryInvalidJsonPollingOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetryNoPayloadOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetryNoPayloadOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorPostNoLocation() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPost202NoLocationOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorPostNoLocation_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPost202NoLocationOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROErrorPut200InvalidJson() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPut200InvalidJsonOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPut200InvalidJson_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPut200InvalidJsonOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutError201NoProvisioningStatePayloadOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutError201NoProvisioningStatePayloadOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryInvalidHeaderOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryInvalidHeaderOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryInvalidJsonPollingOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryInvalidJsonPollingOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryNoStatusOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryNoStatusOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryNoStatusPayloadOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetryNoStatusPayloadOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryDelete202Retry400() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDelete202NonRetry400OperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRONonRetryDelete202Retry400_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDelete202NonRetry400Operation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRONonRetryDelete400() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteNonRetry400OperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRONonRetryDelete400_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteNonRetry400Operation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetry400OperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetry400Operation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRONonRetryPost202Retry400() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPost202NonRetry400OperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRONonRetryPost202Retry400_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPost202NonRetry400Operation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRONonRetryPost400() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostNonRetry400OperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRONonRetryPost400_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostNonRetry400Operation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetry400OperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetry400Operation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRONonRetryPut201Creating400() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutNonRetry201Creating400OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryPut201Creating400_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutNonRetry201Creating400Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutNonRetry201Creating400InvalidJsonOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutNonRetry201Creating400InvalidJsonOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryPut400() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutNonRetry400OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryPut400_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutNonRetry400Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetry400OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROSADsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetry400Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPost200() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPost200WithPayloadOperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
        });

        [Test]
        public Task LROPost200_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPost200WithPayloadOperation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncNoRetrySucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncNoRetrySucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostAsyncRetryCanceled() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetrycanceledOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROPostAsyncRetryCanceled_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetrycanceledOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROPostAsyncRetryFailed() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetryFailedOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROPostAsyncRetryFailed_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetryFailedOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetrySucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRetrySucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPostDoubleHeadersFinalAzureHeaderGetOperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPostDoubleHeadersFinalAzureHeaderGetOperation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPostDoubleHeadersFinalAzureHeaderGetDefaultOperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPostDoubleHeadersFinalAzureHeaderGetDefaultOperation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet() => Test(async (host, pipeline) =>
        {
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPostDoubleHeadersFinalLocationGetOperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet_Sync() => Test((host, pipeline) =>
        {
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPostDoubleHeadersFinalLocationGetOperation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostSuccededNoBody() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPost202NoRetry204OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostSuccededNoBody_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPost202NoRetry204Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPostSuccededWithBody() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPost202Retry200OperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROPostSuccededWithBody_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPost202Retry200Operation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LROPut200InlineCompleteNoState() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededNoStateOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual(null, result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPut200InlineCompleteNoState_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededNoStateOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual(null, result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPut202Retry200() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut202Retry200OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual(null, result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPut202Retry200_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut202Retry200Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual(null, result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNoHeaderInRetryOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNoHeaderInRetryOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNoRetrycanceledOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Canceled", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            host = "http://localhost:3000";
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNoRetrycanceledOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Canceled", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNoRetrySucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNoRetrySucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncRetryFailed() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetryFailedOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Failed", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncRetryFailed_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetryFailedOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Failed", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetrySucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetrySucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutCanceled() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200Acceptedcanceled200OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Canceled", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutCanceled_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200Acceptedcanceled200Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Canceled", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LROPutFailed() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingFailed200OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Failed", result.Value.ProvisioningState);
        });

        [Test]
        [Ignore("Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413")]
        public Task LROPutFailed_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingFailed200Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Failed", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutInlineComplete() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutInlineComplete_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutNoHeaderInRetry() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutNoHeaderInRetryOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutNoHeaderInRetry_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutNoHeaderInRetryOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry() => Test(async (host, pipeline) =>
        {
            var value = new Sku();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNonResourceOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry_Sync() => Test((host, pipeline) =>
        {
            var value = new Sku();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncNonResourceOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
        });

        [Test]
        public Task LROPutNonResourceInRetry() => Test(async (host, pipeline) =>
        {
            var value = new Sku();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutNonResourceOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
        });

        [Test]
        public Task LROPutNonResourceInRetry_Sync() => Test((host, pipeline) =>
        {
            var value = new Sku();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutNonResourceOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry() => Test(async (host, pipeline) =>
        {
            var value = new SubProduct();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncSubResourceOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry_Sync() => Test((host, pipeline) =>
        {
            var value = new SubProduct();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncSubResourceOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutSubResourceInRetry() => Test(async (host, pipeline) =>
        {
            var value = new SubProduct();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutSubResourceOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutSubResourceInRetry_Sync() => Test((host, pipeline) =>
        {
            var value = new SubProduct();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutSubResourceOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutSucceededNoBody() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200UpdatingSucceeded204OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutSucceededNoBody_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200UpdatingSucceeded204Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutSucceededWithBody() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingSucceeded200OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutSucceededWithBody_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingSucceeded200Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded() => Test(async (host, pipeline) =>
        {
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202Accepted200SucceededOperationAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded_Sync() => Test((host, pipeline) =>
        {
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartDeleteProvisioning202Accepted200SucceededOperation();
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartDelete202Retry200OperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartDelete202Retry200Operation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded() => TestStatus(async (host, pipeline) =>
        {
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetrySucceededOperationAsync();
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded_Sync() => TestStatus((host, pipeline) =>
        {
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartDeleteAsyncRelativeRetrySucceededOperation();
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPost202Retry200OperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPost202Retry200Operation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded() => TestStatus(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetrySucceededOperationAsync(value);
            return await operation.WaitForCompletionAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded_Sync() => TestStatus((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPostAsyncRelativeRetrySucceededOperation(value);
            return operation.WaitForCompletion();
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetrySucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetrySucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetrySucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRelativeRetrySucceededOperation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryPutSucceededWithBody() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingSucceeded200OperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LRORetryPutSucceededWithBody_Sync() => Test((host, pipeline) =>
        {
            var value = new Product();
            var operation = new LRORetrysOperations(ClientDiagnostics, pipeline, host).StartPut201CreatingSucceeded200Operation(value);
            var result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });
    }
}
