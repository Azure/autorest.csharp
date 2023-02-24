// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Azure;
using System.Collections.Generic;
using CollectionFormat;

namespace CadlRanchProjects.Tests
{
    public class CollectionFormatTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task CollectionFormat_testMulti() => Test(async (host) =>
        {
            List<string> colors = new List<string>() { "blue", "red", "green" };
            Response response = await new CollectionFormatClient(host, null).TestMultiAsync(colors);
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task CollectionFormat_testCsv() => Test(async (host) =>
        {
            List<string> colors = new List<string>() { "blue", "red", "green" };
            Response response = await new CollectionFormatClient(host, null).TestCsvAsync(colors);
            Assert.AreEqual(200, response.Status);
        });
    }
}
