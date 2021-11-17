// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtExtensionResourceTests : OutputLibraryTestBase
    {
        public MgmtExtensionResourceTests() : base("MgmtExtensionResource") { }

        [TestCase("SubscriptionPolicyDefinition", "SubscriptionExtensions")]
        [TestCase("ManagementGroupPolicyDefinition", "ManagementGroupExtensions")]
        [TestCase("BuiltInPolicyDefinition", "TenantExtensions")]
        public void TestExtensionResource(string resourceName, string parentName)
        {
            (_, var context) = Generate("MgmtExtensionResource").Result;

            var resource = context.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.NotNull(resource);
            var parents = resource.Parent(context);
            Assert.IsTrue(parents.Any(p => p.Type.Name == parentName));
        }
    }
}
