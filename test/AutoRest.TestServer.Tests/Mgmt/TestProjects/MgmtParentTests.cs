using System;
using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtParentTests : TestProjectTests
    {
        public MgmtParentTests() : base("MgmtParent") { }

        [TestCase("AvailabilitySetOperations", true)]
        [TestCase("DedicatedHostGroupOperations", true)]
        [TestCase("DedicatedHostOperations", true)]
        [TestCase("VirtualMachineExtensionImageOperations", true)]
        public void ValidateOperations(string operation, bool isExists)
        {
            var operationTypeExists = FindAllOperations().Any(o => o.Name == operation);
            Assert.AreEqual(isExists, operationTypeExists);
        }

        [TestCase("AvailabilitySet", true)]
        [TestCase("DedicatedHostGroup", true)]
        [TestCase("DedicatedHost", true)]
        [TestCase("VirtualMachineExtensionImage", true)]
        public void ValidateResources(string resource, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == resource);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("AvailabilitySetContainer", true)]
        [TestCase("DedicatedHostGroupContainer", true)]
        [TestCase("DedicatedHostContainer", true)]
        [TestCase("VirtualMachineExtensionImageContainer", true)]
        public void ValidateContainers(string container, bool isExists)
        {
            var containerTypeExists = FindAllContainers().Any(o => o.Name == container);
            Assert.AreEqual(isExists, containerTypeExists);
        }
    }
}
