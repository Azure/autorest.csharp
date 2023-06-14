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
    /// <summary> Test for MgmtMockAndSamplePrivateEndpointConnectionResource. </summary>
    public partial class MgmtMockAndSamplePrivateEndpointConnectionResourceMockTests : MockTestBase
    {
        public MgmtMockAndSamplePrivateEndpointConnectionResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: KeyVaultDeletePrivateEndpointConnection

            ResourceIdentifier mgmtMockAndSamplePrivateEndpointConnectionResourceId = MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault", "sample-pec");
            MgmtMockAndSamplePrivateEndpointConnectionResource mgmtMockAndSamplePrivateEndpointConnection = GetArmClient().GetMgmtMockAndSamplePrivateEndpointConnectionResource(mgmtMockAndSamplePrivateEndpointConnectionResourceId);
            await mgmtMockAndSamplePrivateEndpointConnection.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: KeyVaultGetPrivateEndpointConnection

            ResourceIdentifier mgmtMockAndSamplePrivateEndpointConnectionResourceId = MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault", "sample-pec");
            MgmtMockAndSamplePrivateEndpointConnectionResource mgmtMockAndSamplePrivateEndpointConnection = GetArmClient().GetMgmtMockAndSamplePrivateEndpointConnectionResource(mgmtMockAndSamplePrivateEndpointConnectionResourceId);
            await mgmtMockAndSamplePrivateEndpointConnection.GetAsync();
        }

        [RecordedTest]
        public async Task Update()
        {
            // Example: KeyVaultPutPrivateEndpointConnection

            ResourceIdentifier mgmtMockAndSamplePrivateEndpointConnectionResourceId = MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault", "sample-pec");
            MgmtMockAndSamplePrivateEndpointConnectionResource mgmtMockAndSamplePrivateEndpointConnection = GetArmClient().GetMgmtMockAndSamplePrivateEndpointConnectionResource(mgmtMockAndSamplePrivateEndpointConnectionResourceId);
            await mgmtMockAndSamplePrivateEndpointConnection.UpdateAsync(WaitUntil.Completed, new MgmtMockAndSamplePrivateEndpointConnectionData()
            {
                Etag = "",
                ConnectionState = new MgmtMockAndSamplePrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            });
        }
    }
}
