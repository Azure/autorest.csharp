using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtKeyvaultTestsTests : TestProjectTests
    {
        public MgmtKeyvaultTestsTests() : base("MgmtKeyvault", "tests") { }

        [TestCase("ReplaceWith")]
        public void ValidateHelperMethods(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.TestHelper", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("GetAsync")]
        [TestCase("GetAllAsync")]
        public void ValidateMhsmPrivateEndpointConnectionCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.MhsmPrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("GetAsync")]
        [TestCase("GetAllAsync")]
        public void ValidateManagedHsmCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("GetAsync")]
        [TestCase("GetAllAsync")]
        public void ValidatePrivateEndpointConnectionCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.PrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("CreateOrUpdateAsync2")]
        [TestCase("GetAsync")]
        [TestCase("GetAllAsync")]
        public void ValidateVaultCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.VaultCollectionMockTests", methodName, argTypes);
        }

        [TestCase("GetAsync")]
        [TestCase("DeleteAsync")]
        [TestCase("UpdateAsync")]
        [TestCase("GetMHSMPrivateLinkResourcesByMhsmResourceAsync")]
        public void ValidateManagedHsmMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmMockTests", methodName, argTypes);
        }

        [TestCase("GetAsync")]
        [TestCase("DeleteAsync")]
        public void ValidateMhsmPrivateEndpointConnectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.MhsmPrivateEndpointConnectionMockTests", methodName, argTypes);
        }

        [TestCase("GetAsync")]
        [TestCase("DeleteAsync")]
        public void ValidatePrivateEndpointConnectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.PrivateEndpointConnectionMockTests", methodName, argTypes);
        }

        [TestCase("GetAsync")]
        [TestCase("DeleteAsync")]
        [TestCase("UpdateAsync")]
        [TestCase("GetPrivateLinkResourcesAsync")]
        public void ValidateVaultMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.VaultMockTests", methodName, argTypes);
        }
    }
}
