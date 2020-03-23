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
        [Test]
        public void InputModelsImplementIDictionary()
        {
            var iface = typeof(InputAdditionalPropertiesModel)
                .GetInterfaces()
                .SingleOrDefault(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>));

            Assert.NotNull(iface);
            Assert.AreEqual(typeof(string), iface.GenericTypeArguments[0]);
            Assert.AreEqual(typeof(object), iface.GenericTypeArguments[1]);
        }

        [Test]
        public void OutputModelsImplementIReadOnlyDictionary()
        {
            var iface = typeof(OutputAdditionalPropertiesModel)
                .GetInterfaces()
                .SingleOrDefault(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>));

            Assert.NotNull(iface);
            Assert.AreEqual(typeof(string), iface.GenericTypeArguments[0]);
            Assert.AreEqual(typeof(string), iface.GenericTypeArguments[1]);
        }
    }
}