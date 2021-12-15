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
        [TestCase("VirtualMachineExtensionImage", true)]
        public void ValidateResource(string operation, bool isExists)
        {
            var resourceTypeExists = FindAllResources().Any(o => o.Name == operation);
            Assert.AreEqual(isExists, resourceTypeExists);
        }

        [TestCase("DedicatedHostCollection", "CreateOrUpdate",  "hostName")]
        [TestCase("DedicatedHostCollection", "CreateOrUpdateAsync", "hostName")]
        [TestCase("DedicatedHostCollection", "Get", "hostName")]
        [TestCase("DedicatedHostCollection", "GetAsync", "hostName")]
        [TestCase("DedicatedHostCollection", "GetIfExists", "hostName")]
        [TestCase("DedicatedHostCollection", "GetIfExistsAsync", "hostName")]
        [TestCase("DedicatedHostCollection", "CheckIfExists", "hostName")]
        [TestCase("DedicatedHostCollection", "CheckIfExistsAsync", "hostName")]
        [TestCase("DedicatedHostGroupCollection", "CreateOrUpdate", "hostGroupName")]
        [TestCase("DedicatedHostGroupCollection", "CreateOrUpdateAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupCollection", "Get", "hostGroupName")]
        [TestCase("DedicatedHostGroupCollection", "GetAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupCollection", "GetIfExists", "hostGroupName")]
        [TestCase("DedicatedHostGroupCollection", "GetIfExistsAsync", "hostGroupName")]
        [TestCase("DedicatedHostGroupCollection", "CheckIfExists", "hostGroupName")]
        [TestCase("DedicatedHostGroupCollection", "CheckIfExistsAsync", "hostGroupName")]
        [TestCase("EnvironmentContainerResourceCollection", "CreateOrUpdate", "name")]
        [TestCase("EnvironmentContainerResourceCollection", "CreateOrUpdateAsync", "name")]
        [TestCase("EnvironmentContainerResourceCollection", "Get", "name")]
        [TestCase("EnvironmentContainerResourceCollection", "GetAsync", "name")]
        [TestCase("EnvironmentContainerResourceCollection", "GetIfExists", "name")]
        [TestCase("EnvironmentContainerResourceCollection", "GetIfExistsAsync", "name")]
        [TestCase("EnvironmentContainerResourceCollection", "Exists", "name")]
        [TestCase("EnvironmentContainerResourceCollection", "ExistsAsync", "name")]
        public void ValidateCollectionCorrectFirstParameter(string collectionName, string methodName, string parameterName)
        {
            var method = FindAllCollections().Single(o => o.Name == collectionName).GetMethod(methodName);
            Assert.AreEqual(parameterName, method?.GetParameters().First().Name);
        }
    }
}
