// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;

namespace AutoRest.TestServer.Tests
{
    public class UrlTests : TestServerLowLevelTestBase
    {
        public UrlTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task UrlPathsStringEmpty() => TestStatus(async (host, key) => await new PathsClient(key, host).StringEmptyAsync());

        [Test]
        public Task UrlPathsEnumValid() => TestStatus(async (host, key) => await new PathsClient(key, host).EnumValidAsync( "green color"));

        [Test]
        public Task UrlPathsStringUrlEncoded() => TestStatus(async (host, key) => await new PathsClient(key, host).StringUrlEncodedAsync());

        [Test]
        public Task UrlPathsStringUrlNonEncoded() => TestStatus(async (host, key) => await new PathsClient(key, host).StringUrlNonEncodedAsync());

        // LLC - BUG - This test is failing?
        public Task UrlStringNullAsync() => Test(async (host, key) =>
        {
            var result = await new PathsClient(key, host).StringNullAsync(null);
            Assert.Zero (result.Content.ToMemory().Length);
        }, ignoreScenario: true);

        [Test]
        public Task UrlPathsStringUnicode() => TestStatus(async (host, key) => await new PathsClient(key, host).StringUnicodeAsync());

        [Test]
        public Task UrlPathsArrayCSVInPath() => TestStatus(async (host, key) => await new PathsClient(key, host).ArrayCsvInPathAsync( new[] { "ArrayPath1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlPathsStringBase64Url() => TestStatus(async (host, key) => await new PathsClient(key, host).Base64UrlAsync( Encoding.UTF8.GetBytes("lorem")));

        [Test]
        public Task UrlPathsByteEmpty() => TestStatus(async (host, key) => await new PathsClient(key, host).ByteEmptyAsync());

        [Test]
        public Task UrlPathsByteMultiByte() => TestStatus(async (host, key) => await new PathsClient(key, host).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public void UrlByteNullAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await new PathsClient(null, null).ByteNullAsync(null));
        }

        [Test]
        public Task UrlPathsDateValid() => TestStatus(async (host, key) => await new PathsClient(key, host).DateValidAsync());

        [Test]
        public Task UrlPathsDateTimeValid() => TestStatus(async (host, key) => await new PathsClient(key, host).DateTimeValidAsync());

        [Test]
        public Task UrlPathsLongPositive() => TestStatus(async (host, key) => await new PathsClient(key, host).GetTenBillionAsync());

        [Test]
        public Task UrlPathsIntUnixTime() => TestStatus(async (host, key) => await new PathsClient(key, host).UnixTimeUrlAsync( DateTimeOffset.FromUnixTimeSeconds(1460505600L).UtcDateTime));

        [Test]
        public Task UrlPathsIntNegative() => TestStatus(async (host, key) => await new PathsClient(key, host).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlPathsIntPositive() => TestStatus(async (host, key) => await new PathsClient(key, host).GetIntOneMillionAsync());

        [Test]
        public Task UrlPathsBoolTrue() => TestStatus(async (host, key) => await new PathsClient(key, host).GetBooleanTrueAsync());

        [Test]
        public Task UrlPathsBoolFalse() => TestStatus(async (host, key) => await new PathsClient(key, host).GetBooleanFalseAsync());

        [Test]
        public Task UrlPathsLongNegative() => TestStatus(async (host, key) => await new PathsClient(key, host).GetNegativeTenBillionAsync());

        [Test]
        public Task UrlPathsFloatPositive() => TestStatus(async (host, key) => await new PathsClient(key, host).FloatScientificPositiveAsync());

        [Test]
        public Task UrlPathsFloatNegative() => TestStatus(async (host, key) => await new PathsClient(key, host).FloatScientificNegativeAsync());

        [Test]
        public Task UrlPathsDoubleNegative() => TestStatus(async (host, key) => await new PathsClient(key, host).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlPathsDoublePositive() => TestStatus(async (host, key) => await new PathsClient(key, host).DoubleDecimalPositiveAsync());

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
            "UrlPathsStringUrlNonEncoded",
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
