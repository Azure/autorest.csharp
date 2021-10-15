// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;
using MgmtScopeResource;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtScopeResourceTests : OutputLibraryTestBase
    {
        public MgmtScopeResourceTests() : base("MgmtScopeResource") { }

        [TestCase("PolicyAssignment", "SubscriptionExtensions")]
        [TestCase("PolicyAssignment", "ResourceGroupExtensions")]
        [TestCase("PolicyAssignment", "ManagementGroupExtensions")]
        [TestCase("PolicyAssignment", "TenantExtensions")]
        [TestCase("DeploymentExtended", "SubscriptionExtensions")]
        [TestCase("DeploymentExtended", "ResourceGroupExtensions")]
        [TestCase("DeploymentExtended", "ManagementGroupExtensions")]
        [TestCase("DeploymentExtended", "TenantExtensions")]
        [TestCase("ResourceLink", "TenantExtensions")]
        public void TestScopeResource(string resourceName, string parentName)
        {
            (_, var context) = Generate("MgmtScopeResource").Result;

            var resource = context.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.NotNull(resource);
            var parents = resource.Parent(context);
            Assert.IsTrue(parents.Any(p => p.Type.Name == parentName));
        }
    }
}
