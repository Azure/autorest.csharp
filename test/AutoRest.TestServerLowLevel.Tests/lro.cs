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
        public Task CustomHeaderPostAsyncSucceded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).PostAsyncRetrySucceededAsync(waitUntil, value);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task CustomHeaderPostAsyncSucceded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).PostAsyncRetrySucceeded(waitUntil, value);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task CustomHeaderPostSucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).Post202Retry200Async(waitUntil, value);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task CustomHeaderPostSucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).Post202Retry200(waitUntil, value);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task CustomHeaderPutAsyncSucceded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).PutAsyncRetrySucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutAsyncSucceded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).PutAsyncRetrySucceeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutSucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = await new LROsCustomHeaderClient(Key, endpoint, options).Put201CreatingSucceeded200Async(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task CustomHeaderPutSucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var options = new AutoRestLongRunningOperationTestServiceClientOptions();
            options.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);
            var value = RequestContent.Create(new object());
            var operation = new LROsCustomHeaderClient(Key, endpoint, options).Put201CreatingSucceeded200(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODelete200([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete202Retry200Async(waitUntil);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LRODelete200_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Delete202Retry200(waitUntil);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitUntil).Content.ToMemory().Length);
        });

        [Test]
        public Task LRODelete204([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete202NoRetry204Async(waitUntil);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LRODelete204_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Delete202NoRetry204(waitUntil);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitUntil).Content.ToMemory().Length);
        });

        [Test]
        public Task LRODeleteAsyncNoHeaderInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncNoHeaderInRetryAsync(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncNoHeaderInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncNoHeaderInRetry(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncNoRetrySucceededAsync(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncNoRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncNoRetrySucceeded(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetrycanceledAsync(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetryCanceled_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).DeleteAsyncRetrycanceled(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetryFailedAsync(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetryFailed_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).DeleteAsyncRetryFailed(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteAsyncRetrySucceededAsync(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteAsyncRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteAsyncRetrySucceeded(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRODeleteInlineComplete([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Delete204SucceededAsync(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteInlineComplete_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Delete204Succeeded(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteNoHeaderInRetryAsync(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRODeleteNoHeaderInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteNoHeaderInRetry(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRODeleteProvisioningCanceled([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202Deletingcanceled200Async(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Canceled", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningCanceled_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202Deletingcanceled200(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Canceled", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningFailed([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202DeletingFailed200Async(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Failed", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningFailed_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202DeletingFailed200(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Failed", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).DeleteProvisioning202Accepted200SucceededAsync(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRODeleteProvisioningSucceededWithBody_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).DeleteProvisioning202Accepted200Succeeded(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).Delete202RetryInvalidHeaderAsync(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDelete202RetryInvalidHeader_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).Delete202RetryInvalidHeader(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidHeaderAsync(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidHeader_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidHeader(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidJsonPollingAsync(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncInvalidJsonPolling_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.Throws(Is.InstanceOf<JsonException>(), () =>
            {
                var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryInvalidJsonPolling(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryNoStatusAsync(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorDeleteAsyncNoPollingStatus_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).DeleteAsyncRelativeRetryNoStatus(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorDeleteNoLocation([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LrosaDsClient(Key, endpoint).Delete204SucceededAsync(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LROErrorDeleteNoLocation_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LrosaDsClient(Key, endpoint).Delete204Succeeded(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).Post202RetryInvalidHeaderAsync(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPost202RetryInvalidHeader_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).Post202RetryInvalidHeader(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidHeaderAsync(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidHeader_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidHeader(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.CatchAsync<JsonException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidJsonPollingAsync(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostAsyncInvalidJsonPolling_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Catch<JsonException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryInvalidJsonPolling(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryNoPayloadAsync(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostAsyncNoPollingPayload_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).PostAsyncRelativeRetryNoPayload(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPostNoLocation([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LrosaDsClient(Key, endpoint).Post202NoLocationAsync(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPostNoLocation_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LrosaDsClient(Key, endpoint).Post202NoLocation(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPut200InvalidJson([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.CatchAsync<JsonException>(async () => await WaitForCompletionWithValueAsync(await new LrosaDsClient(Key, endpoint).Put200InvalidJsonAsync(waitUntil, value), waitUntil));
        });

        [Test]
        public Task LROErrorPut200InvalidJson_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Catch<JsonException>(() => WaitForCompletion(new LrosaDsClient(Key, endpoint).Put200InvalidJson(waitUntil, value), waitUntil));
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LrosaDsClient(Key, endpoint).PutError201NoProvisioningStatePayloadAsync(waitUntil, value);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LROErrorPut201NoProvisioningStatePayload_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LrosaDsClient(Key, endpoint).PutError201NoProvisioningStatePayload(waitUntil, value);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitUntil).Content.ToMemory().Length);
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryInvalidHeaderAsync(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncInvalidHeader_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryInvalidHeader(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.CatchAsync<JsonException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryInvalidJsonPollingAsync(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncInvalidJsonPolling_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Catch<JsonException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryInvalidJsonPolling(waitUntil, value);
                WaitForCompletionWithValue(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryNoStatusAsync(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatus_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryNoStatus(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetryNoStatusPayloadAsync(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROErrorPutAsyncNoPollingStatusPayload_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetryNoStatusPayload(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRONonRetryDelete202Retry400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.Delete202NonRetry400Async(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryDelete202Retry400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.Delete202NonRetry400(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRONonRetryDelete400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).DeleteNonRetry400Async(WaitUntil.Started));
        });

        [Test]
        public Task LRONonRetryDelete400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).DeleteNonRetry400(WaitUntil.Started));
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.DeleteAsyncRelativeRetry400Async(waitUntil);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryDeleteAsyncRetry400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.DeleteAsyncRelativeRetry400(waitUntil);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRONonRetryPost202Retry400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.Post202NonRetry400Async(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPost202Retry400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.Post202NonRetry400(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRONonRetryPost400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).PostNonRetry400Async(waitUntil, value));
        });

        [Test]
        public Task LRONonRetryPost400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).PostNonRetry400(waitUntil, value));
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PostAsyncRelativeRetry400Async(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPostAsyncRetry400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PostAsyncRelativeRetry400(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutNonRetry201Creating400Async(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutNonRetry201Creating400(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutNonRetry201Creating400InvalidJsonAsync(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPut201Creating400InvalidJson_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutNonRetry201Creating400InvalidJson(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LRONonRetryPut400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () => await new LrosaDsClient(Key, endpoint).PutNonRetry400Async(waitUntil, value));
        });

        [Test]
        public Task LRONonRetryPut400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() => new LrosaDsClient(Key, endpoint).PutNonRetry400(waitUntil, value));
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await client.PutAsyncRelativeRetry400Async(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LRONonRetryPutAsyncRetry400_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var client = new LrosaDsClient(Key, endpoint);
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = client.PutAsyncRelativeRetry400(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROPost200([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Post200WithPayloadAsync(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("1", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("product", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPost200_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Post200WithPayload(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("1", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("product", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncNoRetrySucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAndGetList([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).Post202ListAsync(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual(1, GetArrayLength(result.Value));
            Assert.AreEqual("100", GetResultArrayValue(result.Value, 0, "Id"));
            Assert.AreEqual("foo", GetResultArrayValue(result.Value, 0, "Name"));
        });

        [Test]
        public Task LROPostAndGetList_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).Post202List(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual(1, GetArrayLength(result.Value));
            Assert.AreEqual("100", GetResultArrayValue(result.Value, 0, "Id"));
            Assert.AreEqual("foo", GetResultArrayValue(result.Value, 0, "Name"));
        });

        [Test]
        public Task LROPostAsyncNoRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncNoRetrySucceeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAsyncRetryCanceled([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PostAsyncRetrycanceledAsync(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPostAsyncRetryCanceled_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PostAsyncRetrycanceled(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROPostAsyncRetryFailed([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PostAsyncRetryFailedAsync(waitUntil, value);
                await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPostAsyncRetryFailed_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PostAsyncRetryFailed(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PostAsyncRetrySucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostAsyncRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PostAsyncRetrySucceeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetAsync(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual(null, GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGet_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGet(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual(null, GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalAzureHeaderGetDefault_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalAzureHeaderGetDefault(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LROsClient(Key, endpoint).PostDoubleHeadersFinalLocationGetAsync(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostDoubleHeadersFinalLocationGet_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LROsClient(Key, endpoint).PostDoubleHeadersFinalLocationGet(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPostSuccededNoBody([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Post202NoRetry204Async(waitUntil, value);
            // Empty response body
            Assert.AreEqual(0, (await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false)).Value.ToMemory().Length);
        });

        [Test]
        public Task LROPostSuccededNoBody_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Post202NoRetry204(waitUntil, value);
            // Empty response body
            Assert.AreEqual(0, WaitForCompletion(operation, waitUntil).Content.ToMemory().Length);
        });

        [Test]
        public Task LROPostSuccededWithBody([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Post202Retry200Async(waitUntil, value);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LROPostSuccededWithBody_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Post202Retry200(waitUntil, value);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LROPut200InlineCompleteNoState([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200SucceededNoStateAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut200InlineCompleteNoState_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200SucceededNoState(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut202Retry200([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put202Retry200Async(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPut202Retry200_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put202Retry200(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual(null, GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNoHeaderInRetryAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoHeaderInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNoHeaderInRetry(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PutAsyncNoRetrycanceledAsync(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutAsyncNoRetryCanceled_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PutAsyncNoRetrycanceled(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNoRetrySucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncNoRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNoRetrySucceeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncRetryFailed([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).PutAsyncRetryFailedAsync(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutAsyncRetryFailed_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).PutAsyncRetryFailed(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncRetrySucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutAsyncRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncRetrySucceeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutCanceled([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).Put200Acceptedcanceled200Async(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutCanceled_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).Put200Acceptedcanceled200(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROPutFailed([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var operation = await new LROsClient(Key, endpoint).Put201CreatingFailed200Async(waitUntil, value);
                await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            });
        });

        [Test]
        public Task LROPutFailed_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            Assert.Throws<RequestFailedException>(() =>
            {
                var operation = new LROsClient(Key, endpoint).Put201CreatingFailed200(waitUntil, value);
                WaitForCompletion(operation, waitUntil);
            });
        });

        [Test]
        public Task LROPutInlineComplete([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200SucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200Succeeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete201([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put201SucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutInlineComplete201_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put201Succeeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNoHeaderInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutNoHeaderInRetryAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNoHeaderInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutNoHeaderInRetry(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncNonResourceAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceAsyncInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncNonResource(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutNonResourceAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutNonResourceInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutNonResource(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("sku", GetResultValue(result.Value, "Name"));
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutAsyncSubResourceAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceAsyncInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutAsyncSubResource(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceInRetry([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).PutSubResourceAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSubResourceInRetry_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).PutSubResource(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededNoBody([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put200UpdatingSucceeded204Async(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededNoBody_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put200UpdatingSucceeded204(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededWithBody([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LROsClient(Key, endpoint).Put201CreatingSucceeded200Async(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LROPutSucceededWithBody_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LROsClient(Key, endpoint).Put201CreatingSucceeded200(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).DeleteProvisioning202Accepted200SucceededAsync(waitUntil);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Accepted200Succeeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var operation = new LRORetrysClient(Key, endpoint).DeleteProvisioning202Accepted200Succeeded(waitUntil);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).Delete202Retry200Async(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDelete202Retry200Succeeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LRORetrysClient(Key, endpoint).Delete202Retry200(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var operation = await new LRORetrysClient(Key, endpoint).DeleteAsyncRelativeRetrySucceededAsync(waitUntil);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorDeleteAsyncRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var operation = new LRORetrysClient(Key, endpoint).DeleteAsyncRelativeRetrySucceeded(waitUntil);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).Post202Retry200Async(waitUntil, value);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPost202Retry200Succeeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).Post202Retry200(waitUntil, value);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PostAsyncRelativeRetrySucceededAsync(waitUntil, value);
            return await WaitForCompletionAsync(operation, waitUntil).ConfigureAwait(false);
        });

        [Test]
        public Task LRORetryErrorPostAsyncRetrySucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => TestStatus(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PostAsyncRelativeRetrySucceeded(waitUntil, value);
            return WaitForCompletion(operation, waitUntil);
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceeded_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceededAsync(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryErrorPutAsyncSucceededPolling_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).PutAsyncRelativeRetrySucceeded(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryPutSucceededWithBody([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(async endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = await new LRORetrysClient(Key, endpoint).Put201CreatingSucceeded200Async(waitUntil, value);
            var result = await WaitForCompletionWithValueAsync(operation, waitUntil).ConfigureAwait(false);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        [Test]
        public Task LRORetryPutSucceededWithBody_Sync([Values(WaitUntil.Completed, WaitUntil.Started)] WaitUntil waitUntil) => Test(endpoint =>
        {
            var value = RequestContent.Create(new object());
            var operation = new LRORetrysClient(Key, endpoint).Put201CreatingSucceeded200(waitUntil, value);
            var result = WaitForCompletionWithValue(operation, waitUntil);
            Assert.AreEqual("100", GetResultValue(result.Value, "Id"));
            Assert.AreEqual("foo", GetResultValue(result.Value, "Name"));
            Assert.AreEqual("Succeeded", GetResultValue(result.Value, "ProvisioningState"));
        });

        private static ValueTask<Response> WaitForCompletionAsync(Operation operation, WaitUntil operationHasCompleted, CancellationToken cancellationToken = default)
        {
            if (operationHasCompleted == WaitUntil.Completed)
            {
                Assert.IsTrue(operation.HasCompleted);
                return new ValueTask<Response>(operation.GetRawResponse());
            }

            return operation.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(1), cancellationToken);
        }

        private static ValueTask<Response<TResult>> WaitForCompletionWithValueAsync<TResult>(Operation<TResult> operation, WaitUntil operationHasCompleted, CancellationToken cancellationToken = default) where TResult : notnull
        {
            if (operationHasCompleted == WaitUntil.Completed)
            {
                Assert.IsTrue(operation.HasCompleted);
                return new ValueTask<Response<TResult>>(Response.FromValue(operation.Value, operation.GetRawResponse()));
            }

            return operation.WaitForCompletionAsync(TimeSpan.FromSeconds(1), cancellationToken);
        }

        private static Response WaitForCompletion(Operation operation, WaitUntil operationHasCompleted, CancellationToken cancellationToken = default)
        {
            if (operationHasCompleted == WaitUntil.Completed)
            {
                Assert.IsTrue(operation.HasCompleted);
                return operation.GetRawResponse();
            }

            return operation.WaitForCompletionResponse(TimeSpan.FromSeconds(1), cancellationToken);
        }

        private static Response<TResult> WaitForCompletionWithValue<TResult>(Operation<TResult> operation, WaitUntil operationHasCompleted, CancellationToken cancellationToken = default) where TResult : notnull
        {
            if (operationHasCompleted == WaitUntil.Completed)
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
