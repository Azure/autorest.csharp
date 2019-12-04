// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using url;
using url.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class UrlQueryTests: TestServerTestBase
    {
        [Test]
        public Task GetBooleanTrueAsync() => TestStatus("queries_bool_true", async (host, pipeline) => await QueriesOperations.GetBooleanTrueAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetBooleanFalseAsync() => TestStatus("queries_bool_false", async (host, pipeline) => await QueriesOperations.GetBooleanFalseAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetBooleanNullAsync() => TestStatus("queries_bool_null", async (host, pipeline) => await QueriesOperations.GetBooleanNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task GetIntOneMillionAsync() => TestStatus("queries_int_1000000", async (host, pipeline) => await QueriesOperations.GetIntOneMillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetIntNegativeOneMillionAsync() => TestStatus("queries_int_-1000000", async (host, pipeline) => await QueriesOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetIntNullAsync() => TestStatus("queries_int_null", async (host, pipeline) => await QueriesOperations.GetIntNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task GetTenBillionAsync() => TestStatus("queries_long_10000000000", async (host, pipeline) => await QueriesOperations.GetTenBillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetNegativeTenBillionAsync() => TestStatus("queries_long_-10000000000", async (host, pipeline) => await QueriesOperations.GetNegativeTenBillionAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task GetLongNullAsync() => TestStatus("queries_long_null", async (host, pipeline) => await QueriesOperations.GetLongNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("Wrong float format")]
        public Task FloatScientificPositiveAsync() => TestStatus("FloatScientificPositiveAsync", async (host, pipeline) => await QueriesOperations.FloatScientificPositiveAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task FloatScientificNegativeAsync() => TestStatus("queries_float_-1034e-20", async (host, pipeline) => await QueriesOperations.FloatScientificNegativeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task FloatNullAsync() => TestStatus("queries_float_null", async (host, pipeline) => await QueriesOperations.FloatNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task DoubleDecimalPositiveAsync() => TestStatus("queries_double_9999999999", async (host, pipeline) => await QueriesOperations.DoubleDecimalPositiveAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DoubleDecimalNegativeAsync() => TestStatus("queries_double_-9999999999", async (host, pipeline) => await QueriesOperations.DoubleDecimalNegativeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DoubleNullAsync() => TestStatus("queries_double_null", async (host, pipeline) => await QueriesOperations.DoubleNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("queries_string_unicode recording missing https://github.com/Azure/autorest.test-server/issues/17")]
        public Task StringUnicodeAsync() => TestStatus("StringUnicodeAsync", async (host, pipeline) => await QueriesOperations.StringUnicodeAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task StringUrlEncodedAsync() => TestStatus("queries_string_begin-_end", async (host, pipeline) => await QueriesOperations.StringUrlEncodedAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task StringEmptyAsync() => TestStatus("queries_string_empty", async (host, pipeline) => await QueriesOperations.StringEmptyAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task StringNullAsync() => TestStatus("queries_string_null", async (host, pipeline) => await QueriesOperations.StringNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task EnumValidAsync() => TestStatus("queries_enum_green-color", async (host, pipeline) => await QueriesOperations.EnumValidAsync(ClientDiagnostics, pipeline, UriColor.GreenColor, host: host));

        [Test]
        public Task EnumNullAsync() => TestStatus("queries_enum_null", async (host, pipeline) => await QueriesOperations.EnumNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        [Ignore("byte[] not supported")]
        public Task ByteMultiByteAsync() => TestStatus("ByteMultiByteAsync", async (host, pipeline) => await QueriesOperations.ByteMultiByteAsync(ClientDiagnostics, pipeline, new byte[0], host: host));

        [Test]
        public Task ByteEmptyAsync() => TestStatus("queries_byte_empty", async (host, pipeline) => await QueriesOperations.ByteEmptyAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        [Ignore("null ref")]
        public Task ByteNullAsync() => TestStatus("ByteNullAsync", async (host, pipeline) => await QueriesOperations.ByteNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task DateValidAsync() => TestStatus("queries_date_2012-01-01", async (host, pipeline) => await QueriesOperations.DateValidAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DateNullAsync() => TestStatus("queries_date_null", async (host, pipeline) => await QueriesOperations.DateNullAsync(ClientDiagnostics, pipeline, null, host: host));

        [Test]
        public Task DateTimeValidAsync() => TestStatus("queries_datetime_2012-01-01t010101z", async (host, pipeline) => await QueriesOperations.DateTimeValidAsync(ClientDiagnostics, pipeline, host: host));

        [Test]
        public Task DateTimeNullAsync() => TestStatus("queries_datetime_null", async (host, pipeline) => await QueriesOperations.DateTimeNullAsync(ClientDiagnostics, pipeline, null, host: host));

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
