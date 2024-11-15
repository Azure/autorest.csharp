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
using NUnit.Framework;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_GuestConfigurationAssignmentResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateOrUpdateGuestConfigurationAssignment()
        {
            // Generated from example definition:
            // this example is just showing the usage of "GuestConfigurationAssignments_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GuestConfigurationAssignmentResource created on azure
            // for more information of creating GuestConfigurationAssignmentResource, please refer to the document of GuestConfigurationAssignmentResource
            string subscriptionId = "mySubscriptionId";
            string resourceGroupName = "myResourceGroupName";
            string vmName = "myVMName";
            string guestConfigurationAssignmentName = "NotInstalledApplicationForWindows";
            ResourceIdentifier guestConfigurationAssignmentResourceId = GuestConfigurationAssignmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vmName, guestConfigurationAssignmentName);
            GuestConfigurationAssignmentResource guestConfigurationAssignment = client.GetGuestConfigurationAssignmentResource(guestConfigurationAssignmentResourceId);

            // invoke the operation
            GuestConfigurationAssignmentData data = new GuestConfigurationAssignmentData()
            {
                Properties = new GuestConfigurationAssignmentProperties()
                {
                    Context = "Azure policy",
                },
                Name = "NotInstalledApplicationForWindows",
                Location = new AzureLocation("westcentralus"),
            };
            ArmOperation<GuestConfigurationAssignmentResource> lro = await guestConfigurationAssignment.UpdateAsync(WaitUntil.Completed, data);
            GuestConfigurationAssignmentResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GuestConfigurationAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetAGuestConfigurationAssignment()
        {
            // Generated from example definition:
            // this example is just showing the usage of "GuestConfigurationAssignments_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GuestConfigurationAssignmentResource created on azure
            // for more information of creating GuestConfigurationAssignmentResource, please refer to the document of GuestConfigurationAssignmentResource
            string subscriptionId = "mySubscriptionId";
            string resourceGroupName = "myResourceGroupName";
            string vmName = "myVMName";
            string guestConfigurationAssignmentName = "SecureProtocol";
            ResourceIdentifier guestConfigurationAssignmentResourceId = GuestConfigurationAssignmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vmName, guestConfigurationAssignmentName);
            GuestConfigurationAssignmentResource guestConfigurationAssignment = client.GetGuestConfigurationAssignmentResource(guestConfigurationAssignmentResourceId);

            // invoke the operation
            GuestConfigurationAssignmentResource result = await guestConfigurationAssignment.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GuestConfigurationAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteAnGuestConfigurationAssignment()
        {
            // Generated from example definition:
            // this example is just showing the usage of "GuestConfigurationAssignments_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this GuestConfigurationAssignmentResource created on azure
            // for more information of creating GuestConfigurationAssignmentResource, please refer to the document of GuestConfigurationAssignmentResource
            string subscriptionId = "mySubscriptionId";
            string resourceGroupName = "myResourceGroupName";
            string vmName = "myVMName";
            string guestConfigurationAssignmentName = "SecureProtocol";
            ResourceIdentifier guestConfigurationAssignmentResourceId = GuestConfigurationAssignmentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vmName, guestConfigurationAssignmentName);
            GuestConfigurationAssignmentResource guestConfigurationAssignment = client.GetGuestConfigurationAssignmentResource(guestConfigurationAssignmentResourceId);

            // invoke the operation
            await guestConfigurationAssignment.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }
    }
}
