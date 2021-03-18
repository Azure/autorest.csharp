// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_date;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyDateTest: TestServerTestBase
    {
        public BodyDateTest(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetDateInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () =>
                await new DateClient(ClientDiagnostics, pipeline, host).GetInvalidDateAsync());
        });

        [Test]
        public Task GetDateMax() => Test(async (host, pipeline) =>
        {
            var result = await new DateClient(ClientDiagnostics, pipeline, host).GetMaxDateAsync();
            Assert.AreEqual(DateTimeOffset.Parse("9999-12-31", styles: DateTimeStyles.AssumeUniversal), result.Value);
        });

        [Test]
        public Task GetDateMin() => Test(async (host, pipeline) =>
        {
            var result = await new DateClient(ClientDiagnostics, pipeline, host).GetMinDateAsync();
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01", styles: DateTimeStyles.AssumeUniversal), result.Value);
        });

        [Test]
        public Task GetDateNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new DateClient(ClientDiagnostics, pipeline, host).GetNullAsync());
        });

        [Test]
        public Task GetDateOverflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () =>
                await new DateClient(ClientDiagnostics, pipeline, host).GetOverflowDateAsync());
        });

        [Test]
        public Task GetDateUnderflow() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () =>
                await new DateClient(ClientDiagnostics, pipeline, host).GetUnderflowDateAsync());
        });

        [Test]
        public Task PutDateMax() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("9999-12-31");
            return await new DateClient(ClientDiagnostics, pipeline, host).PutMaxDateAsync( value);
        });

        [Test]
        public Task PutDateMin() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("0001-01-01");
            return await new DateClient(ClientDiagnostics, pipeline, host).PutMinDateAsync( value);
        });
    }
}
