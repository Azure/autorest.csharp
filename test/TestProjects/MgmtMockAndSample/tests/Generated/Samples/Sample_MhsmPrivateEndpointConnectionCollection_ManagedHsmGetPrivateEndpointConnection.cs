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
    public partial class Sample_MhsmPrivateEndpointConnectionCollection_ManagedHsmGetPrivateEndpointConnection
    {
        // ManagedHsmGetPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // this example is just showing the usage of "MHSMPrivateEndpointConnections_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this ManagedHsmResource created
            // if you do not know how to create ManagedHsmResource, please refer to the document of ManagedHsmResource
            ResourceIdentifier managedHsmResourceId = MgmtMockAndSample.ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            MgmtMockAndSample.ManagedHsmResource managedHsm = client.GetManagedHsmResource(managedHsmResourceId);

            // get the collection of this MhsmPrivateEndpointConnectionResource
            MgmtMockAndSample.MhsmPrivateEndpointConnectionCollection collection = managedHsm.GetMhsmPrivateEndpointConnections();

            // invoke the operation
            MgmtMockAndSample.MhsmPrivateEndpointConnectionResource result = await collection.GetAsync("sample-pec");

            MgmtMockAndSample.MhsmPrivateEndpointConnectionData data = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {data.Id}");
        }
    }
}
