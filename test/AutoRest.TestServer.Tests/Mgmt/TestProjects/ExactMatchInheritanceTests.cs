// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Core;
using ExactMatchInheritance;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ExactMatchInheritanceTests : TestProjectTests
    {
        public ExactMatchInheritanceTests()
            : base("ExactMatchInheritance")
        {
        }

        [TestCase(typeof(Resource<ResourceGroupResourceIdentifier>), typeof(ExactMatchModel1Data))]
        [TestCase(typeof(ExactMatchModel7), typeof(ExactMatchModel2))]
        [TestCase(typeof(ExactMatchModel8), typeof(ExactMatchModel3Data))]
        [TestCase(typeof(ExactMatchModel9), typeof(ExactMatchModel4))]
        [TestCase(typeof(TrackedResource<ResourceGroupResourceIdentifier>), typeof(ExactMatchModel5Data))]
        [TestCase(typeof(SubResource), typeof(ExactMatchModel6))]
        [TestCase(typeof(object), typeof(ExactMatchModel7))]
        [TestCase(typeof(SubResource), typeof(ExactMatchModel8))]
        [TestCase(typeof(object), typeof(ExactMatchModel9))]
        [TestCase(typeof(ExactMatchModel11), typeof(ExactMatchModel10))]
        [TestCase(typeof(object), typeof(ExactMatchModel11))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
            foreach (var property in generatedClass.BaseType.GetProperties())
            {
                Assert.IsFalse(generatedClass.GetProperty(property.Name).DeclaringType == generatedClass);
            }
        }
    }
}
