// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtSingletonTests : OutputLibraryTestBase
    {
        public MgmtSingletonTests() : base("MgmtSingleton") { }

        [TestCase("ParentResource", false)]
        [TestCase("SingletonResource", true)]
        [TestCase("SingletonResource2", true)]
        [TestCase("SubscriptionParentSingleton", true)]
        [TestCase("TenantParentSingleton", true)]
        public void TestSingletonDetection(string resourceName, bool isSingleton)
        {
            (_, var context) = Generate("MgmtSingleton").Result;

            var resource = context.Library.ArmResources.FirstOrDefault(r => r.Type.Name == resourceName);
            Assert.NotNull(resource);
            Assert.AreEqual(isSingleton, resource.IsSingleton);
        }
    }
}
