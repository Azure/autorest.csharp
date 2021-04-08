// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using url;

namespace AutoRest.TestServer.Tests
{
    public class UrlPathItemsTests : TestServerLowLevelTestBase
    {
        public UrlPathItemsTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task UrlPathItemGetAll() => TestStatus(async (host) =>
            await new PathItemsClient(globalStringPath: "globalStringPath",
                    globalStringQuery: "globalStringQuery",
                    credential: Key,
                    endpoint: host)
                .GetAllWithValuesAsync(
                    pathItemStringPath: "pathItemStringPath",
                    pathItemStringQuery: "pathItemStringQuery",
                    localStringPath: "localStringPath",
                    localStringQuery: "localStringQuery"));

        [Test]
        public Task UrlPathItemGetPathItemAndLocalNull() => TestStatus(async (host) =>
            await new PathItemsClient(globalStringPath: "globalStringPath",
                    globalStringQuery: "globalStringQuery",
                    credential: Key,
                    endpoint: host)
                .GetLocalPathItemQueryNullAsync(
                    pathItemStringPath: "pathItemStringPath",
                    pathItemStringQuery: null,
                    localStringPath: "localStringPath",
                    localStringQuery: null));

        [Test]
        public Task UrlPathItemGetGlobalNull() => TestStatus(async (host) =>
            await new PathItemsClient(globalStringPath: "globalStringPath",
                    endpoint: host,
                    credential: Key,
                    globalStringQuery: null)
                .GetGlobalQueryNullAsync(
                    pathItemStringPath: "pathItemStringPath",
                    pathItemStringQuery: "pathItemStringQuery",
                    localStringPath: "localStringPath",
                    localStringQuery: "localStringQuery"));

        [Test]
        public Task UrlPathItemGetGlobalAndLocalNull() => TestStatus(async (host) =>
            await new PathItemsClient(
                    globalStringPath: "globalStringPath",
                    endpoint: host,
                    credential: Key,
                    globalStringQuery: null)
                .GetGlobalAndLocalQueryNullAsync(
                pathItemStringPath: "pathItemStringPath",
                pathItemStringQuery: "pathItemStringQuery",
                localStringPath: "localStringPath",
                localStringQuery: null));
    }
}
