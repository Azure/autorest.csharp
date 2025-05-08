// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.ResourceManager.Resources.Models;
using MgmtNoTypeReplacement;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtNoPropertyTypeReplacementTests : TestProjectTests
    {
        public MgmtNoPropertyTypeReplacementTests()
            : base("MgmtNoTypeReplacement")
        {
        }

        private protected override Assembly GetAssembly() => typeof(NoTypeReplacementModel1Data).Assembly;

        [TestCase(typeof(SubResource), typeof(NoTypeReplacementModel1Data))]
        public void ValidateType(Type expectedType, Type targetClass)
        {
            Assert.AreEqual(expectedType, targetClass.GetProperty("Foo", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).PropertyType);
        }

        [TestCase("NoSubResourceModel", typeof(NoTypeReplacementModel2Data))]
        public void ValidateType(string expectedTypeName, Type targetClass)
            => ValidateType(GetType(expectedTypeName), targetClass);

        [TestCase("NoSubResourceModel2", "MiddleResourceModel")]
        public void ValidateType(string expectedTypeName, string targetClassName)
            => ValidateType(GetType(expectedTypeName), GetType(targetClassName));
    }
}
