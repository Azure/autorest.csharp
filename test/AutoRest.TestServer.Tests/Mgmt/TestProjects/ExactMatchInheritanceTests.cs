// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        [TestCase(typeof(TrackedResource<ResourceGroupResourceIdentifier>), typeof(ExactMatchModel5Data))]
        [TestCase(typeof(SubResource<ResourceGroupResourceIdentifier>), typeof(ExactMatchModel6))]
        [TestCase(typeof(WritableSubResource<ResourceGroupResourceIdentifier>), typeof(ExactMatchModel8))]
        [TestCase(typeof(ExactMatchModel7), typeof(ExactMatchModel2))]
        [TestCase(typeof(ExactMatchModel8), typeof(ExactMatchModel3Data))]
        [TestCase(typeof(ExactMatchModel9), typeof(ExactMatchModel4))]
        [TestCase(typeof(ExactMatchModel11), typeof(ExactMatchModel10))]
        [TestCase(typeof(object), typeof(ExactMatchModel9))]
        [TestCase(typeof(object), typeof(ExactMatchModel7))]
        [TestCase(typeof(object), typeof(ExactMatchModel11))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
            foreach (var property in generatedClass.BaseType.GetProperties())
            {
                Assert.IsFalse(generatedClass.GetProperty(property.Name).DeclaringType == generatedClass);
            }
        }

        [TestCase(typeof(ExactMatchModel1Data), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel2), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel3Data), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel4), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel5Data), new string[] { "location" }, new Type[] { typeof(Location) })]
        [TestCase(typeof(ExactMatchModel6), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel7), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel8), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel9), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel10), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel11), new string[] { }, new Type[] { })]
        public void ValidateCtor(Type model, string[] paramNames, Type[] paramTypes) => ValidatePublicCtor(model, paramNames, paramTypes);
    }
}
