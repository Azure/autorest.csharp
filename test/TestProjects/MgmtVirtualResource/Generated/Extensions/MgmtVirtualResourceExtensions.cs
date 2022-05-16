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

namespace MgmtVirtualResource
{
    /// <summary> A class to add extension methods to MgmtVirtualResource. </summary>
    public static partial class MgmtVirtualResourceExtensions
    {
        private static SubscriptionResourceExtensionClient GetExtensionClient(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient((client) =>
            {
                return new SubscriptionResourceExtensionClient(client, subscriptionResource.Id);
            }
            );
        }

        /// <summary>
        /// Gets all the public IP addresses in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/publicIPAddresses
        /// Operation Id: PublicIPAddresses_ListAll
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PublicIPAddressResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PublicIPAddressResource> GetPublicIPAddressesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetPublicIPAddressesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets all the public IP addresses in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/publicIPAddresses
        /// Operation Id: PublicIPAddresses_ListAll
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PublicIPAddressResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PublicIPAddressResource> GetPublicIPAddresses(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetPublicIPAddresses(cancellationToken);
        }

        private static ResourceGroupResourceExtensionClient GetExtensionClient(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient((client) =>
            {
                return new ResourceGroupResourceExtensionClient(client, resourceGroupResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of PublicIPAddressResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PublicIPAddressResources and their operations over a PublicIPAddressResource. </returns>
        public static PublicIPAddressCollection GetPublicIPAddresses(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetPublicIPAddresses();
        }

        /// <summary>
        /// Gets the specified public IP address in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPAddresses/{publicIpAddressName}
        /// Operation Id: PublicIPAddresses_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="publicIpAddressName"> The name of the public IP address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpAddressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpAddressName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PublicIPAddressResource>> GetPublicIPAddressAsync(this ResourceGroupResource resourceGroupResource, string publicIpAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPublicIPAddresses().GetAsync(publicIpAddressName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified public IP address in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPAddresses/{publicIpAddressName}
        /// Operation Id: PublicIPAddresses_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="publicIpAddressName"> The name of the public IP address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpAddressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpAddressName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PublicIPAddressResource> GetPublicIPAddress(this ResourceGroupResource resourceGroupResource, string publicIpAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPublicIPAddresses().Get(publicIpAddressName, expand, cancellationToken);
        }

        #region PublicIPAddressResource
        /// <summary>
        /// Gets an object representing a <see cref="PublicIPAddressResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PublicIPAddressResource.CreateResourceIdentifier" /> to create a <see cref="PublicIPAddressResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PublicIPAddressResource" /> object. </returns>
        public static PublicIPAddressResource GetPublicIPAddressResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PublicIPAddressResource.ValidateResourceId(id);
                return new PublicIPAddressResource(client, id);
            }
            );
        }
        #endregion

        #region ConfigurationProfileAssignmentResource
        /// <summary>
        /// Gets an object representing a <see cref="ConfigurationProfileAssignmentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ConfigurationProfileAssignmentResource.CreateResourceIdentifier" /> to create a <see cref="ConfigurationProfileAssignmentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ConfigurationProfileAssignmentResource" /> object. </returns>
        public static ConfigurationProfileAssignmentResource GetConfigurationProfileAssignmentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ConfigurationProfileAssignmentResource.ValidateResourceId(id);
                return new ConfigurationProfileAssignmentResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetMgmtVirtualResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetMgmtVirtualResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetMgmtVirtualResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetMgmtVirtualResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetMgmtVirtualResource" /> object. </returns>
        public static VirtualMachineScaleSetMgmtVirtualResource GetVirtualMachineScaleSetMgmtVirtualResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetMgmtVirtualResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetMgmtVirtualResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineMgmtVirtualResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineMgmtVirtualResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineMgmtVirtualResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineMgmtVirtualResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineMgmtVirtualResource" /> object. </returns>
        public static VirtualMachineMgmtVirtualResource GetVirtualMachineMgmtVirtualResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineMgmtVirtualResource.ValidateResourceId(id);
                return new VirtualMachineMgmtVirtualResource(client, id);
            }
            );
        }
        #endregion
    }
}
