﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Models;
using ExactMatchInheritance;
using ExactMatchInheritance.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ExactMatchInheritanceTests : TestProjectTests
    {
        public ExactMatchInheritanceTests()
            : base("ExactMatchInheritance")
        {
        }

        [TestCase(typeof(Resource), typeof(ExactMatchModel1Data))]
        [TestCase(typeof(TrackedResource), typeof(ExactMatchModel5Data))]
        [TestCase(typeof(ExactMatchModel7), typeof(ExactMatchModel2))]
        [TestCase(typeof(ExactMatchModel8), typeof(ExactMatchModel3))]
        [TestCase(typeof(ExactMatchModel9), typeof(ExactMatchModel4))]
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
        [TestCase(typeof(ExactMatchModel3), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel4), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel5Data), new string[] { "location" }, new Type[] { typeof(AzureLocation) })]
        [TestCase(typeof(ExactMatchModel7), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel8), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel9), new string[] { }, new Type[] { })]
        [TestCase(typeof(ExactMatchModel11), new string[] { }, new Type[] { })]
        public void ValidateCtor(Type model, string[] paramNames, Type[] paramTypes) => ValidatePublicCtor(model, paramNames, paramTypes);
    }
}
