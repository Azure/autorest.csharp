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
    /// <summary> Test for DeletedManagedHsmResource. </summary>
    public partial class DeletedManagedHsmResourceMockTests : MockTestBase
    {
        public DeletedManagedHsmResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a deleted managed HSM

            ResourceIdentifier deletedManagedHsmResourceId = MgmtMockAndSample.DeletedManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "westus", "hsm1");
            MgmtMockAndSample.DeletedManagedHsmResource deletedManagedHsm = GetArmClient().GetDeletedManagedHsmResource(deletedManagedHsmResourceId);
            await deletedManagedHsm.GetAsync();
        }

        [RecordedTest]
        public async Task PurgeDeleted()
        {
            // Example: Purge a managed HSM Pool

            ResourceIdentifier deletedManagedHsmResourceId = MgmtMockAndSample.DeletedManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "westus", "hsm1");
            MgmtMockAndSample.DeletedManagedHsmResource deletedManagedHsm = GetArmClient().GetDeletedManagedHsmResource(deletedManagedHsmResourceId);
            await deletedManagedHsm.PurgeDeletedAsync(WaitUntil.Completed);
        }
    }
}
