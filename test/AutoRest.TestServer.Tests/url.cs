// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core.Pipeline;
using NUnit.Framework;
using url;
using url.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class UrlTests : TestServerTestBase
    {
        public UrlTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task UrlPathsStringEmpty() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).StringEmptyAsync());

        [Test]
        [Ignore("Not implemented https://github.com/Azure/autorest.csharp/issues/325")]
        public Task UrlPathsEnumValid() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).EnumValidAsync( UriColor.GreenColor));

        [Test]
        public Task UrlPathsStringUrlEncoded() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).StringUrlEncodedAsync());

        [Test]
        [Ignore("Don't have null-checks yet")]
        public Task UrlStringNullAsync() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).StringNullAsync( null));

        [Test]
        [Ignore("Wasn't able to find a server endpoint for this")]
        public Task UrlStringUnicodeAsync() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).StringUnicodeAsync());

        [Test]
        public Task UrlPathsArrayCSVInPath() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).ArrayCsvInPathAsync( new[] { "ArrayPath1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlPathsStringBase64Url() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).Base64UrlAsync( Encoding.UTF8.GetBytes("lorem")));

        [Test]
        public Task UrlPathsByteEmpty() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).ByteEmptyAsync());

        [Test]
        public Task UrlPathsByteMultiByte() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public void UrlByteNullAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await new PathsOperations("", ClientDiagnostics, null).ByteNullAsync(null));
        }

        [Test]
        [Ignore("Might not apply")]
        public Task UrlUrlDateNullAsync() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).DateNullAsync( new DateTime()));

        [Test]
        [Ignore("Might not apply")]
        public Task UrlEnumNullAsync() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).EnumNullAsync( new UriColor()));

        [Test]
        [Ignore("Might not apply")]
        public Task UrlDateTimeNullAsync() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).DateTimeNullAsync( new DateTime()));

        [Test]
        public Task UrlPathsDateValid() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).DateValidAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Too strict")]
        public Task UrlPathsDateTimeValid() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).DateTimeValidAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlPathsLongPositive() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).GetTenBillionAsync());

        [Test]
        public Task UrlPathsIntUnixTime() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).UnixTimeUrlAsync( DateTimeOffset.FromUnixTimeSeconds(1460505600L).UtcDateTime));

        [Test]
        public Task UrlPathsIntNegative() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlPathsIntPositive() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).GetIntOneMillionAsync());

        [Test]
        public Task UrlPathsBoolTrue() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).GetBooleanTrueAsync());

        [Test]
        public Task UrlPathsBoolFalse() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).GetBooleanFalseAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlPathsLongNegative() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).GetNegativeTenBillionAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Too strict")]
        public Task UrlPathsFloatPositive() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).FloatScientificPositiveAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Too strict")]
        public Task UrlPathsFloatNegative() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).FloatScientificNegativeAsync());

        [Test]
        public Task UrlPathsDoubleNegative() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlPathsDoublePositive() => TestStatus(async (host, pipeline) => await new PathsOperations(host, ClientDiagnostics, pipeline).DoubleDecimalPositiveAsync());


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
