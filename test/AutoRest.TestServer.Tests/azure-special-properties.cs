// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using azure_special_properties;
using azure_special_properties.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class AzureSpecialPropertiesTest : TestServerTestBase
    {
        [Test]
        public Task AzureApiVersionMethodGlobalNotProvidedValid() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionDefaultClient>(pipeline, host).GetMethodGlobalNotProvidedValidAsync());

        [Test]
        public Task AzureApiVersionMethodGlobalValid() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionDefaultClient>(pipeline, host).GetMethodGlobalValidAsync());

        [Test]
        public Task AzureApiVersionMethodLocalNull() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionLocalClient>(pipeline, host).GetMethodLocalNullAsync());

        // Issue with test logic: https://github.com/Azure/autorest.testserver/issues/167
        [Test]
        public Task AzureApiVersionMethodLocalValid() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionLocalClient>(pipeline, host).GetMethodLocalValidAsync());

        [Test]
        public Task AzureApiVersionPathGlobalValid() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionDefaultClient>(pipeline, host).GetPathGlobalValidAsync());

        // Issue with test logic: https://github.com/Azure/autorest.testserver/issues/167
        [Test]
        public Task AzureApiVersionPathLocalValid() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionLocalClient>(pipeline, host).GetPathLocalValidAsync());

        [Test]
        public Task AzureApiVersionSwaggerGlobalValid() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionDefaultClient>(pipeline, host).GetSwaggerGlobalValidAsync());

        // Issue with test logic: https://github.com/Azure/autorest.testserver/issues/167
        [Test]
        public Task AzureApiVersionSwaggerLocalValid() => TestStatus(async (host, pipeline)
            => await GetClient<ApiVersionLocalClient>(pipeline, host).GetSwaggerLocalValidAsync());

        [Test]
        public Task AzureMethodPathUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "path1/path2/path3";
            return await GetClient<SkipUrlEncodingClient>(pipeline, host).GetMethodPathValidAsync(value);
        });

        [Test]
        public Task AzureMethodQueryUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "value1&q2=value2&q3=value3";
            return await GetClient<SkipUrlEncodingClient>(pipeline, host).GetMethodQueryValidAsync(value);
        });

        [Test]
        public Task AzureMethodQueryUrlEncodingNull() => TestStatus(async (host, pipeline)
            => await GetClient<SkipUrlEncodingClient>(pipeline, host).GetMethodQueryNullAsync());

        [Test]
        public Task AzureODataFilter() => TestStatus(async (host, pipeline) =>
        {
            var filter = "id gt 5 and name eq 'foo'";
            var top = 10;
            var orderBy = "id";
            return await GetClient<OdataClient>(pipeline, host).GetWithFilterAsync(filter, top, orderBy);
        });

        [Test]
        public Task AzurePathPathUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "path1/path2/path3";
            return await GetClient<SkipUrlEncodingClient>(pipeline, host).GetPathValidAsync(value);
        });

        [Test]
        public Task AzurePathQueryUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "value1&q2=value2&q3=value3";
            return await GetClient<SkipUrlEncodingClient>(pipeline, host).GetPathQueryValidAsync(value);
        });

        [Test]
        public Task AzureRequestClientIdInError() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<XMsClientRequestIdClient>(pipeline, host).GetAsync());
        });

        [Test]
        public Task AzureSubscriptionMethodGlobalNotProvidedValid() => TestStatus(async (host, pipeline) =>
        {
            var value = "1234-5678-9012-3456";
            return await GetClient<SubscriptionInCredentialsClient>(pipeline, value, host).PostMethodGlobalNotProvidedValidAsync();
        });

        [Test]
        public Task AzureSubscriptionMethodGlobalValid() => TestStatus(async (host, pipeline) =>
        {
            var value = "1234-5678-9012-3456";
            return await GetClient<SubscriptionInCredentialsClient>(pipeline, value, host).PostMethodGlobalValidAsync();
        });

        [Test]
        public Task AzureSubscriptionMethodLocalValid() => TestStatus(async (host, pipeline) =>
        {
            var value = "1234-5678-9012-3456";
            return await GetClient<SubscriptionInMethodClient>(pipeline, host).PostMethodLocalValidAsync(value);
        });

        [Test]
        public Task AzureSubscriptionPathGlobalValid() => TestStatus(async (host, pipeline) =>
        {
            var value = "1234-5678-9012-3456";
            return await GetClient<SubscriptionInCredentialsClient>(pipeline, value, host).PostPathGlobalValidAsync();
        });

        [Test]
        public Task AzureSubscriptionPathLocalValid() => TestStatus(async (host, pipeline) =>
        {
            var value = "1234-5678-9012-3456";
            return await GetClient<SubscriptionInMethodClient>(pipeline, host).PostPathLocalValidAsync(value);
        });

        [Test]
        public Task AzureSubscriptionSwaggerGlobalValid() => TestStatus(async (host, pipeline) =>
        {
            var value = "1234-5678-9012-3456";
            return await GetClient<SubscriptionInCredentialsClient>(pipeline, value, host).PostSwaggerGlobalValidAsync();
        });

        [Test]
        public Task AzureSubscriptionSwaggerLocalValid() => TestStatus(async (host, pipeline) =>
        {
            var value = "1234-5678-9012-3456";
            return await GetClient<SubscriptionInMethodClient>(pipeline, host).PostSwaggerLocalValidAsync(value);
        });

        [Test]
        public Task AzureSwaggerPathUrlEncoding() => TestStatus(async (host, pipeline)
            => await GetClient<SkipUrlEncodingClient>(pipeline, host).GetSwaggerPathValidAsync());

        [Test]
        public Task AzureSwaggerQueryUrlEncoding() => TestStatus(async (host, pipeline)
            => await GetClient<SkipUrlEncodingClient>(pipeline, host).GetSwaggerQueryValidAsync());

        [Test]
        public Task AzureXmsCustomNamedRequestId() => TestStatus(async (host, pipeline) =>
        {
            var value = "9C4D50EE-2D56-4CD3-8152-34347DC9F2B0";
            var result = await GetClient<HeaderClient>(pipeline, host).CustomNamedRequestIdAsync(value);
            return result;
        });

        [Test]
        public Task AzureXmsCustomNamedRequestIdParameterGroup() => TestStatus(async (host, pipeline) =>
        {
            var value = new HeaderCustomNamedRequestIdParamGroupingParameters("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            var result = await GetClient<HeaderClient>(pipeline, host).CustomNamedRequestIdParamGroupingAsync(value);
            return result;
        });

        [Test]
        public Task AzureXmsRequestClientIdNull() => TestStatus(async (host, pipeline) =>
        {
            using var _ = ClientRequestIdScope.Start("");
            return await GetClient<XMsClientRequestIdClient>(pipeline, host).GetAsync();
        });

        [Test]
        public Task AzureXmsRequestClientOverwrite() => TestStatus(async (host, pipeline) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            return await GetClient<XMsClientRequestIdClient>(pipeline, host).GetAsync();
        });

        [Test]
        public Task AzureXmsRequestClientOverwriteViaParameter() => TestStatus(async (host, pipeline) =>
        {
            using var _ = ClientRequestIdScope.Start("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0");
            return await GetClient<XMsClientRequestIdClient>(pipeline, host).ParamGetAsync();
        });
    }
}
