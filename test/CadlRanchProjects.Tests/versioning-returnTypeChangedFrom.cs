// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Versioning.ReturnTypeChangedFrom;

namespace CadlRanchProjects.Tests
{
    public class VersioningReturnTypeChangedFromTests : CadlRanchTestBase
    {
        [Test]
        public Task Versioning_ReturnTypeChangedFrom_test() => Test(async (host) =>
        {
            var response = await new ReturnTypeChangedFromClient(host).TestAsync("test");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("test", response.Value);
        });
    }
}
