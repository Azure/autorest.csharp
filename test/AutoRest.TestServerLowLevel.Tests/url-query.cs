// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url_LowLevel;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests : TestServerLowLevelTestBase
    {
        [Test]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetBooleanTrueAsync());

        [Test]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetBooleanFalseAsync());

        [Test]
        public Task UrlQueriesBoolNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetBooleanNullAsync( null));

        [Test]
        public Task UrlQueriesIntPositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetIntOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetIntNullAsync( null));

        [Test]
        public Task UrlQueriesLongPositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetNegativeTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().GetLongNullAsync( null));

        [Test]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().FloatScientificPositiveAsync());

        [Test]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().FloatScientificNegativeAsync());

        [Test]
        public Task UrlQueriesFloatNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().FloatNullAsync( null));

        [Test]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().DoubleDecimalPositiveAsync());

        [Test]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().DoubleNullAsync( null));

        [Test]
        public Task UrlQueriesStringUnicode() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().StringUnicodeAsync());

        [Test]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().StringUrlEncodedAsync());

        [Test]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().StringEmptyAsync());

        [Test]
        public Task UrlQueriesStringNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().StringNullAsync( null));

        [Test]
        public Task UrlQueriesEnumValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().EnumValidAsync( "green color"));

        [Test]
        public Task UrlQueriesEnumNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().EnumNullAsync( null));

        [Test]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public Task UrlQueriesByteNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ByteNullAsync( null));

        [Test]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ByteEmptyAsync());

        [Test]
        public Task UrlQueriesDateValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().DateValidAsync());

        [Test]
        public Task UrlQueriesDateNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().DateNullAsync( null));

        [Test]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().DateTimeValidAsync());

        [Test]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().DateTimeNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ArrayStringCsvValidAsync( new[] {"ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", ""}));

        [Test]
        public Task UrlQueriesArrayNoCollectionFormatValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ArrayStringNoCollectionFormatEmptyAsync( new[] {"hello", "nihao", "bonjour"}));

        [Test]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ArrayStringCsvNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ArrayStringCsvEmptyAsync(Enumerable.Empty<string>()));

        [Test]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ArrayStringSsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ArrayStringTsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host) => await new AutoRestUrlTestServiceClient(Key, host, null).GetQueriesClient().ArrayStringPipesValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayMultiNull() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesClient(Key, host, null).ArrayStringMultiNullAsync( null));

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/1161")]
        public Task UrlQueriesArrayMultiEmpty() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesClient(Key, host, null).ArrayStringMultiEmptyAsync(Enumerable.Empty<string>()));

        [Test]
        public Task UrlQueriesArrayMultiValid() => TestStatus(async (host) => await new url_multi_collectionFormat_LowLevel.QueriesClient(Key, host, null).ArrayStringMultiValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));
    }
}
