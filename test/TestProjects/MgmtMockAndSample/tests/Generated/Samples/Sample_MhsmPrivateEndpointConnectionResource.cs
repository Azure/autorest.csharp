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
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_MhsmPrivateEndpointConnectionResource
    {
        // ManagedHsmGetPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_ManagedHsmGetPrivateEndpointConnection()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "MHSMPrivateEndpointConnections_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this MhsmPrivateEndpointConnectionResource created on azure
            // for more information of creating MhsmPrivateEndpointConnectionResource, please refer to the document of MhsmPrivateEndpointConnectionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string name = "sample-mhsm";
            string privateEndpointConnectionName = "sample-pec";
            ResourceIdentifier mhsmPrivateEndpointConnectionResourceId = MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            MhsmPrivateEndpointConnectionResource mhsmPrivateEndpointConnection = client.GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);

            // invoke the operation
            MhsmPrivateEndpointConnectionResource result = await mhsmPrivateEndpointConnection.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MhsmPrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // ManagedHsmPutPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_ManagedHsmPutPrivateEndpointConnection()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "MHSMPrivateEndpointConnections_Put" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this MhsmPrivateEndpointConnectionResource created on azure
            // for more information of creating MhsmPrivateEndpointConnectionResource, please refer to the document of MhsmPrivateEndpointConnectionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string name = "sample-mhsm";
            string privateEndpointConnectionName = "sample-pec";
            ResourceIdentifier mhsmPrivateEndpointConnectionResourceId = MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            MhsmPrivateEndpointConnectionResource mhsmPrivateEndpointConnection = client.GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);

            // invoke the operation
            MhsmPrivateEndpointConnectionData data = new MhsmPrivateEndpointConnectionData(new AzureLocation("placeholder"))
            {
                PrivateLinkServiceConnectionState = new MhsmPrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            };
            ArmOperation<MhsmPrivateEndpointConnectionResource> lro = await mhsmPrivateEndpointConnection.UpdateAsync(WaitUntil.Completed, data);
            MhsmPrivateEndpointConnectionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MhsmPrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // ManagedHsmDeletePrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_ManagedHsmDeletePrivateEndpointConnection()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "MHSMPrivateEndpointConnections_Delete" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this MhsmPrivateEndpointConnectionResource created on azure
            // for more information of creating MhsmPrivateEndpointConnectionResource, please refer to the document of MhsmPrivateEndpointConnectionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string name = "sample-mhsm";
            string privateEndpointConnectionName = "sample-pec";
            ResourceIdentifier mhsmPrivateEndpointConnectionResourceId = MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            MhsmPrivateEndpointConnectionResource mhsmPrivateEndpointConnection = client.GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);

            // invoke the operation
            ArmOperation<MhsmPrivateEndpointConnectionResource> lro = await mhsmPrivateEndpointConnection.DeleteAsync(WaitUntil.Completed);
            MhsmPrivateEndpointConnectionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MhsmPrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
