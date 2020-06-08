// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using SerializationCustomization.Models;

namespace AutoRest.TestServer.Tests
{
    public class InitializeWithTests
    {
        [Test]
        public void InitializeWithAddedToDefaultCtor()
        {
            var item = new Item();
            var inputClass = new AlwaysInitializeTestModel(new[] { item }, new[] { item, item }, item);

            Assert.IsInstanceOf<List<Item>>(inputClass.AlwaysInitializeList);
            Assert.IsInstanceOf<Item>(inputClass.AlwaysInitializeObject);

            Assert.AreSame(item, inputClass.RequiredAlwaysInitializeObject);
            CollectionAssert.AreEqual(new object[] { item }, inputClass.RequiredList);
            CollectionAssert.AreEqual(new object[] { item, item }, inputClass.RequiredAlwaysInitializeList);

            Assert.Null(inputClass.DefaultList);
            Assert.Null(inputClass.DefaultObject);
        }

        [Test]
        public void InitializeWithAddedToSerializationCtor()
        {
            var inputClass = new AlwaysInitializeTestModel(null, null, null, null, null, null, null);

            Assert.IsInstanceOf<Item>(inputClass.AlwaysInitializeObject);
            Assert.IsInstanceOf<List<Item>>(inputClass.AlwaysInitializeList);
            Assert.IsInstanceOf<List<Item>>(inputClass.RequiredAlwaysInitializeList);
            Assert.NotNull(inputClass.RequiredList);
            Assert.Null(inputClass.DefaultList);
            Assert.Null(inputClass.DefaultObject);
        }

        [Test]
        public void InitializesMembersWhenDeserializing()
        {
            var inputClass = AlwaysInitializeTestModel.DeserializeAlwaysInitializeTestModel(JsonDocument.Parse("{}").RootElement);

            Assert.IsInstanceOf<Item>(inputClass.AlwaysInitializeObject);
            Assert.IsInstanceOf<List<Item>>(inputClass.AlwaysInitializeList);
            Assert.IsInstanceOf<List<Item>>(inputClass.RequiredAlwaysInitializeList);
            Assert.NotNull(inputClass.RequiredList);
            Assert.Null(inputClass.DefaultList);
            Assert.Null(inputClass.DefaultObject);
        }

        [Test]
        public void RequiredListThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AlwaysInitializeTestModel(new Item[] {}, null, new Item()));
            Assert.Throws<ArgumentNullException>(() => new AlwaysInitializeTestModel(null, new Item[] {}, new Item()));
            Assert.Throws<ArgumentNullException>(() => new AlwaysInitializeTestModel(new Item[] {}, new Item[] {}, null));
        }
    }
}