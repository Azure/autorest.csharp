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
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for MhsmPrivateEndpointConnectionResource. </summary>
    public partial class MhsmPrivateEndpointConnectionResourceMockTests : MockTestBase
    {
        public MhsmPrivateEndpointConnectionResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: ManagedHsmDeletePrivateEndpointConnection

            ResourceIdentifier mhsmPrivateEndpointConnectionResourceId = MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            MhsmPrivateEndpointConnectionResource mhsmPrivateEndpointConnection = GetArmClient().GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);
            await mhsmPrivateEndpointConnection.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: ManagedHsmGetPrivateEndpointConnection

            ResourceIdentifier mhsmPrivateEndpointConnectionResourceId = MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            MhsmPrivateEndpointConnectionResource mhsmPrivateEndpointConnection = GetArmClient().GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);
            await mhsmPrivateEndpointConnection.GetAsync();
        }

        [RecordedTest]
        public async Task Update()
        {
            // Example: ManagedHsmPutPrivateEndpointConnection

            ResourceIdentifier mhsmPrivateEndpointConnectionResourceId = MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm", "sample-pec");
            MhsmPrivateEndpointConnectionResource mhsmPrivateEndpointConnection = GetArmClient().GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);
            await mhsmPrivateEndpointConnection.UpdateAsync(WaitUntil.Completed, new MhsmPrivateEndpointConnectionData(new AzureLocation("placeholder"))
            {
                PrivateLinkServiceConnectionState = new MhsmPrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            });
        }
    }
}
