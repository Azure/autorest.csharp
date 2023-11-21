// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using _Type.Union;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class TypeUnionTests : CadlRanchTestBase
    {
        [Test]
        [Ignore("Ned to fix incorrect request type and response type")]
        public Task Send() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringsOnlyClient().GetStringsOnlyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
        });

    }
}
