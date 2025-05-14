// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using TypeSchemaMapping.Models;
using static AutoRest.TestServer.Tests.Infrastructure.TestServerTestBase;

namespace AutoRest.TestServer.Tests
{
    public class TypeSchemaMappingTest
    {
        [Test]
        public void ObjectTypesAreMappedToSchema()
        {
            var modelType = FindType(typeof(AbstractModel).Assembly, "CustomizedModel");
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("CustomNamespace", modelType.Namespace);

            var property = TypeAsserts.HasProperty(modelType, "PropertyRenamedAndTypeChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(typeof(int?), property.PropertyType);

            var field = TypeAsserts.HasField(modelType, "CustomizedFancyField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(FindType(typeof(AbstractModel).Assembly, "CustomFruitEnum"), field.FieldType);
        }

        [Test]
        public void ModelsAreMappedUsingClassNameOnly()
        {
            var modelType = FindType(typeof(AbstractModel).Assembly, "SecondModel");

            Assert.AreEqual(3, modelType.GetProperties().Length);
            Assert.AreEqual(1, modelType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length);
            Assert.AreEqual(1, modelType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length);
        }

        [Test]
        public void ExtensibleEnumTypesAreMappedToSchema()
        {
            var modelType = FindType(typeof(AbstractModel).Assembly, "CustomDaysOfWeek");
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("NamespaceForEnums", modelType.Namespace);
            TypeAsserts.HasProperty(modelType, "FancyMonday", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void EnumTypesAreMappedToSchema()
        {
            var modelType = FindType(typeof(AbstractModel).Assembly, "CustomFruitEnum");

            Assert.True(modelType.IsEnum);
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual("NamespaceForEnums", modelType.Namespace);
            TypeAsserts.HasField(modelType, "Apple2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void StructsAreMappedToSchemas()
        {
            var modelType = FindType(typeof(AbstractModel).Assembly, "RenamedModelStruct");
            Assert.AreEqual(false, modelType.IsPublic);
            Assert.AreEqual(true, modelType.IsValueType);
            Assert.AreEqual("CustomNamespace", modelType.Namespace);

            var property = TypeAsserts.HasProperty(modelType, "CustomizedFlattenedStringProperty", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(typeof(string), property.PropertyType);

            var field = TypeAsserts.HasProperty(modelType, "Fruit", BindingFlags.Instance | BindingFlags.Public);
            // TODO: Remove nullable after https://github.com/Azure/autorest.modelerfour/issues/231 is done
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(FindType(typeof(AbstractModel).Assembly, "CustomFruitEnum")), field.PropertyType);
        }

        [Test]
        public void ObjectsAreMappedToSchemas()
        {
            Type modelType = FindType(typeof(AbstractModel).Assembly, "RenamedThirdModel");
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
        public void NullableParamsAsNull()
        {
            var model = GetObject(FindType(typeof(AbstractModel).Assembly, "RenamedModelStruct"), ["test", "test", null, null]);
            Assert.Null(GetProperty(model, "DaysOfWeek"));
            Assert.Null(GetProperty(model, "Fruit"));
        }

        [Test]
        public void ObjectTypePropertiesSerializedAsValues()
        {
            DateTime date = DateTime.UtcNow;
            var inputModel = GetObject(FindType(typeof(AbstractModel).Assembly, "RenamedThirdModel"));
            SetProperty(inputModel, "CustomizedETagProperty", new ETag("Id"));
            SetProperty(inputModel, "CustomizedCreatedAtProperty", date);

            JsonAsserts.AssertWireSerialization(
                @"{""ETag"":""Id"",""CreatedAt"":" + JsonSerializer.Serialize(date) + "}",
                inputModel);
        }

        [Test]
        public void ObjectTypePropertiesDeserializedAsValues()
        {
            DateTime date = DateTime.UtcNow;
            var model = ModelReaderWriter.Read(BinaryData.FromString("{\"ETag\":\"ETagValue\", \"CreatedAt\":" + JsonSerializer.Serialize(date) + "}"), FindType(typeof(AbstractModel).Assembly, "RenamedThirdModel"));

            Assert.AreEqual("ETagValue", GetProperty(model, "CustomizedETagProperty").ToString());
            Assert.AreEqual(date, GetProperty(model, "CustomizedCreatedAtProperty"));
        }

        [Test]
        public void ObjectTypePropertiesSerializedAsNull()
        {
            var inputModel = Activator.CreateInstance(FindType(typeof(AbstractModel).Assembly, "RenamedThirdModel"));
            JsonAsserts.AssertWireSerialization(
                @"{""ETag"":"""",""CreatedAt"":" + JsonSerializer.Serialize(new DateTime()) + "}",
                inputModel);
        }
        [Test]
        public void ObjectTypePropertiesDeserializedAsNull()
        {
            var model = ModelReaderWriter.Read(BinaryData.FromString("{}"), FindType(typeof(AbstractModel).Assembly, "RenamedThirdModel"));
            Assert.AreEqual(default(ETag), GetProperty(model, "CustomizedETagProperty"));
            Assert.AreEqual(default(DateTime), GetProperty(model, "CustomizedCreatedAtProperty"));
        }

        [Test]
        public void MembersAreSuppressed()
        {
            var modelType = FindType(typeof(AbstractModel).Assembly, "CustomizedModel");

            Assert.That(modelType.GetConstructors().Where(c => c.GetParameters().Length == 2), Is.Empty);
        }

        [Test]
        public void ClientsAreMappedToTypes()
        {
            Assert.AreEqual("MainClient", FindType(typeof(AbstractModel).Assembly, "MainClient").Name);
            Assert.AreEqual("MainRestClient", FindType(typeof(AbstractModel).Assembly, "MainRestClient").Name);
        }

        [Test]
        public void OperationTypeCanBeMapped()
        {
            Assert.AreEqual("MainOperation", FindType(typeof(AbstractModel).Assembly, "MainOperation").Name);
        }

        [Test]
        public void ModelsUseNamespaceAndAccessibilityFromSwagger()
        {
            Assert.AreEqual("Very.Custom.Namespace.From.Swagger", FindType(typeof(AbstractModel).Assembly, "ModelWithCustomNamespace").Namespace);
            Assert.False(FindType(typeof(AbstractModel).Assembly, "ModelWithCustomNamespace").IsPublic);
        }

        [Test]
        public void EnumsUseNamespaceAndAccessibilityFromSwagger()
        {
            Assert.AreEqual("Very.Custom.Namespace.From.Swagger", FindType(typeof(AbstractModel).Assembly, "EnumWithCustomNamespace").Namespace);
            Assert.False(FindType(typeof(AbstractModel).Assembly, "EnumWithCustomNamespace").IsPublic);
        }

        [Test]
        public void CanChangeEnumKindToExtensible()
        {
            var type = FindType(typeof(AbstractModel).Assembly, "NonExtensibleEnumTurnedExtensible");
            Assert.True(type.IsValueType && !type.IsEnum);
        }

        [Theory]
        [TestCase(typeof(ModelWithCustomUsage))]
        [TestCase(typeof(ModelWithCustomUsageViaAttribute))]
        public void TypesWithCustomUsageGeneratedCorrectly(Type type)
        {
            Assert.True(type.GetInterfaces().Any(i => i.Name == nameof(IUtf8JsonSerializable)));
            Assert.True(type.GetInterfaces().Any(i => i.Name == nameof(IXmlSerializable)));

            Assert.NotNull(type.GetMethod("Deserialize" + type.Name,
                BindingFlags.Static | BindingFlags.NonPublic,
                null,
                new[] { typeof(JsonElement), typeof(ModelReaderWriterOptions) },
                null));
            Assert.NotNull(type.GetMethod("Deserialize" + type.Name,
                BindingFlags.Static | BindingFlags.NonPublic,
                null,
                new[] { typeof(XElement), typeof(ModelReaderWriterOptions) },
                null));
        }

        [Test]
        public void GuidPropertyDeserializedCorrectly()
        {
            Guid guid = Guid.NewGuid();
            var testel = new XElement("Root");
            testel.SetElementValue(XName.Get("ModelProperty"), guid);
            ModelWithGuidProperty model = ModelReaderWriter.Read<ModelWithGuidProperty>(BinaryData.FromString(testel.ToString()), ModelReaderWriterOptions.Xml);

            Assert.AreEqual(guid.ToString(), model.ModelProperty.ToString());
        }

        [Test]
        public void UriPropertyDeserializedCorrectly()
        {
            DateTime date = DateTime.UtcNow;
            ModelWithUriProperty model = ModelReaderWriter.Read<ModelWithUriProperty>(BinaryData.FromString("{\"Uri\":\"http://localhost\"}"));

            Assert.AreEqual("http://localhost/", model.Uri.AbsoluteUri);
        }

        [Test]
        public void UriPropertySerializedCorrectly()
        {
            var inputModel = new ModelWithUriProperty();
            inputModel.Uri = new Uri("http://localhost");

            JsonAsserts.AssertWireSerialization(
                @"{""Uri"":""http://localhost/""}",
                inputModel);
        }

        [Test]
        public void UnexposedExtensibleEnumsAreInternal()
        {
            var modelType = FindType(typeof(AbstractModel).Assembly, "UnexposedExtensibleEnum");
            Assert.AreEqual(false, modelType.IsPublic);
        }

        [Test]
        public void UnexposedNonExtensibleEnumsAreInternal()
        {
            TypeAsserts.TypeIsNotPublic(FindType(typeof(AbstractModel).Assembly, "UnexposedNonExtensibleEnum"));
        }

        [Test]
        public void ModelFactoryIsRenamed()
        {
            TypeAsserts.HasNoType(FindType(typeof(AbstractModel).Assembly, "MainModelFactory").Assembly, "TypeSchemaMapping.SchemaMappingModelFactory");
        }

        [Test]
        public void ModelFactoryIsInternal()
        {
            TypeAsserts.TypeIsNotPublic(FindType(typeof(AbstractModel).Assembly, "MainModelFactory"));
        }

        [Test]
        public void ModelFactoryPublicMethods()
        {
            TypeAsserts.TypeOnlyDeclaresThesePublicMethods(FindType(typeof(AbstractModel).Assembly, "MainModelFactory"), nameof(ModelWithGuidProperty), nameof(ModelWithAbstractModel));
        }

        [Test]
        public void TypesAreSkipped()
        {
            TypeAsserts.HasNoType(FindType(typeof(AbstractModel).Assembly, "CustomizedModel").Assembly, "ModelToBeSkipped");
            TypeAsserts.HasNoType(FindType(typeof(AbstractModel).Assembly, "CustomizedModel").Assembly, "EnumToBeSkipped");
            TypeAsserts.HasNoType(FindType(typeof(AbstractModel).Assembly, "CustomizedModel").Assembly, "EnumToBeSkippedExtensions");
        }
    }
}
