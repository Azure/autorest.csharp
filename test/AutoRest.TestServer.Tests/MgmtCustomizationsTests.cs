// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.TestServer.Tests.Infrastructure;
using MgmtCustomizations.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class MgmtCustomizationsTests
    {
        [Test]
        public void Pet_SizeSerializedAsString()
        {
            Pet pet = new Cat()
            {
                Size = 8,
                Meow = "MEOW"
            };

            var root = JsonAsserts.AssertSerializes(pet);

            var sizeProperty = root.GetProperty("size");

            Assert.IsTrue(sizeProperty.ValueKind == JsonValueKind.String);
            Assert.AreEqual("8", sizeProperty.GetString());
        }

        [Test]
        public void Pet_SizeDeserializeIntoInt()
        {
            var json = @"{""kind"": ""Cat"", ""size"": ""10"", ""meow"": ""MEOW""}";
            var root = JsonAsserts.Parse(json);

            var pet = Pet.DeserializePet(root);
            var cat = pet as Cat;

            Assert.IsTrue(cat != null);
            Assert.AreEqual(10, cat.Size);
            Assert.AreEqual("MEOW", cat.Meow);
        }
    }
}
