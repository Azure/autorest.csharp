﻿using System;
using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtParentTests : TestProjectTests
    {
        public MgmtParentTests() : base("MgmtParent") { }

        [TestCase("AvailabilitySet", true)]
        [TestCase("DedicatedHostGroup", true)]
        [TestCase("DedicatedHost", true)]
        [TestCase("VirtualMachineExtensionImage", false)]
        public void ValidateResources(string resource, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == resource);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("AvailabilitySetContainer", true)]
        [TestCase("DedicatedHostGroupContainer", true)]
        [TestCase("DedicatedHostContainer", true)]
        [TestCase("VirtualMachineExtensionImageContainer", false)]
        public void ValidateContainers(string container, bool isExists)
        {
            var containerTypeExists = FindAllContainers().Any(o => o.Name == container);
            Assert.AreEqual(isExists, containerTypeExists);
        }

        [TestCase("AvailabilitySetContainer", "GetAllAsGenericResources", true)]
        [TestCase("DedicatedHostGroupContainer", "GetAllAsGenericResources", true)]
        public void ValidateMethods(string className, string methodName, bool exist)
        {
            var classesToCheck = FindAllContainers();
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }
    }
}
