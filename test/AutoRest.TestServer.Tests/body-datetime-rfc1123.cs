// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_datetime_rfc1123;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyDateTimeRfc1123Test: TestServerTestBase
    {
        public BodyDateTimeRfc1123Test(TestServerVersion version) : base(version, "datetime-rfc1123") { }

        [Test]
        public Task GetDateTimeRfc1123Invalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () =>
                await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).GetInvalidAsync());
        });

        [Test]
        public Task GetDateTimeRfc1123MaxUtcLowercase() => Test(async (host, pipeline) =>
        {
            var result = await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).GetUtcLowercaseMaxDateTimeAsync();
            Assert.AreEqual(DateTimeOffset.Parse("fri, 31 dec 9999 23:59:59 gmt"), result.Value);
        });

        [Test]
        public Task GetDateTimeRfc1123MaxUtcUppercase() => Test(async (host, pipeline) =>
        {
            var result = await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).GetUtcUppercaseMaxDateTimeAsync();
            Assert.AreEqual(DateTimeOffset.Parse("FRI, 31 DEC 9999 23:59:59 GMT"), result.Value);
        });

        [Test]
        public Task GetDateTimeRfc1123MinUtc() => Test(async (host, pipeline) =>
        {
            var result = await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).GetUtcMinDateTimeAsync();
            Assert.AreEqual(DateTimeOffset.Parse("Mon, 01 Jan 0001 00:00:00 GMT"), result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/300")]
        public Task GetDateTimeRfc1123Null() => Test(async (host, pipeline) =>
        {
            var result = await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).GetNullAsync();
            Assert.AreEqual(null, result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/346")]
        public Task GetDateTimeRfc1123Overflow() => Test(async (host, pipeline) =>
        {
            var result = await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).GetOverflowAsync();
            Assert.AreEqual(DateTimeOffset.Parse("Sat, 1 Jan 10000 00:00:00 GMT"), result.Value);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/346")]
        public Task GetDateTimeRfc1123Underflow() => Test(async (host, pipeline) =>
        {
            var result = await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).GetUnderflowAsync();
            Assert.AreEqual(DateTimeOffset.Parse("Tue, 00 Jan 0000 00:00:00 GMT"), result.Value);
        });

        [Test]
        public Task PutDateTimeRfc1123Max() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("Fri, 31 Dec 9999 23:59:59 GMT");
            return await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).PutUtcMaxDateTimeAsync( value);
        });

        [Test]
        public Task PutDateTimeRfc1123Min() => TestStatus(async (host, pipeline) =>
        {
            var value = DateTimeOffset.Parse("Mon, 01 Jan 0001 00:00:00 GMT");
            return await new Datetimerfc1123Operations(ClientDiagnostics, pipeline, host).PutUtcMinDateTimeAsync( value);
        });
    }
}
