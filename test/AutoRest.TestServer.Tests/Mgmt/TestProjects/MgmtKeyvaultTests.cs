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

        [TestCase("CreateOrUpdate")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidateMhsmPrivateEndpointConnectionCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.MhsmPrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdate")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidateManagedHsmCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdate")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidatePrivateEndpointConnectionCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.PrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdate")]
        [TestCase("CreateOrUpdate2")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidateVaultCollectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.VaultCollectionMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        [TestCase("Update")]
        [TestCase("GetMHSMPrivateLinkResourcesByMhsmResource")]
        public void ValidateManagedHsmMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        public void ValidateMhsmPrivateEndpointConnectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.MhsmPrivateEndpointConnectionMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        public void ValidatePrivateEndpointConnectionMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.PrivateEndpointConnectionMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        [TestCase("Update")]
        [TestCase("GetPrivateLinkResources")]
        public void ValidateVaultMockTests(string methodName, params string[] argTypes)
        {
            this.ValidateMethodExist("MgmtKeyvault.Tests.Mock.VaultMockTests", methodName, argTypes);
        }
    }
}
