// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using ModelsTypeSpec.Models;

namespace AutoRest.TestServer.Tests
{
    public class ModelsTypeSpecTests
    {
        [Test]
        public void InputModelsHaveOnlyOnePublicCtor()
        {
            Assert.AreEqual(1, typeof(InputModel).GetConstructors().Length);
        }

        [Test]
        public void RequiredPropertiesAreSetableInMixedModels()
        {
            var requiredInt = TypeAsserts.HasProperty(typeof(RoundTripModel), nameof(RoundTripModel.RequiredInt), BindingFlags.Public | BindingFlags.Instance);
            var requiredString = TypeAsserts.HasProperty(typeof(RoundTripModel), nameof(RoundTripModel.RequiredString), BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredInt.SetMethod);
            Assert.NotNull(requiredString.SetMethod);
        }

        [Test]
        public void RequiredPropertiesAreNotSetableInInputModels()
        {
            var requiredInt = TypeAsserts.HasProperty(typeof(InputModel), nameof(InputModel.RequiredInt), BindingFlags.Public | BindingFlags.Instance);
            var requiredString = TypeAsserts.HasProperty(typeof(InputModel), nameof(InputModel.RequiredString), BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(requiredInt.SetMethod);
            Assert.Null(requiredString.SetMethod);
        }

        [Test]
        public void RequiredListsAreReadOnly()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(InputModel), nameof(InputModel.RequiredIntList), BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(InputModel), nameof(InputModel.RequiredStringList), BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(requiredIntList.SetMethod);
            Assert.Null(requiredStringList.SetMethod);
        }

        [Test]
        public void RequiredNullableListsOnInputsAreWriteable()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(InputModel), nameof(InputModel.RequiredNullableIntList), BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(InputModel), nameof(InputModel.RequiredNullableStringList), BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredIntList.SetMethod);
            Assert.NotNull(requiredStringList.SetMethod);
        }

        [Test]
        public void RequiredNullableListsOnMixedAreWriteableAndNullByDefault()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(RoundTripModel), nameof(RoundTripModel.RequiredNullableIntList), BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(RoundTripModel), nameof(RoundTripModel.RequiredNullableStringList), BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredIntList.SetMethod);
            Assert.NotNull(requiredStringList.SetMethod);
        }

        [Test]
        public void NotRequiredNullableListsAreSetable()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(RoundTripModel), nameof(RoundTripModel.NonRequiredNullableIntList), BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(RoundTripModel), nameof(RoundTripModel.NonRequiredNullableStringList), BindingFlags.Public | BindingFlags.Instance);

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

            var element = JsonAsserts.AssertSerializes(inputModel);
            Assert.False(element.TryGetProperty("nonRequiredNullableInt", out _));
            Assert.False(element.TryGetProperty("nonRequiredNullableString", out _));
            Assert.False(element.TryGetProperty("nonRequiredNullableIntList", out _));
            Assert.False(element.TryGetProperty("nonRequiredNullableStringList", out _));
        }

        [Test]
        public void NotRequiredNullableListsSerializedAsNull()
        {
            var inputModel = CreateInputModel();
            inputModel.NonRequiredNullableIntList = null;
            inputModel.NonRequiredNullableStringList = null;

            var element = JsonAsserts.AssertSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("nonRequiredNullableIntList").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("nonRequiredNullableStringList").ValueKind);
        }

        [Test]
        public void NotRequiredNullableListsSerializedEmptyWhenCleared()
        {
            var inputModel = CreateInputModel();
            inputModel.NonRequiredNullableIntList.Clear();
            inputModel.NonRequiredNullableStringList.Clear();

            var element = JsonAsserts.AssertSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("nonRequiredNullableIntList").ValueKind);
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("nonRequiredNullableStringList").ValueKind);
        }

        [Test]
        public void NotRequiredNullablePropertiesSerializeWhenSet()
        {
            var inputModel = CreateInputModel();
            inputModel.NonRequiredNullableInt = 1;
            inputModel.NonRequiredNullableString = "2";

            var element = JsonAsserts.AssertSerializes(inputModel);
            Assert.AreEqual(1, element.GetProperty("nonRequiredNullableInt").GetInt32());
            Assert.AreEqual("2", element.GetProperty("nonRequiredNullableString").GetString());
        }

        [Test]
        public void NotRequiredNullablePropertiesDeserializedWithNulls()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{\"NonRequiredNullableInt\":null, \"NonRequiredNullableString\": null}").RootElement);
            Assert.Null(model.NonRequiredNullableInt);
            Assert.Null(model.NonRequiredNullableString);
        }

        [Test]
        public void NotRequiredNullablePropertiesDeserializedWithNullsWhenUndefined()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{}").RootElement);
            Assert.Null(model.NonRequiredNullableInt);
            Assert.Null(model.NonRequiredNullableString);
        }

        [Test]
        public void NotRequiredNullablePropertiesDeserializedWithValues()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{\"nonRequiredNullableInt\":1, \"nonRequiredNullableString\": \"2\"}").RootElement);
            Assert.AreEqual(1, model.NonRequiredNullableInt);
            Assert.AreEqual("2", model.NonRequiredNullableString);
        }

        [Test]
        public void NullablePropertiesCanBeInitializedWithNull()
        {
            var inputModel = new InputModel(
                "string",
                1,
                null,
                null,
                new BaseModel(),
                Array.Empty<int>(),
                Array.Empty<string>(),
                Array.Empty<CollectionItem>(),
                new Dictionary<string, RecordItem>(),
                Array.Empty<float?>(),
                Array.Empty<bool?>(),
                null,
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
                null,
                null,
                new BaseModel(),
                Array.Empty<int>(),
                Array.Empty<string>(),
                Array.Empty<CollectionItem>(),
                new Dictionary<string, RecordItem>(),
                Array.Empty<float?>(),
                Array.Empty<bool?>(),
                null,
                null,
                null
            );

            var element = JsonAsserts.AssertSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("requiredNullableString").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("requiredNullableInt").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("requiredNullableStringList").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("requiredNullableIntList").ValueKind);
        }

        [Test]
        public void NullablePropertiesSerializedAsEmptyLists()
        {
            var inputModel = new InputModel(
                "string",
                1,
                null,
                null,
                new BaseModel(),
                Array.Empty<int>(),
                Array.Empty<string>(),
                Array.Empty<CollectionItem>(),
                new Dictionary<string, RecordItem>(),
                Array.Empty<float?>(),
                Array.Empty<bool?>(),
                Array.Empty<CollectionItem>(),
                Array.Empty<string>(),
                Array.Empty<int>()
            );

            var element = JsonAsserts.AssertSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("requiredNullableStringList").ValueKind);
            Assert.AreEqual(0, element.GetProperty("requiredNullableStringList").GetArrayLength());
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("requiredNullableIntList").ValueKind);
            Assert.AreEqual(0, element.GetProperty("requiredNullableIntList").GetArrayLength());
        }

        [Test]
        public void NullablePropertiesDeserializedAsNullsWithUndefined()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{}").RootElement);
            Assert.IsNull(model.RequiredNullableIntList);
            Assert.IsNull(model.RequiredNullableStringList);
        }

        [Test]
        public void NullablePropertiesDeserializedAsNullsWithNulls()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{\"requiredNullableIntList\":null, \"requiredNullableStringList\": null}").RootElement);
            Assert.IsNull(model.RequiredNullableIntList);
            Assert.IsNull(model.RequiredNullableStringList);
        }

        [Test]
        public void NullablePropertiesDeserializedAsValues()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{\"requiredNullableIntList\":[1,2,3], \"requiredNullableStringList\": [\"a\", \"b\"]}").RootElement);
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

            var element = JsonAsserts.AssertSerializes(inputModel);

            Assert.False(element.TryGetProperty("nonRequiredStringList", out _));
            Assert.False(element.TryGetProperty("nonRequiredIntList", out _));
        }

        [Test]
        public void InputModelSerializeOptionalCollectionAfterMutation()
        {
            var inputModel = CreateInputModel();

            inputModel.NonRequiredIntList.Add(1);
            inputModel.NonRequiredStringList.Add("1");

            var element = JsonAsserts.AssertSerializes(inputModel);

            Assert.AreEqual("[1]", element.GetProperty("nonRequiredIntList").ToString());
            Assert.AreEqual("[\"1\"]", element.GetProperty("nonRequiredStringList").ToString());
        }

        [Test]
        public void InputModelSerializeOptionalEmptyCollectionAfterMutation()
        {
            var inputModel = CreateInputModel();

            inputModel.NonRequiredIntList.Add(1);
            inputModel.NonRequiredIntList.Clear();
            inputModel.NonRequiredStringList.Add("1");
            inputModel.NonRequiredStringList.Clear();

            var element = JsonAsserts.AssertSerializes(inputModel);

            Assert.AreEqual("[]", element.GetProperty("nonRequiredIntList").ToString());
            Assert.AreEqual("[]", element.GetProperty("nonRequiredStringList").ToString());
        }

        [Test]
        public void InputModelDoesntSerializeOptionalCollectionAfterReset()
        {
            var inputModel = CreateInputModel();

            inputModel.NonRequiredIntList.Add(1);
            (inputModel.NonRequiredIntList as ChangeTrackingList<int>).Reset();
            inputModel.NonRequiredStringList.Add("1");
            (inputModel.NonRequiredStringList as ChangeTrackingList<string>).Reset();

            var element = JsonAsserts.AssertSerializes(inputModel);

            Assert.False(element.TryGetProperty("nonRequiredStringList", out _));
            Assert.False(element.TryGetProperty("nonRequiredIntList", out _));
        }

        [Test]
        public void RequiredNullableCollectionsSerializeAsNull()
        {
            var inputModel = CreateInputModel();

            Assert.NotNull(inputModel.RequiredNullableIntList);
            Assert.NotNull(inputModel.RequiredNullableStringList);

            inputModel.RequiredNullableIntList = null;
            inputModel.RequiredNullableStringList = null;

            var element = JsonAsserts.AssertSerializes(inputModel);

            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("requiredNullableIntList").ValueKind);
            Assert.AreEqual(JsonValueKind.Null, element.GetProperty("requiredNullableStringList").ValueKind);
        }

        [Test]
        public void ReadonlyPropertiesAreReadonly()
        {
            var required = TypeAsserts.HasProperty(typeof(RoundTripModel), "RequiredReadonlyInt", BindingFlags.Public | BindingFlags.Instance);
            var nonRequired = TypeAsserts.HasProperty(typeof(RoundTripModel), "NonRequiredReadonlyInt", BindingFlags.Public | BindingFlags.Instance);

            Assert.AreEqual(typeof(int), required.PropertyType);
            Assert.AreEqual(typeof(int?), nonRequired.PropertyType);
            Assert.Null(required.SetMethod);
            Assert.Null(nonRequired.SetMethod);
        }

        [Test]
        public void ReadonlyPropertiesAreDeserialized()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{\"requiredReadonlyInt\":1, \"nonRequiredReadonlyInt\": 2}").RootElement);
            Assert.AreEqual(1, model.RequiredReadonlyInt);
            Assert.AreEqual(2, model.NonRequiredReadonlyInt);
        }

        private static InputModel CreateInputModel()
        {
            return new InputModel(
                "string",
                1,
                null,
                null,
                new BaseModel(),
                Array.Empty<int>(),
                Array.Empty<string>(),
                Array.Empty<CollectionItem>(),
                new Dictionary<string, RecordItem>(),
                Array.Empty<float?>(),
                Array.Empty<bool?>(),
                Array.Empty<CollectionItem>(),
                Array.Empty<string>(),
                Array.Empty<int>()
            );
        }

        [Test]
        public void InputCollectionPropertiesCanBeMutatedAfterConstruction()
        {
            var inputModel = new InputModel(
                "string",
                1,
                null,
                null,
                new BaseModel(),
                Array.Empty<int>(),
                Array.Empty<string>(),
                Array.Empty<CollectionItem>(),
                new Dictionary<string, RecordItem>(),
                Array.Empty<float?>(),
                Array.Empty<bool?>(),
                Array.Empty<CollectionItem>(),
                Array.Empty<string>(),
                Array.Empty<int>()
            );

            inputModel.RequiredIntList.Add(1);

            Assert.AreEqual(1, inputModel.RequiredIntList.Count);
        }

        [Test]
        public void ReadOnlyPropertiesAreReadOnly()
        {
            var property = TypeAsserts.HasProperty(typeof(RoundTripReadOnlyModel), "RequiredReadonlyString", BindingFlags.Public | BindingFlags.Instance);
            var listProperty = TypeAsserts.HasProperty(typeof(RoundTripReadOnlyModel), "RequiredReadOnlyModelList", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(property.SetMethod);
            Assert.Null(listProperty.SetMethod);
            Assert.AreEqual(typeof(IReadOnlyList<CollectionItem>), listProperty.PropertyType);
        }

        [Test]
        public void OptionalPropertyWithNullIsAccepted()
        {
            var model = RoundTripModel.DeserializeRoundTripModel(JsonDocument.Parse("{\"RequiredReadonlyInt\":1, \"NonRequiredReadonlyInt\": 2,\"NonRequiredInt\": null}").RootElement);
            Assert.Null(model.NonRequiredInt);
        }
    }
}
