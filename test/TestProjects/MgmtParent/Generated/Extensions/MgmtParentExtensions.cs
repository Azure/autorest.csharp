// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtParent.Models;

namespace MgmtParent
{
    /// <summary> A class to add extension methods to MgmtParent. </summary>
    public static partial class MgmtParentExtensions
    {
        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ResourceGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ResourceGroupResourceExtensionClient(client, scope);
            });
        }

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new SubscriptionResourceExtensionClient(client, resource.Id);
            });
        }

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new SubscriptionResourceExtensionClient(client, scope);
            });
        }
        #region AvailabilitySetResource
        /// <summary>
        /// Gets an object representing an <see cref="AvailabilitySetResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AvailabilitySetResource.CreateResourceIdentifier" /> to create an <see cref="AvailabilitySetResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetResource" /> object. </returns>
        public static AvailabilitySetResource GetAvailabilitySetResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                AvailabilitySetResource.ValidateResourceId(id);
                return new AvailabilitySetResource(client, id);
            }
            );
        }
        #endregion

        #region DedicatedHostGroupResource
        /// <summary>
        /// Gets an object representing a <see cref="DedicatedHostGroupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DedicatedHostGroupResource.CreateResourceIdentifier" /> to create a <see cref="DedicatedHostGroupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHostGroupResource" /> object. </returns>
        public static DedicatedHostGroupResource GetDedicatedHostGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DedicatedHostGroupResource.ValidateResourceId(id);
                return new DedicatedHostGroupResource(client, id);
            }
            );
        }
        #endregion

        #region DedicatedHostResource
        /// <summary>
        /// Gets an object representing a <see cref="DedicatedHostResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DedicatedHostResource.CreateResourceIdentifier" /> to create a <see cref="DedicatedHostResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DedicatedHostResource" /> object. </returns>
        public static DedicatedHostResource GetDedicatedHostResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DedicatedHostResource.ValidateResourceId(id);
                return new DedicatedHostResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineExtensionImageResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineExtensionImageResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineExtensionImageResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineExtensionImageResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtensionImageResource" /> object. </returns>
        public static VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineExtensionImageResource.ValidateResourceId(id);
                return new VirtualMachineExtensionImageResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of AvailabilitySetResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of AvailabilitySetResources and their operations over a AvailabilitySetResource. </returns>
        public static AvailabilitySetCollection GetAvailabilitySets(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetAvailabilitySets();
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<AvailabilitySetResource>> GetAvailabilitySetAsync(this ResourceGroupResource resourceGroupResource, string availabilitySetName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetAvailabilitySets().GetAsync(availabilitySetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<AvailabilitySetResource> GetAvailabilitySet(this ResourceGroupResource resourceGroupResource, string availabilitySetName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetAvailabilitySets().Get(availabilitySetName, cancellationToken);
        }

        /// <summary> Gets a collection of DedicatedHostGroupResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DedicatedHostGroupResources and their operations over a DedicatedHostGroupResource. </returns>
        public static DedicatedHostGroupCollection GetDedicatedHostGroups(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetDedicatedHostGroups();
        }

        /// <summary>
        /// Retrieves information about a dedicated host group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. The response shows the list of instance view of the dedicated hosts under the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DedicatedHostGroupResource>> GetDedicatedHostGroupAsync(this ResourceGroupResource resourceGroupResource, string hostGroupName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetDedicatedHostGroups().GetAsync(hostGroupName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about a dedicated host group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. The response shows the list of instance view of the dedicated hosts under the dedicated host group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostGroupName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DedicatedHostGroupResource> GetDedicatedHostGroup(this ResourceGroupResource resourceGroupResource, string hostGroupName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDedicatedHostGroups().Get(hostGroupName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of VirtualMachineExtensionImageResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="publisherName"/> is null. </exception>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public static VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this SubscriptionResource subscriptionResource, string location, string publisherName)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineExtensionImages(location, publisherName);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(this SubscriptionResource subscriptionResource, string location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName).GetAsync(type, version, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(this SubscriptionResource subscriptionResource, string location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName).Get(type, version, cancellationToken);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AvailabilitySetResource> GetAvailabilitySetsAsync(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetAvailabilitySetsAsync(expand, cancellationToken);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AvailabilitySetResource> GetAvailabilitySets(this SubscriptionResource subscriptionResource, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetAvailabilitySets(expand, cancellationToken);
        }
    }
}
