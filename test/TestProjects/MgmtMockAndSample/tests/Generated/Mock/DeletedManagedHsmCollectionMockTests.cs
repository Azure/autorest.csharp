// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for DeletedManagedHsmCollection. </summary>
    public partial class DeletedManagedHsmCollectionMockTests : MockTestBase
    {
        public DeletedManagedHsmCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: Retrieve a deleted managed HSM

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetDeletedManagedHsms();
            await collection.ExistsAsync(new AzureLocation("westus"), "hsm1");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a deleted managed HSM

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            var collection = subscriptionResource.GetDeletedManagedHsms();
            await collection.GetAsync(new AzureLocation("westus"), "hsm1");
        }
    }
}
