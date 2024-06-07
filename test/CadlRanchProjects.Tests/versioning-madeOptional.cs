// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Versioning.MadeOptional;
using Versioning.MadeOptional.Models;

namespace CadlRanchProjects.Tests
{
    public class VersioningMadeOptionalTests : CadlRanchTestBase
    {
        [Test]
        public void CheckMadeOptionalMemebers()
        {
            var constructors = typeof(TestModel).GetConstructors();
            Assert.IsNotNull(constructors);
            Assert.AreEqual(1, constructors.Length);
            /* optional property will not show in public constructor signature. */
            Assert.False(constructors[0].GetParameters().Any(p => p.Name == "changedProp"));
        }

        [Test]
        public Task Versioning_MadeOptional_test() => Test(async (host) =>
        {
            TestModel body = new TestModel("foo");
            var response = await new MadeOptionalClient(host, Versions.V2).TestAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
        });
    }
}
