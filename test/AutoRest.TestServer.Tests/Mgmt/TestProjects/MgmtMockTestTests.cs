using System;
using System.Collections.Generic;
using NUnit.Framework;
using MgmtMockTest;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtMockTestTests : TestProjectTests
    {
        public MgmtMockTestTests() : base("MgmtMockTest", "tests") { }

        protected override HashSet<Type> ListExceptionCollections { get; } = new HashSet<Type>() { typeof(DeletedManagedHsmCollection), typeof(DeletedVaultCollection) };

        [TestCase("CreateOrUpdate")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidateMhsmPrivateEndpointConnectionCollectionMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.MhsmPrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdate")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidateManagedHsmCollectionMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdate")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidatePrivateEndpointConnectionCollectionMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.MgmtKeyvaultPrivateEndpointConnectionCollectionMockTests", methodName, argTypes);
        }

        [TestCase("CreateOrUpdate")]
        [TestCase("CreateOrUpdate2")]
        [TestCase("Get")]
        [TestCase("GetAll")]
        public void ValidateVaultCollectionMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.VaultCollectionMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        [TestCase("Update")]
        [TestCase("GetMHSMPrivateLinkResourcesByMhsmResource")]
        public void ValidateManagedHsmResourceMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.ManagedHsmResourceMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        public void ValidateMhsmPrivateEndpointConnectionResourceMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.MhsmPrivateEndpointConnectionResourceMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        public void ValidatePrivateEndpointConnectionResourceMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.MgmtKeyvaultPrivateEndpointConnectionResourceMockTests", methodName, argTypes);
        }

        [TestCase("Get")]
        [TestCase("Delete")]
        [TestCase("Update")]
        [TestCase("GetPrivateLinkResources")]
        public void ValidateVaultResourceMockTests(string methodName, params string[] argTypes)
        {
            ValidateMethodExist("MgmtKeyvault.Tests.Mock.VaultResourceMockTests", methodName, argTypes);
        }
    }
}
