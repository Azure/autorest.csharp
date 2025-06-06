// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using AutoRest.TestServer.Tests.Infrastructure;
using ModelShapes.Models;
using NUnit.Framework;
using TypeSchemaMapping.Models;
using static AutoRest.TestServer.Tests.Infrastructure.TestServerTestBase;

namespace AutoRest.TestServer.Tests
{
    public class ModelShapeTests
    {
        [Test]
        public void UnusedModelAreInternal()
        {
            Assert.False(FindType(typeof(InputModel).Assembly, "UnusedModel").IsPublic);
        }

        [Test]
        public void InputModelsHaveOnlyOnePublicCtor()
        {
            Assert.AreEqual(1, typeof(InputModel).GetConstructors().Length);
        }

        [Test]
        public void RequiredPropertiesAreSetableInMixedModels()
        {
            var requiredInt = TypeAsserts.HasProperty(typeof(MixedModel), "RequiredInt", BindingFlags.Public | BindingFlags.Instance);
            var requiredString = TypeAsserts.HasProperty(typeof(MixedModel), "RequiredString", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredInt.SetMethod);
            Assert.NotNull(requiredString.SetMethod);
        }

        [Test]
        public void RequiredPropertiesAreNotSetableInInputModels()
        {
            var requiredInt = TypeAsserts.HasProperty(typeof(InputModel), "RequiredInt", BindingFlags.Public | BindingFlags.Instance);
            var requiredString = TypeAsserts.HasProperty(typeof(InputModel), "RequiredString", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(requiredInt.SetMethod);
            Assert.Null(requiredString.SetMethod);
        }

        [Test]
        public void RequiredListsAreReadOnly()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(InputModel), "RequiredIntList", BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(InputModel), "RequiredStringList", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(requiredIntList.SetMethod);
            Assert.Null(requiredStringList.SetMethod);
        }

        [Test]
        public void RequiredNullableListsOnInputsAreWriteable()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(InputModel), "RequiredNullableIntList", BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(InputModel), "RequiredNullableStringList", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredIntList.SetMethod);
            Assert.NotNull(requiredStringList.SetMethod);
        }

        [Test]
        public void RequiredNullableListsAreNotNullByDefault()
        {
            var input = CreateInputModel();
            Assert.NotNull(input.RequiredNullableIntList);
            Assert.NotNull(input.RequiredNullableStringList);
        }

        [Test]
        public void RequiredNullableListsOnMixedAreWriteableAndNullByDefault()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(MixedModel), "RequiredNullableIntList", BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(MixedModel), "RequiredNullableStringList", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredIntList.SetMethod);
            Assert.NotNull(requiredStringList.SetMethod);
        }

        [Test]
        public void NotRequiredNullableListsAreSetable()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(MixedModel), "NonRequiredNullableIntList", BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(MixedModel), "NonRequiredNullableStringList", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredIntList.SetMethod);
            Assert.NotNull(requiredStringList.SetMethod);
        }

        [Test]
        public void NotRequiredNullableListsAreNotNullByDefault()
        {
            var inputModel = CreateInputModel();

            Assert.NotNull(inputModel.NonRequiredNullableIntList);
            Assert.NotNull(inputModel.NonRequiredNullableStringList);
        }


        [Test]
        public void NotRequiredNullablePropertiesOmitedByDefault()
        {
            var inputModel = CreateInputModel();

            var element = JsonAsserts.AssertWireSerializes(inputModel);
            Assert.False(element.TryGetProperty("NonRequiredNullableInt", out _));
            Assert.False(element.TryGetProperty("NonRequiredNullableString", out _));
            Assert.False(element.TryGetProperty("NonRequiredNullableIntList", out _));
            Assert.False(element.TryGetProperty("NonRequiredNullableStringList", out _));
        }

        [Test]
        public void NotRequiredNullableListsSerializedAsNull()
        {
            var inputModel = CreateInputModel();
            inputModel.NonRequiredNullableIntList = null;
            inputModel.NonRequiredNullableStringList = null;

            var element = JsonAsserts.AssertWireSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("NonRequiredNullableIntList").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("NonRequiredNullableStringList").ValueKind);
        }

        [Test]
        public void NotRequiredNullableListsSerializedEmptyWhenCleared()
        {
            var inputModel = CreateInputModel();
            inputModel.NonRequiredNullableIntList.Clear();
            inputModel.NonRequiredNullableStringList.Clear();

            var element = JsonAsserts.AssertWireSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("NonRequiredNullableIntList").ValueKind);
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("NonRequiredNullableStringList").ValueKind);
        }

        [Test]
        public void NotRequiredNullablePropertiesSerializeWhenSet()
        {
            var inputModel = CreateInputModel();
            inputModel.NonRequiredNullableInt = 1;
            inputModel.NonRequiredNullableString = "2";

            var element = JsonAsserts.AssertWireSerializes(inputModel);
            Assert.AreEqual(1, element.GetProperty("NonRequiredNullableInt").GetInt32());
            Assert.AreEqual("2", element.GetProperty("NonRequiredNullableString").GetString());
        }

        [Test]
        public void NotRequiredNullablePropertiesDeserializedWithNulls()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{\"NonRequiredNullableInt\":null, \"NonRequiredNullableString\": null}"));
            Assert.Null(model.NonRequiredNullableInt);
            Assert.Null(model.NonRequiredNullableString);
        }

        [Test]
        public void NotRequiredNullablePropertiesDeserializedWithNullsWhenUndefined()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{}"));
            Assert.Null(model.NonRequiredNullableInt);
            Assert.Null(model.NonRequiredNullableString);
        }

        [Test]
        public void NotRequiredNullablePropertiesDeserializedWithValues()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{\"NonRequiredNullableInt\":1, \"NonRequiredNullableString\": \"2\"}"));
            Assert.AreEqual(1, model.NonRequiredNullableInt);
            Assert.AreEqual("2", model.NonRequiredNullableString);
        }

        [Test]
        public void NullablePropertiesCanBeInitializedWithNull()
        {
            var inputModel = new InputModel(
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                null,
                null,
                null,
                null,
                ReadOnlyMemory<float>.Empty,
                ReadOnlyMemory<float>.Empty,
                null,
                null
            );

            Assert.IsNull(inputModel.RequiredNullableInt);
            Assert.IsNull(inputModel.RequiredNullableString);
            Assert.IsNull(inputModel.RequiredNullableIntList);
            Assert.IsNull(inputModel.RequiredNullableStringList);
        }

        [Test]
        public void NullablePropertiesSerializedAsNulls()
        {
            var inputModel = new InputModel(
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                null,
                null,
                null,
                null,
                ReadOnlyMemory<float>.Empty,
                ReadOnlyMemory<float>.Empty,
                null,
                null
            );

            var element = JsonAsserts.AssertWireSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("RequiredNullableString").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("RequiredNullableInt").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("RequiredNullableStringList").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("RequiredNullableIntList").ValueKind);
        }

        [Test]
        public void NullablePropertiesSerializedAsEmptyLists()
        {
            var inputModel = new InputModel(
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                ReadOnlyMemory<float>.Empty,
                ReadOnlyMemory<float>.Empty,
                null,
                null

            );

            var element = JsonAsserts.AssertWireSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("RequiredNullableStringList").ValueKind);
            Assert.AreEqual(0, element.GetProperty("RequiredNullableStringList").GetArrayLength());
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("RequiredNullableIntList").ValueKind);
            Assert.AreEqual(0, element.GetProperty("RequiredNullableIntList").GetArrayLength());
        }

        [Test]
        public void NullablePropertiesDeserializedAsNullsWithUndefined()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{}"));
            Assert.IsNull(model.RequiredNullableIntList);
            Assert.IsNull(model.RequiredNullableStringList);
        }

        [Test]
        public void NullablePropertiesDeserializedAsUndefinedWithNulls()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{\"RequiredNullableIntList\":null, \"RequiredNullableStringList\": null}"));
            Assert.IsNotNull(model.RequiredNullableIntList);
            Assert.IsFalse(!(bool?)GetProperty(model.RequiredNullableIntList, "IsUndefined"));
            Assert.IsNotNull(model.RequiredNullableStringList);
            Assert.IsFalse(!(bool?)GetProperty(model.RequiredNullableStringList, "IsUndefined"));
        }

        [Test]
        public void NullablePropertiesDeserializedAsValues()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{\"RequiredNullableIntList\":[1,2,3], \"RequiredNullableStringList\": [\"a\", \"b\"]}"));
            Assert.AreEqual(new[] { 1, 2, 3 }, model.RequiredNullableIntList);
            Assert.AreEqual(new[] { "a", "b" }, model.RequiredNullableStringList);
        }

        [Test]
        public void InputModelDoesntSerializeOptionalCollections()
        {
            var inputModel = CreateInputModel();

            // Perform non mutating operations
            _ = inputModel.NonRequiredIntList.Count;
            _ = inputModel.NonRequiredStringList.Count;
            _ = inputModel.NonRequiredIntList.Count();
            _ = inputModel.NonRequiredStringList.Count();
            _ = inputModel.NonRequiredIntList.IsReadOnly;
            _ = inputModel.NonRequiredStringList.IsReadOnly;
            _ = inputModel.NonRequiredIntList.Remove(1);
            _ = inputModel.NonRequiredStringList.Remove("s");

            var element = JsonAsserts.AssertWireSerializes(inputModel);

            Assert.False(element.TryGetProperty("NonRequiredStringList", out _));
            Assert.False(element.TryGetProperty("NonRequiredIntList", out _));
        }

        [Test]
        public void InputModelSerializeOptionalCollectionAfterMutation()
        {
            var inputModel = CreateInputModel();

            inputModel.NonRequiredIntList.Add(1);
            inputModel.NonRequiredStringList.Add("1");

            var element = JsonAsserts.AssertWireSerializes(inputModel);

            Assert.AreEqual("[1]", element.GetProperty("NonRequiredIntList").ToString());
            Assert.AreEqual("[\"1\"]", element.GetProperty("NonRequiredStringList").ToString());
        }

        [Test]
        public void InputModelSerializeOptionalEmptyCollectionAfterMutation()
        {
            var inputModel = CreateInputModel();

            inputModel.NonRequiredIntList.Add(1);
            inputModel.NonRequiredIntList.Clear();
            inputModel.NonRequiredStringList.Add("1");
            inputModel.NonRequiredStringList.Clear();

            var element = JsonAsserts.AssertWireSerializes(inputModel);

            Assert.AreEqual("[]", element.GetProperty("NonRequiredIntList").ToString());
            Assert.AreEqual("[]", element.GetProperty("NonRequiredStringList").ToString());
        }

        [Test]
        public void InputModelDoesntSerializeOptionalCollectionAfterReset()
        {
            var inputModel = CreateInputModel();

            inputModel.NonRequiredIntList.Add(1);
            InvokeMethod(inputModel.NonRequiredIntList, "Reset");
            inputModel.NonRequiredStringList.Add("1");
            InvokeMethod(inputModel.NonRequiredStringList, "Reset");

            var element = JsonAsserts.AssertWireSerializes(inputModel);

            Assert.False(element.TryGetProperty("NonRequiredStringList", out _));
            Assert.False(element.TryGetProperty("NonRequiredIntList", out _));
        }

        [Test]
        public void RequiredNullableCollectionsSerializeAsNull()
        {
            var inputModel = CreateInputModel();

            Assert.NotNull(inputModel.RequiredNullableIntList);
            Assert.NotNull(inputModel.RequiredNullableStringList);

            inputModel.RequiredNullableIntList = null;
            inputModel.RequiredNullableStringList = null;

            var element = JsonAsserts.AssertWireSerializes(inputModel);

            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("RequiredNullableIntList").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("RequiredNullableStringList").ValueKind);
        }

        [Test]
        public void ReadonlyPropertiesAreReadonly()
        {
            var required = TypeAsserts.HasProperty(typeof(MixedModel), "RequiredReadonlyInt", BindingFlags.Public | BindingFlags.Instance);
            var nonRequired = TypeAsserts.HasProperty(typeof(MixedModel), "NonRequiredReadonlyInt", BindingFlags.Public | BindingFlags.Instance);

            Assert.AreEqual(typeof(int), required.PropertyType);
            Assert.AreEqual(typeof(int?), nonRequired.PropertyType);
            Assert.Null(required.SetMethod);
            Assert.Null(nonRequired.SetMethod);
        }

        [Test]
        public void ReadonlyPropertiesAreDeserialized()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{\"RequiredReadonlyInt\":1, \"NonRequiredReadonlyInt\": 2}"));
            Assert.AreEqual(1, model.RequiredReadonlyInt);
            Assert.AreEqual(2, model.NonRequiredReadonlyInt);
        }

        private static InputModel CreateInputModel()
        {
            return new InputModel(
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                null,
                null,
                Array.Empty<string>(),
                Array.Empty<int>(),
                ReadOnlyMemory<float>.Empty,
                ReadOnlyMemory<float>.Empty,
                null,
                null

            );
        }

        [Test]
        public void InputCollectionPropertiesCanBeMutatedAfterConstruction()
        {
            var inputModel = new InputModel(
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                ReadOnlyMemory<float>.Empty,
                ReadOnlyMemory<float>.Empty,
                null,
                null

            );

            inputModel.RequiredIntList.Add(1);

            Assert.AreEqual(1, inputModel.RequiredIntList.Count);
        }

        [Test]
        public void ErrorModelsAreInternalWithDeserializers()
        {
            var errorModel = FindType(typeof(InputModel).Assembly, "ErrorModel");
            Assert.False(errorModel.IsPublic);
            Assert.NotNull(errorModel.GetMethod("DeserializeErrorModel", BindingFlags.Static | BindingFlags.NonPublic));
        }

        [Test]
        public void ReadOnlyPropertyTypesOfMixedModelIsOutputOnly()
        {
            Assert.IsTrue(typeof(ReadonlyModel).IsPublic);
            Assert.IsTrue(typeof(ReadonlyModel).GetInterfaces().Any(i => i.Name == "IUtf8JsonSerializable"));
            Assert.IsNotNull(typeof(ReadonlyModel).GetMethod("DeserializeReadonlyModel", BindingFlags.Static | BindingFlags.NonPublic));
        }

        [Test]
        public void ReadOnlyPropertiesAreReadOnly()
        {
            var property = TypeAsserts.HasProperty(typeof(MixedModelWithReadonlyProperty), "ReadonlyProperty", BindingFlags.Public | BindingFlags.Instance);
            var listProperty = TypeAsserts.HasProperty(typeof(MixedModelWithReadonlyProperty), "ReadonlyListProperty", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(property.SetMethod);
            Assert.Null(listProperty.SetMethod);
            Assert.AreEqual(typeof(IReadOnlyList<ReadonlyModel>), listProperty.PropertyType);
        }

        [Test]
        public void ModelsFlattenedIntoParametersAreInternal()
        {
            Assert.IsFalse(FindType(typeof(InputModel).Assembly, "ParametersModel").IsPublic);
            Assert.IsTrue(typeof(ReadonlyModel).GetInterfaces().Any(i => i.Name == "IUtf8JsonSerializable"));
            Assert.IsNull(typeof(ReadonlyModel).GetMethod("DeserializeParametersModel", BindingFlags.Static | BindingFlags.NonPublic));
        }


        [Test]
        public void OptionalPropertyWithNullIsAccepted()
        {
            var model = ModelReaderWriter.Read<MixedModel>(BinaryData.FromString("{\"RequiredReadonlyInt\":1, \"NonRequiredReadonlyInt\": 2,\"NonRequiredInt\": null}"));
            Assert.Null(model.NonRequiredInt);
        }

        [Test]
        public void ModelWithCustomizedNullableJsonElementPropertyDeserializesNull()
        {
            var model = ModelReaderWriter.Read(BinaryData.FromString("{\"ModelProperty\":null}"), FindType(typeof(AbstractModel).Assembly, "ModelWithNullableObjectProperty"));

            Assert.AreEqual(JsonValueKind.Null, GetProperty(GetProperty(model, "ModelProperty"), "ValueKind"));
        }

        [Test]
        public void ModelWithCustomizedNullableJsonElementPropertyDeserializesUndefined()
        {
            var model = ModelReaderWriter.Read(BinaryData.FromString("{}"), FindType(typeof(AbstractModel).Assembly, "ModelWithNullableObjectProperty"));

            Assert.AreEqual(JsonValueKind.Undefined, GetProperty(GetProperty(model, "ModelProperty"), "ValueKind"));
        }

        [Test]
        public void ModelWithCustomizedNullableJsonElementPropertyDeserializesValue()
        {
            var model = ModelReaderWriter.Read(BinaryData.FromString("{\"ModelProperty\":1}"), FindType(typeof(AbstractModel).Assembly, "ModelWithNullableObjectProperty"));

            Assert.AreEqual(1, InvokeMethod(GetProperty(model, "ModelProperty"), "GetInt32"));
        }

        //[Test]
        //public void ModelWithCustomizedNullableJsonElementPropertySerializesNull()
        //{
        //    JsonAsserts.AssertWireSerialization("{\"ModelProperty\":null}", new ModelWithNullableObjectProperty() { ModelProperty = JsonDocument.Parse("null").RootElement });
        //}

        //[Test]
        //public void ModelWithCustomizedNullableJsonElementPropertySerializesUndefined()
        //{
        //    JsonAsserts.AssertWireSerialization("{}", new ModelWithNullableObjectProperty() { ModelProperty = default });
        //}

        //[Test]
        //public void ModelWithCustomizedNullableJsonElementPropertySerializesValue()
        //{
        //    JsonAsserts.AssertWireSerialization("{\"ModelProperty\":1}", new ModelWithNullableObjectProperty() { ModelProperty = JsonDocument.Parse("1").RootElement });
        //}

        [Test]
        public void ModelFactory_DeclaresOnlyStaticMethodsForReadonlyTypes()
        {
            TypeAsserts.TypeIsStatic(typeof(ModelShapesModelFactory));
            TypeAsserts.TypeOnlyDeclaresThesePublicMethods(typeof(ModelShapesModelFactory),
                nameof(InputModel),
                nameof(MixedModel),
                nameof(OutputModel),
                nameof(MixedModelWithReadonlyProperty),
                nameof(OutputModel),
                nameof(ReadonlyModel));
        }

        [Test]
        public void ModelFactory_AlwaysInitializesCollectionFields()
        {
            var model = ModelShapesModelFactory.MixedModelWithReadonlyProperty();
            Assert.NotNull(model.ReadonlyListProperty);
        }

        [Test]
        public void ModelFactory_InstantiatesReadonlyModel()
        {
            const string stringValue = "stringValue";

            var expectedModel = (ReadonlyModel)Activator.CreateInstance(typeof(ReadonlyModel), BindingFlags.NonPublic | BindingFlags.Instance, null, [stringValue, new Dictionary<string, BinaryData>()], null);
            var actualModel = ModelShapesModelFactory.ReadonlyModel(stringValue);

            Assert.AreEqual(expectedModel.Name, actualModel.Name);
        }

        [Test]
        public void ModelFactory_InstantiatesMixedModelWithReadonlyProperty()
        {
            const string stringValue = "stringValue";
            var readonlyModel = (ReadonlyModel)Activator.CreateInstance(typeof(ReadonlyModel), BindingFlags.NonPublic | BindingFlags.Instance, null, [stringValue, new Dictionary<string, BinaryData>()], null);
            var readonlyModelList = new List<ReadonlyModel> { readonlyModel };

            var expectedModel = (MixedModelWithReadonlyProperty)Activator.CreateInstance(typeof(MixedModelWithReadonlyProperty), BindingFlags.NonPublic | BindingFlags.Instance, null, [readonlyModel, readonlyModelList.ToList(), new Dictionary<string, BinaryData>()], null);
            var actualModel = ModelShapesModelFactory.MixedModelWithReadonlyProperty(readonlyModel, readonlyModelList);

            Assert.AreEqual(expectedModel.ReadonlyProperty, actualModel.ReadonlyProperty);
            Assert.AreEqual(expectedModel.ReadonlyProperty.Name, actualModel.ReadonlyProperty.Name);
            Assert.AreEqual(expectedModel.ReadonlyListProperty[0], actualModel.ReadonlyListProperty[0]);
        }
    }
}
