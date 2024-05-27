// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using System.Threading.Tasks;
using Versioning.TypeChangedFrom;
using Versioning.TypeChangedFrom.Models;

namespace CadlRanchProjects.Tests
{
    public class VersioningTypeChangedFromTests : CadlRanchTestBase
    {
        [Test]
        public Task Versioning_TypeChangedFrom_test() => Test(async (host) =>
        {
            TestModel body = new TestModel("foo", "bar");
            var response = await new TypeChangedFromClient(host, Versions.V2).TestAsync("baz", body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
            Assert.AreEqual("bar", response.Value.ChangedProp);
        });
    }
}
