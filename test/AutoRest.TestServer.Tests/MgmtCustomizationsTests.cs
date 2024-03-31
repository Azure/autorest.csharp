// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using AutoRest.TestServer.Tests.Infrastructure;
using MgmtCustomizations.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class MgmtCustomizationsTests
    {
        [Test]
        public void Cat_SizeSerializeIntoString()
        {
            Pet pet = new Cat()
            {
                Size = 8,
                Meow = "MEOW",
                Color = "Red",
                Tags = new Dictionary<string, string>()
                {
                    ["like"]="Cheese",
                    ["area"]="China"
                }
            };

            var root = JsonAsserts.AssertWireSerializes(pet);
            var sizeProperty = root.GetProperty("size");

            // asserts we serialize the int size into a string
            Assert.AreEqual(JsonValueKind.String, sizeProperty.ValueKind);
            Assert.AreEqual("8", sizeProperty.GetString());
            Assert.AreEqual("Red", root.GetProperty("properties").GetProperty("color").GetString());
            Assert.AreEqual("Cheese", root.GetProperty("tags").GetProperty("like").ToString());
            Assert.AreEqual("China", root.GetProperty("tags").GetProperty("area").ToString());
        }

        [Test]
        public void Cat_SizeDeserializeIntoInt()
        {
            var json = @"{""kind"":""Cat"",""size"":""10"", ""meow"": ""MEOW"",""tags"":{""like"":""Cheese"",""area"":""China""},""properties"":{""color"":""Red""}}";
            using var document = JsonDocument.Parse(json);

            var pet = Pet.DeserializePet(document.RootElement);
            var cat = pet as Cat;

            Assert.IsTrue(cat != null);
            Assert.AreEqual(10, cat.Size);
            Assert.AreEqual("MEOW", cat.Meow);
            Assert.AreEqual(pet.Color, "Red");
            Assert.AreEqual(pet.Tags.Count, 2);
            Assert.AreEqual(pet.Tags["like"], "Cheese");
            Assert.AreEqual(pet.Tags["area"], "China");
        }

        [Test]
        public void Dog_SerializeIntoProperties()
        {
            Pet friendDog = new Dog()
            {
                Bark = "bark again"
            };
            Pet pet = new Dog()
            {
                Bark = "Dog barks",
                Friend = friendDog
            };

            // this should serialize into:
            // {"kind":"Dog","size":"0","properties":{"dog":{"bark":"DOG BARKS","friend":{"kind":"Dog","size":"0","properties":{"dog":{"bark":"BARK AGAIN"}}}}}}

            var root = JsonAsserts.AssertWireSerializes(pet);
            var properties = root.GetProperty("properties");
            Assert.AreEqual(JsonValueKind.Object, properties.ValueKind);
            var dogProperty = properties.GetProperty("dog");
            Assert.AreEqual(JsonValueKind.Object, dogProperty.ValueKind);
            var barkProperty = dogProperty.GetProperty("bark");
            Assert.AreEqual(JsonValueKind.String, barkProperty.ValueKind);
            Assert.AreEqual("DOG BARKS", barkProperty.GetString());
            Assert.AreEqual("BARK AGAIN", dogProperty.GetProperty("friend").GetProperty("properties").GetProperty("dog").GetProperty("bark").GetString());
        }

        [Test]
        public void Dog_DeserializeFromProperties()
        {
            var json = @"{""kind"":""Dog"",""size"":""0"",""properties"":{""dog"":{""bark"":""dog barks"",""friend"":{""kind"":""Dog"",""size"":""0"",""properties"":{""dog"":{""bark"":""bark again""}}}}}}";
            using var document = JsonDocument.Parse(json);

            var pet = Pet.DeserializePet(document.RootElement);
            var dog = pet as Dog;

            Assert.IsTrue(dog != null);
            Assert.AreEqual("dog barks", dog.Bark);
            Assert.AreEqual("bark again", ((Dog)dog.Friend).Bark);
        }
    }
}
