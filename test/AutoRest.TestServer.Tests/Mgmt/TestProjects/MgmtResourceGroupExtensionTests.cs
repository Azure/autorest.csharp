using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using NUnit.Framework;
using MgmtResourceGroupExtension;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtResourceGroupExtensionTests : TestProjectTests
    {
        public MgmtResourceGroupExtensionTests() : base("MgmtResourceGroupExtension") { }

        [Test]
        public void TestResourceGroupExtensionTests()
        {
            var errorCode = 0;
            foreach (var method in typeof(MgmtResourceGroupExtension.ResourceGroupExtensions).GetMethods())
            {
                if (method.DeclaringType.Name.Equals("Object"))
                    continue;
                if (!method.Name.Equals("GetAvailabilitySets"))
                    errorCode++;
                if (!method.ReturnType.Name.Equals("AvailabilitySetContainer"))
                    errorCode++;
                if (method.Name.Equals("GetVirtualMachineExtensionImages"))
                    errorCode++;
                if (method.ReturnType.Name.Equals("VirtualMachineExtensionImageContainer"))
                    errorCode++;
                if (!method.IsStatic)
                    errorCode++;
                foreach (var parameter in method.GetParameters())
                {
                    if (!parameter.Name.Equals("resourceGroup"))
                        errorCode++;
                    if (!parameter.ParameterType.Name.Equals("ResourceGroupOperations"))
                        errorCode++;
                }
            }
            Assert.IsTrue(errorCode == 0);
        }
    }
}
