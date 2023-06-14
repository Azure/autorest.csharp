// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for MgmtMockAndSamplePrivateEndpointConnectionCollection. </summary>
    public partial class MgmtMockAndSamplePrivateEndpointConnectionCollectionMockTests : MockTestBase
    {
        public MgmtMockAndSamplePrivateEndpointConnectionCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Example: KeyVaultPutPrivateEndpointConnection

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "sample-pec", new MgmtMockAndSamplePrivateEndpointConnectionData()
            {
                Etag = "",
                ConnectionState = new MgmtMockAndSamplePrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            });
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: KeyVaultGetPrivateEndpointConnection

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();
            await collection.ExistsAsync("sample-pec");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: KeyVaultGetPrivateEndpointConnection

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();
            await collection.GetAsync("sample-pec");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: KeyVaultListPrivateEndpointConnection

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            var collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }
    }
}
