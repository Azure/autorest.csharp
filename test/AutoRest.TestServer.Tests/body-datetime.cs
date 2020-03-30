// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_datetime;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyDateTimeTest: TestServerTestBase
    {
        public BodyDateTimeTest(TestServerVersion version) : base(version, "datetime") { }

        [Test]
        public Task GetDateTimeInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () =>
                await new DatetimeClient(ClientDiagnostics, pipeline, host).GetInvalidAsync());
        });

        [Test]
        public Task GetDateTimeMinLocalNegativeOffset() => Test(async (host, pipeline) =>
        {
            var result = await new DatetimeClient(ClientDiagnostics, pipeline, host).GetLocalNegativeOffsetMinDateTimeAsync();
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01T00:00:00-14:00"), result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/346")]
        public Task GetDateTimeMinLocalPositiveOffset() => Test(async (host, pipeline) =>
        {
            var result = await new DatetimeClient(ClientDiagnostics, pipeline, host).GetLocalPositiveOffsetMinDateTimeAsync();
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01T00:00:00+14:00"), result.Value);
        });

        [Test]
        public Task GetDateTimeMinUtc() => Test(async (host, pipeline) =>
        {
            var result = await new DatetimeClient(ClientDiagnostics, pipeline, host).GetUtcMinDateTimeAsync();
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01T00:00:00Z"), result.Value);
        });

        [Test]
        public Task GetDateTimeNull() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new DatetimeClient(ClientDiagnostics, pipeline, host).GetNullAsync());
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/346")]
        public Task GetDateTimeOverflow() => Test(async (host, pipeline) =>
        {
            var result = await new DatetimeClient(ClientDiagnostics, pipeline, host).GetOverflowAsync();
            Assert.AreEqual(DateTimeOffset.Parse("9999-12-31T23:59:59.9999999-14:00"), result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/346")]
        public Task GetDateTimeUnderflow() => Test(async (host, pipeline) =>
        {
            var result = await new DatetimeClient(ClientDiagnostics, pipeline, host).GetUnderflowAsync();
            Assert.AreEqual(DateTimeOffset.Parse("0000-00-00T00:00:00.0000000+00:00"), result.Value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched")]
        public Task GetDateTimeMaxUtc7MSUppercase() => Test(async (host, pipeline) =>
        {
            var result = await new DatetimeClient(ClientDiagnostics, pipeline, host).GetUtcUppercaseMaxDateTime7DigitsAsync();
            Assert.AreEqual(DateTimeOffset.Parse("9999-12-31T23:59:59.9999999Z"), result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/391")]
        public Task PutDateTimeMaxUtc7MS() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("9999-12-31T23:59:59.9999999Z");
            return await new DatetimeClient(ClientDiagnostics, pipeline, host).PutUtcMaxDateTime7DigitsAsync( value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/346")]
        public Task PutDateTimeMaxLocalNegativeOffset() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("9999-12-31T23:59:59.9999999-14:00");
            return await new DatetimeClient(ClientDiagnostics, pipeline, host).PutLocalNegativeOffsetMaxDateTimeAsync( value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched")]
        public Task PutDateTimeMaxLocalPositiveOffset() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("9999-12-31T09:59:59.9999999Z");
            return await new DatetimeClient(ClientDiagnostics, pipeline, host).PutLocalPositiveOffsetMaxDateTimeAsync( value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched")]
        public Task PutDateTimeMaxUtc() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("9999-12-31T23:59:59.9999999Z");
            return await new DatetimeClient(ClientDiagnostics, pipeline, host).PutUtcMaxDateTimeAsync( value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched")]
        public Task PutDateTimeMinLocalNegativeOffset() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("0001-01-01T00:00:00-14:00");
            return await new DatetimeClient(ClientDiagnostics, pipeline, host).PutLocalNegativeOffsetMinDateTimeAsync( value);
        });

        [Test]
        [Ignore("Value outside the DateTimeOffset range")]
        public Task PutDateTimeMinLocalPositiveOffset() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("0001-01-01T00:00:00+14:00");
            return await new DatetimeClient(ClientDiagnostics, pipeline, host).PutLocalPositiveOffsetMinDateTimeAsync( value);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched")]
        public Task PutDateTimeMinUtc() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("0001-01-01T00:00:00Z");
            return await new DatetimeClient(ClientDiagnostics, pipeline, host).PutUtcMinDateTimeAsync( value);
        });
    }
}
