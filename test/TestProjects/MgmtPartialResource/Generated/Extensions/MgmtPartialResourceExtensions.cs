// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtPartialResource.Mocking;

namespace MgmtPartialResource
{
    /// <summary> A class to add extension methods to MgmtPartialResource. </summary>
    public static partial class MgmtPartialResourceExtensions
    {
        private static MockableMgmtPartialResourceArmClient GetMockableMgmtPartialResourceArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMgmtPartialResourceArmClient(client0));
        }

        private static MockableMgmtPartialResourceResourceGroupResource GetMockableMgmtPartialResourceResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtPartialResourceResourceGroupResource(client, resource.Id));
        }

        private static MockableMgmtPartialResourceSubscriptionResource GetMockableMgmtPartialResourceSubscriptionResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtPartialResourceSubscriptionResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="PublicIPAddressResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PublicIPAddressResource.CreateResourceIdentifier" /> to create a <see cref="PublicIPAddressResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceArmClient.GetPublicIPAddressResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="PublicIPAddressResource"/> object. </returns>
        public static PublicIPAddressResource GetPublicIPAddressResource(this ArmClient client, ResourceIdentifier id)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return GetMockableMgmtPartialResourceArmClient(client).GetPublicIPAddressResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ConfigurationProfileAssignmentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ConfigurationProfileAssignmentResource.CreateResourceIdentifier" /> to create a <see cref="ConfigurationProfileAssignmentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceArmClient.GetConfigurationProfileAssignmentResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ConfigurationProfileAssignmentResource"/> object. </returns>
        public static ConfigurationProfileAssignmentResource GetConfigurationProfileAssignmentResource(this ArmClient client, ResourceIdentifier id)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return GetMockableMgmtPartialResourceArmClient(client).GetConfigurationProfileAssignmentResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PartialVmssResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PartialVmssResource.CreateResourceIdentifier" /> to create a <see cref="PartialVmssResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceArmClient.GetPartialVmssResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="PartialVmssResource"/> object. </returns>
        public static PartialVmssResource GetPartialVmssResource(this ArmClient client, ResourceIdentifier id)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return GetMockableMgmtPartialResourceArmClient(client).GetPartialVmssResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineMgmtPartialResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineMgmtPartialResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineMgmtPartialResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceArmClient.GetVirtualMachineMgmtPartialResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="VirtualMachineMgmtPartialResource"/> object. </returns>
        public static VirtualMachineMgmtPartialResource GetVirtualMachineMgmtPartialResource(this ArmClient client, ResourceIdentifier id)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return GetMockableMgmtPartialResourceArmClient(client).GetVirtualMachineMgmtPartialResource(id);
        }

        /// <summary>
        /// Gets a collection of PublicIPAddressResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceResourceGroupResource.GetPublicIPAddresses()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of PublicIPAddressResources and their operations over a PublicIPAddressResource. </returns>
        public static PublicIPAddressCollection GetPublicIPAddresses(this ResourceGroupResource resourceGroupResource)
        {
            if (resourceGroupResource == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupResource));
            }

            return GetMockableMgmtPartialResourceResourceGroupResource(resourceGroupResource).GetPublicIPAddresses();
        }

        /// <summary>
        /// Gets the specified public IP address in a specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPAddresses/{publicIpAddressName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublicIPAddressResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceResourceGroupResource.GetPublicIPAddressAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="publicIpAddressName"> The name of the public IP address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="publicIpAddressName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publicIpAddressName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PublicIPAddressResource>> GetPublicIPAddressAsync(this ResourceGroupResource resourceGroupResource, string publicIpAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupResource));
            }

            return await GetMockableMgmtPartialResourceResourceGroupResource(resourceGroupResource).GetPublicIPAddressAsync(publicIpAddressName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified public IP address in a specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPAddresses/{publicIpAddressName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublicIPAddressResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceResourceGroupResource.GetPublicIPAddress(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="publicIpAddressName"> The name of the public IP address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="publicIpAddressName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publicIpAddressName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<PublicIPAddressResource> GetPublicIPAddress(this ResourceGroupResource resourceGroupResource, string publicIpAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupResource));
            }

            return GetMockableMgmtPartialResourceResourceGroupResource(resourceGroupResource).GetPublicIPAddress(publicIpAddressName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets all the public IP addresses in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/publicIPAddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_ListAll</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublicIPAddressResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceSubscriptionResource.GetPublicIPAddresses(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="PublicIPAddressResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PublicIPAddressResource> GetPublicIPAddressesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            if (subscriptionResource == null)
            {
                throw new ArgumentNullException(nameof(subscriptionResource));
            }

            return GetMockableMgmtPartialResourceSubscriptionResource(subscriptionResource).GetPublicIPAddressesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets all the public IP addresses in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/publicIPAddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_ListAll</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PublicIPAddressResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtPartialResourceSubscriptionResource.GetPublicIPAddresses(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="PublicIPAddressResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PublicIPAddressResource> GetPublicIPAddresses(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            if (subscriptionResource == null)
            {
                throw new ArgumentNullException(nameof(subscriptionResource));
            }

            return GetMockableMgmtPartialResourceSubscriptionResource(subscriptionResource).GetPublicIPAddresses(cancellationToken);
        }
    }
}
