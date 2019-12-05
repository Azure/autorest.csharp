// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using url;
using url.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests : TestServerTestBase
    {
        public UrlQueryTests(TestServerVersion version) : base(version, "queries") { }

        [Test]
        public Task UrlQueriesBoolTrue() => TestStatus(async (host, pipeline) => await QueriesOperations.GetBooleanTrueAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesBoolFalse() => TestStatus(async (host, pipeline) => await QueriesOperations.GetBooleanFalseAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesBoolNull() => TestStatus(async (host, pipeline) => await QueriesOperations.GetBooleanNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task UrlQueriesIntPositive() => TestStatus(async (host, pipeline) => await QueriesOperations.GetIntOneMillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesIntNegative() => TestStatus(async (host, pipeline) => await QueriesOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesIntNull() => TestStatus(async (host, pipeline) => await QueriesOperations.GetIntNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task UrlQueriesLongPositive() => TestStatus(async (host, pipeline) => await QueriesOperations.GetTenBillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesLongNegative() => TestStatus(async (host, pipeline) => await QueriesOperations.GetNegativeTenBillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesLongNull() => TestStatus(async (host, pipeline) => await QueriesOperations.GetLongNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("Wrong float format")]
        public Task UrlQueriesFloatPositive() => TestStatus(async (host, pipeline) => await QueriesOperations.FloatScientificPositiveAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesFloatNegative() => TestStatus(async (host, pipeline) => await QueriesOperations.FloatScientificNegativeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesFloatNull() => TestStatus(async (host, pipeline) => await QueriesOperations.FloatNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task FloatNullAsync() => Test("UrlQueriesFloatNull", async (host, pipeline) => await QueriesOperations.FloatNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task UrlQueriesDoublePositive() => TestStatus(async (host, pipeline) => await QueriesOperations.DoubleDecimalPositiveAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesDoubleNegative() => TestStatus(async (host, pipeline) => await QueriesOperations.DoubleDecimalNegativeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesDoubleNull() => TestStatus(async (host, pipeline) => await QueriesOperations.DoubleNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "queries_string_unicode recording missing https://github.com/Azure/autorest.test-server/issues/17")]
        public Task StringUnicodeAsync() => TestStatus(async (host, pipeline) => await QueriesOperations.StringUnicodeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesStringUrlEncoded() => TestStatus(async (host, pipeline) => await QueriesOperations.StringUrlEncodedAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesStringEmpty() => TestStatus(async (host, pipeline) => await QueriesOperations.StringEmptyAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesStringNull() => TestStatus(async (host, pipeline) => await QueriesOperations.StringNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task UrlQueriesEnumValid() => TestStatus(async (host, pipeline) => await QueriesOperations.EnumValidAsync(ClientDiagnostics, pipeline, UriColor.GreenColor, host: host));

        [Test]
        public Task UrlQueriesEnumNull() => TestStatus(async (host, pipeline) => await QueriesOperations.EnumNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("byte[] not supported")]
        public Task UrlQueriesByteMultiByte() => TestStatus(async (host, pipeline) => await QueriesOperations.ByteMultiByteAsync(ClientDiagnostics, pipeline, new byte[0], host: host));

        [Test]
        public Task UrlQueriesByteNull() => TestStatus(async (host, pipeline) => await QueriesOperations.ByteNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task UrlQueriesByteEmpty() => TestStatus(async (host, pipeline) => await QueriesOperations.ByteEmptyAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        [Ignore("null ref")]
        public Task ByteNullAsync() => TestStatus(async (host, pipeline) => await QueriesOperations.ByteNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task UrlQueriesDateValid() => TestStatus(async (host, pipeline) => await QueriesOperations.DateValidAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesDateNull() => TestStatus(async (host, pipeline) => await QueriesOperations.DateNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task UrlQueriesDateTimeValid() => TestStatus(async (host, pipeline) => await QueriesOperations.DateTimeValidAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task UrlQueriesDateTimeNull() => TestStatus(async (host, pipeline) => await QueriesOperations.DateTimeNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task UrlQueriesArrayCsvValid() => TestStatus(async (host, pipeline) => await QueriesOperations.ArrayStringCsvValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task UrlQueriesArrayCsvNull() => TestStatus(async (host, pipeline) => await QueriesOperations.ArrayStringCsvNullAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task UrlQueriesArrayCsvEmpty() => TestStatus(async (host, pipeline) => await QueriesOperations.ArrayStringCsvEmptyAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task UrlQueriesArraySsvValid() => TestStatus(async (host, pipeline) => await QueriesOperations.ArrayStringSsvValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task UrlQueriesArrayTsvValid() => TestStatus(async (host, pipeline) => await QueriesOperations.ArrayStringTsvValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task UrlQueriesArrayPipesValid() => TestStatus(async (host, pipeline) => await QueriesOperations.ArrayStringPipesValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("We don't seem to have operation for this")]
        public void UrlQueriesArrayMultiNull() => Assert.Fail("");

        [Test]
        [Ignore("We don't seem to have operation for this")]
        public void UrlQueriesArrayMultiEmpty() => Assert.Fail("");

        [Test]
        [Ignore("We don't seem to have operation for this")]
        public void UrlQueriesArrayMultiValid() => Assert.Fail("");

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
