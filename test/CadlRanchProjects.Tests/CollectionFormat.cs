// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Azure;
using System.Collections.Generic;
using Parameters.CollectionFormat;

namespace CadlRanchProjects.Tests
{
    public class CollectionFormatTests : CadlRanchTestBase
    {
        [Test]
        public Task CollectionFormat_testMulti() => Test(async (host) =>
        {
            List<string> colors = new List<string>() { "blue", "red", "green" };
            Response response = await new CollectionFormatClient(host, null).GetQueryClient().MultiAsync(colors);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task CollectionFormat_testCsv() => Test(async (host) =>
        {
            List<string> colors = new List<string>() { "blue", "red", "green" };
            Response response = await new CollectionFormatClient(host, null).GetQueryClient().CsvAsync(colors);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task CollectionFormat_testCsvHeader() => Test(async (host) =>
        {
            List<string> colors = new List<string>() { "blue", "red", "green" };
            Response response = await new CollectionFormatClient(host, null).GetHeaderClient().CsvAsync(colors);
            Assert.AreEqual(204, response.Status);
        });
    }
}
