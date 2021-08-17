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

        [TestCase("AvailabilitySet", true)]
        [TestCase("DedicatedHostGroup", true)]
        [TestCase("DedicatedHost", true)]
        [TestCase("VirtualMachineExtensionImage", false)]
        public void ValidateResource(string operation, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == operation);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("DedicatedHostContainer", "CreateOrUpdate",  "hostName")]
        [TestCase("DedicatedHostContainer", "CreateOrUpdateAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "StartCreateOrUpdate", "hostName")]
        [TestCase("DedicatedHostContainer", "StartCreateOrUpdateAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "Get", "hostName")]
        [TestCase("DedicatedHostContainer", "GetAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "GetIfExists", "hostName")]
        [TestCase("DedicatedHostContainer", "GetIfExistsAsync", "hostName")]
        [TestCase("DedicatedHostContainer", "CheckIfExists", "hostName")]
        [TestCase("DedicatedHostContainer", "CheckIfExistsAsync", "hostName")]
        [TestCase("DedicatedHostGroupContainer", "CreateOrUpdate", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "CreateOrUpdateAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "StartCreateOrUpdate", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "StartCreateOrUpdateAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "Get", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "GetAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "GetIfExists", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "GetIfExistsAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "CheckIfExists", "hostGroupName")]
        [TestCase("DedicatedHostGroupContainer", "CheckIfExistsAsync", "hostGroupName")]
        [TestCase("EnvironmentContainerResourceContainer", "CreateOrUpdate", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "CreateOrUpdateAsync", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "StartCreateOrUpdate", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "StartCreateOrUpdateAsync", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "Get", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "GetAsync", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "GetIfExists", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "GetIfExistsAsync", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "CheckIfExists", "name")]
        [TestCase("EnvironmentContainerResourceContainer", "CheckIfExistsAsync", "name")]
        public void ValidateContainerCorrectFirstParameter(string containerName, string methodName, string parameterName)
        {
            var method = FindAllContainers().Single(o => o.Name == containerName).GetMethod(methodName);
            Assert.AreEqual(parameterName, method?.GetParameters().First().Name);
        }
    }
}
