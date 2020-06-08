// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using AutoRest.TestServer.Tests.Infrastructure;
using ModelShapes.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ModelShapeTests
    {
        [Test]
        public void UnusedModelAreInternal()
        {
            Assert.False(typeof(UnusedModel).IsPublic);
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
        public void RequiredNullableListsOnInputsAreWriteableAndNullByDefault()
        {
            var requiredIntList = TypeAsserts.HasProperty(typeof(InputModel), "RequiredNullableIntList", BindingFlags.Public | BindingFlags.Instance);
            var requiredStringList = TypeAsserts.HasProperty(typeof(InputModel), "RequiredNullableStringList", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(requiredIntList.SetMethod);
            Assert.Null(requiredStringList.SetMethod);
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
        public void NullablePropertiesCanBeInitializedWithNull()
        {
            var inputModel = new InputModel(
                "string",
                1,
                Array.Empty<string>(),
                Array.Empty<int>(),
                null,
                null
            );

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
                null
            );

            var element = JsonAsserts.AssertSerializes(inputModel);
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
                Array.Empty<string>(),
                Array.Empty<int>()
            );

            var element = JsonAsserts.AssertSerializes(inputModel);
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("RequiredNullableStringList").ValueKind);
            Assert.AreEqual(0, element.GetProperty("RequiredNullableStringList").GetArrayLength());
            Assert.AreEqual(JsonValueKind.Array, element.GetProperty("RequiredNullableIntList").ValueKind);
            Assert.AreEqual(0, element.GetProperty("RequiredNullableIntList").GetArrayLength());
        }
    }
}