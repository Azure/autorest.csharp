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
        public Task CustomHeaderPostAsyncSucceded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task CustomHeaderPostSucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task CustomHeaderPutAsyncSucceded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task CustomHeaderPutSucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODelete200() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LRODelete204() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

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
        public Task LROPut200InlineCompleteNoState() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededNoStateOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual(null, result.Value.ProvisioningState);

            operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededNoStateOperation(value);
            result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual(null, result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPut202Retry200() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutAsyncNoRetryCanceled() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutAsyncRetryFailed() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutAsyncRetrySucceeded() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetrySucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);

            operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPutAsyncRetrySucceededOperation(value);
            result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutCanceled() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutFailed() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task LROPutInlineComplete() => Test(async (host, pipeline) =>
        {
            var value = new Product();
            var operation = await new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededOperationAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);

            operation = new LROsOperations(ClientDiagnostics, pipeline, host).StartPut200SucceededOperation(value);
            result = operation.WaitForCompletion();
            Assert.AreEqual("100", result.Value.Id);
            Assert.AreEqual("foo", result.Value.Name);
            Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
        });

        [Test]
        public Task LROPutNoHeaderInRetry() => Test(async (host, pipeline) =>
        {
            ////TODO: NOT DONE
            var value = new Product();
            var result = await new LROsOperations(ClientDiagnostics, pipeline, host).PutNoHeaderInRetryAsync(value);
            //Assert.AreEqual("100", result.Value.Id);
            //Assert.AreEqual("foo", result.Value.Name);
            //Assert.AreEqual("Succeeded", result.Value.ProvisioningState);
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
