// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;
using url.Models;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests : TestServerTestBase
    {
        public UrlQueryTests(TestServerVersion version) : base(version, "queries") { }

        [Test]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetBooleanTrueAsync());

        [Test]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetBooleanFalseAsync());

        [Test]
        public Task UrlQueriesBoolNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetBooleanNullAsync( null));

        [Test]
        public Task UrlQueriesIntPositive() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetIntOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNegative() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetIntNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongPositive() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetTenBillionAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongNegative() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetNegativeTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).GetLongNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).FloatScientificPositiveAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).FloatScientificNegativeAsync());

        [Test]
        public Task UrlQueriesFloatNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).FloatNullAsync( null));

        [Test]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).DoubleDecimalPositiveAsync());

        [Test]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).DoubleNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Request not matched.")]
        public Task UrlQueriesStringUnicode() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).StringUnicodeAsync());

        [Test]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).StringUrlEncodedAsync());

        [Test]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).StringEmptyAsync());

        [Test]
        public Task UrlQueriesStringNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).StringNullAsync( null));

        [Test]
        public Task UrlQueriesEnumValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).EnumValidAsync( UriColor.GreenColor));

        [Test]
        public Task UrlQueriesEnumNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).EnumNullAsync( null));

        [Test]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public Task UrlQueriesByteNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ByteNullAsync( null));

        [Test]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ByteEmptyAsync());

        [Test]
        public Task UrlQueriesDateValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).DateValidAsync());

        [Test]
        public Task UrlQueriesDateNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).DateNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).DateTimeValidAsync());

        [Test]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).DateTimeNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringCsvValidAsync( new[] {"ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", ""}));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlQueriesArrayNoCollectionFormatValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringNoCollectionFormatEmptyAsync( new[] {"hello", "nihao", "bonjour"}));

        [Test]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringCsvNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringCsvEmptyAsync( new string[0]));

        [Test]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringSsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringTsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host, pipeline) => await new QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringPipesValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public void UrlQueriesArrayMultiNull() => TestStatus(async (host, pipeline) => await new url_multi_collectionFormat.QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringMultiNullAsync( null));

        [Test]
        public void UrlQueriesArrayMultiEmpty() => TestStatus(async (host, pipeline) => await new url_multi_collectionFormat.QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringMultiEmptyAsync( new string[] { }));

        [Test]
        public void UrlQueriesArrayMultiValid() => TestStatus(async (host, pipeline) => await new url_multi_collectionFormat.QueriesClient(ClientDiagnostics, pipeline, host).ArrayStringMultiValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

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
