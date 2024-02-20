// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using ModelReaderWriterValidationTypeSpec.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    internal class KnownBaseModelTests : ModelJsonTests<BaseModel>
    {
        protected override BaseModel GetModelInstance()
        {
            var typeToActivate = typeof(BaseModel).Assembly.GetTypes().FirstOrDefault(t => t.Name == $"Unknown{typeof(BaseModel).Name}") ?? throw new InvalidOperationException("Unable to find BaseModel type");
            return Activator.CreateInstance(typeToActivate, true) as BaseModel ?? throw new InvalidOperationException($"Unable to create model instance of BaseModel");
        }

        protected override string JsonPayload => WirePayload;

        protected override string WirePayload => "{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":15,\"extra\":\"stuff\"}";

        protected override void CompareModels(BaseModel model, BaseModel model2, string format)
        {
            var modelX = model as ModelX;
            var modelX2 = model2 as ModelX;
            Assert.IsTrue(modelX is not null);
            Assert.IsTrue(modelX2 is not null);
            Assert.AreEqual(modelX.Kind, modelX2.Kind);
            Assert.AreEqual(modelX.Name, modelX2.Name);
            if (format == "J")
                Assert.AreEqual(modelX.XProperty, modelX2.XProperty); // this property is readonly, and it is not guaranteed to be roundtrip
            var rawData = GetRawData(modelX);
            var rawData2 = GetRawData(modelX2);
            Assert.IsNotNull(rawData);
            Assert.IsNotNull(rawData2);
            if (format == "J")
            {
                Assert.AreEqual(rawData.Count, rawData2.Count);
                Assert.AreEqual(rawData["extra"].ToObjectFromJson<string>(), rawData2["extra"].ToObjectFromJson<string>());
            }
        }

        protected override string GetExpectedResult(string format)
        {
            string expected = "{\"kind\":\"X\",\"name\":\"xmodel\"";
            if (format == "J")
                expected += ",\"xProperty\":15,\"extra\":\"stuff\"";
            expected += "}";
            return expected;
        }

        protected override void VerifyModel(BaseModel model, string format)
        {
            var modelX = model as ModelX;
            Assert.IsTrue(modelX is not null);
            Assert.AreEqual("X", modelX.Kind);
            Assert.AreEqual("xmodel", modelX.Name);
            Assert.AreEqual(15, modelX.XProperty);
            var rawData = GetRawData(model);
            Assert.IsNotNull(rawData);
            if (format == "J")
            {
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
