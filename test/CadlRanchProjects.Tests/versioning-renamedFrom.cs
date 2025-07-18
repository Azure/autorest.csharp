// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Versioning.RenamedFrom;
using Versioning.RenamedFrom.Models;

namespace CadlRanchProjects.Tests
{
    public class VersioningRenamedFromTests : CadlRanchTestBase
    {
        [Test]
        public void TestRenamedMembers()
        {
            /* check the renamed model from `OldModel` to `NewModel` */
            Assert.IsNull(TestServerTestBase.FindType(typeof(NewModel).Assembly, "OldModel"));
            Assert.IsNotNull(TestServerTestBase.FindType(typeof(NewModel).Assembly, "NewModel"));

            /* check the renamed property of model */
            var properties = typeof(NewModel).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);
            Assert.IsNull(typeof(NewModel).GetProperty("OldProp"));
            Assert.IsNotNull(typeof(NewModel).GetProperty("NewProp"));

            /* check the renamed enum from `OldEnum` to `NewEnum` */
            Assert.IsNull(TestServerTestBase.FindType(typeof(NewEnum).Assembly, "OldEnum"));
            Assert.IsNotNull(TestServerTestBase.FindType(typeof(NewEnum).Assembly, "NewEnum"));

            /* check the renamed enum value */
            var enumValues = typeof(NewEnum).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(1, enumValues.Length);
            Assert.IsFalse(enumValues.Contains("OldEnumMember"));
            Assert.IsTrue(enumValues.Contains("NewEnumMember"));

            /* check the renamed operation */
            var oldMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "OldOp" || m.Name == "OldOpAsync");
            Assert.AreEqual(0, oldMethods.Count());
            var newMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "NewOp" || m.Name == "NewOpAsync");
            Assert.AreEqual(4, newMethods.Count());

            /* check the renamed interface */
            Assert.IsNull(TestServerTestBase.FindType(typeof(NewModel).Assembly, "OldInterface"));
            Assert.IsNotNull(TestServerTestBase.FindType(typeof(NewModel).Assembly, "NewInterface"));
        }

        [Test]
        public Task Versioning_RenamedFrom_newOp() => Test(async (host) =>
        {
            NewModel body = new NewModel("foo", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson(10));
            var response = await new RenamedFromClient(host).NewOpAsync("bar", body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.NewProp);
            Assert.AreEqual(NewEnum.NewEnumMember, response.Value.EnumProp);
            Assert.AreEqual(10, response.Value.UnionProp.ToObjectFromJson<int>());
        });

        [Test]
        public Task Versioning_RenamedFrom_NewInterface() => Test(async (host) =>
        {
            NewModel body = new NewModel("foo", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson(10));
            var response = await new RenamedFromClient(host).GetNewInterfaceClient().NewOpInNewInterfaceAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.NewProp);
            Assert.AreEqual(NewEnum.NewEnumMember, response.Value.EnumProp);
            Assert.AreEqual(10, response.Value.UnionProp.ToObjectFromJson<int>());
        });
    }
}
