// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NoTestTypeSpec.Models;
using NUnit.Framework;

namespace NoTestTypeSpec.Tests
{
    public class InternalAdditionalRawDataTests
    {
        [Test]
        public void RawDataShouldOverrideUsualProperty()
        {
            var thing = new Thing("wrongName", BinaryData.FromObjectAsJson("union"), "something", Array.Empty<int>());
            thing.SerializedAdditionalRawData.Add("name", BinaryData.FromObjectAsJson("correctName"));

            var json = ModelReaderWriter.Write(thing);
            using var document = JsonDocument.Parse(json);

            var nameProperty = document.RootElement.GetProperty("name");
            Assert.AreEqual("correctName", nameProperty.GetString());
        }

        [Test]
        public void RawDataShouldOverrideUsualProperty_Derived()
        {
            var thing = new DerivedThing("wrongName", BinaryData.FromObjectAsJson("union"), "something", Array.Empty<int>());
            thing.SerializedAdditionalRawData.Add("name", BinaryData.FromObjectAsJson("correctName"));

            var json = ModelReaderWriter.Write(thing);
            using var document = JsonDocument.Parse(json);

            var nameProperty = document.RootElement.GetProperty("name");
            Assert.AreEqual("correctName", nameProperty.GetString());
        }

        [Test]
        public void ValuesShouldBeHiddenViaSentinelValues()
        {
            var thing = new Thing("wrongName", BinaryData.FromObjectAsJson("union"), "something", Array.Empty<int>());
            thing.SerializedAdditionalRawData.Add("name", ModelSerializationExtensions.SentinelValue);

            var json = ModelReaderWriter.Write(thing);
            using var document = JsonDocument.Parse(json);

            Assert.IsFalse(document.RootElement.TryGetProperty("name", out _));
        }

        [Test]
        public void ValuesShouldBeHiddenViaSentinelValues_Derived()
        {
            var thing = new DerivedThing("wrongName", BinaryData.FromObjectAsJson("union"), "something", Array.Empty<int>());
            thing.SerializedAdditionalRawData.Add("name", ModelSerializationExtensions.SentinelValue);

            var json = ModelReaderWriter.Write(thing);
            using var document = JsonDocument.Parse(json);

            Assert.IsFalse(document.RootElement.TryGetProperty("name", out _));
        }
    }
}
