// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using url;
using url.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests: TestServerTestBase
    {
        public UrlQueryTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetBooleanTrueAsync() => TestStatus("UrlQueriesBoolTrue", async (host, pipeline) => await QueriesOperations.GetBooleanTrueAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetBooleanFalseAsync() => TestStatus("UrlQueriesBoolFalse", async (host, pipeline) => await QueriesOperations.GetBooleanFalseAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetBooleanNullAsync() => TestStatus("UrlQueriesBoolNull", async (host, pipeline) => await QueriesOperations.GetBooleanNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task GetIntOneMillionAsync() => TestStatus("UrlQueriesIntPositive", async (host, pipeline) => await QueriesOperations.GetIntOneMillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetIntNegativeOneMillionAsync() => TestStatus("UrlQueriesIntNegative", async (host, pipeline) => await QueriesOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetIntNullAsync() => TestStatus("UrlQueriesIntNull", async (host, pipeline) => await QueriesOperations.GetIntNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task GetTenBillionAsync() => TestStatus("UrlQueriesLongPositive", async (host, pipeline) => await QueriesOperations.GetTenBillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetNegativeTenBillionAsync() => TestStatus("UrlQueriesLongNegative", async (host, pipeline) => await QueriesOperations.GetNegativeTenBillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetLongNullAsync() => TestStatus("UrlQueriesLongNull", async (host, pipeline) => await QueriesOperations.GetLongNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("Wrong float format")]
        public Task FloatScientificPositiveAsync() => TestStatus("FloatScientificPositiveAsync", async (host, pipeline) => await QueriesOperations.FloatScientificPositiveAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task FloatScientificNegativeAsync() => TestStatus("UrlQueriesFloatNegative", async (host, pipeline) => await QueriesOperations.FloatScientificNegativeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task FloatNullAsync() => Test("UrlQueriesFloatNull", async (host, pipeline) => await QueriesOperations.FloatNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task DoubleDecimalPositiveAsync() => TestStatus("UrlQueriesDoublePositive", async (host, pipeline) => await QueriesOperations.DoubleDecimalPositiveAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DoubleDecimalNegativeAsync() => TestStatus("UrlQueriesDoubleNegative", async (host, pipeline) => await QueriesOperations.DoubleDecimalNegativeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DoubleNullAsync() => TestStatus("UrlQueriesDoubleNull", async (host, pipeline) => await QueriesOperations.DoubleNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("queries_string_unicode recording missing https://github.com/Azure/autorest.test-server/issues/17")]
        public Task StringUnicodeAsync() => TestStatus("StringUnicodeAsync", async (host, pipeline) => await QueriesOperations.StringUnicodeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task StringUrlEncodedAsync() => TestStatus("UrlQueriesStringUrlEncoded", async (host, pipeline) => await QueriesOperations.StringUrlEncodedAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task StringEmptyAsync() => TestStatus("UrlQueriesStringEmpty", async (host, pipeline) => await QueriesOperations.StringEmptyAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task StringNullAsync() => TestStatus("UrlQueriesStringNull", async (host, pipeline) => await QueriesOperations.StringNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task EnumValidAsync() => TestStatus("UrlQueriesEnumValid", async (host, pipeline) => await QueriesOperations.EnumValidAsync(ClientDiagnostics, pipeline, UriColor.GreenColor, host: host));

        [Test]
        public Task EnumNullAsync() => TestStatus("UrlQueriesEnumNull", async (host, pipeline) => await QueriesOperations.EnumNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("byte[] not supported")]
        public Task ByteMultiByteAsync() => TestStatus("ByteMultiByteAsync", async (host, pipeline) => await QueriesOperations.ByteMultiByteAsync(ClientDiagnostics, pipeline, new byte[0], host: host));

        [Test]
        public Task ByteEmptyAsync() => TestStatus("UrlQueriesByteEmpty", async (host, pipeline) => await QueriesOperations.ByteEmptyAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        [Ignore("null ref")]
        public Task ByteNullAsync() => TestStatus("ByteNullAsync", async (host, pipeline) => await QueriesOperations.ByteNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task DateValidAsync() => TestStatus("UrlQueriesDateValid", async (host, pipeline) => await QueriesOperations.DateValidAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DateNullAsync() => TestStatus("UrlQueriesDateNull", async (host, pipeline) => await QueriesOperations.DateNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task DateTimeValidAsync() => TestStatus("UrlQueriesDateTimeValid", async (host, pipeline) => await QueriesOperations.DateTimeValidAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DateTimeNullAsync() => TestStatus("UrlQueriesDateTimeNull", async (host, pipeline) => await QueriesOperations.DateTimeNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringCsvValidAsync() => TestStatus("ArrayStringCsvValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringCsvValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringCsvNullAsync() => TestStatus("ArrayStringCsvNullAsync", async (host, pipeline) => await QueriesOperations.ArrayStringCsvNullAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringCsvEmptyAsync() => TestStatus("ArrayStringCsvEmptyAsync", async (host, pipeline) => await QueriesOperations.ArrayStringCsvEmptyAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringSsvValidAsync() => TestStatus("ArrayStringSsvValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringSsvValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringTsvValidAsync() => TestStatus("ArrayStringTsvValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringTsvValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringPipesValidAsync() => TestStatus("ArrayStringPipesValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringPipesValidAsync(ClientDiagnostics, pipeline, new string[0], host: host));
    }
}
