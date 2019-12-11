// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_number;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class NumberTest : TestServerTestBase
    {
        public NumberTest(TestServerVersion version) : base(version, "number") { }

        [Test]
        public Task putFloatBigScientificNotation() => TestStatus(async (host, pipeline) => await NumberOperations.PutBigFloatAsync(ClientDiagnostics, pipeline, 3.402823e+20f, host));

        [Test]
        public Task putFloatSmallScientificNotation() => TestStatus(async (host, pipeline) => await NumberOperations.PutSmallFloatAsync(ClientDiagnostics, pipeline, 3.402823e-20f, host));

        [Test]
        public Task putDoubleSmallScientificNotation() => TestStatus(async (host, pipeline) => await NumberOperations.PutSmallDoubleAsync(ClientDiagnostics, pipeline, 2.5976931e-101d, host));

        [Test]
        public Task putDoubleBigScientificNotation() => TestStatus(async (host, pipeline) => await NumberOperations.PutBigDoubleAsync(ClientDiagnostics, pipeline, 2.5976931e+101d, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task putDecimalBigPositiveDecimal() => TestStatus(async (host, pipeline) => await NumberOperations.PutBigDecimalPositiveDecimalAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Value 2.5976931e+101 is out of range of C# decimal")]
        public Task putDecimalBig() => TestStatus(async (host, pipeline) => await NumberOperations.PutBigDecimalAsync(ClientDiagnostics, pipeline, 2.5976931e+10m, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task putDecimalBigNegativeDecimal() => TestStatus(async (host, pipeline) => await NumberOperations.PutBigDecimalNegativeDecimalAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Value 2.5976931e-101m is out of range of C# decimal")]
        public Task putDecimalSmall() => TestStatus(async (host, pipeline) => await NumberOperations.PutSmallDecimalAsync(ClientDiagnostics, pipeline, 2.5976931e-101m, host));

        [Test]
        public Task putDoubleBigNegativeDecimal() => TestStatus(async (host, pipeline) => await NumberOperations.PutBigDoubleNegativeDecimalAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task putDoubleBigPositiveDecimal() => TestStatus(async (host, pipeline) => await NumberOperations.PutBigDoublePositiveDecimalAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task getDecimalInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await NumberOperations.GetInvalidDecimalAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task getDoubleInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await NumberOperations.GetInvalidDoubleAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        public Task getFloatInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await NumberOperations.GetInvalidFloatAsync(ClientDiagnostics, pipeline, host));
        });

        [Test]
        [Ignore("Value 2.5976931e+101 is out of range of C# decimal")]
        public Task getDecimalBig() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetBigDecimalAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(2.5976931e+101, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task getDecimalBigNegativeDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetBigDecimalNegativeDecimalAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(-99999999.99m, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task getDecimalBigPositiveDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetBigDecimalPositiveDecimalAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(99999999.99m, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Value is out of range of C# decimal")]
        public Task getDecimalSmall() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetSmallDecimalAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(2.5976931e-101m, response.Value);
            return response.GetRawResponse();
        });


        [Test]
        public Task getDoubleBigScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetBigDoubleAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(2.5976931E+101d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task getDoubleBigNegativeDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetBigDoubleNegativeDecimalAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(-99999999.989999995d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task getDoubleBigPositiveDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetBigDoublePositiveDecimalAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(99999999.989999995d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task getDoubleSmallScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetSmallDoubleAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(2.5976931000000001E-101d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task getFloatBigScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetBigFloatAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(3.40282312E+20f, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task getFloatSmallScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetSmallFloatAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(3.4028229999999997E-20d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("No support for null results")]
        public Task getNumberNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await NumberOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.Null(response.Value);
            return response.GetRawResponse();
        });
    }
}
