﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text;
using ModelReaderWriterValidationTypeSpec.Models;
using NUnit.Framework;
using static AutoRest.TestServer.Tests.Infrastructure.TestServerTestBase;

namespace AutoRest.TestServer.Tests
{
    internal class ModelXDeserializationProxyTests
    {
        [TestCase("J")]
        [TestCase("W")]
        public void CanDeserializeModelX(string format)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            BinaryData data = new BinaryData(Encoding.UTF8.GetBytes("{\"kind\":\"X\",\"name\":\"xmodel\",\"xProperty\":100,\"extra\":\"stuff\"}"));
            object? modelX = ModelReaderWriter.Read(data, typeof(ModelXDeserializationProxy), options);
            Assert.IsNotNull(modelX);
            Assert.IsInstanceOf<ModelX>(modelX);
            Assert.AreEqual("X", GetProperty(modelX, "Kind"));
            Assert.AreEqual("xmodel", ((ModelX)modelX).Name);
            Assert.AreEqual(100, ((ModelX)modelX).XProperty);
            if (format == "J")
            {
                var rawData = ModelTests<ModelX>.GetRawData((ModelX)modelX);
                Assert.IsNotNull(rawData);
                Assert.AreEqual("stuff", rawData["extra"].ToObjectFromJson<string>());
            }
        }
    }
}
