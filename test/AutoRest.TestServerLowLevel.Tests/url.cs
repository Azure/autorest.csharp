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
        public Task UrlPathsStringEmpty() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().StringEmptyAsync());

        [Test]
        public Task UrlPathsEnumValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().EnumValidAsync( "green color"));

        [Test]
        public Task UrlPathsStringUrlEncoded() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().StringUrlEncodedAsync());

        [Test]
        public Task UrlPathsStringUrlNonEncoded() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().StringUrlNonEncodedAsync());

        // LLC - BUG - This test is failing?
        public Task UrlStringNullAsync() => Test(async (host) =>
        {
            var result = await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().StringNullAsync(null);
            Assert.Zero (result.Content.ToMemory().Length);
        }, ignoreScenario: true);

        [Test]
        public Task UrlPathsStringUnicode() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().StringUnicodeAsync());

        [Test]
        public Task UrlPathsArrayCSVInPath() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().ArrayCsvInPathAsync( new[] { "ArrayPath1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlPathsStringBase64Url() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().Base64UrlAsync( Encoding.UTF8.GetBytes("lorem")));

        [Test]
        public Task UrlPathsByteEmpty() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().ByteEmptyAsync());

        [Test]
        public Task UrlPathsByteMultiByte() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public void UrlByteNullAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await new AutoRestUrlTestServiceClient(null, null, null).GetPathsClient().ByteNullAsync(null));
        }

        [Test]
        public Task UrlPathsDateValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().DateValidAsync());

        [Test]
        public Task UrlPathsDateTimeValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().DateTimeValidAsync());

        [Test]
        public Task UrlPathsLongPositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().GetTenBillionAsync());

        [Test]
        public Task UrlPathsIntUnixTime() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().UnixTimeUrlAsync( DateTimeOffset.FromUnixTimeSeconds(1460505600L).UtcDateTime));

        [Test]
        public Task UrlPathsIntNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlPathsIntPositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().GetIntOneMillionAsync());

        [Test]
        public Task UrlPathsBoolTrue() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().GetBooleanTrueAsync());

        [Test]
        public Task UrlPathsBoolFalse() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().GetBooleanFalseAsync());

        [Test]
        public Task UrlPathsLongNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().GetNegativeTenBillionAsync());

        [Test]
        public Task UrlPathsFloatPositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().FloatScientificPositiveAsync());

        [Test]
        public Task UrlPathsFloatNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().FloatScientificNegativeAsync());

        [Test]
        public Task UrlPathsDoubleNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlPathsDoublePositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetPathsClient().DoubleDecimalPositiveAsync());
    }
}
