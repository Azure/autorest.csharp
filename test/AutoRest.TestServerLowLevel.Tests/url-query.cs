// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests : TestServerLowLevelTestBase
    {
        public UrlQueryTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetBooleanTrueAsync());

        [Test]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetBooleanFalseAsync());

        [Test]
        public Task UrlQueriesBoolNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetBooleanNullAsync( null));

        [Test]
        public Task UrlQueriesIntPositive() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetIntOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNegative() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetIntNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongPositive() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetTenBillionAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongNegative() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetNegativeTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).GetLongNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host, key) => await new QueriesClient(key, host).FloatScientificPositiveAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host, key) => await new QueriesClient(key, host).FloatScientificNegativeAsync());

        [Test]
        public Task UrlQueriesFloatNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).FloatNullAsync( null));

        [Test]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host, key) => await new QueriesClient(key, host).DoubleDecimalPositiveAsync());

        [Test]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host, key) => await new QueriesClient(key, host).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).DoubleNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched.")]
        public Task UrlQueriesStringUnicode() => TestStatus(async (host, key) => await new QueriesClient(key, host).StringUnicodeAsync());

        [Test]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host, key) => await new QueriesClient(key, host).StringUrlEncodedAsync());

        [Test]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host, key) => await new QueriesClient(key, host).StringEmptyAsync());

        [Test]
        public Task UrlQueriesStringNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).StringNullAsync( null));

        [Test]
        public Task UrlQueriesEnumValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).EnumValidAsync( "green color"));

        [Test]
        public Task UrlQueriesEnumNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).EnumNullAsync( null));

        [Test]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host, key) => await new QueriesClient(key, host).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public Task UrlQueriesByteNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).ByteNullAsync( null));

        [Test]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host, key) => await new QueriesClient(key, host).ByteEmptyAsync());

        [Test]
        public Task UrlQueriesDateValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).DateValidAsync());

        [Test]
        public Task UrlQueriesDateNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).DateNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).DateTimeValidAsync());

        [Test]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).DateTimeNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).ArrayStringCsvValidAsync( new[] {"ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", ""}));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlQueriesArrayNoCollectionFormatValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).ArrayStringNoCollectionFormatEmptyAsync( new[] {"hello", "nihao", "bonjour"}));

        [Test]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host, key) => await new QueriesClient(key, host).ArrayStringCsvNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host, key) => await new QueriesClient(key, host).ArrayStringCsvEmptyAsync( new string[0]));

        [Test]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).ArrayStringSsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).ArrayStringTsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host, key) => await new QueriesClient(key, host).ArrayStringPipesValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public void UrlQueriesArrayMultiNull() => TestStatus(async (host, key) => await new url_multi_collectionFormat.QueriesClient(key, host).ArrayStringMultiNullAsync( null));

        [Test]
        public void UrlQueriesArrayMultiEmpty() => TestStatus(async (host, key) => await new url_multi_collectionFormat.QueriesClient(key, host).ArrayStringMultiEmptyAsync( new string[] { }));

        [Test]
        public void UrlQueriesArrayMultiValid() => TestStatus(async (host, key) => await new url_multi_collectionFormat.QueriesClient(key, host).ArrayStringMultiValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        public override IEnumerable<string> AdditionalKnownScenarios { get; } = new string[]
        {
            "UrlQueriesBoolFalse",
            "UrlQueriesBoolTrue",
            "UrlQueriesBoolNull",
            "UrlQueriesIntPositive",
            "UrlQueriesIntNegative",
            "UrlQueriesIntNull",
            "UrlQueriesLongPositive",
            "UrlQueriesLongNegative",
            "UrlQueriesLongNull",
            "UrlQueriesFloatPositive",
            "UrlQueriesFloatNegative",
            "UrlQueriesFloatNull",
            "UrlQueriesDoublePositive",
            "UrlQueriesDoubleNegative",
            "UrlQueriesDoubleNull",
            "UrlQueriesStringUrlEncoded",
            "UrlQueriesStringEmpty",
            "UrlQueriesStringNull",
            "UrlQueriesEnumValid",
            "UrlQueriesEnumNull",
            "UrlQueriesByteMultiByte",
            "UrlQueriesByteEmpty",
            "UrlQueriesByteNull",
            "UrlQueriesDateValid",
            "UrlQueriesDateNull",
            "UrlQueriesDateTimeValid",
            "UrlQueriesDateTimeNull",
            "UrlQueriesArrayCsvNull",
            "UrlQueriesArrayCsvEmpty",
            "UrlQueriesArrayCsvValid",
            "UrlQueriesArrayMultiNull",
            "UrlQueriesArrayMultiEmpty",
            "UrlQueriesArrayMultiValid",
            "UrlQueriesArraySsvValid",
            "UrlQueriesArrayPipesValid",
            "UrlQueriesArrayTsvValid",
        };
    }
}
