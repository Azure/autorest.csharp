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
        public Task HeaderParameterExistingKey() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamExistingKeyAsync(ClientDiagnostics, pipeline, "overwrite", host: host));

        [Test]
        public Task HeaderResponseExistingKey() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseExistingKeyAsync(ClientDiagnostics, pipeline, host: host);
            Assert.AreEqual("overwrite", response.Headers.UserAgent);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Azure.Core doesn't send Content-Type without having some content")]
        public Task HeaderParameterProtectedKey() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamProtectedKeyAsync(ClientDiagnostics, pipeline, "text/html", host: host));

        [Test]
        public Task HeaderResponseProtectedKey() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseProtectedKeyAsync(ClientDiagnostics, pipeline, host: host);
            Assert.AreEqual("text/html; charset=utf-8", response.Headers.ContentType);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterIntegerNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamIntegerAsync(ClientDiagnostics, pipeline, scenario: "negative", -2, host: host));

        [Test]
        public Task HeaderParameterIntegerPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamIntegerAsync(ClientDiagnostics, pipeline, scenario: "positive", 1, host: host));

        [Test]
        public Task HeaderResponseIntegerPositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseIntegerAsync(ClientDiagnostics, pipeline, scenario: "positive", host: host);
            Assert.AreEqual(1, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseIntegerNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseIntegerAsync(ClientDiagnostics, pipeline, scenario: "negative", host: host);
            Assert.AreEqual(-2, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterLongPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamLongAsync(ClientDiagnostics, pipeline, scenario: "positive", 105, host: host));

        [Test]
        public Task HeaderParameterLongNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamLongAsync(ClientDiagnostics, pipeline, scenario: "negative", -2, host: host));

        [Test]
        public Task HeaderResponseLongPositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseLongAsync(ClientDiagnostics, pipeline, scenario: "positive", host: host);
            Assert.AreEqual(105, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseLongNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseLongAsync(ClientDiagnostics, pipeline, scenario: "negative", host: host);
            Assert.AreEqual(-2, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterFloatPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamFloatAsync(ClientDiagnostics, pipeline, scenario: "positive", 0.07F, host: host));

        [Test]
        public Task HeaderParameterFloatNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamFloatAsync(ClientDiagnostics, pipeline, scenario: "negative", -3, host: host));

        [Test]
        public Task HeaderResponseFloatPositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseFloatAsync(ClientDiagnostics, pipeline, scenario: "positive", host: host);
            Assert.AreEqual(0.0700000003f, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseFloatNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseFloatAsync(ClientDiagnostics, pipeline, scenario: "negative",  host: host);
            Assert.AreEqual(-3f, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDoublePositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDoubleAsync(ClientDiagnostics, pipeline, scenario: "positive", 7e120, host: host));

        [Test]
        public Task HeaderParameterDoubleNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDoubleAsync(ClientDiagnostics, pipeline, scenario: "negative", -3.0, host: host));

        [Test]
        public Task HeaderResponseDoublePositive() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDoubleAsync(ClientDiagnostics, pipeline, scenario: "positive", host: host);
            Assert.AreEqual(7.0000000000000001E+120d, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDoubleNegative() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDoubleAsync(ClientDiagnostics, pipeline, scenario: "negative", host: host);
            Assert.AreEqual(-3, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterBoolFalse() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamBoolAsync(ClientDiagnostics, pipeline, scenario: "false", false, host: host));

        [Test]
        public Task HeaderParameterBoolTrue() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamBoolAsync(ClientDiagnostics, pipeline, scenario: "true", true, host: host));

        [Test]
        public Task HeaderResponseBoolTrue() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseBoolAsync(ClientDiagnostics, pipeline, scenario: "true", host: host);
            Assert.AreEqual(true, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseBoolFalse() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseBoolAsync(ClientDiagnostics, pipeline, scenario: "false", host: host);
            Assert.AreEqual(false, response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterStringValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamStringAsync(ClientDiagnostics, pipeline, scenario: "valid", "The quick brown fox jumps over the lazy dog", host: host));

        [Test]
        public Task HeaderParameterStringEmpty() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamStringAsync(ClientDiagnostics, pipeline, scenario: "empty", "", host: host));

        [Test]
        public Task HeaderParameterStringNull() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamStringAsync(ClientDiagnostics, pipeline, scenario: "null", null, host: host));

        [Test]
        public Task HeaderResponseStringValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseStringAsync(ClientDiagnostics, pipeline, scenario: "valid", host: host);
            Assert.AreEqual("The quick brown fox jumps over the lazy dog", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseStringNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseStringAsync(ClientDiagnostics, pipeline, scenario: "null", host: host);
            Assert.AreEqual("null", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseStringEmpty() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseStringAsync(ClientDiagnostics, pipeline, scenario: "empty", host: host);
            Assert.AreEqual("", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDateValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDateAsync(ClientDiagnostics, pipeline, scenario: "valid", new DateTime(2010, 1, 1), host: host));

        [Test]
        public Task HeaderParameterDateMin() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDateAsync(ClientDiagnostics, pipeline, scenario: "min", new DateTime(0001, 1, 1), host: host));

        [Test]
        public Task HeaderResponseDateValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDateAsync(ClientDiagnostics, pipeline, scenario: "valid", host: host);
            Assert.AreEqual(DateTimeOffset.Parse("2010-01-01"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDateMin() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDateAsync(ClientDiagnostics, pipeline, scenario: "min", host: host);
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDateTimeValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeAsync(ClientDiagnostics, pipeline, scenario: "valid", ValidDate, host: host));

        [Test]
        public Task HeaderParameterDateTimeMin() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeAsync(ClientDiagnostics, pipeline, scenario: "min", MinDate, host: host));

        [Test]
        public Task HeaderResponseDateTimeValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDatetimeAsync(ClientDiagnostics, pipeline, scenario: "valid", host: host);
            Assert.AreEqual(DateTimeOffset.Parse("2010-01-01T12:34:56Z"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDateTimeMin() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDatetimeAsync(ClientDiagnostics, pipeline, scenario: "min", host: host);
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01T00:00:00Z"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeRfc1123Async(ClientDiagnostics, pipeline, scenario: "valid", ValidDate, host: host));

        [Test]
        public Task HeaderParameterDateTimeRfc1123Min() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeRfc1123Async(ClientDiagnostics, pipeline, scenario: "min", MinDate, host: host));

        [Test]
        public Task HeaderResponseDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDatetimeRfc1123Async(ClientDiagnostics, pipeline, scenario: "valid", host: host);
            Assert.AreEqual(DateTimeOffset.Parse("Fri, 01 Jan 2010 12:34:56 GMT"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderResponseDateTimeRfc1123Min() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDatetimeRfc1123Async(ClientDiagnostics, pipeline, scenario: "min", host: host);
            Assert.AreEqual(DateTimeOffset.Parse("Mon, 01 Jan 0001 00:00:00 GMT"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterDurationValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDurationAsync(ClientDiagnostics, pipeline, scenario: "valid", XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), host: host));

        [Test]
        public Task HeaderResponseDurationValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseDurationAsync(ClientDiagnostics, pipeline, scenario: "valid", host: host);
            Assert.AreEqual(new TimeSpan(123, 22, 14, 12, 11), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterBytesValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamByteAsync(ClientDiagnostics, pipeline, scenario: "valid", TestConstants.ByteArray, host: host));

        [Test]
        public Task HeaderResponseBytesValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseByteAsync(ClientDiagnostics, pipeline, scenario: "valid", host: host);
            Assert.AreEqual(Convert.FromBase64String("5ZWK6b2E5LiC54ub54uc76ex76Ss76ex76iM76ip"), response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        public Task HeaderParameterEnumValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamEnumAsync(ClientDiagnostics, pipeline, scenario: "valid", GreyscaleColors.GREY, host: host));

        [Test]
        public Task HeaderParameterEnumNull() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamEnumAsync(ClientDiagnostics, pipeline, scenario: "null", null, host: host));

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/339")]
        public Task HeaderResponseEnumValid() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseEnumAsync(ClientDiagnostics, pipeline, scenario: "valid", host: host);
            Assert.AreEqual("GREY", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/339")]
        public Task HeaderResponseEnumNull() => TestStatus(async (host, pipeline) =>
        {
            var response = await HeaderOperations.ResponseEnumAsync(ClientDiagnostics, pipeline, scenario: "null", host: host);
            Assert.AreEqual("", response.Headers.Value);
            return response.GetRawResponse();
        });

        [Test]
        [Ignore("Azure.Core doesn't provide the feature yet")]
        public Task CustomHeaderInRequest() => TestStatus(async (host, pipeline) => await HeaderOperations.CustomRequestIdAsync(ClientDiagnostics, pipeline, host: host));
    }
}
