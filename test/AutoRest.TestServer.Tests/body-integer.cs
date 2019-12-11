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
            Assert.ThrowsAsync<FormatException>(async () => await IntOperations.GetOverflowInt32Async(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetIntegerUnderflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await IntOperations.GetUnderflowInt32Async(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetIntegerInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await IntOperations.GetInvalidAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetLongOverflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await IntOperations.GetOverflowInt64Async(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task GetLongUnderflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () => await IntOperations.GetUnderflowInt64Async(ClientDiagnostics, pipeline, host));
        });

        [Test]
        [Ignore("Unit time in json not implemented")]
        public Task GetUnixTime() => TestStatus(async (host, pipeline) =>
        {
            var response = await IntOperations.GetUnixTimeAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1460505600), response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Nullable return types are not implemented")]
        public Task GetNullUnixTime() => TestStatus(async (host, pipeline) =>
        {
            var response = await IntOperations.GetNullUnixTimeAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Nullable return types are not implemented")]
        public Task GetIntegerNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await IntOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetInvalidUnixTime() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(),async () => await IntOperations.GetInvalidUnixTimeAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task PutIntegerMax() => TestStatus(async (host, pipeline) => await IntOperations.PutMax32Async(ClientDiagnostics, pipeline, int.MaxValue, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task PutLongMax() => TestStatus(async (host, pipeline) => await IntOperations.PutMax64Async(ClientDiagnostics, pipeline, long.MaxValue, host));

        [Test]
        public Task PutIntegerMin() => TestStatus(async (host, pipeline) => await IntOperations.PutMin32Async(ClientDiagnostics, pipeline, int.MinValue, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task PutLongMin() => TestStatus(async (host, pipeline) => await IntOperations.PutMin64Async(ClientDiagnostics, pipeline, long.MinValue, host));

        [Test]
        [Ignore("Unit time in json not implemented")]
        public Task PutUnixTime() => TestStatus(async (host, pipeline) => await IntOperations.PutUnixTimeDateAsync(ClientDiagnostics, pipeline, DateTimeOffset.FromUnixTimeSeconds(1460505600), host));
    }
}
