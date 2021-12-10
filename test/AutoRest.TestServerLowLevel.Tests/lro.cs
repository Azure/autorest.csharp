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
        public Task CustomHeaderPostAsyncSucceded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).PostAsyncRetrySucceededAsync(waitForCompletion, value);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task CustomHeaderPostAsyncSucceded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).PostAsyncRetrySucceeded(waitForCompletion, value);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task CustomHeaderPostSucceeded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).Post202Retry200Async(waitForCompletion, value);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task CustomHeaderPostSucceeded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).Post202Retry200(waitForCompletion, value);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task CustomHeaderPutAsyncSucceded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).PutAsyncRetrySucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutAsyncSucceded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).PutAsyncRetrySucceeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutSucceeded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).Put201CreatingSucceeded200Async(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutSucceeded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).Put201CreatingSucceeded200(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODelete200([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete202Retry200Async(waitForCompletion);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LRODelete200_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Delete202Retry200(waitForCompletion);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitForCompletion).Content.ToMemory().Length);
        });

        [Test]
        public Task LRODelete204([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete202NoRetry204Async(waitForCompletion);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LRODelete204_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Delete202NoRetry204(waitForCompletion);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitForCompletion).Content.ToMemory().Length);
        });

        [Test]
        public Task LRODeleteAsyncNoHeaderInRetry([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncNoHeaderInRetryAsync(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncNoHeaderInRetry_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncNoHeaderInRetry(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncNoRetrySucceededAsync(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncNoRetrySucceeded(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetrycanceledAsync(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).DeleteAsyncRetrycanceled(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetryFailedAsync(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).DeleteAsyncRetryFailed(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetrySucceededAsync(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncRetrySucceeded(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRODeleteInlineComplete([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete204SucceededAsync(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteInlineComplete_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Delete204Succeeded(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteNoHeaderInRetryAsync(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteNoHeaderInRetry(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRODeleteProvisioningCanceled([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202Deletingcanceled200Async(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Canceled", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningCanceled_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202Deletingcanceled200(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Canceled", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningFailed([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202DeletingFailed200Async(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Failed", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningFailed_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202DeletingFailed200(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Failed", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202Accepted200SucceededAsync(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202Accepted200Succeeded(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).Delete202RetryInvalidHeaderAsync(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).Delete202RetryInvalidHeader(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidHeaderAsync(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidHeader(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidJsonPollingAsync(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.Throws(Is.InstanceOf<JsonException>(), () =>
            {
                var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidJsonPolling(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryNoStatusAsync(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryNoStatus(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorDeleteNoLocation([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).Delete204SucceededAsync(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDeleteNoLocation_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LrosaDsClient(Key, endpoint).Delete204Succeeded(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).Post202RetryInvalidHeaderAsync(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).Post202RetryInvalidHeader(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidHeaderAsync(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidHeader(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.CatchAsync<JsonException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidJsonPollingAsync(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Catch<JsonException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidJsonPolling(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryNoPayloadAsync(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryNoPayload(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPostNoLocation([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).Post202NoLocationAsync(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostNoLocation_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).Post202NoLocation(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPut200InvalidJson([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.CatchAsync<JsonException>(async () => await WaitForCompletionWithValueAsync(await new LrosaDsClient(Key, endpoint).Put200InvalidJsonAsync(waitForCompletion, value), waitForCompletion));
        });

        [Test]
        public Task LROErrorPut200InvalidJson_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Catch<JsonException>(() => WaitForCompletion(new LrosaDsClient(Key, endpoint).Put200InvalidJson(waitForCompletion, value), waitForCompletion));
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutError201NoProvisioningStatePayloadAsync(waitForCompletion, value);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutError201NoProvisioningStatePayload(waitForCompletion, value);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitForCompletion).Content.ToMemory().Length);
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryInvalidHeaderAsync(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryInvalidHeader(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.CatchAsync<JsonException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryInvalidJsonPollingAsync(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Catch<JsonException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryInvalidJsonPolling(waitForCompletion, value);
                WaitForCompletionWithValue(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryNoStatusAsync(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryNoStatus(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryNoStatusPayloadAsync(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryNoStatusPayload(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRONonRetryDelete202Retry400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.Delete202NonRetry400Async(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryDelete202Retry400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.Delete202NonRetry400(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRONonRetryDelete400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).DeleteNonRetry400Async(false));
        });

        [Test]
        public Task LRONonRetryDelete400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).DeleteNonRetry400(false));
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.DeleteAsyncRelativeRetry400Async(waitForCompletion);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.DeleteAsyncRelativeRetry400(waitForCompletion);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRONonRetryPost202Retry400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.Post202NonRetry400Async(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPost202Retry400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.Post202NonRetry400(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRONonRetryPost400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).PostNonRetry400Async(waitForCompletion, value));
        });

        [Test]
        public Task LRONonRetryPost400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).PostNonRetry400(waitForCompletion, value));
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PostAsyncRelativeRetry400Async(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PostAsyncRelativeRetry400(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutNonRetry201Creating400Async(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutNonRetry201Creating400(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutNonRetry201Creating400InvalidJsonAsync(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutNonRetry201Creating400InvalidJson(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LRONonRetryPut400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).PutNonRetry400Async(waitForCompletion, value));
        });

        [Test]
        public Task LRONonRetryPut400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).PutNonRetry400(waitForCompletion, value));
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetry400Async(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetry400(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROPost200([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Post200WithPayloadAsync(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("1", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("product", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPost200_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Post200WithPayload(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("1", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("product", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncNoRetrySucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAndGetList([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Post202ListAsync(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual(1, GetArrayLength(result.Value));
            Assert.AreEqual("100", GetResultArrayValue(result.Value, 0, "Id"));
            Assert.AreEqual("foo", GetResultArrayValue(result.Value, 0, "Name"));
        });

        [Test]
        public Task LROPostAndGetList_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Post202List(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual(1, GetArrayLength(result.Value));
            Assert.AreEqual("100", GetResultArrayValue(result.Value, 0, "Id"));
            Assert.AreEqual("foo", GetResultArrayValue(result.Value, 0, "Name"));
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncNoRetrySucceeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAsyncRetryCanceled([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PostAsyncRetrycanceledAsync(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPostAsyncRetryCanceled_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PostAsyncRetrycanceled(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROPostAsyncRetryFailed([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PostAsyncRetryFailedAsync(waitForCompletion, value);
                await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPostAsyncRetryFailed_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PostAsyncRetryFailed(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncRetrySucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncRetrySucceeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetAsync(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual(null, GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGet(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual(null, GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetDefault(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalLocationGetAsync(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalLocationGet(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostSuccededNoBody([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Post202NoRetry204Async(waitForCompletion, value);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LROPostSuccededNoBody_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Post202NoRetry204(waitForCompletion, value);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitForCompletion).Content.ToMemory().Length);
        });

        [Test]
        public Task LROPostSuccededWithBody([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Post202Retry200Async(waitForCompletion, value);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LROPostSuccededWithBody_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Post202Retry200(waitForCompletion, value);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LROPut200InlineCompleteNoState([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200SucceededNoStateAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut200InlineCompleteNoState_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200SucceededNoState(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut202Retry200([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put202Retry200Async(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut202Retry200_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put202Retry200(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNoHeaderInRetryAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNoHeaderInRetry(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PutAsyncNoRetrycanceledAsync(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PutAsyncNoRetrycanceled(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNoRetrySucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNoRetrySucceeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncRetryFailed([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PutAsyncRetryFailedAsync(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutAsyncRetryFailed_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PutAsyncRetryFailed(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncRetrySucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncRetrySucceeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutCanceled([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).Put200Acceptedcanceled200Async(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutCanceled_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).Put200Acceptedcanceled200(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROPutFailed([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).Put201CreatingFailed200Async(waitForCompletion, value);
                await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutFailed_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).Put201CreatingFailed200(waitForCompletion, value);
                WaitForCompletion(operation, waitForCompletion);
            });
        });

        [Test]
        public Task LROPutInlineComplete([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200SucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200Succeeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete201([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put201SucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete201_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put201Succeeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNoHeaderInRetry([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutNoHeaderInRetryAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNoHeaderInRetry_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutNoHeaderInRetry(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNonResourceAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNonResource(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceInRetry([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutNonResourceAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceInRetry_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutNonResource(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncSubResourceAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncSubResource(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceInRetry([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutSubResourceAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceInRetry_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutSubResource(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededNoBody([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200UpdatingSucceeded204Async(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededNoBody_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200UpdatingSucceeded204(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededWithBody([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put201CreatingSucceeded200Async(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededWithBody_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put201CreatingSucceeded200(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).DeleteProvisioning202Accepted200SucceededAsync(waitForCompletion);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var operation = new LRORetrysClient(Key, endpoint).DeleteProvisioning202Accepted200Succeeded(waitForCompletion);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).Delete202Retry200Async(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LRORetrysClient(Key, endpoint).Delete202Retry200(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).DeleteAsyncRelativeRetrySucceededAsync(waitForCompletion);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var operation = new LRORetrysClient(Key, endpoint).DeleteAsyncRelativeRetrySucceeded(waitForCompletion);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).Post202Retry200Async(waitForCompletion, value);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).Post202Retry200(waitForCompletion, value);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded([Values(true, false)] bool waitForCompletion) => TestStatus(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PostAsyncRelativeRetrySucceededAsync(waitForCompletion, value);
            return await WaitForCompletionAsync(operation, waitForCompletion).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded_Sync([Values(true, false)] bool waitForCompletion) => TestStatus(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PostAsyncRelativeRetrySucceeded(waitForCompletion, value);
            return WaitForCompletion(operation, waitForCompletion);
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceededAsync(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceeded(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryPutSucceededWithBody([Values(true, false)] bool waitForCompletion) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).Put201CreatingSucceeded200Async(waitForCompletion, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitForCompletion).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryPutSucceededWithBody_Sync([Values(true, false)] bool waitForCompletion) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).Put201CreatingSucceeded200(waitForCompletion, value);
            var result = WaitForCompletionWithValue(operation, waitForCompletion);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        private static ValueTask<Response> WaitForCompletionAsync(Operation operation, bool operationHasCompleted, CancellationToken cancellationToken = default)
        {
            if (operationHasCompleted)
            {
                Assert.IsTrue(operation.HasCompleted);
                return new ValueTask<Response>(operation.GetRawResponse());
            }

            return operation.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(1), cancellationToken);
        }

        private static ValueTask<Response<TResult>> WaitForCompletionWithValueAsync<TResult>(Operation<TResult> operation, bool operationHasCompleted, CancellationToken cancellationToken = default) where TResult : notnull
        {
            if (operationHasCompleted)
            {
                Assert.IsTrue(operation.HasCompleted);
                return new ValueTask<Response<TResult>>(Response.FromValue(operation.Value, operation.GetRawResponse()));
            }

            return operation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), cancellationToken);
        }

        private static Response WaitForCompletion(Operation operation, bool operationHasCompleted, CancellationToken cancellationToken = default)
        {
            if (operationHasCompleted)
            {
                Assert.IsTrue(operation.HasCompleted);
                return operation.GetRawResponse();
            }

            return operation.WaitForCompletionResponse(TimeSpan.FromSeconds(1), cancellationToken);
        }

        private static Response<TResult> WaitForCompletionWithValue<TResult>(Operation<TResult> operation, bool operationHasCompleted, CancellationToken cancellationToken = default) where TResult : notnull
        {
            if (operationHasCompleted)
            {
                Assert.IsTrue(operation.HasCompleted);
                return Response.FromValue(operation.Value, operation.GetRawResponse());
            }

            return operation.WaitForCompletion(TimeSpan.FromSeconds(1), cancellationToken);
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
