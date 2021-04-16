// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url_LowLevel;

namespace AutoRest.TestServer.Tests
{
    public class UrlTests : TestServerLowLevelTestBase
    {
        [Test]
        public Task UrlPathsStringEmpty() => TestStatus(async (host) => await new PathsClient(Key, host).StringEmptyAsync());

        [Test]
        public Task UrlPathsEnumValid() => TestStatus(async (host) => await new PathsClient(Key, host).EnumValidAsync( "green color"));

        [Test]
        public Task UrlPathsStringUrlEncoded() => TestStatus(async (host) => await new PathsClient(Key, host).StringUrlEncodedAsync());

        [Test]
        public Task UrlPathsStringUrlNonEncoded() => TestStatus(async (host) => await new PathsClient(Key, host).StringUrlNonEncodedAsync());

        // LLC - BUG - This test is failing?
        public Task UrlStringNullAsync() => Test(async (host) =>
        {
            var result = await new PathsClient(Key, host).StringNullAsync(null);
            Assert.Zero (result.Content.ToMemory().Length);
        }, ignoreScenario: true);

        [Test]
        public Task UrlPathsStringUnicode() => TestStatus(async (host) => await new PathsClient(Key, host).StringUnicodeAsync());

        [Test]
        public Task UrlPathsArrayCSVInPath() => TestStatus(async (host) => await new PathsClient(Key, host).ArrayCsvInPathAsync( new[] { "ArrayPath1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlPathsStringBase64Url() => TestStatus(async (host) => await new PathsClient(Key, host).Base64UrlAsync( Encoding.UTF8.GetBytes("lorem")));

        [Test]
        public Task UrlPathsByteEmpty() => TestStatus(async (host) => await new PathsClient(Key, host).ByteEmptyAsync());

        [Test]
        public Task UrlPathsByteMultiByte() => TestStatus(async (host) => await new PathsClient(Key, host).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public void UrlByteNullAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await new PathsClient(null, null).ByteNullAsync(null));
        }

        [Test]
        public Task UrlPathsDateValid() => TestStatus(async (host) => await new PathsClient(Key, host).DateValidAsync());

        [Test]
        public Task UrlPathsDateTimeValid() => TestStatus(async (host) => await new PathsClient(Key, host).DateTimeValidAsync());

        [Test]
        public Task UrlPathsLongPositive() => TestStatus(async (host) => await new PathsClient(Key, host).GetTenBillionAsync());

        [Test]
        public Task UrlPathsIntUnixTime() => TestStatus(async (host) => await new PathsClient(Key, host).UnixTimeUrlAsync( DateTimeOffset.FromUnixTimeSeconds(1460505600L).UtcDateTime));

        [Test]
        public Task UrlPathsIntNegative() => TestStatus(async (host) => await new PathsClient(Key, host).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlPathsIntPositive() => TestStatus(async (host) => await new PathsClient(Key, host).GetIntOneMillionAsync());

        [Test]
        public Task UrlPathsBoolTrue() => TestStatus(async (host) => await new PathsClient(Key, host).GetBooleanTrueAsync());

        [Test]
        public Task UrlPathsBoolFalse() => TestStatus(async (host) => await new PathsClient(Key, host).GetBooleanFalseAsync());

        [Test]
        public Task UrlPathsLongNegative() => TestStatus(async (host) => await new PathsClient(Key, host).GetNegativeTenBillionAsync());

        [Test]
        public Task UrlPathsFloatPositive() => TestStatus(async (host) => await new PathsClient(Key, host).FloatScientificPositiveAsync());

        [Test]
        public Task UrlPathsFloatNegative() => TestStatus(async (host) => await new PathsClient(Key, host).FloatScientificNegativeAsync());

        [Test]
        public Task UrlPathsDoubleNegative() => TestStatus(async (host) => await new PathsClient(Key, host).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlPathsDoublePositive() => TestStatus(async (host) => await new PathsClient(Key, host).DoubleDecimalPositiveAsync());
    }
}
