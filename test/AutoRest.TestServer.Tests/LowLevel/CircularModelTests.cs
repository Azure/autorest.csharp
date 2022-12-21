// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ModelsInCadl.Models;
using NUnit.Framework;
using AutoRest.TestServer.Tests.Infrastructure;
using System.Text.Json;

namespace AutoRest.LowLevel.Tests
{
    public class CircularModelTest1s
    {
        [Test]
        public void InputRecursive()
        {
            var input = new InputRecursiveModel("parent");
            input.Inner = new InputRecursiveModel("child");

            JsonAsserts.AssertSerialization("{\"message\":\"parent\",\"inner\":{\"message\":\"child\"}}", input);
        }

        [Test]
        public void OutputRecursive()
        {
            var output = ErrorModel.DeserializeErrorModel(Parse("{\"message\":\"parent\",\"innerError\":{\"message\":\"child\"}}"));

            Assert.AreEqual("parent", output.Message);
            Assert.AreEqual("child", output.InnerError.Message);
            Assert.IsNull(output.InnerError.InnerError);
        }

        [Test]
        public void RoundTripRecursive()
        {
            var input = new RoundTripRecursiveModel("parent");
            input.Inner = new RoundTripRecursiveModel("child");

            JsonAsserts.AssertSerialization("{\"message\":\"parent\",\"inner\":{\"message\":\"child\"}}", input);

            var output = RoundTripRecursiveModel.DeserializeRoundTripRecursiveModel(JsonAsserts.AssertSerializes(input));

            Assert.AreEqual(input.Message, output.Message);
            Assert.AreEqual(input.Inner.Message, output.Inner.Message);
            Assert.AreEqual(input.Inner.Inner, output.Inner.Inner);
        }

        private static JsonElement Parse(string content)
        {
            return JsonDocument.Parse(content).RootElement;
        }
    }
}
