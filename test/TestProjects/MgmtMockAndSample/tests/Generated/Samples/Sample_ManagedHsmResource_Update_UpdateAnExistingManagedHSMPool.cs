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

namespace MgmtMockAndSample
{
    public partial class Sample_ManagedHsmResource_Update_UpdateAnExistingManagedHSMPool
    {
        // Update an existing managed HSM Pool
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "ManagedHsms_Update" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this ManagedHsmResource created on azure
            // for more information of creating ManagedHsmResource, please refer to the document of ManagedHsmResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "hsm-group";
            string name = "hsm1";
            ResourceIdentifier managedHsmResourceId = MgmtMockAndSample.ManagedHsmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, name);
            MgmtMockAndSample.ManagedHsmResource managedHsm = client.GetManagedHsmResource(managedHsmResourceId);

            // invoke the operation
            ManagedHsmData data = new ManagedHsmData(new AzureLocation("placeholder"))
            {
                Tags =
{
["Dept"] = "hsm",
["Environment"] = "dogfood",
["Slice"] = "A",
},
            };
            ArmOperation<ManagedHsmResource> lro = await managedHsm.UpdateAsync(WaitUntil.Completed, data);
            ManagedHsmResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            ManagedHsmData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
