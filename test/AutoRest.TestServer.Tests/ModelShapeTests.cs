// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using ModelShapes.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ModelShapeTests
    {
        [Test]
        public void UnusedModelAreInternal()
        {
            Assert.False(typeof(UnusedModel).IsPublic);
        }

        [Test]
        public void RequiredPropertiesAreSetableInMixedModels()
        {
            var requiredInt = TypeAsserts.HasProperty(typeof(MixedModel), "RequiredInt", BindingFlags.Public | BindingFlags.Instance);
            var requiredString = TypeAsserts.HasProperty(typeof(MixedModel), "RequiredString", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(requiredInt.SetMethod);
            Assert.NotNull(requiredString.SetMethod);
        }

        [Test]
        public void RequiredPropertiesAreNotSetableInInputModels()
        {
            var requiredInt = TypeAsserts.HasProperty(typeof(InputModel), "RequiredInt", BindingFlags.Public | BindingFlags.Instance);
            var requiredString = TypeAsserts.HasProperty(typeof(InputModel), "RequiredString", BindingFlags.Public | BindingFlags.Instance);

            Assert.Null(requiredInt.SetMethod);
            Assert.Null(requiredString.SetMethod);
        }
    }
}