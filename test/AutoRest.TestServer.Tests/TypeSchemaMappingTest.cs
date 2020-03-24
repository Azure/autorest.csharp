// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using NamespaceForEnums;
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
        public void ExtensibleEnumTypesAreMappedToSchema()
        {
            var modelType = typeof(CustomDaysOfWeek);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("NamespaceForEnums", modelType.Namespace);
            TypeAsserts.HasProperty(modelType, "FancyMonday", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void EnumTypesAreMappedToSchema()
        {
            var modelType = typeof(CustomFruitEnum);

            Assert.True(modelType.IsEnum);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("NamespaceForEnums", modelType.Namespace);
            TypeAsserts.HasField(modelType, "Apple2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void UserDefinedDefaultCtorsOverrideDefault()
        {
            var modelType = typeof(CustomizedModel);
            Assert.NotNull(modelType.GetConstructors().SingleOrDefault(c => !c.IsStatic && !c.GetParameters().Any()));
        }

        [Test]
        public void StructsAreMappedToSchemas()
        {
            var modelType = typeof(RenamedModelStruct);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual(true, modelType.IsValueType);
            Assert.AreEqual("CustomNamespace", modelType.Namespace);

            var property = TypeAsserts.HasProperty(modelType, "CustomizedFlattenedStringProperty", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(typeof(string), property.PropertyType);

            var field = TypeAsserts.HasProperty(modelType, "Fruit", BindingFlags.Instance | BindingFlags.Public);
            // TODO: Remove nullable after https://github.com/Azure/autorest.modelerfour/issues/231 is done
            Assert.AreEqual(typeof(CustomFruitEnum?), field.PropertyType);
        }
    }
}
