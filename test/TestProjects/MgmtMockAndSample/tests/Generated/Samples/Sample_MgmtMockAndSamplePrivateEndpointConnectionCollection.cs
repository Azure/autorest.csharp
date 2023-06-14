// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public partial class Sample_MgmtMockAndSamplePrivateEndpointConnectionCollection
    {
        // KeyVaultGetPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_KeyVaultGetPrivateEndpointConnection()
        {
            // Generated from example definition:
            // this example is just showing the usage of "PrivateEndpointConnections_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // get the collection of this MgmtMockAndSamplePrivateEndpointConnectionResource
            MgmtMockAndSamplePrivateEndpointConnectionCollection collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();

            // invoke the operation
            string privateEndpointConnectionName = "sample-pec";
            MgmtMockAndSamplePrivateEndpointConnectionResource result = await collection.GetAsync(privateEndpointConnectionName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MgmtMockAndSamplePrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // KeyVaultGetPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_KeyVaultGetPrivateEndpointConnection()
        {
            // Generated from example definition:
            // this example is just showing the usage of "PrivateEndpointConnections_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // get the collection of this MgmtMockAndSamplePrivateEndpointConnectionResource
            MgmtMockAndSamplePrivateEndpointConnectionCollection collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();

            // invoke the operation
            string privateEndpointConnectionName = "sample-pec";
            bool result = await collection.ExistsAsync(privateEndpointConnectionName);

            Console.WriteLine($"Succeeded: {result}");
        }

        // KeyVaultPutPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate_KeyVaultPutPrivateEndpointConnection()
        {
            // Generated from example definition:
            // this example is just showing the usage of "PrivateEndpointConnections_Put" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // get the collection of this MgmtMockAndSamplePrivateEndpointConnectionResource
            MgmtMockAndSamplePrivateEndpointConnectionCollection collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();

            // invoke the operation
            string privateEndpointConnectionName = "sample-pec";
            MgmtMockAndSamplePrivateEndpointConnectionData data = new MgmtMockAndSamplePrivateEndpointConnectionData()
            {
                Etag = "",
                ConnectionState = new MgmtMockAndSamplePrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            };
            ArmOperation<MgmtMockAndSamplePrivateEndpointConnectionResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionName, data);
            MgmtMockAndSamplePrivateEndpointConnectionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MgmtMockAndSamplePrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // KeyVaultListPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_KeyVaultListPrivateEndpointConnection()
        {
            // Generated from example definition:
            // this example is just showing the usage of "PrivateEndpointConnections_ListByResource" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // get the collection of this MgmtMockAndSamplePrivateEndpointConnectionResource
            MgmtMockAndSamplePrivateEndpointConnectionCollection collection = vault.GetMgmtMockAndSamplePrivateEndpointConnections();

            // invoke the operation and iterate over the result
            await foreach (MgmtMockAndSamplePrivateEndpointConnectionResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                MgmtMockAndSamplePrivateEndpointConnectionData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
