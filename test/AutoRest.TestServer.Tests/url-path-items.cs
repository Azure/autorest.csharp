// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;

namespace AutoRest.TestServer.Tests
{
    public class UrlPathItemsTests : TestServerTestBase
    {
        public UrlPathItemsTests(TestServerVersion version) : base(version, "pathitem") { }

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlPathItemGetAll() => TestStatus(async (host, pipeline) =>
            await new PathItemsOperations(ClientDiagnostics,
                    pipeline,
                    globalStringPath: "globalStringPath",
                    globalStringQuery: "globalStringQuery",
                    host)
                .GetAllWithValuesAsync(
                    pathItemStringPath: "pathItemStringPath",
                    pathItemStringQuery: "pathItemStringQuery",
                    localStringPath: "localStringPath",
                    localStringQuery: "localStringQuery"));

        [Test]
        public Task UrlPathItemGetPathItemAndLocalNull() => TestStatus(async (host, pipeline) =>
            await new PathItemsOperations(
                    ClientDiagnostics,
                    pipeline,
                    globalStringPath: "globalStringPath",
                    globalStringQuery: "globalStringQuery",
                    host)
                .GetLocalPathItemQueryNullAsync(
                    pathItemStringPath: "pathItemStringPath",
                    pathItemStringQuery: null,
                    localStringPath: "localStringPath",
                    localStringQuery: null));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlPathItemGetGlobalNull() => TestStatus(async (host, pipeline) =>
            await new PathItemsOperations(
                    ClientDiagnostics,
                    pipeline,
                    globalStringPath: "globalStringPath",
                    globalStringQuery: null,
                    host)
                .GetGlobalQueryNullAsync(
                    pathItemStringPath: "pathItemStringPath",
                    pathItemStringQuery: "pathItemStringQuery",
                    localStringPath: "localStringPath",
                    localStringQuery: "localStringQuery"));

        [Test]
        public Task UrlPathItemGetGlobalAndLocalNull() => TestStatus(async (host, pipeline) =>
            await new PathItemsOperations(
                    ClientDiagnostics,
                    pipeline,
                    globalStringPath: "globalStringPath",
                    globalStringQuery: null,
                    host)
                .GetGlobalAndLocalQueryNullAsync(
                pathItemStringPath: "pathItemStringPath",
                pathItemStringQuery: "pathItemStringQuery",
                localStringPath: "localStringPath",
                localStringQuery: null));
    }
}
