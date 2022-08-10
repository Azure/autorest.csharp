// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_MgmtMockAndSamplePrivateEndpointConnectionResource_KeyVaultPutPrivateEndpointConnection
    {
        // KeyVaultPutPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update()
        {
            // this example is just showing the usage of "PrivateEndpointConnections_Put" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this MgmtMockAndSamplePrivateEndpointConnectionResource created on azure
            // for more information of creating MgmtMockAndSamplePrivateEndpointConnectionResource, please refer to the document of MgmtMockAndSamplePrivateEndpointConnectionResource
            ResourceIdentifier mgmtMockAndSamplePrivateEndpointConnectionResourceId = MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault", "sample-pec");
            MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionResource mgmtMockAndSamplePrivateEndpointConnection = client.GetMgmtMockAndSamplePrivateEndpointConnectionResource(mgmtMockAndSamplePrivateEndpointConnectionResourceId);

            // invoke the operation
            ArmOperation<MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionResource> lro = await mgmtMockAndSamplePrivateEndpointConnection.UpdateAsync(WaitUntil.Completed, new MgmtMockAndSamplePrivateEndpointConnectionData()
            {
                Etag = "",
                ConnectionState = new MgmtMockAndSamplePrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            });
            MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionResource result = lro.Value;

            MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionData data = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {data.Id}");
        }
    }
}
