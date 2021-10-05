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
        [Test]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetBooleanTrueAsync());

        [Test]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetBooleanFalseAsync());

        [Test]
        public Task UrlQueriesBoolNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetBooleanNullAsync( null));

        [Test]
        public Task UrlQueriesIntPositive() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetIntOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNegative() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetIntNullAsync( null));

        [Test]
        public Task UrlQueriesLongPositive() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNegative() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetNegativeTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).GetLongNullAsync( null));

        [Test]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host) => await new QueriesRestClient(Key, host).FloatScientificPositiveAsync());

        [Test]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host) => await new QueriesRestClient(Key, host).FloatScientificNegativeAsync());

        [Test]
        public Task UrlQueriesFloatNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).FloatNullAsync( null));

        [Test]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host) => await new QueriesRestClient(Key, host).DoubleDecimalPositiveAsync());

        [Test]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host) => await new QueriesRestClient(Key, host).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).DoubleNullAsync( null));

        [Test]
        public Task UrlQueriesStringUnicode() => TestStatus(async (host) => await new QueriesRestClient(Key, host).StringUnicodeAsync());

        [Test]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host) => await new QueriesRestClient(Key, host).StringUrlEncodedAsync());

        [Test]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host) => await new QueriesRestClient(Key, host).StringEmptyAsync());

        [Test]
        public Task UrlQueriesStringNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).StringNullAsync( null));

        [Test]
        public Task UrlQueriesEnumValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).EnumValidAsync( "green color"));

        [Test]
        public Task UrlQueriesEnumNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).EnumNullAsync( null));

        [Test]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public Task UrlQueriesByteNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ByteNullAsync( null));

        [Test]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ByteEmptyAsync());

        [Test]
        public Task UrlQueriesDateValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).DateValidAsync());

        [Test]
        public Task UrlQueriesDateNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).DateNullAsync( null));

        [Test]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).DateTimeValidAsync());

        [Test]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).DateTimeNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ArrayStringCsvValidAsync( new[] {"ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", ""}));

        [Test]
        public Task UrlQueriesArrayNoCollectionFormatValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ArrayStringNoCollectionFormatEmptyAsync( new[] {"hello", "nihao", "bonjour"}));

        [Test]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ArrayStringCsvNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ArrayStringCsvEmptyAsync( new string[0]));

        [Test]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ArrayStringSsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ArrayStringTsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host) => await new QueriesRestClient(Key, host).ArrayStringPipesValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayMultiNull() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesRestClient(Key, host).ArrayStringMultiNullAsync( null));

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/1161")]
        public Task UrlQueriesArrayMultiEmpty() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesRestClient(Key, host).ArrayStringMultiEmptyAsync( new string[] { }));

        [Test]
        public Task UrlQueriesArrayMultiValid() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesRestClient(Key, host).ArrayStringMultiValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));
    }
}
