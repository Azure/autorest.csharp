// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using AutoRest.TestServer.Tests.Infrastructure;
using ModelReaderWriterValidationTypeSpec.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    internal class ModelWithArrayAdditionalPropertiesTests : ModelJsonTests<ModelWithArrayAdditionalProperties>
    {
        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"id\":\"X\",\"name\":\"xmodel\",\"age\":100,\"extra1\":[null,{\"tokenType\": \"String\"}],\"extra2\":[],\"invalid\":10}";

        protected override void CompareModels(ModelWithArrayAdditionalProperties model, ModelWithArrayAdditionalProperties model2, string format)
        {
            if (format == "J")
                Assert.AreEqual(model.Id, model2.Id);
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Age, model2.Age);

            Assert.AreEqual(model.AdditionalProperties.Count, model2.AdditionalProperties.Count);
            AssertBinaryDataArray(model.AdditionalProperties["extra1"], model2.AdditionalProperties["extra1"]);
            AssertBinaryDataArray(model.AdditionalProperties["extra2"], model2.AdditionalProperties["extra2"]);
        }

        private static void AssertBinaryDataArray(IList<BinaryData> list1, IList<BinaryData> list2)
        {
            Assert.AreEqual(list1.Count, list2.Count);
            for (int i = 0; i < list1.Count; i++)
            {
                BinaryDataAssert.AreEqual(list1[i], list2[i]);
            }
        }

        protected override string GetExpectedResult(string format)
        {
            string expected = "{\"age\":100,\"name\":\"xmodel\"";
            if (format == "J")
                expected += ",\"id\":\"X\"";
            expected += ",\"extra1\":[null,{\"tokenType\":\"String\"}],\"extra2\":[]";
            if (format == "J")
                expected += ",\"invalid\":10";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(ModelWithArrayAdditionalProperties model, string format)
        {
            if (format == "J")
                Assert.AreEqual("X", model.Id); // id is readonly
            Assert.AreEqual("xmodel", model.Name);
            Assert.AreEqual(100, model.Age);

            Assert.AreEqual(2, model.AdditionalProperties.Count);
            var extra1 = model.AdditionalProperties["extra1"];
            Assert.AreEqual(2, extra1.Count);
            Assert.IsNull(extra1[0]);
            var metadata = ModelReaderWriter.Read<ResourceTypeAliasPathMetadata>(extra1[1]);
            Assert.IsNotNull(metadata);
            Assert.AreEqual("String", metadata.TokenType.ToString());
            var extra2 = model.AdditionalProperties["extra2"];
            Assert.AreEqual(0, extra2.Count);
        }
    }
}
