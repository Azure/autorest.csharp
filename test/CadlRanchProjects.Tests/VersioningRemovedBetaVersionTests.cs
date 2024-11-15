// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Versioning.Removed.BetaVersion;
using Versioning.Removed.BetaVersion.Models;

namespace CadlRanchProjects.Tests
{
    public class VersioningRemovedBetaVersionTests : CadlRanchTestBase
    {
        [Test]
        public Task Versioning_Removed_BetaVersion_V3Model() => Test(async (host) =>
        {
            var model = new ModelV3("123");
            var response = await new RemovedClient(host, Versions.V2preview).ModelV3Async(model);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
        });
    }
}
