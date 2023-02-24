// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Azure;
using ArrayAsQueryOrHeader;
using System.Collections.Generic;

namespace CadlRanchProjects.Tests
{
    public class CollectionFormatCadlTests : CadlRanchMockApiTestBase
    {
        [Test]
        public Task CollectionFormat_CsvQueryAsync() => Test(async (host) =>
        {
            List<string> options = new List<string>() { "value1", "value2", "value3" };
            Response response = await new ArrayAsQueryOrHeaderClient(host).CsvQueryAsync(options);
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task CollectionFormat_MultiQueryAsync() => Test(async (host) =>
        {
            List<string> options = new List<string>(){"value1", "value2", "value3"};
            Response response = await new ArrayAsQueryOrHeaderClient(host).MultiQueryAsync(options);
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task CollectionFormat_NoFormatQueryAsync() => Test(async (host) =>
        {
            List<string> options = new List<string>() { "value1", "value2", "value3" };
            Response response = await new ArrayAsQueryOrHeaderClient(host).NoFormatQueryAsync(options);
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task CollectionFormat_CsvHeaderAsync() => Test(async (host) =>
        {
            List<string> options = new List<string>(){"value1", "value2", "value3"};
            Response response = await new ArrayAsQueryOrHeaderClient(host).CsvHeaderAsync(options);
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task CollectionFormat_NoFormatHeaderAsync() => Test(async (host) =>
        {
            List<string> options = new List<string>() { "value1", "value2", "value3" };
            Response response = await new ArrayAsQueryOrHeaderClient(host).NoFormatHeaderAsync(options);
            Assert.AreEqual(200, response.Status);
        });
    }
}
