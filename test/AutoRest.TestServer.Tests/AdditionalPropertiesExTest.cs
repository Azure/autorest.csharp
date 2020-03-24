// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using additionalProperties;
using additionalProperties.Models;
using AdditionalPropertiesEx.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class AdditionalPropertiesExTest
    {
        [Theory]
        [TestCase(typeof(InputAdditionalPropertiesModel))]
        [TestCase(typeof(InputAdditionalPropertiesModelStruct))]
        public void InputModelsImplementIDictionary(Type type)
        {
            var iface = type
                .GetInterfaces()
                .SingleOrDefault(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>));

            Assert.NotNull(iface);
            Assert.AreEqual(typeof(string), iface.GenericTypeArguments[0]);
            Assert.AreEqual(typeof(object), iface.GenericTypeArguments[1]);
        }

        [Theory]
        [TestCase(typeof(OutputAdditionalPropertiesModel))]
        [TestCase(typeof(OutputAdditionalPropertiesModelStruct))]
        public void OutputModelsImplementIReadOnlyDictionary(Type type)
        {
            var iface = type
                .GetInterfaces()
                .SingleOrDefault(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>));

            Assert.NotNull(iface);
            Assert.AreEqual(typeof(string), iface.GenericTypeArguments[0]);
            Assert.AreEqual(typeof(string), iface.GenericTypeArguments[1]);
        }

        [Test]
        public void CanCreateStructWithAdditionalProperties()
        {
            var s = new InputAdditionalPropertiesModelStruct(123, new Dictionary<string, object>()
            {
                {"a", "b"},
                {"c", 2}
            });

            Assert.AreEqual(123, s.Id);
            Assert.AreEqual("b", s["a"]);
            Assert.AreEqual(2, s["c"]);
        }
    }
}