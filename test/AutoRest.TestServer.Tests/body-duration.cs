// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using body_duration;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyDurationTest: TestServerTestBase
    {
        public BodyDurationTest(TestServerVersion version) : base(version, "duration") { }

        [Test]
        public Task GetDurationInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<FormatException>(async () =>
                await new DurationOperations(ClientDiagnostics, pipeline, host).GetInvalidAsync());
        });

        [Test]
        [Ignore("Test is commented out in test server scripts")]
        public Task GetDurationNegative() => Test(async (host, pipeline) => { await Task.FromException(new Exception()); });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/300")]
        public Task GetDurationNull() => Test(async (host, pipeline) =>
        {
            var result = await new DurationOperations(ClientDiagnostics, pipeline, host).GetNullAsync();
            Assert.AreEqual(null, result.Value);
        });

        [Test]
        public Task GetDurationPositive() => Test(async (host, pipeline) =>
        {
            var result = await new DurationOperations(ClientDiagnostics, pipeline, host).GetPositiveDurationAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P3Y6M4DT12H30M5S"), result.Value);
        });

        [Test]
        [Ignore("Test is commented out in test server scripts")]
        public Task PutDurationNegative() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task PutDurationPositive() => TestStatus(async (host, pipeline) =>
        {
            var value = XmlConvert.ToTimeSpan("P123DT22H14M12.011S");
            return await new DurationOperations(ClientDiagnostics, pipeline, host).PutPositiveDurationAsync( value);
        });
    }
}
