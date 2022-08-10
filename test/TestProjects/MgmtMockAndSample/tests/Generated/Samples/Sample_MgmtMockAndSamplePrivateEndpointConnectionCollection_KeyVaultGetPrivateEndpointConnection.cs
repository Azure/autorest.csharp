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
    public partial class Sample_MgmtMockAndSamplePrivateEndpointConnectionCollection_KeyVaultGetPrivateEndpointConnection
    {
        // KeyVaultGetPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // this example is just showing the usage of "PrivateEndpointConnections_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this VaultResource created
            // if you do not know how to create VaultResource, please refer to the document of VaultResource
            ResourceIdentifier vaultResourceId = MgmtMockAndSample.VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            MgmtMockAndSample.VaultResource vault = client.GetVaultResource(vaultResourceId);

            // get the collection of this MgmtMockAndSamplePrivateEndpointConnectionResource
            MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionCollection collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();

            // invoke the operation
            MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionResource result = await collection.GetAsync("sample-pec");

            MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionData data = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {data.Id}");
        }
    }
}
