// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Hello;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class HelloTests : CadlRanchTestBase
    {
        [Test]
        public Task Hello_world() => Test(async (host) =>
        {
            Response response = await new HelloClient(host, null).WorldAsync();
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("application/json; charset=utf-8", response.Headers.ContentType);
            JsonData responseBody = JsonData.FromBytes(response.Content.ToMemory());
            Assert.AreEqual("Hello World!", (string)responseBody);
        });
    }
}
