// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            TypeAsserts.HasProperty(modelType, "ModelProperty");

            var fruitProperty = TypeAsserts.HasProperty(modelType, "Fruit");
            Assert.AreEqual(typeof(CustomFruitEnum), fruitProperty.PropertyType);
        }

        [Test]
        public void EnumTypesAreMappedToSchema()
        {
            var modelType = typeof(CustomFruitEnum);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("AnotherCustomNamespace", modelType.Namespace);
            TypeAsserts.HasProperty(modelType, "Apple");
        }
    }
}
