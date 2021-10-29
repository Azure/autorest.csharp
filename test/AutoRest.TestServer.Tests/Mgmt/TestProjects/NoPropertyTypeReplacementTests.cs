// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Resources.Models;
using NoTypeReplacement;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class NoPropertyTypeReplacementTests : TestProjectTests
    {
        public NoPropertyTypeReplacementTests()
            : base("NoTypeReplacement")
        {
        }

        [TestCase(typeof(SubResource), typeof(NoTypeReplacementModel1Data))]
        [TestCase(typeof(NoTypeReplacement.Models.NoSubResourceModel), typeof(NoTypeReplacementModel2Data))]
        [TestCase(typeof(NoTypeReplacement.Models.NoSubResourceModel2), typeof(NoTypeReplacement.Models.MiddleResourceModel))]
        public void ValidateType(Type expectedType, Type targetClass)
        {
            Assert.AreEqual(expectedType, targetClass.GetProperty("Foo").PropertyType);
        }

    }
}
