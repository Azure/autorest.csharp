// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public Task PutFloatBigScientificNotation() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutBigFloatAsync( 3.402823e+20f));

        [Test]
        public Task PutFloatSmallScientificNotation() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutSmallFloatAsync( 3.402823e-20f));

        [Test]
        public Task PutDoubleSmallScientificNotation() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutSmallDoubleAsync( 2.5976931e-101d));

        [Test]
        public Task PutDoubleBigScientificNotation() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutBigDoubleAsync( 2.5976931e+101d));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task PutDecimalBigPositiveDecimal() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutBigDecimalPositiveDecimalAsync());

        [Test]
        [Ignore("Value 2.5976931e+101 is out of range of C# decimal")]
        public Task PutDecimalBig() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutBigDecimalAsync( 2.5976931e+10m));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Match too strict")]
        public Task PutDecimalBigNegativeDecimal() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutBigDecimalNegativeDecimalAsync());

        [Test]
        [Ignore("Value 2.5976931e-101m is out of range of C# decimal")]
        public Task PutDecimalSmall() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutSmallDecimalAsync( 2.5976931e-101m));

        [Test]
        public Task PutDoubleBigNegativeDecimal() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutBigDoubleNegativeDecimalAsync());

        [Test]
        public Task PutDoubleBigPositiveDecimal() => TestStatus(async (host, pipeline) => await new NumberOperations(host, ClientDiagnostics, pipeline).PutBigDoublePositiveDecimalAsync());

        [Test]
        public Task GetDecimalInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new NumberOperations(host, ClientDiagnostics, pipeline).GetInvalidDecimalAsync());
        });

        [Test]
        public Task GetDoubleInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new NumberOperations(host, ClientDiagnostics, pipeline).GetInvalidDoubleAsync());
        });

        [Test]
        public Task GetFloatInvalid() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync(Is.InstanceOf<JsonException>(), async () => await new NumberOperations(host, ClientDiagnostics, pipeline).GetInvalidFloatAsync());
        });

        [Test]
        [Ignore("Value 2.5976931e+101 is out of range of C# decimal")]
        public Task GetDecimalBig() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetBigDecimalAsync();
            Assert.AreEqual(2.5976931e+101, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetDecimalBigNegativeDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetBigDecimalNegativeDecimalAsync();
            Assert.AreEqual(-99999999.99m, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetDecimalBigPositiveDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetBigDecimalPositiveDecimalAsync();
            Assert.AreEqual(99999999.99m, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Value is out of range of C# decimal")]
        public Task GetDecimalSmall() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetSmallDecimalAsync();
            Assert.AreEqual(2.5976931e-101m, response.Value);
            return response.GetRawResponse();
        });


        [Test]
        public Task GetDoubleBigScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetBigDoubleAsync();
            Assert.AreEqual(2.5976931E+101d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetDoubleBigNegativeDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetBigDoubleNegativeDecimalAsync();
            Assert.AreEqual(-99999999.989999995d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetDoubleBigPositiveDecimal() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetBigDoublePositiveDecimalAsync();
            Assert.AreEqual(99999999.989999995d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetDoubleSmallScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetSmallDoubleAsync();
            Assert.AreEqual(2.5976931000000001E-101d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetFloatBigScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetBigFloatAsync();
            Assert.AreEqual(3.40282312E+20f, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task GetFloatSmallScientificNotation() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetSmallFloatAsync();
            Assert.AreEqual(3.4028229999999997E-20d, response.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("No support for null results")]
        public Task GetNumberNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await new NumberOperations(host, ClientDiagnostics, pipeline).GetNullAsync();
            Assert.Null(response.Value);
            return response.GetRawResponse();
        });
    }
}
