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

        [TestCase(typeof(Resource<TenantResourceIdentifier>), typeof(ExactMatchModel1Data))]
        [TestCase(typeof(ExactMatchModel7), typeof(ExactMatchModel2Data))]
        [TestCase(typeof(ExactMatchModel8), typeof(ExactMatchModel3Data))]
        [TestCase(typeof(ExactMatchModel9), typeof(ExactMatchModel4Data))]
        [TestCase(typeof(TrackedResource<TenantResourceIdentifier>), typeof(ExactMatchModel5Data))]
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
