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
        public Task GetBooleanTrueAsync() => TestStatus("UrlQueriesBoolTrue", async (host, pipeline) => await QueriesOperations.GetBooleanTrueAsync(pipeline, host: host));

        [Test]
        public Task GetBooleanFalseAsync() => TestStatus("UrlQueriesBoolFalse", async (host, pipeline) => await QueriesOperations.GetBooleanFalseAsync(pipeline, host: host));

        [Test]
        public Task GetBooleanNullAsync() => TestStatus("UrlQueriesBoolNull", async (host, pipeline) => await QueriesOperations.GetBooleanNullAsync(pipeline, null, host: host));

        [Test]
        public Task GetIntOneMillionAsync() => TestStatus("UrlQueriesIntPositive", async (host, pipeline) => await QueriesOperations.GetIntOneMillionAsync(pipeline, host: host));

        [Test]
        public Task GetIntNegativeOneMillionAsync() => TestStatus("UrlQueriesIntNegative", async (host, pipeline) => await QueriesOperations.GetIntNegativeOneMillionAsync(pipeline, host: host));

        [Test]
        public Task GetIntNullAsync() => TestStatus("UrlQueriesIntNull", async (host, pipeline) => await QueriesOperations.GetIntNullAsync(pipeline, null, host: host));

        [Test]
        public Task GetTenBillionAsync() => TestStatus("UrlQueriesLongPositive", async (host, pipeline) => await QueriesOperations.GetTenBillionAsync(pipeline, host: host));

        [Test]
        public Task GetNegativeTenBillionAsync() => TestStatus("UrlQueriesLongNegative", async (host, pipeline) => await QueriesOperations.GetNegativeTenBillionAsync(pipeline, host: host));

        [Test]
        public Task GetLongNullAsync() => TestStatus("UrlQueriesLongNull", async (host, pipeline) => await QueriesOperations.GetLongNullAsync(pipeline, null, host: host));

        [Test]
        [Ignore("Wrong float format")]
        public Task FloatScientificPositiveAsync() => TestStatus("FloatScientificPositiveAsync", async (host, pipeline) => await QueriesOperations.FloatScientificPositiveAsync(pipeline, host: host));

        [Test]
        public Task FloatScientificNegativeAsync() => TestStatus("UrlQueriesFloatNegative", async (host, pipeline) => await QueriesOperations.FloatScientificNegativeAsync(pipeline, host: host));

        [Test]
        public Task FloatNullAsync() => Test("UrlQueriesFloatNull", async (host, pipeline) => await QueriesOperations.FloatNullAsync(pipeline, null, host: host));

        [Test]
        public Task DoubleDecimalPositiveAsync() => TestStatus("UrlQueriesDoublePositive", async (host, pipeline) => await QueriesOperations.DoubleDecimalPositiveAsync(pipeline, host: host));

        [Test]
        public Task DoubleDecimalNegativeAsync() => TestStatus("UrlQueriesDoubleNegative", async (host, pipeline) => await QueriesOperations.DoubleDecimalNegativeAsync(pipeline, host: host));

        [Test]
        public Task DoubleNullAsync() => TestStatus("UrlQueriesDoubleNull", async (host, pipeline) => await QueriesOperations.DoubleNullAsync(pipeline, null, host: host));

        [Test]
        [Ignore("queries_string_unicode recording missing https://github.com/Azure/autorest.test-server/issues/17")]
        public Task StringUnicodeAsync() => TestStatus("StringUnicodeAsync", async (host, pipeline) => await QueriesOperations.StringUnicodeAsync(pipeline, host: host));

        [Test]
        public Task StringUrlEncodedAsync() => TestStatus("UrlQueriesStringUrlEncoded", async (host, pipeline) => await QueriesOperations.StringUrlEncodedAsync(pipeline, host: host));

        [Test]
        public Task StringEmptyAsync() => TestStatus("UrlQueriesStringEmpty", async (host, pipeline) => await QueriesOperations.StringEmptyAsync(pipeline, host: host));

        [Test]
        public Task StringNullAsync() => TestStatus("UrlQueriesStringNull", async (host, pipeline) => await QueriesOperations.StringNullAsync(pipeline, null, host: host));

        [Test]
        public Task EnumValidAsync() => TestStatus("UrlQueriesEnumValid", async (host, pipeline) => await QueriesOperations.EnumValidAsync(pipeline, UriColor.GreenColor, host: host));

        [Test]
        public Task EnumNullAsync() => TestStatus("UrlQueriesEnumNull", async (host, pipeline) => await QueriesOperations.EnumNullAsync(pipeline, null, host: host));

        [Test]
        [Ignore("byte[] not supported")]
        public Task ByteMultiByteAsync() => TestStatus("ByteMultiByteAsync", async (host, pipeline) => await QueriesOperations.ByteMultiByteAsync(pipeline, new byte[0], host: host));

        [Test]
        public Task ByteEmptyAsync() => TestStatus("UrlQueriesByteEmpty", async (host, pipeline) => await QueriesOperations.ByteEmptyAsync(pipeline, host: host));

        [Test]
        [Ignore("null ref")]
        public Task ByteNullAsync() => TestStatus("ByteNullAsync", async (host, pipeline) => await QueriesOperations.ByteNullAsync(pipeline, null, host: host));

        [Test]
        public Task DateValidAsync() => TestStatus("UrlQueriesDateValid", async (host, pipeline) => await QueriesOperations.DateValidAsync(pipeline, host: host));

        [Test]
        public Task DateNullAsync() => TestStatus("UrlQueriesDateNull", async (host, pipeline) => await QueriesOperations.DateNullAsync(pipeline, null, host: host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Recording match is too strict")]
        public Task DateTimeValidAsync() => TestStatus("UrlQueriesDateTimeValid", async (host, pipeline) => await QueriesOperations.DateTimeValidAsync(pipeline, host: host));

        [Test]
        public Task DateTimeNullAsync() => TestStatus("UrlQueriesDateTimeNull", async (host, pipeline) => await QueriesOperations.DateTimeNullAsync(pipeline, null, host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringCsvValidAsync() => TestStatus("ArrayStringCsvValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringCsvValidAsync(pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringCsvNullAsync() => TestStatus("ArrayStringCsvNullAsync", async (host, pipeline) => await QueriesOperations.ArrayStringCsvNullAsync(pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringCsvEmptyAsync() => TestStatus("ArrayStringCsvEmptyAsync", async (host, pipeline) => await QueriesOperations.ArrayStringCsvEmptyAsync(pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringSsvValidAsync() => TestStatus("ArrayStringSsvValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringSsvValidAsync(pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringTsvValidAsync() => TestStatus("ArrayStringTsvValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringTsvValidAsync(pipeline, new string[0], host: host));

        [Test]
        [Ignore("CSV not supported")]
        public Task ArrayStringPipesValidAsync() => TestStatus("ArrayStringPipesValidAsync", async (host, pipeline) => await QueriesOperations.ArrayStringPipesValidAsync(pipeline, new string[0], host: host));
    }
}
