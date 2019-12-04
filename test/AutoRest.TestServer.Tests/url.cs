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
        public UrlTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetStringEmpty() => TestStatus("UrlPathsStringEmpty", async (host, pipeline) => await PathsOperations.StringEmptyAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task EnumValidAsync() => TestStatus("UrlPathsEnumValid", async (host, pipeline) => await PathsOperations.EnumValidAsync(ClientDiagnostics, pipeline, UriColor.GreenColor, host));

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
        public Task ByteEmptyAsync() => TestStatus("UrlPathsByteEmpty", async (host, pipeline) => await PathsOperations.ByteEmptyAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ByteMultiByteAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.ByteMultiByteAsync(ClientDiagnostics, pipeline, new byte[] { 1, 2, 3 }, host));

        [Test]
        [Ignore("Wrong url")]
        public Task ByteNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.ByteNullAsync(ClientDiagnostics, pipeline, new byte[0], host));

        [Test]
        [Ignore("Might not apply")]
        public Task DateNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.DateNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        [Ignore("Might not apply")]
        public Task EnumNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.EnumNullAsync(ClientDiagnostics, pipeline, new UriColor(), host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateTimeNullAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.DateTimeNullAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        public Task DateValidAsync() => TestStatus("UrlPathsDateValid", async (host, pipeline) => await PathsOperations.DateValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task DateTimeValidAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.DateTimeValidAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetTenBillionAsync() => TestStatus("UrlPathsLongPositive", async (host, pipeline) => await PathsOperations.GetTenBillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("Wrong url")]
        public Task UnixTimeUrlAsync() => TestStatus("unknown", async (host, pipeline) => await PathsOperations.UnixTimeUrlAsync(ClientDiagnostics, pipeline, new DateTime(), host));

        [Test]
        public Task GetIntNegativeOneMillionAsync() => TestStatus("UrlPathsIntNegative", async (host, pipeline) => await PathsOperations.GetIntNegativeOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetIntOneMillionAsync() => TestStatus("UrlPathsIntPositive", async (host, pipeline) => await PathsOperations.GetIntOneMillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetBooleanTrueAsync() => TestStatus("UrlPathsBoolTrue", async (host, pipeline) => await PathsOperations.GetBooleanTrueAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetBooleanFalseAsync() => TestStatus("UrlPathsBoolFalse", async (host, pipeline) => await PathsOperations.GetBooleanFalseAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task GetNegativeTenBillionAsync() => TestStatus("UrlPathsLongNegative", async (host, pipeline) => await PathsOperations.GetNegativeTenBillionAsync(ClientDiagnostics, pipeline, host));

        [Test]
        [Ignore("We don't escape enough")]
        public Task FloatScientificPositiveAsync() => TestStatus("FloatScientificPositiveAsync", async (host, pipeline) => await PathsOperations.FloatScientificPositiveAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task FloatScientificNegativeAsync() => TestStatus("UrlPathsFloatNegative", async (host, pipeline) => await PathsOperations.FloatScientificNegativeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task DoubleDecimalNegativeAsync() => TestStatus("UrlPathsDoubleNegative", async (host, pipeline) => await PathsOperations.DoubleDecimalNegativeAsync(ClientDiagnostics, pipeline, host));

        [Test]
        public Task DoubleDecimalPositiveAsync() => TestStatus("UrlPathsDoublePositive", async (host, pipeline) => await PathsOperations.DoubleDecimalPositiveAsync(ClientDiagnostics, pipeline, host));
    }
}
