// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using AnotherCustomNamespace;
using CustomNamespace;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class TypeSchemaMappingTest
    {
        [Test]
        public void ObjectTypesAreMappedToSchema()
        {
            var modelType = typeof(CustomizedModel);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("CustomNamespace", modelType.Namespace);

            var property = TypeAsserts.HasProperty(modelType, "CustomizedStringProperty", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(typeof(string), property.PropertyType);

            var field = TypeAsserts.HasField(modelType, "CustomizedFancyField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(typeof(CustomFruitEnum), field.FieldType);
        }

        [Test]
        public void EnumTypesAreMappedToSchema()
        {
            var modelType = typeof(CustomFruitEnum);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("AnotherCustomNamespace", modelType.Namespace);
            TypeAsserts.HasProperty(modelType, "Apple", BindingFlags.Static | BindingFlags.Public);
        }
    }
}
