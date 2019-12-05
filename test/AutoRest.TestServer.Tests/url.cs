// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [Ignore("Wrong url")]
        public Task UrlPathsStringUrlEncoded() => TestStatus(async (host, pipeline) => await PathsOperations.StringUrlEncodedAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlStringNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.StringNullAsync(ClientDiagnostics, pipeline, "", host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlStringUnicodeAsync() => TestStatus(async (host, pipeline) => await PathsOperations.StringUnicodeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlPathsArrayCSVInPath() => TestStatus(async (host, pipeline) => await PathsOperations.ArrayCsvInPathAsync(ClientDiagnostics, pipeline, new[] { "a", "b", "c" }, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlPathsStringBase64Url() => TestStatus(async (host, pipeline) => await PathsOperations.Base64UrlAsync(ClientDiagnostics, pipeline, new byte[] { 1, 2, 3 }, host));

        [Test]
        public Task UrlPathsByteEmpty() => TestStatus(async (host, pipeline) => await PathsOperations.ByteEmptyAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlPathsByteMultiByte() => TestStatus(async (host, pipeline) => await PathsOperations.ByteMultiByteAsync(ClientDiagnostics, pipeline, new byte[] { 1, 2, 3 }, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlByteNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.ByteNullAsync(ClientDiagnostics, pipeline, new byte[0], host));

        [Test]
        [Ignore("Might not apply")]
        public Task UrlUrlDateNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.DateNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        [Ignore("Might not apply")]
        public Task UrlEnumNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.EnumNullAsync(ClientDiagnostics, pipeline, new UriColor(), host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlDateTimeNullAsync() => TestStatus(async (host, pipeline) => await PathsOperations.DateTimeNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        public Task UrlPathsDateValid() => TestStatus(async (host, pipeline) => await PathsOperations.DateValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlPathsDateTimeValid() => TestStatus(async (host, pipeline) => await PathsOperations.DateTimeValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsLongPositive() => TestStatus(async (host, pipeline) => await PathsOperations.GetTenBillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UrlPathsIntUnixTime() => TestStatus(async (host, pipeline) => await PathsOperations.UnixTimeUrlAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        public Task UrlPathsIntNegative() => TestStatus(async (host, pipeline) => await PathsOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsIntPositive() => TestStatus(async (host, pipeline) => await PathsOperations.GetIntOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsBoolTrue() => TestStatus(async (host, pipeline) => await PathsOperations.GetBooleanTrueAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsBoolFalse() => TestStatus(async (host, pipeline) => await PathsOperations.GetBooleanFalseAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsLongNegative() => TestStatus(async (host, pipeline) => await PathsOperations.GetNegativeTenBillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Too strict")]
        public Task UrlPathsFloatPositive() => TestStatus(async (host, pipeline) => await PathsOperations.FloatScientificPositiveAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsFloatNegative() => TestStatus(async (host, pipeline) => await PathsOperations.FloatScientificNegativeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsDoubleNegative() => TestStatus(async (host, pipeline) => await PathsOperations.DoubleDecimalNegativeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task UrlPathsDoublePositive() => TestStatus(async (host, pipeline) => await PathsOperations.DoubleDecimalPositiveAsync(ClientDiagnostics, pipeline, host));

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
