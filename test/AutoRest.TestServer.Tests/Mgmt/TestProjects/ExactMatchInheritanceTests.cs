// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.ResourceManager.Models;
using ExactMatchInheritance;
using ExactMatchInheritance.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ExactMatchInheritanceTests : TestProjectTests
    {
        public ExactMatchInheritanceTests()
            : base("ExactMatchInheritance")
        {
        }

        [TestCase(typeof(ResourceData), typeof(ExactMatchModel1Data))]
        [TestCase(typeof(TrackedResourceData), typeof(ExactMatchModel5Data))]
        [TestCase(typeof(ExactMatchModel7), typeof(ExactMatchModel2))]
        [TestCase(typeof(ExactMatchModel8), typeof(ExactMatchModel3))]
        [TestCase(typeof(ExactMatchModel9), typeof(ExactMatchModel4))]
        [TestCase(typeof(object), typeof(ExactMatchModel9))]
        [TestCase(typeof(object), typeof(ExactMatchModel7))]
        [TestCase(typeof(object), typeof(ExactMatchModel11))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
            foreach (var property in generatedClass.BaseType.GetProperties())
            {
                Assert.IsFalse(generatedClass.GetProperty(property.Name).DeclaringType == generatedClass);
            }
        }

        [TestCase(typeof(ExactMatchModel1Data), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel2), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel3), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel4), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel5Data), new string[] { "location" }, new Type[] { typeof(AzureLocation) })]
        [TestCase(typeof(ExactMatchModel7), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel8), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel9), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel11), new string[] { }, new Type[] { })]
        public void ValidateCtor(Type model, string[] paramNames, Type[] paramTypes) => ValidatePublicCtor(model, paramNames, paramTypes);

        [TestCase("Id", "ExactMatchModel3", typeof(ResourceIdentifier))]
        [TestCase("Id", "ExactMatchModel8", typeof(ResourceIdentifier))]
        [TestCase("ResourceType", "ExactMatchModel11", typeof(ResourceType?))]
        [TestCase("ID", "ExactMatchModel7", typeof(string))]
        [TestCase("ExactMatchModel7Type", "ExactMatchModel7", typeof(string))]
        [TestCase("Id", "ExactMatchModel1Data", typeof(ResourceIdentifier))]
        [TestCase("ResourceType", "ExactMatchModel1Data", typeof(ResourceType))]
        [TestCase("SupportingUris", "ExactMatchModel1Data", typeof(IList<Uri>))]
        [TestCase("Type1", "ExactMatchModel1Data", typeof(ResourceType?))]
        [TestCase("Type2", "ExactMatchModel1Data", typeof(string))]
        public void ValidatePropertyType(string propertyName, string className, Type expectedType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == className);
            Assert.NotNull(type, $"Type {className} should exist");
            var property = type.GetProperty(propertyName);
            Assert.AreEqual(property.PropertyType, expectedType);
        }

        [TestCase(true, "ResourceType", "ExactMatchModel1Data")]
        [TestCase(false, "Type", "ExactMatchModel1Data")]
        [TestCase(true, "ResourceType", "ExactMatchModel5Data")]
        [TestCase(false, "Type", "ExactMatchModel5Data")]
        [TestCase(false, "ExactMatchModel11Type", "ExactMatchModel5Data")]
        [TestCase(true, "ExactMatchModel7Type", "ExactMatchModel2")]
        [TestCase(false, "ResourceType", "ExactMatchModel2")]
        [TestCase(false, "Type", "ExactMatchModel2")]
        [TestCase(true, "ExactMatchModel9Type", "ExactMatchModel4")]
        [TestCase(false, "ResourceType", "ExactMatchModel4")]
        [TestCase(false, "Type", "ExactMatchModel4")]
        [TestCase(true, "ExactMatchModel9Type", "ExactMatchModel9")]
        [TestCase(false, "ResourceType", "ExactMatchModel9")]
        [TestCase(false, "Type", "ExactMatchModel9")]
        public void ValidatePropertyName(bool exist, string propertyName, string className)
        {
            var type = FindTypeByName(className);
            Assert.NotNull(type, $"Type {className} should exist");
            var property = type.GetProperty(propertyName);
            Assert.AreEqual(exist, property != null, $"Property {propertyName} should {(exist ? string.Empty : "not")} exist");
        }

        private Type? FindTypeByName(string name)
        {
            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
            return allTypes.FirstOrDefault(t => t.Name == name);
        }
    }
}
