// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using AutoRest.TestServer.Tests.Infrastructure;
using llc_initial_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class LlcInitialTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task GetRequired() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).GetRequiredAsync("a", "b", "c");
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
        });
    }
}
