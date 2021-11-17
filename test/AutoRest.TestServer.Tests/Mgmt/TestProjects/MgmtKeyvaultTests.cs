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

        [TestCase("CreateOrUpdateExampleInstanceAsync", "VaultCollection", "String")]
        [TestCase("GetAllExampleInstanceAsync", "VaultCollection")]
        [TestCase("CreateOrUpdateExampleInstanceAsync", "PrivateEndpointConnectionCollection", "String")]
        [TestCase("GetAllExampleInstanceAsync", "PrivateEndpointConnectionCollection")]
        [TestCase("CreateOrUpdateExampleInstanceAsync", "ManagedHsmCollection", "String")]
        [TestCase("GetAllExampleInstanceAsync", "ManagedHsmCollection")]
        [TestCase("CreateOrUpdateExampleInstanceAsync", "MhsmPrivateEndpointConnectionCollection", "String")]
        [TestCase("GetAllExampleInstanceAsync", "MhsmPrivateEndpointConnectionCollection")]
        [TestCase("CreateResourceGroupAsync", "String", "ArmClient")]
        [TestCase("ReplaceWith")]
        public void ValidateHelperMethods(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.TestHelper", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("GetAllAsync")]
        public void ValidateDeletedVaultCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.MhsmPrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("GetAllAsync")]
        public void ValidateManagedHsmCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("GetAllAsync")]
        public void ValidatePrivateEndpointConnectionCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.PrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdateAsync")]
        [TestCase("GetAllAsync")]
        public void ValidateVaultCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.VaultCollectionMockTests", methodName, argTypes);
        }

        [TestCase("GetAsync")]
        [TestCase("DeleteAsync")]
        [TestCase("UpdateAsync")]
        public void ValidateManagedHsmMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmMockTests", methodName, argTypes);
        }
    }
}
