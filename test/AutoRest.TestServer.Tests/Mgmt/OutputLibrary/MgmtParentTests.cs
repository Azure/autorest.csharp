// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtParentTests : OutputLibraryTestBase
    {
        public MgmtParentTests() : base("MgmtParent") { }

        [TestCase("VirtualMachineExtensionImage", "SubscriptionExtensions")]
        [TestCase("AvailabilitySet", "ResourceGroupExtensions")]
        [TestCase("DedicatedHost", "DedicatedHostGroup")]
        public void TestParent(string resourceName, string parentName)
        {
            (_, var context) = Generate("MgmtParent").Result;

            var resource = context.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.NotNull(resource);
            var parents = resource.Parent(context);
            Assert.IsTrue(parents.Any(p => p.Type.Name == parentName));
        }
    }
}
