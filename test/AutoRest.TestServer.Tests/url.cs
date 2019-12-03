// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using url;
using url.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class UrlTests: TestServerTestBase
    {
        [Test]
        public Task GetStringEmpty() => TestStatus("paths_string_empty", async (host, pipeline) => await PathsOperations.StringEmptyAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task EnumValidAsync() => TestStatus("paths_enum_green-color_green-color", async (host, pipeline) => await PathsOperations.EnumValidAsync(ClientDiagnostics, pipeline, UriColor.GreenColor, host));

        [Test]
        [Ignore("Wrong url")]
        public Task StringUrlEncodedAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.StringUrlEncodedAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task StringNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.StringNullAsync(ClientDiagnostics, pipeline, "", host));

        [Test]
        [Ignore("Wrong url")]
        public Task StringUnicodeAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.StringUnicodeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ArrayCsvInPathAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.ArrayCsvInPathAsync(ClientDiagnostics, pipeline, new[] { "a", "b", "c" }, host));

        [Test]
        [Ignore("Wrong url")]
        public Task Base64UrlAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.Base64UrlAsync(ClientDiagnostics, pipeline, new byte[] { 1, 2, 3}, host));

        [Test]
        public Task ByteEmptyAsync() => TestStatus("paths_byte_empty", async (host, pipeline) => await PathsOperations.ByteEmptyAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ByteMultiByteAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.ByteMultiByteAsync(ClientDiagnostics, pipeline, new byte[] { 1, 2, 3 }, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ByteNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.ByteNullAsync(ClientDiagnostics, pipeline, new byte[0], host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.DateNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateTimeNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.DateTimeNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        public Task DateValidAsync() => TestStatus("paths_date_2012-01-01_2012-01-01", async (host, pipeline) => await PathsOperations.DateValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateTimeValidAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.DateTimeValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetTenBillionAsync() => TestStatus("paths_long_10000000000_10000000000", async (host, pipeline) => await PathsOperations.GetTenBillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UnixTimeUrlAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.UnixTimeUrlAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        public Task GetIntNegativeOneMillionAsync() => TestStatus("paths_int_-1000000_-1000000", async (host, pipeline) => await PathsOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetIntOneMillionAsync() => TestStatus("paths_int_1000000_1000000", async (host, pipeline) => await PathsOperations.GetIntOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetBooleanTrueAsync() => TestStatus("paths_bool_true_true", async (host, pipeline) => await PathsOperations.GetBooleanTrueAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetBooleanFalseAsync() => TestStatus("paths_bool_false_false", async (host, pipeline) => await PathsOperations.GetBooleanFalseAsync(ClientDiagnostics, pipeline, host));
    }
}
