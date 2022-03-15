// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Models;
using NUnit.Framework;
using SupersetInheritance;
using SupersetInheritance.Models;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class SupersetInheritanceTests : TestProjectTests
    {
        public SupersetInheritanceTests()
            : base("SupersetInheritance")
        {
        }

        [TestCase(typeof(ResourceData), typeof(SupersetModel1ResourceData))]
        [TestCase(typeof(Object), typeof(SupersetModel2))]
        [TestCase(typeof(Object), typeof(SupersetModel3))]
        [TestCase(typeof(TrackedResourceData), typeof(SupersetModel4ResourceData))]
        [TestCase(typeof(SupersetModel4ResourceData), typeof(SupersetModel5))]
        [TestCase(typeof(ResourceData), typeof(SupersetModel6ResourceData))]
        [TestCase(typeof(Object), typeof(SupersetModel7ResourceData))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
            foreach (var property in generatedClass.BaseType.GetProperties())
            {
                Assert.IsFalse(generatedClass.GetProperty(property.Name).DeclaringType == generatedClass);
            }
        }

        [TestCase(typeof(SupersetModel1ResourceData), new string[] { }, new Type[] { })]
        [TestCase(typeof(SupersetModel2), new string[] { }, new Type[] { })]
        [TestCase(typeof(SupersetModel3), new string[] { }, new Type[] { })]
        [TestCase(typeof(SupersetModel4ResourceData), new string[] { "location" }, new Type[] { typeof(AzureLocation) })]
        [TestCase(typeof(SupersetModel5), new string[] { "location" }, new Type[] { typeof(AzureLocation) })]
        [TestCase(typeof(SupersetModel6ResourceData), new string[] { }, new Type[] { })]
        [TestCase(typeof(SupersetModel7ResourceData), new string[] { }, new Type[] { })]
        public void ValidateCtor(Type model, string[] paramNames, Type[] paramTypes) => ValidatePublicCtor(model, paramNames, paramTypes);
    }
}
