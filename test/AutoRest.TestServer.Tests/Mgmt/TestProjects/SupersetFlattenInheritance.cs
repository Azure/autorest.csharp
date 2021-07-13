// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Core;
using SupersetFlattenInheritance;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class SupersetFlattenInheritanceTests : TestProjectTests
    {
        public SupersetFlattenInheritanceTests()
            : base("SupersetFlattenInheritance")
        {
        }

        [TestCase(typeof(object), typeof(CustomModel1Data))]
        [TestCase(typeof(object), typeof(CustomModel2Data))]
        [TestCase(typeof(SubResource<ResourceGroupResourceIdentifier>), typeof(SubResourceModel1Data))]
        [TestCase(typeof(SubResource<ResourceGroupResourceIdentifier>), typeof(SubResourceModel2Data))]
        [TestCase(typeof(WritableSubResource<ResourceGroupResourceIdentifier>), typeof(WritableSubResourceModel1Data))]
        [TestCase(typeof(WritableSubResource<ResourceGroupResourceIdentifier>), typeof(WritableSubResourceModel2Data))]
        [TestCase(typeof(Resource<ResourceGroupResourceIdentifier>), typeof(ResourceModel1Data))]
        [TestCase(typeof(Resource<ResourceGroupResourceIdentifier>), typeof(ResourceModel2Data))]
        [TestCase(typeof(TrackedResource<ResourceGroupResourceIdentifier>), typeof(TrackedResourceModel1Data))]
        [TestCase(typeof(TrackedResource<ResourceGroupResourceIdentifier>), typeof(TrackedResourceModel2Data))]
        [TestCase(typeof(object), typeof(NonResourceModel1))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
            foreach (var property in generatedClass.BaseType.GetProperties())
            {
                Assert.IsFalse(generatedClass.GetProperty(property.Name).DeclaringType == generatedClass);
            }
        }

        [TestCase(typeof(CustomModel1Data), typeof(CustomModel2Data))]
        [TestCase(typeof(CustomModel1Data), typeof(SubResourceModel2Data))]
        [TestCase(typeof(CustomModel1Data), typeof(WritableSubResourceModel2Data))]
        [TestCase(typeof(SubResourceModel1Data), typeof(ResourceModel2Data))]
        [TestCase(typeof(ResourceModel1Data), typeof(TrackedResourceModel2Data))]
        [TestCase(typeof(CustomModel1Data), typeof(NonResourceModel1))]
        public void ValidateFlattenType(Type sourceType, Type targetType)
        {
            // source type is not the parent of the target type
            Assert.AreNotEqual(sourceType, targetType.BaseType);
            // all properties of source type should be in the target type
            foreach (var property in sourceType.GetProperties())
            {
                Assert.IsTrue(targetType.GetProperty(property.Name).GetType() == property.GetType() );
            }
        }

        [TestCase(typeof(CustomModel1Data), new string[] { "foo" }, new Type[] { typeof(string) })]
        [TestCase(typeof(CustomModel2Data), new string[] { "foo", "bar" }, new Type[] { typeof(string), typeof(string) })]
        [TestCase(typeof(SubResourceModel1Data), new string[] { "id", "foo" }, new Type[] { typeof(string), typeof(string) })]
        [TestCase(typeof(SubResourceModel2Data), new string[] { "id", "foo" }, new Type[] { typeof(string), typeof(string) })]
        [TestCase(typeof(WritableSubResourceModel1Data), new string[] { "id", "foo" }, new Type[] { typeof(string), typeof(string) })]
        [TestCase(typeof(WritableSubResourceModel2Data), new string[] { "id", "foo" }, new Type[] { typeof(string), typeof(string) })]
        [TestCase(typeof(ResourceModel1Data), new string[] { "id", "name", "type", "foo"}, new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) })]
        [TestCase(typeof(ResourceModel1Data), new string[] { "id", "name", "type", "foo"}, new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) })]
        [TestCase(typeof(TrackedResourceModel1Data), new string[] { "location" }, new Type[] { typeof(Location) })]
        [TestCase(typeof(TrackedResourceModel2Data), new string[] { "location" }, new Type[] { typeof(Location) })]
        [TestCase(typeof(NonResourceModel1), new string[] { "foo", "bar" }, new Type[] { typeof(string), typeof(string) })]
        public void ValidateCtor(Type model, string[] paramNames, Type[] paramTypes) => ValidatePublicCtor(model, paramNames, paramTypes);
    }
}
