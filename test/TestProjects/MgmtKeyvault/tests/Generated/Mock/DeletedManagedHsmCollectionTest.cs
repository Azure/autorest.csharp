// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault.Models;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for DeletedManagedHsm. </summary>
    public partial class DeletedManagedHsmCollectionMockTests : MockTestBase
    {
        public DeletedManagedHsmCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task GetAsync()
        {
            // Example: Retrieve a deleted managed HSM
            var collection = GetArmClient().GetSubscription(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000")).GetDeletedManagedHsms();
            string location = "westus";
            string name = "hsm1";

            await collection.GetAsync(location, name);
        }
    }
}
