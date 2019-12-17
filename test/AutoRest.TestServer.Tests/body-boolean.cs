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
            var result = await BoolOperations.GetFalseAsync(ClientDiagnostics, pipeline, host);
            Assert.False(result.Value);
        });

        [Test]
        public Task GetBoolInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await BoolOperations.GetInvalidAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        [Ignore("Nullable return types are not implemented")]
        public Task GetBoolNull() => Test(async (host, pipeline) =>
        {
            var result = await BoolOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.False(result.Value);
        });

        [Test]
        public Task GetBoolTrue() => Test(async (host, pipeline) =>
        {
            var result = await BoolOperations.GetTrueAsync(ClientDiagnostics, pipeline, host);
            Assert.True(result.Value);
        });

        [Test]
        public Task PutBoolFalse() => TestStatus(async (host, pipeline) => await BoolOperations.PutFalseAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task PutBoolTrue() => TestStatus(async (host, pipeline) => await BoolOperations.PutTrueAsync(ClientDiagnostics, pipeline, host));

    }
}
