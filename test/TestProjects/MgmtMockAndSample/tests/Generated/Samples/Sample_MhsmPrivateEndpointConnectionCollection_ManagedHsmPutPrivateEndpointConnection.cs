// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

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

            // we assume you already have this ManagedHsmResource created
            // if you do not know how to create ManagedHsmResource, please refer to the document of ManagedHsmResource
            ResourceIdentifier managedHsmResourceId = MgmtMockAndSample.ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            MgmtMockAndSample.ManagedHsmResource managedHsm = client.GetManagedHsmResource(managedHsmResourceId);

            // get the collection of this MhsmPrivateEndpointConnectionResource
            MhsmPrivateEndpointConnectionCollection collection = managedHsm.GetMhsmPrivateEndpointConnections();

            // invoke the operation
            ArmOperation<MgmtMockAndSample.MhsmPrivateEndpointConnectionResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "sample-pec", new MhsmPrivateEndpointConnectionData(new AzureLocation("placeholder"))
            {
                PrivateLinkServiceConnectionState = new MhsmPrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            });
            MgmtMockAndSample.MhsmPrivateEndpointConnectionResource result = lro.Value;
            MgmtMockAndSample.MhsmPrivateEndpointConnectionData data = result.Data;

            await Task.Run(() => _ = string.Empty);
        }
    }
}
