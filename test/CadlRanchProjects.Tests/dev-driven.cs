// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using dev_driven_cadl;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class DevDrivenTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task GetRawModel() => Test(async (host) =>
        {
            Response response = await new TestserverClient(host, null).GetModelAsync("raw");
            JsonData responseBody = JsonData.FromBytes(response.Content.ToMemory());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("raw", result.GetProperty("received").ToString());
        }, new[] { TestServerType.CadlRanch });
    }
}
