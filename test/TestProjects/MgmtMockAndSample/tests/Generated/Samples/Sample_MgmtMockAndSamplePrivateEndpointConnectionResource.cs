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
    public partial class Sample_MgmtMockAndSamplePrivateEndpointConnectionResource
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

            // this example assumes you already have this MgmtMockAndSamplePrivateEndpointConnectionResource created on azure
            // for more information of creating MgmtMockAndSamplePrivateEndpointConnectionResource, please refer to the document of MgmtMockAndSamplePrivateEndpointConnectionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            string privateEndpointConnectionName = "sample-pec";
            ResourceIdentifier mgmtMockAndSamplePrivateEndpointConnectionResourceId = MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName, privateEndpointConnectionName);
            MgmtMockAndSamplePrivateEndpointConnectionResource mgmtMockAndSamplePrivateEndpointConnection = client.GetMgmtMockAndSamplePrivateEndpointConnectionResource(mgmtMockAndSamplePrivateEndpointConnectionResourceId);

            // invoke the operation
            MgmtMockAndSamplePrivateEndpointConnectionResource result = await mgmtMockAndSamplePrivateEndpointConnection.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MgmtMockAndSamplePrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // KeyVaultPutPrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_KeyVaultPutPrivateEndpointConnection()
        {
            // Generated from example definition:
            // this example is just showing the usage of "PrivateEndpointConnections_Put" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MgmtMockAndSamplePrivateEndpointConnectionResource created on azure
            // for more information of creating MgmtMockAndSamplePrivateEndpointConnectionResource, please refer to the document of MgmtMockAndSamplePrivateEndpointConnectionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            string privateEndpointConnectionName = "sample-pec";
            ResourceIdentifier mgmtMockAndSamplePrivateEndpointConnectionResourceId = MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName, privateEndpointConnectionName);
            MgmtMockAndSamplePrivateEndpointConnectionResource mgmtMockAndSamplePrivateEndpointConnection = client.GetMgmtMockAndSamplePrivateEndpointConnectionResource(mgmtMockAndSamplePrivateEndpointConnectionResourceId);

            // invoke the operation
            MgmtMockAndSamplePrivateEndpointConnectionData data = new MgmtMockAndSamplePrivateEndpointConnectionData()
            {
                Etag = "",
                ConnectionState = new MgmtMockAndSamplePrivateLinkServiceConnectionState()
                {
                    Status = MgmtMockAndSamplePrivateEndpointServiceConnectionStatus.Approved,
                    Description = "My name is Joe and I'm approving this.",
                },
            };
            ArmOperation<MgmtMockAndSamplePrivateEndpointConnectionResource> lro = await mgmtMockAndSamplePrivateEndpointConnection.UpdateAsync(WaitUntil.Completed, data);
            MgmtMockAndSamplePrivateEndpointConnectionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MgmtMockAndSamplePrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // KeyVaultDeletePrivateEndpointConnection
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_KeyVaultDeletePrivateEndpointConnection()
        {
            // Generated from example definition:
            // this example is just showing the usage of "PrivateEndpointConnections_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this MgmtMockAndSamplePrivateEndpointConnectionResource created on azure
            // for more information of creating MgmtMockAndSamplePrivateEndpointConnectionResource, please refer to the document of MgmtMockAndSamplePrivateEndpointConnectionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-group";
            string vaultName = "sample-vault";
            string privateEndpointConnectionName = "sample-pec";
            ResourceIdentifier mgmtMockAndSamplePrivateEndpointConnectionResourceId = MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName, privateEndpointConnectionName);
            MgmtMockAndSamplePrivateEndpointConnectionResource mgmtMockAndSamplePrivateEndpointConnection = client.GetMgmtMockAndSamplePrivateEndpointConnectionResource(mgmtMockAndSamplePrivateEndpointConnectionResourceId);

            // invoke the operation
            ArmOperation<MgmtMockAndSamplePrivateEndpointConnectionResource> lro = await mgmtMockAndSamplePrivateEndpointConnection.DeleteAsync(WaitUntil.Completed);
            MgmtMockAndSamplePrivateEndpointConnectionResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MgmtMockAndSamplePrivateEndpointConnectionData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
