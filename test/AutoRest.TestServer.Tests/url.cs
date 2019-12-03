// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public Task GetEnumValid() => TestStatus("customuri", async host => await PathsOperations.EnumValidAsync(ClientDiagnostics, Pipeline, UriColor.GreenColor, host));
    }
}
