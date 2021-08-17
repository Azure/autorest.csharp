// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;
using NUnit.Framework;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for MhsmPrivateEndpointConnection. </summary>
    public partial class MhsmPrivateEndpointConnectionCollectionMockTests : MockTestBase
    {
        public MhsmPrivateEndpointConnectionCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        public MhsmPrivateEndpointConnectionCollectionMockTests() : this(false)
        {
        }

        private async Task<MgmtKeyvault.MhsmPrivateEndpointConnectionCollection> GetMhsmPrivateEndpointConnectionCollectionAsync(string resourceGroupName, string name)
        {
            ResourceGroup resourceGroup = await TestHelper.CreateResourceGroupAsync(resourceGroupName, GetArmClient());
            ManagedHsmCollection managedHsmCollection = resourceGroup.GetManagedHsms();
            var managedHsmOperation = await TestHelper.CreateOrUpdateExampleInstanceAsync(managedHsmCollection, name);
            ManagedHsm managedHsm = managedHsmOperation.Value;
            MhsmPrivateEndpointConnectionCollection mhsmPrivateEndpointConnectionCollection = managedHsm.GetMhsmPrivateEndpointConnections();
            return mhsmPrivateEndpointConnectionCollection;
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task CreateOrUpdateAsync()
        {
            // Example: ManagedHsmPutPrivateEndpointConnection
            var collection = await GetMhsmPrivateEndpointConnectionCollectionAsync("sample-group", "sample-mhsm");
            await TestHelper.CreateOrUpdateExampleInstanceAsync(collection, "sample-pec");
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task GetAllAsync()
        {
            // Example: List managed HSM Pools in a subscription
            var collection = await GetMhsmPrivateEndpointConnectionCollectionAsync("sample-group", "sample-mhsm");
            TestHelper.GetAllExampleInstanceAsync(collection).AsPages();
        }
    }
}
