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
        public BooleanTests(TestServerVersion version) : base(version, "bool") { }

        [Test]
        public Task GetBoolFalse() => Test(async (host, pipeline) =>
        {
            var result = await new BoolOperations(ClientDiagnostics, pipeline, host).GetFalseAsync();
            Assert.False(result.Value);
        });

        [Test]
        public Task GetBoolInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new BoolOperations(ClientDiagnostics, pipeline, host).GetInvalidAsync());
        });

        [Test]
        [Ignore("Nullable return types are not implemented")]
        public Task GetBoolNull() => Test(async (host, pipeline) =>
        {
            var result = await new BoolOperations(ClientDiagnostics, pipeline, host).GetNullAsync();
            Assert.False(result.Value);
        });

        [Test]
        public Task GetBoolTrue() => Test(async (host, pipeline) =>
        {
            var result = await new BoolOperations(ClientDiagnostics, pipeline, host).GetTrueAsync();
            Assert.True(result.Value);
        });

        [Test]
        public Task PutBoolFalse() => TestStatus(async (host, pipeline) => await new BoolOperations(ClientDiagnostics, pipeline, host).PutFalseAsync());

        [Test]
        public Task PutBoolTrue() => TestStatus(async (host, pipeline) => await new BoolOperations(ClientDiagnostics, pipeline, host).PutTrueAsync());

    }
}
