// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using SupersetInheritance;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class SupersetInheritanceTests
    {
        [TestCase(typeof(Resource), typeof(SupersetModel1Data))]
        [TestCase(typeof(Object), typeof(SupersetModel2Data))]
        [TestCase(typeof(Object), typeof(SupersetModel3Data))]
        [TestCase(typeof(TrackedResource), typeof(SupersetModel4Data))]
        [TestCase(typeof(Resource), typeof(SupersetModel5Data))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
        }
    }
}
