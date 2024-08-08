// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Common.Transformation
{
    public class InputUrlToUriTransformerTests
    {
        [TestCase("serviceUrl", true, "serviceUri")]
        [TestCase("ServiceUrl", true, "ServiceUri")]
        [TestCase("somethingUrl", true, "somethingUri")]
        [TestCase("SomethingUrl", true, "SomethingUri")]
        [TestCase("ServiceUri", false, null)]
        [TestCase("ServiceUri", false, null)]
        [TestCase("somethingurl", false, null)]
        [TestCase("something", false, null)]
        public void ValidateUrlToUriTransformation(string name, bool canTransform, string? expected)
        {
            var result = InputUrlToUriTransformer.TryTransformUrlToUri(name, out var newName);
            Assert.AreEqual(canTransform, result);
            Assert.AreEqual(expected, newName);
        }
    }
}
