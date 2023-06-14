// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_VaultResource
    {
        // Delete a vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_DeleteAVault()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-resource-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation
            await vault.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // Retrieve a vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_RetrieveAVault()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-resource-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation
            VaultResource result = await vault.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VaultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // List keys on an existing vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetKeys_ListKeysOnAnExistingVault()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_ListKeys" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-resource-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation and iterate over the result
            await foreach (VaultKey item in vault.GetKeysAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Validate an existing vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Validate_ValidateAnExistingVault()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_Validate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-resource-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation
            VaultValidationResult result = await vault.ValidateAsync();

            Console.WriteLine($"Succeeded: {result}");
        }

        // Disable a vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Disable_DisableAVault()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_Disable" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-resource-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation
            await vault.DisableAsync();

            Console.WriteLine($"Succeeded");
        }

        // Add an access policy, or update an access policy with new permissions
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task UpdateAccessPolicy_AddAnAccessPolicyOrUpdateAnAccessPolicyWithNewPermissions()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_UpdateAccessPolicy" operation, for the dependent resources, they will have to be created separately.

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

            // invoke the operation
            AccessPolicyUpdateKind operationKind = AccessPolicyUpdateKind.Add;
            VaultAccessPolicyParameters vaultAccessPolicyParameters = new VaultAccessPolicyParameters(new VaultAccessPolicyProperties(new AccessPolicyEntry[]
            {
new AccessPolicyEntry(Guid.Parse("00000000-0000-0000-0000-000000000000"),"00000000-0000-0000-0000-000000000000",new Permissions()
{
Keys =
{
KeyPermission.Encrypt
},
Secrets =
{
SecretPermission.Get
},
Certificates =
{
CertificatePermission.Get
},
})
            }));
            VaultAccessPolicyParameters result = await vault.UpdateAccessPolicyAsync(operationKind, vaultAccessPolicyParameters);

            Console.WriteLine($"Succeeded: {result}");
        }

        // List vaults in the specified subscription
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetVaults_ListVaultsInTheSpecifiedSubscription()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_ListBySubscription" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            int? top = 1;
            await foreach (VaultResource item in subscriptionResource.GetVaultsAsync(top: top))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VaultData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Validate a vault name
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CheckNameAvailabilityVault_ValidateAVaultName()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            VaultCheckNameAvailabilityContent content = new VaultCheckNameAvailabilityContent("sample-vault");
            CheckNameAvailabilityResult result = await subscriptionResource.CheckNameAvailabilityVaultAsync(content);

            Console.WriteLine($"Succeeded: {result}");
        }

        // KeyVaultListPrivateLinkResources
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetPrivateLinkResources_KeyVaultListPrivateLinkResources()
        {
            // Generated from example definition:
            // this example is just showing the usage of "PrivateLinkResources_ListByVault" operation, for the dependent resources, they will have to be created separately.

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

            // invoke the operation and iterate over the result
            await foreach (MgmtMockAndSamplePrivateLinkResource item in vault.GetPrivateLinkResourcesAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
