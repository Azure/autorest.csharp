// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using SerializationCustomization.Models;

namespace AutoRest.TestServer.Tests
{
    public class EmptyAsUndefinedTests
    {
        [Test]
        public void EmptyAsUndefinedListNotSerializedWhenEmpty()
        {
            var emptyAsUndefinedModel = new EmptyAsUndefinedTestModel();
            emptyAsUndefinedModel.EmptyAsUndefinedList = new List<Item>();

            JsonAsserts.AssertSerialization(@"{}", emptyAsUndefinedModel);
        }

        [Test]
        public void EmptyAsUndefinedListNotSerializedWhenNull()
        {
            var emptyAsUndefinedModel = new EmptyAsUndefinedTestModel();
            emptyAsUndefinedModel.EmptyAsUndefinedList = null;

            JsonAsserts.AssertSerialization(@"{}", emptyAsUndefinedModel);
        }

        [Test]
        public void EmptyAsUndefinedListNotSerializedWithItems()
        {
            var emptyAsUndefinedModel = new EmptyAsUndefinedTestModel();
            emptyAsUndefinedModel.EmptyAsUndefinedList = new List<Item>() { new Item() };
            emptyAsUndefinedModel.EmptyAsAlwaysInitializeList.Add(new Item());

            JsonAsserts.AssertSerialization(@"{""EmptyAsUndefinedList"":[{}],""EmptyAsAlwaysInitializeList"":[{}]}", emptyAsUndefinedModel);
        }

        [Test]
        public void EmptyAsUndefinedListDeserializedWithNull()
        {
            var model = EmptyAsUndefinedTestModel.DeserializeEmptyAsUndefinedTestModel(JsonDocument.Parse("{}").RootElement);
            Assert.IsNull(model.EmptyAsUndefinedList);
            Assert.IsNotNull(model.EmptyAsAlwaysInitializeList);
        }
    }
}