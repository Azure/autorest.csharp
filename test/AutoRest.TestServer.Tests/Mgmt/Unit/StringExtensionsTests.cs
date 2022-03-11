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

        [TestCase("MetadataRole", "MetadataRoleResource")]
        [TestCase("PrivateResource", "PrivateResource")]
        [TestCase("PrivateResource2", "PrivateResource2Resource")]
        public void ValidateAddResourceSuffixToResourceName(string resourceName, string expected)
        {
            var result = resourceName.AddResourceSuffixToResourceName();
            Assert.AreEqual(expected, result);

        }

        [TestCase("MetadataRole", "MetadataRole")]
        [TestCase("PrivateResource", "Private")]
        [TestCase("PrivateResource2", "PrivateResource2")]
        public void ValidateRemoveResourceSuffixFromResourceName(string resourceName, string expected)
        {
            var result = resourceName.TrimResourceSuffixFromResourceName();
            Assert.AreEqual(expected, result);

        }
    }
}
