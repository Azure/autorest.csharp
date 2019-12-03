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
        [Test]
        [Ignore("globalStringQuery not generated")]
        public Task GetAllWithValuesAsync() => TestStatus("unknown", async host =>
            await PathItemsOperations.GetAllWithValuesAsync(ClientDiagnostics, Pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: "localStringQuery", host));

        [Test]
        [Ignore("globalStringQuery not generated")]
        public Task GetLocalPathItemQueryNullAsync() => TestStatus("unknown", async host =>
            await PathItemsOperations.GetLocalPathItemQueryNullAsync(ClientDiagnostics, Pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: null, host));

        [Test]
        [Ignore("query order mismatch")]
        public Task GetGlobalQueryNullAsync() => TestStatus("unknown", async host =>
            await PathItemsOperations.GetGlobalQueryNullAsync(ClientDiagnostics, Pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: "localStringQuery", host));

        [Test]
        public Task GetGlobalAndLocalQueryNullAsync() => TestStatus("pathitem_nullable_globalstringpath_globalstringpath_pathitemstringpath_pathitemstringpath_localstringpath_localstringpath_null_pathitemstringquery_null", async host =>
            await PathItemsOperations.GetGlobalAndLocalQueryNullAsync(ClientDiagnostics, Pipeline, pathItemStringPath: "pathItemStringPath", pathItemStringQuery: "pathItemStringQuery", localStringPath: "localStringPath", localStringQuery: null, host));
    }
}
