// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using ModelWithConverterUsage.Models;
using Newtonsoft.Json;

namespace AutoRest.TestServer.Tests
{
    public class ModelWithConverterUsageTests
    {
        [Test]
        public void SerializeModelClass()
        {
            var model = new ModelClass(EnumProperty.A)
            {
                StringProperty = "test_str"
            };
            var jsonAsString = JsonConvert.SerializeObject(model);
            Assert.AreEqual("{\"StringProperty\":\"test_str\",\"EnumProperty\":0,\"ObjProperty\":null}", jsonAsString);
        }

        [Test]
        public void DeserializeModelClass()
        {
            string json = @"{""StringProperty"":""test_str"",""EnumProperty"":0,""ObjProperty"":null}";

            ModelClass model = JsonConvert.DeserializeObject<ModelClass>(json);
            Assert.AreEqual("test_str", model.StringProperty);
            Assert.AreEqual(EnumProperty.A, model.EnumProperty);
            Assert.AreEqual(null, model.ObjProperty);
        }
    }
}
