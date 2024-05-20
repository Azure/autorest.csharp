// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using ModelReaderWriterValidationTypeSpec.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    internal class ModelWithStringAdditionalPropertiesTests : ModelJsonTests<ModelWithStringAdditionalProperties>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"id\":\"X\",\"name\":\"xmodel\",\"age\":100,\"extra1\":\"other\",\"extra2\":\"stuff\",\"invalid\":10}";

        protected override void CompareModels(ModelWithStringAdditionalProperties model, ModelWithStringAdditionalProperties model2, string format)
        {
            if (format == "J")
                Assert.AreEqual(model.Id, model2.Id);
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Age, model2.Age);
            CollectionAssert.AreEquivalent(model.AdditionalProperties, model2.AdditionalProperties);
            if (format == "J")
            {
                var rawData = GetRawData(model);
                var rawData2 = GetRawData(model2);
                Assert.IsNotNull(rawData);
                Assert.IsNotNull(rawData2);
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["invalid"].ToObjectFromJson<int>(), rawData2["invalid"].ToObjectFromJson<int>());
            }
        }

        protected override string GetExpectedResult(string format)
        {
            string expected = "{\"age\":100,\"name\":\"xmodel\"";
            if (format == "J")
                expected += ",\"id\":\"X\"";
            expected += ",\"extra1\":\"other\",\"extra2\":\"stuff\"";
            if (format == "J")
                expected += ",\"invalid\":10";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(ModelWithStringAdditionalProperties model, string format)
        {
            if (format == "J")
                Assert.AreEqual("X", model.Id); // id is readonly
            Assert.AreEqual("xmodel", model.Name);
            Assert.AreEqual(100, model.Age);
            CollectionAssert.AreEquivalent(new Dictionary<string, string>
            {
                ["extra1"] = "other",
                ["extra2"] = "stuff"
            }, model.AdditionalProperties);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
            {
                Assert.AreEqual(10, rawData["invalid"].ToObjectFromJson<int>());
            }
        }
    }
}
