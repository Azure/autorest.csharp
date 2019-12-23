// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_integer;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class IntegerTest : TestServerTestBase
    {
        public IntegerTest(TestServerVersion version) : base(version, "int") { }

        [Test]
        public Task GetIntegerOverflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await new IntOperations(host, ClientDiagnostics, pipeline).GetOverflowInt32Async());
        });

        [Test]
        public Task GetIntegerUnderflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await new IntOperations(host, ClientDiagnostics, pipeline).GetUnderflowInt32Async());
        });

        [Test]
        public Task GetIntegerInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new IntOperations(host, ClientDiagnostics, pipeline).GetInvalidAsync());
        });

        [Test]
        public Task GetLongOverflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await new IntOperations(host, ClientDiagnostics, pipeline).GetOverflowInt64Async());
        });

        [Test]
        public Task GetLongUnderflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await new IntOperations(host, ClientDiagnostics, pipeline).GetUnderflowInt64Async());
        });

        [Test]
        public Task GetUnixTime() => TestStatus(async (host, pipeline) =>
        {
            var response = await new IntOperations(host, ClientDiagnostics, pipeline).GetUnixTimeAsync();
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1460505600), response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Nullable return types are not implemented")]
        public Task GetNullUnixTime() => TestStatus(async (host, pipeline) =>
        {
            var response = await new IntOperations(host, ClientDiagnostics, pipeline).GetNullUnixTimeAsync();
            Assert.AreEqual(null, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Nullable return types are not implemented")]
        public Task GetIntegerNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await new IntOperations(host, ClientDiagnostics, pipeline).GetNullAsync();
            Assert.AreEqual(null, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetInvalidUnixTime() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(),async () => await new IntOperations(host, ClientDiagnostics, pipeline).GetInvalidUnixTimeAsync());
        });

        [Test]
        public Task PutIntegerMax() => TestStatus(async (host, pipeline) => await new IntOperations(host, ClientDiagnostics, pipeline).PutMax32Async( int.MaxValue));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task PutLongMax() => TestStatus(async (host, pipeline) => await new IntOperations(host, ClientDiagnostics, pipeline).PutMax64Async( long.MaxValue));

        [Test]
        public Task PutIntegerMin() => TestStatus(async (host, pipeline) => await new IntOperations(host, ClientDiagnostics, pipeline).PutMin32Async( int.MinValue));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task PutLongMin() => TestStatus(async (host, pipeline) => await new IntOperations(host, ClientDiagnostics, pipeline).PutMin64Async( long.MinValue));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task PutUnixTime() => TestStatus(async (host, pipeline) => await new IntOperations(host, ClientDiagnostics, pipeline).PutUnixTimeDateAsync( DateTimeOffset.FromUnixTimeSeconds(1460505600)));
    }
}
