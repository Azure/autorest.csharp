// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using lro_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class LroTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task CustomHeaderPostAsyncSucceded() => TestStatus(async (endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).PostAsyncRetrySucceededAsync(value);
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task CustomHeaderPostAsyncSucceded_Sync() => TestStatus((endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).PostAsyncRetrySucceeded(value);
            return WaitForCompletion(operation);
        });

        [Test]
        public Task CustomHeaderPostSucceeded() => TestStatus(async (endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).Post202Retry200Async(value);
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task CustomHeaderPostSucceeded_Sync() => TestStatus((endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).Post202Retry200(value);
            return WaitForCompletion(operation);
        });

        [Test]
        public Task CustomHeaderPutAsyncSucceded() => Test(async (endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).PutAsyncRetrySucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutAsyncSucceded_Sync() => Test((endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).PutAsyncRetrySucceeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutSucceeded() => Test(async (endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).Put201CreatingSucceeded200Async(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutSucceeded_Sync() => Test((endpoint) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).Put201CreatingSucceeded200(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODelete200() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete202Retry200Async();
            // Empty response body
            Assert.AreEqual(0, (await operation.WaitForCompletionAsync().ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LRODelete200_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).Delete202Retry200();
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation).Content.ToMemory().Length);
        });

        [Test]
        public Task LRODelete204() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete202NoRetry204Async();
            // Empty response body
            Assert.AreEqual(0, (await operation.WaitForCompletionAsync().ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LRODelete204_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).Delete202NoRetry204();
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation).Content.ToMemory().Length);
        });

        [Test]
        public Task LRODeleteAsyncNoHeaderInRetry() => TestStatus(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncNoHeaderInRetryAsync();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncNoHeaderInRetry_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncNoHeaderInRetry();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded() => TestStatus(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncNoRetrySucceededAsync();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncNoRetrySucceeded();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetrycanceledAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncRetrycanceled();
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetryFailedAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncRetryFailed();
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded() => TestStatus(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetrySucceededAsync();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncRetrySucceeded();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRODeleteInlineComplete() => TestStatus(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete204SucceededAsync();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteInlineComplete_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).Delete204Succeeded();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry() => TestStatus(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteNoHeaderInRetryAsync();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteNoHeaderInRetry();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRODeleteProvisioningCanceled() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202Deletingcanceled200Async();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Canceled", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningCanceled_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202Deletingcanceled200();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Canceled", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningFailed() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202DeletingFailed200Async();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Failed", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningFailed_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202DeletingFailed200();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Failed", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202Accepted200SucceededAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202Accepted200Succeeded();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader() => Test(async (endpoint) =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).Delete202RetryInvalidHeaderAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader_Sync() => Test((endpoint) =>
        {
            var operation = new LrosaDsClient(Key, endpoint).Delete202RetryInvalidHeader();
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader() => Test(async (endpoint) =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidHeaderAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader_Sync() => Test((endpoint) =>
        {
            var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidHeader();
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling() => Test(async (endpoint) =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidJsonPollingAsync();
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling_Sync() => Test((endpoint) =>
        {
            var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidJsonPolling();
            Assert.Throws(Is.InstanceOf<JsonException>(), () => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus() => Test(async (endpoint) =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryNoStatusAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus_Sync() => Test((endpoint) =>
        {
            var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryNoStatus();
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorDeleteNoLocation() => TestStatus(async (endpoint) =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).Delete204SucceededAsync();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDeleteNoLocation_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LrosaDsClient(Key, endpoint).Delete204Succeeded();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).Post202RetryInvalidHeaderAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).Post202RetryInvalidHeader(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidHeaderAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidHeader(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidJsonPollingAsync(value);
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidJsonPolling(value);
            Assert.Throws(Is.InstanceOf<JsonException>(), () => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryNoPayloadAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryNoPayload(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPostNoLocation() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).Post202NoLocationAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPostNoLocation_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).Post202NoLocation(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPut200InvalidJson() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).Put200InvalidJsonAsync(value);
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPut200InvalidJson_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).Put200InvalidJson(value);
            Assert.Throws(Is.InstanceOf<JsonException>(), () => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutError201NoProvisioningStatePayloadAsync(value);
            // Empty response body
            Assert.AreEqual(0, (await operation.WaitForCompletionAsync().ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutError201NoProvisioningStatePayload(value);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation).Content.ToMemory().Length);
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryInvalidHeaderAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryInvalidHeader(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryInvalidJsonPollingAsync(value);
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryInvalidJsonPolling(value);
            Assert.Throws(Is.InstanceOf<JsonException>(), () => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryNoStatusAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryNoStatus(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryNoStatusPayloadAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetryNoStatusPayload(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRONonRetryDelete202Retry400() => Test(async (endpoint) =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).Delete202NonRetry400Async();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRONonRetryDelete202Retry400_Sync() => Test((endpoint) =>
        {
            var operation = new LrosaDsClient(Key, endpoint).Delete202NonRetry400();
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRONonRetryDelete400() => Test((endpoint) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).DeleteNonRetry400Async());
        });

        [Test]
        public Task LRONonRetryDelete400_Sync() => Test((endpoint) =>
        {
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).DeleteNonRetry400());
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400() => Test(async (endpoint) =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetry400Async();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400_Sync() => Test((endpoint) =>
        {
            var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetry400();
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRONonRetryPost202Retry400() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).Post202NonRetry400Async(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRONonRetryPost202Retry400_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).Post202NonRetry400(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRONonRetryPost400() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).PostNonRetry400Async(value));
        });

        [Test]
        public Task LRONonRetryPost400_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).PostNonRetry400(value));
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetry400Async(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetry400(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRONonRetryPut201Creating400() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutNonRetry201Creating400Async(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRONonRetryPut201Creating400_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutNonRetry201Creating400(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutNonRetry201Creating400InvalidJsonAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutNonRetry201Creating400InvalidJson(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LRONonRetryPut400() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).PutNonRetry400Async(value));
        });

        [Test]
        public Task LRONonRetryPut400_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).PutNonRetry400(value));
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetry400Async(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutAsyncRelativeRetry400(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROPost200() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).Post200WithPayloadAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("1", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("product", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPost200_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).Post200WithPayload();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("1", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("product", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncNoRetrySucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAndGetList() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).Post202ListAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual(1, GetArrayLength(result.Value));
            Assert.AreEqual("100", GetResultArrayValue(result.Value, 0, "Id"));
            Assert.AreEqual("foo", GetResultArrayValue(result.Value, 0, "Name"));
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncNoRetrySucceeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAsyncRetryCanceled() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncRetrycanceledAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROPostAsyncRetryCanceled_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncRetrycanceled(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROPostAsyncRetryFailed() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncRetryFailedAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROPostAsyncRetryFailed_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncRetryFailed(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncRetrySucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncRetrySucceeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual(null, GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGet();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual(null, GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetDefaultAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetDefault();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet() => Test(async (endpoint) =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalLocationGetAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet_Sync() => Test((endpoint) =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalLocationGet();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostSuccededNoBody() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Post202NoRetry204Async(value);
            // Empty response body
            Assert.AreEqual(0, (await operation.WaitForCompletionAsync().ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LROPostSuccededNoBody_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Post202NoRetry204(value);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation).Content.ToMemory().Length);
        });

        [Test]
        public Task LROPostSuccededWithBody() => TestStatus(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Post202Retry200Async(value);
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LROPostSuccededWithBody_Sync() => TestStatus((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Post202Retry200(value);
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LROPut200InlineCompleteNoState() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200SucceededNoStateAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut200InlineCompleteNoState_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200SucceededNoState(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut202Retry200() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put202Retry200Async(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut202Retry200_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put202Retry200(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNoHeaderInRetryAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNoHeaderInRetry(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNoRetrycanceledAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNoRetrycanceled(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNoRetrySucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNoRetrySucceeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncRetryFailed() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncRetryFailedAsync(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROPutAsyncRetryFailed_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncRetryFailed(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncRetrySucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncRetrySucceeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutCanceled() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200Acceptedcanceled200Async(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROPutCanceled_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200Acceptedcanceled200(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROPutFailed() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put201CreatingFailed200Async(value);
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync().ConfigureAwait(false));
        });

        [Test]
        public Task LROPutFailed_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put201CreatingFailed200(value);
            Assert.Throws<RequestFailedException>(() => WaitForCompletion(operation));
        });

        [Test]
        public Task LROPutInlineComplete() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200SucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200Succeeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete201() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put201SucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete201_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put201Succeeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNoHeaderInRetry() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutNoHeaderInRetryAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNoHeaderInRetry_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutNoHeaderInRetry(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNonResourceAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNonResource(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceInRetry() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutNonResourceAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceInRetry_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutNonResource(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncSubResourceAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncSubResource(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceInRetry() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutSubResourceAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceInRetry_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutSubResource(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededNoBody() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200UpdatingSucceeded204Async(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededNoBody_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200UpdatingSucceeded204(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededWithBody() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put201CreatingSucceeded200Async(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededWithBody_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put201CreatingSucceeded200(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded() => Test(async (endpoint) =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).DeleteProvisioning202Accepted200SucceededAsync();
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded_Sync() => Test((endpoint) =>
        {
            var operation = new LRORetrysClient(Key, endpoint).DeleteProvisioning202Accepted200Succeeded();
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded() => TestStatus(async (endpoint) =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).Delete202Retry200Async();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LRORetrysClient(Key, endpoint).Delete202Retry200();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded() => TestStatus(async (endpoint) =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).DeleteAsyncRelativeRetrySucceededAsync();
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded_Sync() => TestStatus((endpoint) =>
        {
            var operation = new LRORetrysClient(Key, endpoint).DeleteAsyncRelativeRetrySucceeded();
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded() => TestStatus(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).Post202Retry200Async(value);
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded_Sync() => TestStatus((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).Post202Retry200(value);
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded() => TestStatus(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PostAsyncRelativeRetrySucceededAsync(value);
            return await operation.WaitForCompletionResponseAsync().ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded_Sync() => TestStatus((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PostAsyncRelativeRetrySucceeded(value);
            return WaitForCompletion(operation);
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceededAsync(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceeded(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryPutSucceededWithBody() => Test(async (endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).Put201CreatingSucceeded200Async(value);
            var result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryPutSucceededWithBody_Sync() => Test((endpoint) =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).Put201CreatingSucceeded200(value);
            var result = WaitForCompletionWithValue(operation);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        private static Response WaitForCompletion(Operation operation, CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(operation, OperationHelpers.DefaultPollingInterval, cancellationToken);
        }

        private static Response WaitForCompletion(Operation operation, TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return operation.GetRawResponse();
                }

                Thread.Sleep(pollingInterval);
            }
        }

        private static Response<TResult> WaitForCompletionWithValue<TResult>(Operation<TResult> operation, CancellationToken cancellationToken = default) where TResult : notnull
        {
            return WaitForCompletionWithValue(operation, OperationHelpers.DefaultPollingInterval, cancellationToken);
        }

        private static Response<TResult> WaitForCompletionWithValue<TResult>(Operation<TResult> operation, TimeSpan pollingInterval, CancellationToken cancellationToken = default) where TResult : notnull
        {
            while (true)
            {
                operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return Response.FromValue(operation.Value, operation.GetRawResponse());
                }

                Thread.Sleep(pollingInterval);
            }
        }

        private static int GetArrayLength(BinaryData result)
        {
            using var doc = JsonDocument.Parse(result);
            int length = 0;
            foreach (var _ in doc.RootElement.EnumerateArray())
            {
                length++;
            }
            return length;
        }

        private static string GetResultArrayValue(BinaryData result, int index, string valueName)
        {
            using var doc = JsonDocument.Parse(result);
            var enumerator = doc.RootElement.EnumerateArray();

            int cur = 0;
            while (enumerator.MoveNext())
            {
                if (cur == index)
                {
                    return GetElementValue(enumerator.Current, valueName);
                }
                cur++;
            }

            throw new IndexOutOfRangeException();
        }

        private static string GetResultValue(BinaryData result, string valueName)
        {
            using var doc = JsonDocument.Parse(result);
            return GetElementValue(doc.RootElement, valueName);
        }

        private static string GetElementValue(JsonElement element, string valueName)
        {
            switch (valueName)
            {
                case "Id":
                    return element.GetProperty("id").GetString();
                case "Name":
                    if (element.TryGetProperty("name", out var name))
                    {
                        return name.GetString();
                    }
                    return null;
                case "ProvisioningState":
                    if (element.TryGetProperty("properties", out var properties))
                    {
                        if (properties.TryGetProperty("provisioningState", out var provisioningState))
                        {
                            return provisioningState.GetString();
                        }
                    }
                    return null;
                default:
                    throw new KeyNotFoundException(valueName);
            }
        }
    }
}
