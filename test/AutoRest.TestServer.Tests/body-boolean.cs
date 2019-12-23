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
            var result = await new BoolOperations(host, ClientDiagnostics, pipeline).GetFalseAsync();
            Assert.False(result.Value);
        });

        [Test]
        public Task GetBoolInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new BoolOperations(host, ClientDiagnostics, pipeline).GetInvalidAsync());
        });

        [Test]
        [Ignore("Nullable return types are not implemented")]
        public Task GetBoolNull() => Test(async (host, pipeline) =>
        {
            var result = await new BoolOperations(host, ClientDiagnostics, pipeline).GetNullAsync();
            Assert.False(result.Value);
        });

        [Test]
        public Task GetBoolTrue() => Test(async (host, pipeline) =>
        {
            var result = await new BoolOperations(host, ClientDiagnostics, pipeline).GetTrueAsync();
            Assert.True(result.Value);
        });

        [Test]
        public Task PutBoolFalse() => TestStatus(async (host, pipeline) => await new BoolOperations(host, ClientDiagnostics, pipeline).PutFalseAsync());

        [Test]
        public Task PutBoolTrue() => TestStatus(async (host, pipeline) => await new BoolOperations(host, ClientDiagnostics, pipeline).PutTrueAsync());

    }
}
