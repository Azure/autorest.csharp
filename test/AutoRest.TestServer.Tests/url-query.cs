// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;
using url.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests : TestServerTestBase
    {
        public UrlQueryTests(TestServerVersion version) : base(version, "queries") { }

        [Test]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetBooleanTrueAsync());

        [Test]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetBooleanFalseAsync());

        [Test]
        public Task UrlQueriesBoolNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetBooleanNullAsync( null));

        [Test]
        public Task UrlQueriesIntPositive() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetIntOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNegative() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetIntNegativeOneMillionAsync());

        [Test]
        public Task UrlQueriesIntNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetIntNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongPositive() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetTenBillionAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Strict type checking, format from code model is incorrect")]
        public Task UrlQueriesLongNegative() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetNegativeTenBillionAsync());

        [Test]
        public Task UrlQueriesLongNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).GetLongNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).FloatScientificPositiveAsync());

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).FloatScientificNegativeAsync());

        [Test]
        public Task UrlQueriesFloatNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).FloatNullAsync( null));

        [Test]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).DoubleDecimalPositiveAsync());

        [Test]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).DoubleDecimalNegativeAsync());

        [Test]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).DoubleNullAsync( null));

        [Test]
        [Ignore("No test server handler for this one")]
        public Task StringUnicodeAsync() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).StringUnicodeAsync());

        [Test]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).StringUrlEncodedAsync());

        [Test]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).StringEmptyAsync());

        [Test]
        public Task UrlQueriesStringNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).StringNullAsync( null));

        [Test]
        [Ignore("Not implemented https://github.com/Azure/autorest.csharp/issues/325")]
        public Task UrlQueriesEnumValid() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).EnumValidAsync( UriColor.GreenColor));

        [Test]
        public Task UrlQueriesEnumNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).EnumNullAsync( null));

        [Test]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ByteMultiByteAsync( TestConstants.ByteArray));

        [Test]
        public Task UrlQueriesByteNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ByteNullAsync( null));

        [Test]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ByteEmptyAsync());

        [Test]
        public Task UrlQueriesDateValid() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).DateValidAsync());

        [Test]
        public Task UrlQueriesDateNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).DateNullAsync( null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).DateTimeValidAsync());

        [Test]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).DateTimeNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringCsvValidAsync( new[] {"ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", ""}));

        [Test]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringCsvNullAsync( null));

        [Test]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringCsvEmptyAsync( new string[0]));

        [Test]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringSsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringTsvValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host, pipeline) => await new QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringPipesValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

        [Test]
        public void UrlQueriesArrayMultiNull() => TestStatus(async (host, pipeline) => await new url_multi_collectionFormat.QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringMultiNullAsync( null));

        [Test]
        public void UrlQueriesArrayMultiEmpty() => TestStatus(async (host, pipeline) => await new url_multi_collectionFormat.QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringMultiEmptyAsync( new string[] { }));

        [Test]
        public void UrlQueriesArrayMultiValid() => TestStatus(async (host, pipeline) => await new url_multi_collectionFormat.QueriesOperations(host, ClientDiagnostics, pipeline).ArrayStringMultiValidAsync( new[] { "ArrayQuery1", "begin!*'();:@ &=+$,/?#[]end", "", "" }));

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
