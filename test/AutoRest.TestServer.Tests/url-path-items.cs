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
        [Ignore("globalStringQuery not generated")]
        public Task UrlPathItemGetAll() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetAllWithValuesAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: "localStringQuery", host));

        [Test]
        [Ignore("globalStringQuery not generated")]
        public Task UrlPathItemGetPathItemAndLocalNull() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetLocalPathItemQueryNullAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: null, host));

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No recording")]
        public Task UrlPathItemGetGlobalNull() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetGlobalQueryNullAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: "localStringQuery", host));

        [Test]
        public Task UrlPathItemGetGlobalAndLocalNull() => TestStatus(async (host, pipeline) =>
            await PathItemsOperations.GetGlobalAndLocalQueryNullAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: null, host));
    }
}
