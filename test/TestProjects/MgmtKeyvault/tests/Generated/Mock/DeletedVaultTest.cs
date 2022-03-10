// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for DeletedVault. </summary>
    public partial class DeletedVaultMockTests : MockTestBase
    {
        public DeletedVaultMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a deleted vault
            var deletedVaultId = MgmtKeyvault.DeletedVault.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "westus", "sample-vault");
            var deletedVault = GetArmClient().GetDeletedVault(deletedVaultId);

            await deletedVault.GetAsync();
        }

        [RecordedTest]
        public async Task PurgeDeleted()
        {
            // Example: Purge a deleted vault
            var deletedVaultId = MgmtKeyvault.DeletedVault.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "westus", "sample-vault");
            var deletedVault = GetArmClient().GetDeletedVault(deletedVaultId);

            await deletedVault.PurgeDeletedAsync(WaitUntil.Completed);
        }
    }
}
