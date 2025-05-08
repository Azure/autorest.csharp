// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_boolean;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BooleanTests : TestServerTestBase
    {
        [Test]
        public Task GetBoolFalse() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<BoolClient>(pipeline, host).GetFalseAsync();
            Assert.False(result.Value);
        });

        [Test]
        public Task GetBoolInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await GetClient<BoolClient>(pipeline, host).GetInvalidAsync());
        });

        [Test]
        public Task GetBoolNull() => Test((host, pipeline) =>
        {
            // Empty response body
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await GetClient<BoolClient>(pipeline, host).GetNullAsync());
        });

        [Test]
        public Task GetBoolTrue() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<BoolClient>(pipeline, host).GetTrueAsync();
            Assert.True(result.Value);
        });

        [Test]
        public Task PutBoolFalse() => TestStatus(async (host, pipeline) => await GetClient<BoolClient>(pipeline, host).PutFalseAsync());

        [Test]
        public Task PutBoolTrue() => TestStatus(async (host, pipeline) => await GetClient<BoolClient>(pipeline, host).PutTrueAsync());

    }
}
