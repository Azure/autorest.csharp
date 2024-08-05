// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using Versioning.Removed;
using Versioning.Removed.Models;

namespace CadlRanchProjects.Tests
{
    public class VersioningRemovedTests : CadlRanchTestBase
    {
        [Test]
        public void TestRemovedMembers()
        {
            /* check existence of the removed model ModelV1. */
            Assert.IsNull(Type.GetType("Versioning.Removed.Models.ModelV1"));

            /* check existence of the removed enum EnumV1. */
            Assert.IsNull(Type.GetType("Versioning.Removed.Models.EnumV1"));

            /* verify ModelV2. */
            var properties = typeof(ModelV2).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);
            /* verify removed property RemovedProp in V2.*/
            Assert.IsNull(typeof(ModelV2).GetProperty("RemovedProp"));

            /* verify EnumV2 */
            Assert.IsTrue(typeof(EnumV2).IsEnum);
            var enumValues = typeof(EnumV2).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(1, enumValues.Length);
            /* verify added enum value EnumMemberV1. */
            Assert.IsFalse(enumValues.Contains("EnumMemberV1"));

            /* check existence of removed method V1 */
            var removedMethods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.AreEqual(0, removedMethods.Count());

            /* check existence of removed parameter. */
            var v2Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.IsNotNull(v2Methods);
            Assert.AreEqual(4, v2Methods.Count());
            foreach (var method in v2Methods)
            {
                Assert.False(method.GetParameters().Any(p => p.Name == "param"));
            }

            /* check existence of removed interface. */
            Assert.IsNull(Type.GetType("Versioning.Removed.InterfaceV1"));
        }

        [Test]
        public Task Versioning_Removed_v2() => Test(async (host) =>
        {
            ModelV2 modelV2 = new ModelV2("foo", EnumV2.EnumMemberV2, BinaryData.FromObjectAsJson("bar"));
            var response = await new RemovedClient(host, Versions.V2).V2Async(modelV2);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
            Assert.AreEqual(EnumV2.EnumMemberV2, response.Value.EnumProp);
            Assert.AreEqual("bar", response.Value.UnionProp.ToObjectFromJson<string>());
        });

        [Test]
        public Task Versioning_Removed_V3_V2() => Test(async (host) =>
        {
            ModelV3 modelV3 = new ModelV3("123", "bar");
            var response = await new RemovedClient(host, Versions.V2).V3Async(modelV3);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
            Assert.AreEqual("bar", response.Value.Type);
        });

        [Test]
        public Task Versioning_Removed_V3_V1() => Test(async (host) =>
        {
            ModelV3 modelV3 = new ModelV3("123", "bar");
            var response = await new RemovedClient(host, Versions.V1).V3Async(modelV3);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
            Assert.AreEqual("bar", response.Value.Type);
        });

        [Test]
        public Task Versioning_Removed_V3_Beta() => Test(async (host) =>
        {
            ModelV3 modelV3 = new ModelV3("123", "bar");
            var response = await new RemovedClient(host, Versions.Beta).V3Async(modelV3);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
            Assert.AreEqual("bar", response.Value.Type);
        });
    }
}
