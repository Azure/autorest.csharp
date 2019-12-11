// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;

namespace AutoRest.TestServer.Tests
{
    public class UrlPathItemsTests: TestServerTestBase
    {
        public UrlPathItemsTests(TestServerVersion version) : base(version, "pathitem") { }

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlPathItemGetAll() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetAllWithValuesAsync(ClientDiagnostics,
                pipeline,
                pathItemStringPath: "pathItemStringPath",
                pathItemStringQuery: "pathItemStringQuery",
                globalStringPath: "globalStringPath",
                globalStringQuery: "globalStringQuery",
                localStringPath: "localStringPath",
                localStringQuery: "localStringQuery",
                host: host));

        [Test]
        public Task UrlPathItemGetPathItemAndLocalNull() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetLocalPathItemQueryNullAsync(
                ClientDiagnostics,
                pipeline,
                pathItemStringPath: "pathItemStringPath",
                pathItemStringQuery: null,
                globalStringPath: "globalStringPath",
                globalStringQuery: "globalStringQuery",
                localStringPath: "localStringPath",
                localStringQuery: null,
                host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlPathItemGetGlobalNull() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetGlobalQueryNullAsync(
                ClientDiagnostics,
                pipeline,
                pathItemStringPath: "pathItemStringPath",
                pathItemStringQuery: "pathItemStringQuery",
                globalStringPath: "globalStringPath",
                globalStringQuery: null,
                localStringPath: "localStringPath",
                localStringQuery: "localStringQuery",
                host));

        [Test]
        public Task UrlPathItemGetGlobalAndLocalNull() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetGlobalAndLocalQueryNullAsync(
                ClientDiagnostics,
                pipeline,
                pathItemStringPath: "pathItemStringPath",
                pathItemStringQuery: "pathItemStringQuery",
                globalStringPath: "globalStringPath",
                globalStringQuery: null,
                localStringPath: "localStringPath",
                localStringQuery: null,
                host));
    }
}
