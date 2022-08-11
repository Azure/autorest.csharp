// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for DeletedVaultResource. </summary>
    public partial class DeletedVaultResourceMockTests : MockTestBase
    {
        public DeletedVaultResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a deleted vault

            ResourceIdentifier deletedVaultResourceId = MgmtMockAndSample.DeletedVaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", new AzureLocation("westus"), "sample-vault");
            MgmtMockAndSample.DeletedVaultResource deletedVault = GetArmClient().GetDeletedVaultResource(deletedVaultResourceId);
            await deletedVault.GetAsync();
        }

        [RecordedTest]
        public async Task PurgeDeleted()
        {
            // Example: Purge a deleted vault

            ResourceIdentifier deletedVaultResourceId = MgmtMockAndSample.DeletedVaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", new AzureLocation("westus"), "sample-vault");
            MgmtMockAndSample.DeletedVaultResource deletedVault = GetArmClient().GetDeletedVaultResource(deletedVaultResourceId);
            await deletedVault.PurgeDeletedAsync(WaitUntil.Completed);
        }
    }
}
