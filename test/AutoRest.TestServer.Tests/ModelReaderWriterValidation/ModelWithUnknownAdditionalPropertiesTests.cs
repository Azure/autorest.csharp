// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ModelReaderWriterValidationTypeSpec.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    internal class ModelWithUnknownAdditionalPropertiesTests : ModelJsonTests<ModelWithUnknownAdditionalProperties>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"id\":\"X\",\"name\":\"xmodel\",\"age\":100,\"extra1\":\"other\",\"extra2\":\"stuff\",\"invalid\":10}";

        protected override void CompareModels(ModelWithUnknownAdditionalProperties model, ModelWithUnknownAdditionalProperties model2, string format)
        {
            if (format == "J")
                Assert.AreEqual(model.Id, model2.Id);
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Age, model2.Age);

            Assert.AreEqual(3, model.AdditionalProperties.Count);
            Assert.AreEqual("other", model.AdditionalProperties["extra1"].ToObjectFromJson<string>());
            Assert.AreEqual("stuff", model.AdditionalProperties["extra2"].ToObjectFromJson<string>());
            Assert.AreEqual(10, model.AdditionalProperties["invalid"].ToObjectFromJson<int>());
        }

        protected override string GetExpectedResult(string format)
        {
            string expected = "{\"age\":100,\"name\":\"xmodel\"";
            if (format == "J")
                expected += ",\"id\":\"X\"";
            expected += ",\"extra1\":\"other\",\"extra2\":\"stuff\",\"invalid\":10}";
            return expected;
        }

        protected override void VerifyModel(ModelWithUnknownAdditionalProperties model, string format)
        {
            if (format == "J")
                Assert.AreEqual("X", model.Id); // id is readonly
            Assert.AreEqual("xmodel", model.Name);
            Assert.AreEqual(100, model.Age);

            Assert.AreEqual(3, model.AdditionalProperties.Count);
            Assert.AreEqual("other", model.AdditionalProperties["extra1"].ToObjectFromJson<string>());
            Assert.AreEqual("stuff", model.AdditionalProperties["extra2"].ToObjectFromJson<string>());
            Assert.AreEqual(10, model.AdditionalProperties["invalid"].ToObjectFromJson<int>());
        }
    }
}
