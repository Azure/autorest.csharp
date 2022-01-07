// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class StringExtensionsTests
    {

        [TestCase("MetadataRole", "MetadataRoles")]
        [TestCase("KeyInformation", "AllKeyInformation")]
        [TestCase("RoleMetadata", "AllRoleMetadata")]
        public void ValidateResourceNameToPlural(string resourceName, string expected)
        {
            var result = resourceName.ResourceNameToPlural();
            Assert.AreEqual(expected, result);
        }
    }
}
