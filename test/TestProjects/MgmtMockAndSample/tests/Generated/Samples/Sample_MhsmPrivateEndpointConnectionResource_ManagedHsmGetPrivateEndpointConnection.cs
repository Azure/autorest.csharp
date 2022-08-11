// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_MhsmPrivateEndpointConnectionResource_ManagedHsmGetPrivateEndpointConnection
    {
        // ManagedHsmGetPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // this example is just showing the usage of "MHSMPrivateEndpointConnections_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this MhsmPrivateEndpointConnectionResource created on azure
            // for more information of creating MhsmPrivateEndpointConnectionResource, please refer to the document of MhsmPrivateEndpointConnectionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string name = "sample-mhsm";
            string privateEndpointConnectionName = "sample-pec";
            ResourceIdentifier mhsmPrivateEndpointConnectionResourceId = MgmtMockAndSample.MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, name, privateEndpointConnectionName);
            MgmtMockAndSample.MhsmPrivateEndpointConnectionResource mhsmPrivateEndpointConnection = client.GetMhsmPrivateEndpointConnectionResource(mhsmPrivateEndpointConnectionResourceId);

            // invoke the operation
            MgmtMockAndSample.MhsmPrivateEndpointConnectionResource result = await mhsmPrivateEndpointConnection.GetAsync();

            MgmtMockAndSample.MhsmPrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
