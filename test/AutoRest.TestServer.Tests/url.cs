// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;
using url.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class UrlTests : TestServerTestBase
    {
        public UrlTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task UrlPathsStringEmpty() => TestStatus(async (host, pipeline) => await PathsOperations.StringEmptyAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsEnumValid() => TestStatus(async (host, pipeline) => await PathsOperations.EnumValidAsync(ClientDiagnostics, pipeline, UriColor.GreenColor, host));

        [Test]
        public Task UrlPathsStringUrlEncoded() => TestStatus(async (host, pipeline) => await PathsOperations.StringUrlEncodedAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Don't have null-checks yet")]
        public Task UrlStringNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.StringNullAsync(ClientDiagnostics, pipeline, null, host));

        [Test]
        [Ignore("Wasn't able to find a server endpoint for this")]
        public Task UrlStringUnicodeAsync() => TestStatus(async (host, pipeline) => await PathsOperations.StringUnicodeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsArrayCSVInPath() => TestStatus(async (host, pipeline) => await PathsOperations.ArrayCsvInPathAsync(ClientDiagnostics, pipeline, new[] { "ArrayPath1", "begin!*'();:@ &=+$,/?#[]end", "", "" }, host));

        [Test]
        public Task UrlPathsStringBase64Url() => TestStatus(async (host, pipeline) => await PathsOperations.Base64UrlAsync(ClientDiagnostics, pipeline, Encoding.UTF8.GetBytes("lorem"), host));

        [Test]
        public Task UrlPathsByteEmpty() => TestStatus(async (host, pipeline) => await PathsOperations.ByteEmptyAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsByteMultiByte() => TestStatus(async (host, pipeline) => await PathsOperations.ByteMultiByteAsync(ClientDiagnostics, pipeline, TestConstants.ByteArray, host));

        [Test]
        [Ignore("Don't have null-checks yet")]
        public Task UrlByteNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.ByteNullAsync(ClientDiagnostics, pipeline, null, host));

        [Test]
        [Ignore("Might not apply")]
        public Task UrlUrlDateNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.DateNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        [Ignore("Might not apply")]
        public Task UrlEnumNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.EnumNullAsync(ClientDiagnostics, pipeline, new UriColor(), host));

        [Test]
        [Ignore("Might not apply")]
        public Task UrlDateTimeNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.DateTimeNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        public Task UrlPathsDateValid() => TestStatus(async (host, pipeline) => await PathsOperations.DateValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Too strict")]
        public Task UrlPathsDateTimeValid() => TestStatus(async (host, pipeline) => await PathsOperations.DateTimeValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlPathsLongPositive() => TestStatus(async (host, pipeline) => await PathsOperations.GetTenBillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsIntUnixTime() => TestStatus(async (host, pipeline) => await PathsOperations.UnixTimeUrlAsync(ClientDiagnostics, pipeline, DateTimeOffset.FromUnixTimeSeconds(1460505600L).UtcDateTime, host));

        [Test]
        public Task UrlPathsIntNegative() => TestStatus(async (host, pipeline) => await PathsOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsIntPositive() => TestStatus(async (host, pipeline) => await PathsOperations.GetIntOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsBoolTrue() => TestStatus(async (host, pipeline) => await PathsOperations.GetBooleanTrueAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsBoolFalse() => TestStatus(async (host, pipeline) => await PathsOperations.GetBooleanFalseAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlPathsLongNegative() => TestStatus(async (host, pipeline) => await PathsOperations.GetNegativeTenBillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Too strict")]
        public Task UrlPathsFloatPositive() => TestStatus(async (host, pipeline) => await PathsOperations.FloatScientificPositiveAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Too strict")]
        public Task UrlPathsFloatNegative() => TestStatus(async (host, pipeline) => await PathsOperations.FloatScientificNegativeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsDoubleNegative() => TestStatus(async (host, pipeline) => await PathsOperations.DoubleDecimalNegativeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsDoublePositive() => TestStatus(async (host, pipeline) => await PathsOperations.DoubleDecimalPositiveAsync(ClientDiagnostics, pipeline, host));


        [Test]
        public void EnumGeneratedNonExtesibleWithoutModelAsString()
        {
            // modelAsString
            Assert.True(typeof(UriColor).IsEnum);
        }

        public override IEnumerable<string> AdditionalKnownScenarios { get; } = new string[] {"UrlPathsBoolFalse",
            "UrlPathsBoolTrue",
            "UrlPathsIntPositive",
            "UrlPathsIntNegative",
            "UrlPathsLongPositive",
            "UrlPathsLongNegative",
            "UrlPathsFloatPositive",
            "UrlPathsFloatNegative",
            "UrlPathsDoublePositive",
            "UrlPathsDoubleNegative",
            "UrlPathsStringUrlEncoded",
            "UrlPathsStringEmpty",
            "UrlPathsEnumValid",
            "UrlPathsByteMultiByte",
            "UrlPathsByteEmpty",
            "UrlPathsDateValid",
            "UrlPathsDateTimeValid",
            "UrlPathsStringBase64Url",
            "UrlPathsArrayCSVInPath",
            "UrlPathsIntUnixTime"
        };
    }
}
