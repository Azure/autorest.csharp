// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using CustomNamespace;
using NamespaceForEnums;
using NUnit.Framework;
using TypeSchemaMapping;
using TypeSchemaMapping.Models;
using Very.Custom.Namespace.From.Swagger;

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

            var property = TypeAsserts.HasProperty(modelType, "PropertyRenamedAndTypeChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(typeof(int?), property.PropertyType);

            var field = TypeAsserts.HasField(modelType, "CustomizedFancyField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(typeof(CustomFruitEnum), field.FieldType);
        }

        [Test]
        public void ModelsAreMappedUsingClassNameOnly()
        {
            var modelType = typeof(SecondModel);

            Assert.AreEqual(3, modelType.GetProperties().Length);
            Assert.AreEqual(1, modelType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length);
            Assert.AreEqual(1, modelType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length);
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

        [Test]
        public void ObjectsAreMappedToSchemas()
        {
            Type modelType = typeof(RenamedThirdModel);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("CustomNamespace", modelType.Namespace);

            Assert.AreEqual(1, modelType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length);
            Assert.AreEqual(1, modelType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length);

            PropertyInfo firstProperty = TypeAsserts.HasProperty(modelType, "CustomizedETagProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(typeof(ETag), firstProperty.PropertyType);

            PropertyInfo secondProperty = TypeAsserts.HasProperty(modelType, "CustomizedCreatedAtProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(typeof(DateTime), secondProperty.PropertyType);
        }

        [Test]
        public void ObjectTypePropertiesSerializedAsValues()
        {
            DateTime date = DateTime.UtcNow;
            var inputModel = new RenamedThirdModel(new ETag("Id"), date);

            JsonAsserts.AssertSerialization(
                @"{""ETag"":""Id"",""CreatedAt"":" + JsonSerializer.Serialize(date) + "}",
                inputModel);
        }

        [Test]
        public void ObjectTypePropertiesDeserializedAsValues()
        {
            DateTime date = DateTime.UtcNow;
            RenamedThirdModel model = RenamedThirdModel.DeserializeRenamedThirdModel(JsonDocument.Parse("{\"ETag\":\"ETagValue\", \"CreatedAt\":" + JsonSerializer.Serialize(date) + "}").RootElement);

            Assert.AreEqual("ETagValue", model.CustomizedETagProperty.ToString());
            Assert.AreEqual(date, model.CustomizedCreatedAtProperty);
        }

        [Test]
        public void ObjectTypePropertiesSerializedAsNull()
        {
            var inputModel = new RenamedThirdModel();

            JsonAsserts.AssertSerialization(
                @"{""ETag"":""\u003Cnull\u003E"",""CreatedAt"":" + JsonSerializer.Serialize(new DateTime()) + "}",
                inputModel);
        }

        [Test]
        public void ObjectTypePropertiesDeserializedAsNull()
        {
            var model = RenamedThirdModel.DeserializeRenamedThirdModel(JsonDocument.Parse("{}").RootElement);

            Assert.AreEqual("<null>", model.CustomizedETagProperty.ToString());
            Assert.AreEqual(new DateTime(), model.CustomizedCreatedAtProperty);
        }

        [Test]
        public void MembersAreSuppressed()
        {
            var modelType = typeof(CustomizedModel);

            Assert.That(modelType.GetConstructors().Where(c => c.GetParameters().Length == 2), Is.Empty);
        }

        [Test]
        public void ClientsAreMappedToTypes()
        {
            Assert.AreEqual("MainClient", typeof(MainClient).Name);
            Assert.AreEqual("MainRestClient", typeof(MainRestClient).Name);
        }

        [Test]
        public void OperationTypeCanBeMapped()
        {
            Assert.AreEqual("MainOperation", typeof(MainOperation).Name);
        }

        [Test]
        public void ModelsUseNamespaceAndAccessibilityFromSwagger()
        {
            Assert.AreEqual("Very.Custom.Namespace.From.Swagger", typeof(ModelWithCustomNamespace).Namespace);
            Assert.False(typeof(ModelWithCustomNamespace).IsPublic);
        }

        [Test]
        public void EnumsUseNamespaceAndAccessibilityFromSwagger()
        {
            Assert.AreEqual("Very.Custom.Namespace.From.Swagger", typeof(EnumWithCustomNamespace).Namespace);
            Assert.False(typeof(EnumWithCustomNamespace).IsPublic);
        }

        [Test]
        public void CanChangeEnumKindToExtensible()
        {
            var type = typeof(NonExtensibleEnumTurnedExtensible);
            Assert.True(type.IsValueType && !type.IsEnum);
        }

        [Theory]
        [TestCase(typeof(ModelWithCustomUsage))]
        [TestCase(typeof(ModelWithCustomUsageViaAttribute))]
        public void TypesWithCustomUsageGeneratedCorrectly(Type type)
        {
            Assert.True(typeof(IUtf8JsonSerializable).IsAssignableFrom(type));
            Assert.True(typeof(IXmlSerializable).IsAssignableFrom(type));

            Assert.NotNull(type.GetMethod("Deserialize" + type.Name,
                BindingFlags.Static | BindingFlags.NonPublic,
                null,
                new[] { typeof(JsonElement) },
                null));
            Assert.NotNull(type.GetMethod("Deserialize" + type.Name,
                BindingFlags.Static | BindingFlags.NonPublic,
                null,
                new[] { typeof(XElement) },
                null));
        }
    }
}
