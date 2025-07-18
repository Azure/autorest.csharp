// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Versioning.Added;
using Versioning.Added.Models;
using System;
using System.Linq;
using System.Reflection;

namespace CadlRanchProjects.Tests
{
    public class VersioningAddedTests : CadlRanchTestBase
    {
        [Test]
        public void TestAddedMembers()
        {
            /* verify ModelV1. */
            var properties = typeof(ModelV1).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);
            /* verify added property UnionProp in V2.*/
            Assert.IsNotNull(typeof(ModelV1).GetProperty("UnionProp"));

            /* verify EnumV1. */
            Assert.True(typeof(EnumV1).IsEnum);
            var enumValues = typeof(EnumV1).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(2, enumValues.Length);
            /* verify added enum value EnumMemberV2. */
            Assert.IsTrue(enumValues.Contains("EnumMemberV2"));

            /* check existence of the added model ModelV2. */
            Assert.IsNotNull(TestServerTestBase.FindType(typeof(ModelV1).Assembly, "ModelV2"));

            /* check existence of the added enum EnumV2. */
            Assert.IsNotNull(TestServerTestBase.FindType(typeof(ModelV1).Assembly, "EnumV2"));

            /* check the added parameter. */
            var methods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.IsNotNull(methods);
            Assert.AreEqual(4, methods.Count());
            var methodsArray = methods.ToArray();
            foreach (var method in methodsArray)
            {
                Assert.True(method.GetParameters().Any(p => p.Name == "headerV2"));
            }

            /* check the existence of added method in V2. */
            var addedMethods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.IsNotNull(addedMethods);
            Assert.AreEqual(4, addedMethods.Count());

            /* check the existence of added interface in V2. */
            Assert.IsNotNull(TestServerTestBase.FindType(typeof(ModelV1).Assembly, "InterfaceV2"));
        }

        [Test]
        public Task Versioning_Added_v1() => Test(async (host) =>
        {
            ModelV1 modelV1 = new ModelV1("foo", EnumV1.EnumMemberV2, BinaryData.FromObjectAsJson(10));
            var response = await new AddedClient(host).V1Async("bar", modelV1);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
            Assert.AreEqual(EnumV1.EnumMemberV2, response.Value.EnumProp);
            Assert.AreEqual(10, response.Value.UnionProp.ToObjectFromJson<int>());
        });

        [Test]
        public Task Versioning_Added_v2() => Test(async (host) =>
        {
            ModelV2 modelV2 = new ModelV2("foo", EnumV2.EnumMember, BinaryData.FromObjectAsJson("bar"));
            var response = await new AddedClient(host).V2Async(modelV2);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
            Assert.AreEqual(EnumV2.EnumMember, response.Value.EnumProp);
            Assert.AreEqual("bar", response.Value.UnionProp.ToObjectFromJson<string>());
        });

        [Test]
        public Task Versioning_Added_InterfaceV2() => Test(async (host) =>
        {
            ModelV2 modelV2 = new ModelV2("foo", EnumV2.EnumMember, BinaryData.FromObjectAsJson("bar"));
            var response = await new AddedClient(host).GetInterfaceV2Client().V2InInterfaceAsync(modelV2);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
            Assert.AreEqual(EnumV2.EnumMember, response.Value.EnumProp);
            Assert.AreEqual("bar", response.Value.UnionProp.ToObjectFromJson<string>());
        });
    }
}
