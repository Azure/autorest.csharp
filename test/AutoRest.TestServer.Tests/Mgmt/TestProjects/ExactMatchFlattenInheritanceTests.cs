﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Models;
using ExactMatchFlattenInheritance;
using ExactMatchFlattenInheritance.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ExactMatchFlattenInheritanceTests : TestProjectTests
    {
        public ExactMatchFlattenInheritanceTests()
            : base("ExactMatchFlattenInheritance")
        {
        }

        [TestCase(typeof(TrackedResource), typeof(AzureResourceFlattenModel1Data))]
        [TestCase(typeof(TrackedResource), typeof(AzureResourceFlattenModel2))]
        [TestCase(typeof(TrackedResource), typeof(AzureResourceFlattenModel3))]
        [TestCase(typeof(object), typeof(AzureResourceFlattenModel4))]
        [TestCase(typeof(Resource), typeof(AzureResourceFlattenModel5))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
            foreach (var property in generatedClass.BaseType.GetProperties())
            {
                Assert.IsFalse(generatedClass.GetProperty(property.Name).DeclaringType == generatedClass);
            }
        }

        [TestCase(typeof(AzureResourceFlattenModel1Data), new string[] { "location", "foo", "fooPropertiesFoo" }, new Type[] { typeof(AzureLocation), typeof(string), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel2), new string[] { "location", "new" }, new Type[] { typeof(AzureLocation), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel3), new string[] { "location", "new" }, new Type[] { typeof(AzureLocation), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel4), new string[] { "id", "name", "type", "foo" }, new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel5), new string[] { "id", "name", "type", "foo" }, new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) })]
        [TestCase(typeof(AzureResourceFlattenModel7), new string[] { "id", "name", "type" }, new Type[] { typeof(string), typeof(string), typeof(string) })]
        public void ValidateCtor(Type model, string[] paramNames, Type[] paramTypes) => ValidatePublicCtor(model, paramNames, paramTypes);
    }
}
