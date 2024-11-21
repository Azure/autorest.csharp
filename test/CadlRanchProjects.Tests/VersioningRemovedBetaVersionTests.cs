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
        public void TestRemovedMembers()
        {
            /* verify ModelV1. */
            var propertiesV1 = typeof(ModelV1).GetProperties();
            Assert.IsNotNull(propertiesV1);
            Assert.AreEqual(3, propertiesV1.Length);

            /* verify EnumV1 */
            Assert.IsTrue(typeof(EnumV1).IsEnum);
            var enumValuesV1 = typeof(EnumV1).GetEnumNames();
            Assert.IsNotNull(enumValuesV1);
            Assert.AreEqual(1, enumValuesV1.Length);

            /* verify ModelV2. */
            var properties = typeof(ModelV2).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(4, properties.Length);
            /* verify property RemovedProp in V2.*/
            Assert.IsNotNull(typeof(ModelV2).GetProperty("RemovedProp"));

            /* verify EnumV2 */
            Assert.IsTrue(typeof(EnumV2).IsEnum);
            var enumValues = typeof(EnumV2).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(2, enumValues.Length);

            /* verify ModelV3. */
            var propertiesv3 = typeof(ModelV3).GetProperties();
            Assert.IsNotNull(propertiesv3);
            Assert.AreEqual(1, propertiesv3.Length);
            /* verify property id in ModelV3.*/
            Assert.IsNotNull(typeof(ModelV3).GetProperty("Id"));

            /* check existence of method V1 */
            var v1Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.IsNotNull(v1Methods);
            Assert.AreEqual(4, v1Methods.Count());

            /* check existence of method V2. */
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

            // All 2 versions are defined
            var enumType = typeof(Versions);
            Assert.AreEqual(new string[] { "V1", "V2preview"}, enumType.GetEnumNames());
        }

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
