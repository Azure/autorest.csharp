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
        public Task CustomHeaderPostAsyncSucceded_Async() => TestStatus(async (host, pipeline) =>
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
        public Task CustomHeaderPostSucceeded_Async() => TestStatus(async (host, pipeline) =>
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
        public Task CustomHeaderPutAsyncSucceded_Async() => Test(async (host, pipeline) =>
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
        public Task CustomHeaderPutSucceeded_Async() => Test(async (host, pipeline) =>
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
        public Task LRODelete200_Async() => Test(async (host, pipeline) =>
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
        public Task LRODelete204_Async() => Test(async (host, pipeline) =>
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
        public Task LRODeleteAsyncNoHeaderInRetry() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteAsyncRetryCanceled() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteAsyncRetryFailed() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteInlineComplete() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteNoHeaderInRetry() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteProvisioningCanceled() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteProvisioningFailed() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorDeleteNoLocation() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPostNoLocation() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPut200InvalidJson() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryDelete202Retry400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryDelete400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryPost202Retry400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryPost400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryPostAsyncRetry400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryPut201Creating400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryPut400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRONonRetryPutAsyncRetry400() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPost200() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostAsyncRetryCanceled() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostAsyncRetryFailed() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostAsyncRetrySucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostSuccededNoBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPostSuccededWithBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPut200InlineCompleteNoState_Async() => Test(async (host, pipeline) =>
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
        public Task LROPut202Retry200_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutAsyncNoHeaderInRetry_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutAsyncNoRetryCanceled_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutAsyncNoRetrySucceeded_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutAsyncRetryFailed_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutAsyncRetrySucceeded_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutCanceled_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutFailed_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutInlineComplete_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutNoHeaderInRetry_Async() => Test(async (host, pipeline) =>
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
        public Task LROPutNonResourceAsyncInRetry() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutNonResourceInRetry() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutSubResourceAsyncInRetry() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutSubResourceInRetry() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutSucceededNoBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutSucceededWithBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRORetryPutSucceededWithBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });
    }
}
