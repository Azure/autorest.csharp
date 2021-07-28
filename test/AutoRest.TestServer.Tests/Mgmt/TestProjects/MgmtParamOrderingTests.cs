using System;
using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtParamOrderingTests : TestProjectTests
    {
        public MgmtParamOrderingTests() : base("MgmtParamOrdering")
        {
        }

        [TestCase("AvailabilitySetOperations", true)]
        [TestCase("DedicatedHostGroupOperations", true)]
        [TestCase("DedicatedHostOperations", true)]
        [TestCase("VirtualMachineExtensionImageOperations", false)]
        public void ValidateOperations(string operation, bool isExists)
        {
            var operationTypeExists = FindAllOperations().Any(o => o.Name == operation);
            Assert.AreEqual(isExists, operationTypeExists);
        }

        [TestCase("DedicatedHostContainer", "CreateOrUpdate",  "hostName")]
        [TestCase("DedicatedHostContainer", "CreateOrUpdateAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "StartCreateOrUpdate", "hostName")]
        [TestCase("DedicatedHostContainer", "StartCreateOrUpdateAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "Get", "hostName")]
        [TestCase("DedicatedHostContainer", "GetAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "TryGet", "hostName")]
        [TestCase("DedicatedHostContainer", "TryGetAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "CheckIfExists", "hostName")]
        [TestCase("DedicatedHostContainer", "CheckIfExistsAsync", "hostName")]
        [TestCase("DedicatedHostGroupContainer", "CreateOrUpdate", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "CreateOrUpdateAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "StartCreateOrUpdate", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "StartCreateOrUpdateAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "Get", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "GetAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "TryGet", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "TryGetAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "CheckIfExists", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "CheckIfExistsAsync", "hostGroupName")]
        public void ValidateContainerCorrectFirstParameter(string containerName, string methodName, string parameterName)
        {
            var method = FindAllContainers().Single(o => o.Name == containerName).GetMethod(methodName);
            Assert.AreEqual(parameterName, method?.GetParameters().First().Name);
        }
    }
}
