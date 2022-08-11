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
    public partial class Sample_MhsmPrivateEndpointConnectionCollection_ManagedHsmPutPrivateEndpointConnection
    {
        // ManagedHsmPutPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            // this example is just showing the usage of "MHSMPrivateEndpointConnections_Put" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this ManagedHsmResource created on azure
            // for more information of creating ManagedHsmResource, please refer to the document of ManagedHsmResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string name = "sample-mhsm";
            ResourceIdentifier managedHsmResourceId = MgmtMockAndSample.ManagedHsmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, name);
            MgmtMockAndSample.ManagedHsmResource managedHsm = client.GetManagedHsmResource(managedHsmResourceId);

            // get the collection of this MhsmPrivateEndpointConnectionResource
            MgmtMockAndSample.MhsmPrivateEndpointConnectionCollection collection = managedHsm.GetMhsmPrivateEndpointConnections();

            // invoke the operation
            string privateEndpointConnectionName = "sample-pec";
            MgmtMockAndSample.MhsmPrivateEndpointConnectionData data = new MhsmPrivateEndpointConnectionData(new AzureLocation("placeholder"))
            {
                PrivateLinkServiceConnectionState = new MhsmPrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            };
            ArmOperation<MgmtMockAndSample.MhsmPrivateEndpointConnectionResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionName, data);
            MgmtMockAndSample.MhsmPrivateEndpointConnectionResource result = lro.Value;

            MgmtMockAndSample.MhsmPrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
