// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;
using ExactMatchFlattenInheritance;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ExactMatchFlattenInheritanceTests : TestProjectTests
    {
        public ExactMatchFlattenInheritanceTests()
            : base("ExactMatchFlattenInheritance")
        {
        }

        [TestCase(typeof(TrackedResource<ResourceGroupResourceIdentifier>), typeof(AzureResourceFlattenModel1Data))]
        [TestCase(typeof(TrackedResource<ResourceGroupResourceIdentifier>), typeof(AzureResourceFlattenModel2Data))]
        [TestCase(typeof(TrackedResource<ResourceGroupResourceIdentifier>), typeof(AzureResourceFlattenModel3Data))]
        [TestCase(typeof(object), typeof(AzureResourceFlattenModel4Data))]
        [TestCase(typeof(Resource<ResourceGroupResourceIdentifier>), typeof(AzureResourceFlattenModel5Data))]
        [TestCase(typeof(SubResource<ResourceGroupResourceIdentifier>), typeof(AzureResourceFlattenModel6))]
        [TestCase(typeof(WritableSubResource<ResourceGroupResourceIdentifier>), typeof(AzureResourceFlattenModel7))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
            foreach (var property in generatedClass.BaseType.GetProperties())
            {
                Assert.IsFalse(generatedClass.GetProperty(property.Name).DeclaringType == generatedClass);
            }
        }

        [TestCase(typeof(AzureResourceFlattenModel1Data), new string[] { "location", "foo", "fooPropertiesFoo" }, new Type[] { typeof(Location), typeof(string), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel2Data), new string[] { "location", "new" }, new Type[] { typeof(Location), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel3Data), new string[] { "location", "new" }, new Type[] { typeof(Location), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel4Data), new string[] { "id", "name", "type", "foo" }, new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel5Data), new string[] { "id", "name", "type", "foo" }, new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) })]
        // [TestCase(typeof(AzureResourceFlattenModel6), new string[] {}, new Type[] {})]
        [TestCase(typeof(AzureResourceFlattenModel7), new string[] { "id", "name", "type" }, new Type[] { typeof(string), typeof(string), typeof(string) })]
        public void ValidateCtor(Type model, string[] paramNames, Type[] paramTypes) => ValidatePublicCtor(model, paramNames, paramTypes);
    }
}
