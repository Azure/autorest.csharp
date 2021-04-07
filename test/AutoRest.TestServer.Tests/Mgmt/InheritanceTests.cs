// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using SupersetInheritance;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class InheritanceTests
    {
        [TestCase(typeof(Resource), typeof(SupersetModel1Data))]
        [TestCase(typeof(Object), typeof(SupersetModel2Data))]
        [TestCase(typeof(Object), typeof(SupersetModel3Data))]
        [TestCase(typeof(Object), typeof(SupersetModel4Data))]
        [TestCase(typeof(TrackedResource), typeof(SupersetModel5Data))]
        public void ValidateSupersetInheritance(Type expected, Type actual)
        {
            Assert.AreEqual(expected, actual.BaseType);
        }

        [TestCase(typeof(Resource), typeof(SupersetModel1Data))]
        [TestCase(typeof(Object), typeof(SupersetModel2Data))]
        [TestCase(typeof(Object), typeof(SupersetModel3Data))]
        [TestCase(typeof(Object), typeof(SupersetModel4Data))]
        [TestCase(typeof(TrackedResource), typeof(SupersetModel5Data))]
        public void ValidateExactMatchInheritance(Type expected, Type actual)
        {
            Assert.AreEqual(expected, actual.BaseType);
        }
    }
}
