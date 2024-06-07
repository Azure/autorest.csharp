// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using Versioning.ReturnTypeChangedFrom;
using Versioning.ReturnTypeChangedFrom.Models;

namespace CadlRanchProjects.Tests
{
    public class VersioningReturnTypeChangedFromTests : CadlRanchTestBase
    {
        [Test]
        public Task Versioning_ReturnTypeChangedFrom_test() => Test(async (host) =>
        {
            var response = await new ReturnTypeChangedFromClient(host, Versions.V2).TestAsync("test");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("test", response.Value);
        });
    }
}
