// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtParentTests : OutputLibraryTestBase
    {
        public MgmtParentTests() : base("MgmtParent") { }

        [Test]
        public void TestParentComputer()
        {
            var result = Generate("MgmtParent").Result;
            var model = result.Model;
            var context = result.Context;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.ParentResourceType(context.Configuration.MgmtConfiguration));
                if (operations.Key.Equals("VirtualMachineExtensionImages"))
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals("Microsoft.Compute/locations/publishers"));
                else if (operations.Key.Equals("AvailabilitySets"))
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals("resourceGroups"));
                else if (operations.Key.Equals("DedicatedHosts"))
                    Assert.IsTrue(operations.ParentResourceType(context.Configuration.MgmtConfiguration).Equals("Microsoft.Compute/hostGroups"));
            }
        }
    }
}
