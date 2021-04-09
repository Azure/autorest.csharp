// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url_LowLevel;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests : TestServerLowLevelTestBase
    {
        public UrlQueryTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host) => await new QueriesClient(Key, host).GetBooleanTrueAsync());

        [Test]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host) => await new QueriesClient(Key, host).GetBooleanFalseAsync());

        [Test]
        public Task UrlQueriesBoolNull() => TestStatus(async (host) => await new QueriesClient(Key, host).GetBooleanNullAsync( null));

        [Test]
        public Task UrlQueriesIntPositive() => TestStatus(async (host) => await new QueriesClient(Key, host).GetIntOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNegative() => TestStatus(async (host) => await new QueriesClient(Key, host).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNull() => TestStatus(async (host) => await new QueriesClient(Key, host).GetIntNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongPositive() => TestStatus(async (host) => await new QueriesClient(Key, host).GetTenBillionAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongNegative() => TestStatus(async (host) => await new QueriesClient(Key, host).GetNegativeTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNull() => TestStatus(async (host) => await new QueriesClient(Key, host).GetLongNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host) => await new QueriesClient(Key, host).FloatScientificPositiveAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host) => await new QueriesClient(Key, host).FloatScientificNegativeAsync());

        [Test]
        public Task UrlQueriesFloatNull() => TestStatus(async (host) => await new QueriesClient(Key, host).FloatNullAsync( null));

        [Test]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host) => await new QueriesClient(Key, host).DoubleDecimalPositiveAsync());

        [Test]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host) => await new QueriesClient(Key, host).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host) => await new QueriesClient(Key, host).DoubleNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched.")]
        public Task UrlQueriesStringUnicode() => TestStatus(async (host) => await new QueriesClient(Key, host).StringUnicodeAsync());

        [Test]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host) => await new QueriesClient(Key, host).StringUrlEncodedAsync());

        [Test]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host) => await new QueriesClient(Key, host).StringEmptyAsync());

        [Test]
        public Task UrlQueriesStringNull() => TestStatus(async (host) => await new QueriesClient(Key, host).StringNullAsync( null));

        [Test]
        public Task UrlQueriesEnumValid() => TestStatus(async (host) => await new QueriesClient(Key, host).EnumValidAsync( "green color"));

        [Test]
        public Task UrlQueriesEnumNull() => TestStatus(async (host) => await new QueriesClient(Key, host).EnumNullAsync( null));

        [Test]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host) => await new QueriesClient(Key, host).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public Task UrlQueriesByteNull() => TestStatus(async (host) => await new QueriesClient(Key, host).ByteNullAsync( null));

        [Test]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host) => await new QueriesClient(Key, host).ByteEmptyAsync());

        [Test]
        public Task UrlQueriesDateValid() => TestStatus(async (host) => await new QueriesClient(Key, host).DateValidAsync());

        [Test]
        public Task UrlQueriesDateNull() => TestStatus(async (host) => await new QueriesClient(Key, host).DateNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host) => await new QueriesClient(Key, host).DateTimeValidAsync());

        [Test]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host) => await new QueriesClient(Key, host).DateTimeNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host) => await new QueriesClient(Key, host).ArrayStringCsvValidAsync( new[] {"ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", ""}));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlQueriesArrayNoCollectionFormatValid() => TestStatus(async (host) => await new QueriesClient(Key, host).ArrayStringNoCollectionFormatEmptyAsync( new[] {"hello", "nihao", "bonjour"}));

        [Test]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host) => await new QueriesClient(Key, host).ArrayStringCsvNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host) => await new QueriesClient(Key, host).ArrayStringCsvEmptyAsync( new string[0]));

        [Test]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host) => await new QueriesClient(Key, host).ArrayStringSsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host) => await new QueriesClient(Key, host).ArrayStringTsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host) => await new QueriesClient(Key, host).ArrayStringPipesValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public void UrlQueriesArrayMultiNull() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesClient(Key, host).ArrayStringMultiNullAsync( null));

        [Test]
        public void UrlQueriesArrayMultiEmpty() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesClient(Key, host).ArrayStringMultiEmptyAsync( new string[] { }));

        [Test]
        public void UrlQueriesArrayMultiValid() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesClient(Key, host).ArrayStringMultiValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));
    }
}
