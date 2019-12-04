// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using url;

namespace AutoRest.TestServer.Tests
{
    public class UrlPathItemsTests: TestServerTestBase
    {
        public UrlPathItemsTests(TestServerVersion version) : base(version) { }

        [Test]
        [Ignore("globalStringQuery not generated")]
        public Task GetAllWithValuesAsync() => TestStatus("unknown", async (host, pipeline) =>
            await PathItemsOperations.GetAllWithValuesAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: "localStringQuery", host));

        [Test]
        [Ignore("globalStringQuery not generated")]
        public Task GetLocalPathItemQueryNullAsync() => TestStatus("unknown", async (host, pipeline) =>
            await PathItemsOperations.GetLocalPathItemQueryNullAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: null, host));

        [Test]
        public Task GetGlobalQueryNullAsync() => TestStatus("UrlPathItemGetGlobalNull", async (host, pipeline) =>
            await PathItemsOperations.GetGlobalQueryNullAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: "localStringQuery", host));

        [Test]
        public Task GetGlobalAndLocalQueryNullAsync() => TestStatus("UrlPathItemGetGlobalAndLocalNull", async (host, pipeline) =>
            await PathItemsOperations.GetGlobalAndLocalQueryNullAsync(ClientDiagnostics, pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: null, host));
    }
}
