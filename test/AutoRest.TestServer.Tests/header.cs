// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using header;
using header.Models.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    [IgnoreOnTestServer(TestServerVersion.V2, "Too many missing or too strict recordings")]
    public class HeaderTests : TestServerTestBase
    {
        private static readonly DateTimeOffset MinDate = new DateTimeOffset(0001, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset ValidDate = new DateTimeOffset(2010, 1, 1, 12, 34, 56, TimeSpan.Zero);
        public HeaderTests(TestServerVersion version) : base(version, "header") { }

        [Test]
        public Task HeaderParameterExistingKey() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamExistingKeyAsync( "overwrite"));

        [Test]
        public Task HeaderResponseExistingKey() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseExistingKeyAsync();
            Assert.AreEqual("overwrite", response.Headers.UserAgent);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Azure.Core doesn't send Content-Type without having some content")]
        public Task HeaderParameterProtectedKey() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamProtectedKeyAsync( "text/html"));

        [Test]
        public Task HeaderResponseProtectedKey() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseProtectedKeyAsync();
            Assert.AreEqual("text/html; charset=utf-8", response.Headers.ContentType);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterIntegerNegative() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamIntegerAsync( scenario: "negative", -2));

        [Test]
        public Task HeaderParameterIntegerPositive() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamIntegerAsync( scenario: "positive", 1));

        [Test]
        public Task HeaderResponseIntegerPositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseIntegerAsync( scenario: "positive");
            Assert.AreEqual(1, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseIntegerNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseIntegerAsync( scenario: "negative");
            Assert.AreEqual(-2, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterLongPositive() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamLongAsync( scenario: "positive", 105));

        [Test]
        public Task HeaderParameterLongNegative() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamLongAsync( scenario: "negative", -2));

        [Test]
        public Task HeaderResponseLongPositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseLongAsync( scenario: "positive");
            Assert.AreEqual(105, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseLongNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseLongAsync( scenario: "negative");
            Assert.AreEqual(-2, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterFloatPositive() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamFloatAsync( scenario: "positive", 0.07F));

        [Test]
        public Task HeaderParameterFloatNegative() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamFloatAsync( scenario: "negative", -3));

        [Test]
        public Task HeaderResponseFloatPositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseFloatAsync( scenario: "positive");
            Assert.AreEqual(0.0700000003f, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseFloatNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseFloatAsync( scenario: "negative");
            Assert.AreEqual(-3f, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDoublePositive() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDoubleAsync( scenario: "positive", 7e120));

        [Test]
        public Task HeaderParameterDoubleNegative() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDoubleAsync( scenario: "negative", -3.0));

        [Test]
        public Task HeaderResponseDoublePositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDoubleAsync( scenario: "positive");
            Assert.AreEqual(7.0000000000000001E+120d, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDoubleNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDoubleAsync( scenario: "negative");
            Assert.AreEqual(-3, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterBoolFalse() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamBoolAsync( scenario: "false", false));

        [Test]
        public Task HeaderParameterBoolTrue() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamBoolAsync( scenario: "true", true));

        [Test]
        public Task HeaderResponseBoolTrue() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseBoolAsync( scenario: "true");
            Assert.AreEqual(true, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseBoolFalse() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseBoolAsync( scenario: "false");
            Assert.AreEqual(false, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterStringValid() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamStringAsync( scenario: "valid", "The quick brown fox jumps over the lazy dog"));

        [Test]
        public Task HeaderParameterStringEmpty() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamStringAsync( scenario: "empty", ""));

        [Test]
        public Task HeaderParameterStringNull() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamStringAsync( scenario: "null", null));

        [Test]
        public Task HeaderResponseStringValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseStringAsync( scenario: "valid");
            Assert.AreEqual("The quick brown fox jumps over the lazy dog", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseStringNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseStringAsync( scenario: "null");
            Assert.AreEqual("null", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseStringEmpty() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseStringAsync( scenario: "empty");
            Assert.AreEqual("", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDateValid() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDateAsync( scenario: "valid", new DateTime(2010, 1, 1)));

        [Test]
        public Task HeaderParameterDateMin() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDateAsync( scenario: "min", new DateTime(0001, 1, 1)));

        [Test]
        public Task HeaderResponseDateValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDateAsync( scenario: "valid");
            Assert.AreEqual(DateTimeOffset.Parse("2010-01-01"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDateMin() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDateAsync( scenario: "min");
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDateTimeValid() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDatetimeAsync( scenario: "valid", ValidDate));

        [Test]
        public Task HeaderParameterDateTimeMin() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDatetimeAsync( scenario: "min", MinDate));

        [Test]
        public Task HeaderResponseDateTimeValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDatetimeAsync( scenario: "valid");
            Assert.AreEqual(DateTimeOffset.Parse("2010-01-01T12:34:56Z"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDateTimeMin() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDatetimeAsync( scenario: "min");
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01T00:00:00Z"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDatetimeRfc1123Async( scenario: "valid", ValidDate));

        [Test]
        public Task HeaderParameterDateTimeRfc1123Min() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDatetimeRfc1123Async( scenario: "min", MinDate));

        [Test]
        public Task HeaderResponseDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDatetimeRfc1123Async( scenario: "valid");
            Assert.AreEqual(DateTimeOffset.Parse("Fri, 01 Jan 2010 12:34:56 GMT"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDateTimeRfc1123Min() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDatetimeRfc1123Async( scenario: "min");
            Assert.AreEqual(DateTimeOffset.Parse("Mon, 01 Jan 0001 00:00:00 GMT"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDurationValid() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamDurationAsync( scenario: "valid", XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));

        [Test]
        public Task HeaderResponseDurationValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseDurationAsync( scenario: "valid");
            Assert.AreEqual(new TimeSpan(123, 22, 14, 12, 11), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterBytesValid() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamByteAsync( scenario: "valid", TestConstants.ByteArray));

        [Test]
        public Task HeaderResponseBytesValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseByteAsync( scenario: "valid");
            Assert.AreEqual(Convert.FromBase64String("5ZWK6b2E5LiC54ub54uc76ex76Ss76ex76iM76ip"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterEnumValid() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamEnumAsync( scenario: "valid", GreyscaleColors.GREY));

        [Test]
        public Task HeaderParameterEnumNull() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).ParamEnumAsync( scenario: "null", null));

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/339")]
        public Task HeaderResponseEnumValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseEnumAsync( scenario: "valid");
            Assert.AreEqual("GREY", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/339")]
        public Task HeaderResponseEnumNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await new HeaderOperations(host, ClientDiagnostics, pipeline).ResponseEnumAsync( scenario: "null");
            Assert.AreEqual("", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Azure.Core doesn't provide the feature yet")]
        public Task CustomHeaderInRequest() => TestStatus(async (host, pipeline) => await new HeaderOperations(host, ClientDiagnostics, pipeline).CustomRequestIdAsync());
    }
}
