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
        public void TestRemovedMembers()
        {
            /* verify ModelV1. */
            var properties = typeof(ModelV1).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);

            /* verify EnumV1 */
            Assert.IsTrue(typeof(EnumV1).IsEnum);
            var enumValues = typeof(EnumV1).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(1, enumValues.Length);

            /* verify ModelV2. */
            var propertiesV2 = typeof(ModelV2).GetProperties();
            Assert.IsNotNull(propertiesV2);
            Assert.AreEqual(4, propertiesV2.Length);

            /* verify EnumV2 */
            Assert.IsTrue(typeof(EnumV2).IsEnum);
            var enumValuesV2 = typeof(EnumV2).GetEnumNames();
            Assert.IsNotNull(enumValuesV2);
            Assert.AreEqual(2, enumValuesV2.Length);

            /* verify ModelV3. */
            var propertiesV3 = typeof(ModelV3).GetProperties();
            Assert.IsNotNull(propertiesV3);
            Assert.AreEqual(2, propertiesV3.Length);

            /* verify EnumV3 */
            Assert.IsTrue(typeof(EnumV3).IsEnum);
            var enumValuesV3 = typeof(EnumV3).GetEnumNames();
            Assert.IsNotNull(enumValuesV3);
            Assert.AreEqual(2, enumValuesV3.Length);

            /* check existence of method v1. */
            var v1Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.IsNotNull(v1Methods);
            Assert.AreEqual(4, v1Methods.Count());

            /* check existence of method v2. */
            var v2Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.IsNotNull(v2Methods);
            Assert.AreEqual(4, v2Methods.Count());
            foreach (var method in v2Methods)
            {
                Assert.True(method.GetParameters().Any(p => p.Name == "param"));
            }

            /* check existence of method ModelV3. */
            var v3Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "ModelV3" || m.Name == "ModelV3Async");
            Assert.IsNotNull(v3Methods);
            Assert.AreEqual(4, v3Methods.Count());

            // 1 version are defined
            var enumType = typeof(Versions);
            Assert.AreEqual(new string[] { "V1"}, enumType.GetEnumNames());
        }

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
