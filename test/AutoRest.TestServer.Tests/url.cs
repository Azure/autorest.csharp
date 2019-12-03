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
        public Task GetStringEmpty() => TestStatus("paths_string_empty", async host => await PathsOperations.StringEmptyAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        public Task EnumValidAsync() => TestStatus("paths_enum_green-color_green-color", async host => await PathsOperations.EnumValidAsync(ClientDiagnostics, Pipeline, UriColor.GreenColor, host));

        [Test]
        [Ignore("Wrong url")]
        public Task StringUrlEncodedAsync() => TestStatus("unknown", async host => await PathsOperations.StringUrlEncodedAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task StringNullAsync() => TestStatus("unknown", async host => await PathsOperations.StringNullAsync(ClientDiagnostics, Pipeline, "", host));

        [Test]
        [Ignore("Wrong url")]
        public Task StringUnicodeAsync() => TestStatus("unknown", async host => await PathsOperations.StringUnicodeAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ArrayCsvInPathAsync() => TestStatus("unknown", async host => await PathsOperations.ArrayCsvInPathAsync(ClientDiagnostics, Pipeline, new[] { "a", "b", "c" }, host));

        [Test]
        [Ignore("Wrong url")]
        public Task Base64UrlAsync() => TestStatus("unknown", async host => await PathsOperations.Base64UrlAsync(ClientDiagnostics, Pipeline, new byte[] { 1, 2, 3}, host));

        [Test]
        public Task ByteEmptyAsync() => TestStatus("paths_byte_empty", async host => await PathsOperations.ByteEmptyAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ByteMultiByteAsync() => TestStatus("unknown", async host => await PathsOperations.ByteMultiByteAsync(ClientDiagnostics, Pipeline, new byte[] { 1, 2, 3 }, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ByteNullAsync() => TestStatus("unknown", async host => await PathsOperations.ByteNullAsync(ClientDiagnostics, Pipeline, new byte[0], host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateNullAsync() => TestStatus("unknown", async host => await PathsOperations.DateNullAsync(ClientDiagnostics, Pipeline, new DateTime(), host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateTimeNullAsync() => TestStatus("unknown", async host => await PathsOperations.DateTimeNullAsync(ClientDiagnostics, Pipeline, new DateTime(), host));

        [Test]
        public Task DateValidAsync() => TestStatus("paths_date_2012-01-01_2012-01-01", async host => await PathsOperations.DateValidAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateTimeValidAsync() => TestStatus("unknown", async host => await PathsOperations.DateTimeValidAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        public Task GetTenBillionAsync() => TestStatus("paths_long_10000000000_10000000000", async host => await PathsOperations.GetTenBillionAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UnixTimeUrlAsync() => TestStatus("unknown", async host => await PathsOperations.UnixTimeUrlAsync(ClientDiagnostics, Pipeline, new DateTime(), host));

        [Test]
        public Task GetIntNegativeOneMillionAsync() => TestStatus("paths_int_-1000000_-1000000", async host => await PathsOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        public Task GetIntOneMillionAsync() => TestStatus("paths_int_1000000_1000000", async host => await PathsOperations.GetIntOneMillionAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        public Task GetBooleanTrueAsync() => TestStatus("paths_bool_true_true", async host => await PathsOperations.GetBooleanTrueAsync(ClientDiagnostics, Pipeline, host));

        [Test]
        public Task GetBooleanFalseAsync() => TestStatus("paths_bool_false_false", async host => await PathsOperations.GetBooleanFalseAsync(ClientDiagnostics, Pipeline, host));
    }
}
