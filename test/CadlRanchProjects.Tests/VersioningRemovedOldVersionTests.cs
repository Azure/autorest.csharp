// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Versioning.Removed.OldVersion;
using Versioning.Removed.OldVersion.Models;

namespace CadlRanchProjects.Tests
{
    public class VersioningRemovedOldVersionTests : CadlRanchTestBase
    {
        [Test]
        public Task Versioning_Removed_OldVersion_V3Model() => Test(async (host) =>
        {
            var model = new ModelV3("123", EnumV3.EnumMemberV1);
            var response = await new RemovedClient(host, Versions.V1).ModelV3Async(model);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
            Assert.AreEqual(EnumV3.EnumMemberV1, response.Value.EnumProp);
        });
    }
}
