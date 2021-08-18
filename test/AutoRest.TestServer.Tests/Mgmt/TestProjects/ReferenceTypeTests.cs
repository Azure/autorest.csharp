// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using ReferenceTypes.Models;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ReferenceTypeTests : TestProjectTests
    {
        public ReferenceTypeTests()
            : base("ReferenceTypes")
        {
        }

        private const string ReferenceNamespace = "Azure.ResourceManager.Resources.Models";
        private const string ProjectNamespace = "ReferenceTypes.Models";
        private IEnumerable<Type>? _referenceTypes;
        private IEnumerable<Type>? _projectTypes;
        private IEnumerable<Type> ReferenceTypes => _referenceTypes ??= Assembly.GetAssembly(typeof(ResourceReference)).GetTypes().Where(
            t => t.IsPublic &&
            t.Namespace == ReferenceNamespace &&
            !t.IsEnum);
        private IEnumerable<Type> ProjectTypes => _projectTypes ??= Assembly.GetAssembly(typeof(ResourceReference)).GetTypes().Where(
            t => t.IsPublic &&
            t.Namespace == ProjectNamespace &&
            !t.IsEnum);

        protected override IEnumerable<Type> MyTypes() => ReferenceTypes;

        [Test]
        public void ValidateSerialization()
        {
            //all should have serialization
            foreach (var type in ReferenceTypes)
            {
                Assert.IsNotNull(type.GetInterface("IUtf8JsonSerializable", true), $"IUtf8JsonSerializable interface was not found for {type.Name}");
                Assert.IsNotNull(type.GetMethod($"Deserialize{type.Name}", BindingFlags.NonPublic | BindingFlags.Static), $"Deserialize{type.Name} method was not found for {type.Name}");
            }
        }

        [TestCase(typeof(ResourceReference), ReferenceNamespace)]
        [TestCase(typeof(TrackedResourceReference), ReferenceNamespace)]
        [TestCase(typeof(SkuReference), ReferenceNamespace)]
        [TestCase(typeof(SkuTier), ReferenceNamespace)]
        [TestCase(typeof(ResourceNon), ProjectNamespace)]
        public void ValidateNamespace(Type typeToTest, string expectedNamespace)
        {
            //all should be resources.models namespace from referencetype
            //all should be referencetype.modesl namespace from nonreferencetype
            Assert.AreEqual(expectedNamespace, typeToTest.Namespace);
        }

        [TestCase(typeof(ResourceReference), typeof(ReferenceTypeAttribute))]
        [TestCase(typeof(TrackedResourceReference), typeof(ReferenceTypeAttribute))]
        [TestCase(typeof(SkuReference), typeof(PropertyReferenceTypeAttribute))]
        public void ValidateAttributes(Type referenceType, Type attributeType)
        {
            Assert.IsNotNull(referenceType.GetCustomAttribute(attributeType), $"ReferenceType attribute was not found for {referenceType.Name}");
            var ctors = referenceType.GetConstructors();
            Assert.IsNotNull(ctors.Any(c => c.GetCustomAttribute(typeof(InitializationConstructorAttribute)) != null), $"InitializationConstructor attribute was not found for {referenceType.Name}");
            Assert.IsNotNull(ctors.Any(c => c.GetCustomAttribute(typeof(SerializationConstructorAttribute)) != null), $"SerializationConstructor attribute was not found for {referenceType.Name}");
        }
    }
}
