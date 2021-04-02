// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace AutoRest.TestServer.Tests.Mgmt
{
    internal class MgmtParentTests : OutputLibraryTestBase
    {
        [Test]
        public void TestParentComputer()
        {
            CodeModel model = Generate("MgmtParent").Result;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.Parent);
                if (operations.Key.Equals("VirtualMachineExtensionImages"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Compute/locations/publishers"));
                else if (operations.Key.Equals("AvailabilitySets"))
                    Assert.IsTrue(operations.Parent.Equals("resourceGroups"));
                else if (operations.Key.Equals("DedicatedHosts"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Compute/hostGroups"));
            }
        }
    }
}
