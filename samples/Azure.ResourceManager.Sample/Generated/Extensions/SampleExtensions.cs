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
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Sample. </summary>
    public static partial class SampleExtensions
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

        #region ProximityPlacementGroupResource
        /// <summary>
        /// Gets an object representing a <see cref="ProximityPlacementGroupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ProximityPlacementGroupResource.CreateResourceIdentifier" /> to create a <see cref="ProximityPlacementGroupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ProximityPlacementGroupResource" /> object. </returns>
        public static ProximityPlacementGroupResource GetProximityPlacementGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ProximityPlacementGroupResource.ValidateResourceId(id);
                return new ProximityPlacementGroupResource(client, id);
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

        #region SshPublicKeyResource
        /// <summary>
        /// Gets an object representing a <see cref="SshPublicKeyResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SshPublicKeyResource.CreateResourceIdentifier" /> to create a <see cref="SshPublicKeyResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SshPublicKeyResource" /> object. </returns>
        public static SshPublicKeyResource GetSshPublicKeyResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SshPublicKeyResource.ValidateResourceId(id);
                return new SshPublicKeyResource(client, id);
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

        #region VirtualMachineExtensionResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineExtensionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineExtensionResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineExtensionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtensionResource" /> object. </returns>
        public static VirtualMachineExtensionResource GetVirtualMachineExtensionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineExtensionResource.ValidateResourceId(id);
                return new VirtualMachineExtensionResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetVirtualMachineExtensionResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVirtualMachineExtensionResource" /> object. </returns>
        public static VirtualMachineScaleSetVirtualMachineExtensionResource GetVirtualMachineScaleSetVirtualMachineExtensionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetVirtualMachineExtensionResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetVirtualMachineExtensionResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineResource" /> object. </returns>
        public static VirtualMachineResource GetVirtualMachineResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineResource.ValidateResourceId(id);
                return new VirtualMachineResource(client, id);
            }
            );
        }
        #endregion

        #region ImageResource
        /// <summary>
        /// Gets an object representing an <see cref="ImageResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ImageResource.CreateResourceIdentifier" /> to create an <see cref="ImageResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ImageResource" /> object. </returns>
        public static ImageResource GetImageResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ImageResource.ValidateResourceId(id);
                return new ImageResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetResource" /> object. </returns>
        public static VirtualMachineScaleSetResource GetVirtualMachineScaleSetResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetExtensionResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetExtensionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetExtensionResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetExtensionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetExtensionResource" /> object. </returns>
        public static VirtualMachineScaleSetExtensionResource GetVirtualMachineScaleSetExtensionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetExtensionResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetExtensionResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetRollingUpgradeResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetRollingUpgradeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetRollingUpgradeResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetRollingUpgradeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetRollingUpgradeResource" /> object. </returns>
        public static VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgradeResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetRollingUpgradeResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetRollingUpgradeResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineScaleSetVMResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineScaleSetVMResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineScaleSetVMResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineScaleSetVMResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVMResource" /> object. </returns>
        public static VirtualMachineScaleSetVMResource GetVirtualMachineScaleSetVMResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineScaleSetVMResource.ValidateResourceId(id);
                return new VirtualMachineScaleSetVMResource(client, id);
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

        /// <summary> Gets a collection of ProximityPlacementGroupResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ProximityPlacementGroupResources and their operations over a ProximityPlacementGroupResource. </returns>
        public static ProximityPlacementGroupCollection GetProximityPlacementGroups(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetProximityPlacementGroups();
        }

        /// <summary>
        /// Retrieves information about a proximity placement group .
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ProximityPlacementGroupResource>> GetProximityPlacementGroupAsync(this ResourceGroupResource resourceGroupResource, string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetProximityPlacementGroups().GetAsync(proximityPlacementGroupName, includeColocationStatus, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about a proximity placement group .
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/proximityPlacementGroups/{proximityPlacementGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="includeColocationStatus"> includeColocationStatus=true enables fetching the colocation status of all the resources in the proximity placement group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="proximityPlacementGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="proximityPlacementGroupName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ProximityPlacementGroupResource> GetProximityPlacementGroup(this ResourceGroupResource resourceGroupResource, string proximityPlacementGroupName, string includeColocationStatus = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetProximityPlacementGroups().Get(proximityPlacementGroupName, includeColocationStatus, cancellationToken);
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

        /// <summary> Gets a collection of SshPublicKeyResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SshPublicKeyResources and their operations over a SshPublicKeyResource. </returns>
        public static SshPublicKeyCollection GetSshPublicKeys(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSshPublicKeys();
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SshPublicKeyResource>> GetSshPublicKeyAsync(this ResourceGroupResource resourceGroupResource, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetSshPublicKeys().GetAsync(sshPublicKeyName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<SshPublicKeyResource> GetSshPublicKey(this ResourceGroupResource resourceGroupResource, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetSshPublicKeys().Get(sshPublicKeyName, cancellationToken);
        }

        /// <summary> Gets a collection of VirtualMachineResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of VirtualMachineResources and their operations over a VirtualMachineResource. </returns>
        public static VirtualMachineCollection GetVirtualMachines(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetVirtualMachines();
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineResource>> GetVirtualMachineAsync(this ResourceGroupResource resourceGroupResource, string vmName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetVirtualMachines().GetAsync(vmName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineResource> GetVirtualMachine(this ResourceGroupResource resourceGroupResource, string vmName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetVirtualMachines().Get(vmName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of ImageResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ImageResources and their operations over a ImageResource. </returns>
        public static ImageCollection GetImages(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetImages();
        }

        /// <summary>
        /// Gets an image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/images/{imageName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="imageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ImageResource>> GetImageAsync(this ResourceGroupResource resourceGroupResource, string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetImages().GetAsync(imageName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/images/{imageName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="imageName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ImageResource> GetImage(this ResourceGroupResource resourceGroupResource, string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetImages().Get(imageName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of VirtualMachineScaleSetResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of VirtualMachineScaleSetResources and their operations over a VirtualMachineScaleSetResource. </returns>
        public static VirtualMachineScaleSetCollection GetVirtualMachineScaleSets(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetVirtualMachineScaleSets();
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineScaleSetResource>> GetVirtualMachineScaleSetAsync(this ResourceGroupResource resourceGroupResource, string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetVirtualMachineScaleSets().GetAsync(vmScaleSetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmScaleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmScaleSetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineScaleSetResource> GetVirtualMachineScaleSet(this ResourceGroupResource resourceGroupResource, string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetVirtualMachineScaleSets().Get(vmScaleSetName, cancellationToken);
        }

        /// <summary> Gets a collection of VirtualMachineExtensionImageResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public static VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName)
        {
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
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
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
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Lists all proximity placement groups in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/proximityPlacementGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProximityPlacementGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ProximityPlacementGroupResource> GetProximityPlacementGroupsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetProximityPlacementGroupsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all proximity placement groups in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/proximityPlacementGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProximityPlacementGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ProximityPlacementGroupResource> GetProximityPlacementGroups(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetProximityPlacementGroups(cancellationToken);
        }

        /// <summary>
        /// Lists all of the dedicated host groups in the subscription. Use the nextLink property in the response to get the next page of dedicated host groups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/hostGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DedicatedHostGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DedicatedHostGroupResource> GetDedicatedHostGroupsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDedicatedHostGroupsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all of the dedicated host groups in the subscription. Use the nextLink property in the response to get the next page of dedicated host groups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/hostGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DedicatedHostGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DedicatedHostGroupResource> GetDedicatedHostGroups(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDedicatedHostGroups(cancellationToken);
        }

        /// <summary>
        /// Lists all of the SSH public keys in the subscription. Use the nextLink property in the response to get the next page of SSH public keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/sshPublicKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SshPublicKeyResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<SshPublicKeyResource> GetSshPublicKeysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSshPublicKeysAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all of the SSH public keys in the subscription. Use the nextLink property in the response to get the next page of SSH public keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/sshPublicKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SshPublicKeyResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<SshPublicKeyResource> GetSshPublicKeys(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSshPublicKeys(cancellationToken);
        }

        /// <summary>
        /// Gets a virtual machine image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is null. </exception>
        public static async Task<Response<VirtualMachineImage>> GetVirtualMachineImageAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            return await GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineImageAsync(location, publisherName, offer, skus, version, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a virtual machine image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is null. </exception>
        public static Response<VirtualMachineImage> GetVirtualMachineImage(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineImage(location, publisherName, offer, skus, version, cancellationToken);
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineImageResource> GetVirtualMachineImagesAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineImagesAsync(options, cancellationToken);
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineImageResource> GetVirtualMachineImages(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineImages(options, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image offers for the specified location and publisher.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListOffers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineImageResource> GetOffersVirtualMachineImagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetOffersVirtualMachineImagesAsync(location, publisherName, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image offers for the specified location and publisher.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListOffers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineImageResource> GetOffersVirtualMachineImages(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetOffersVirtualMachineImages(location, publisherName, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image publishers for the specified Azure location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListPublishers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineImageResource> GetPublishersVirtualMachineImagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetPublishersVirtualMachineImagesAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image publishers for the specified Azure location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListPublishers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineImageResource> GetPublishersVirtualMachineImages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetPublishersVirtualMachineImages(location, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image SKUs for the specified location, publisher, and offer.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListSkus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> or <paramref name="offer"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> or <paramref name="offer"/> is null. </exception>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineImageResource> GetSkusVirtualMachineImagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSkusVirtualMachineImagesAsync(location, publisherName, offer, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image SKUs for the specified location, publisher, and offer.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListSkus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> or <paramref name="offer"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> or <paramref name="offer"/> is null. </exception>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineImageResource> GetSkusVirtualMachineImages(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetSkusVirtualMachineImages(location, publisherName, offer, cancellationToken);
        }

        /// <summary>
        /// Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usage_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SampleUsage" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<SampleUsage> GetUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetUsagesAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usage_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SampleUsage" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<SampleUsage> GetUsages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetUsages(location, cancellationToken);
        }

        /// <summary>
        /// Gets all the virtual machines under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineResource> GetVirtualMachinesByLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachinesByLocationAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets all the virtual machines under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineResource> GetVirtualMachinesByLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachinesByLocation(location, cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineResource> GetVirtualMachinesAsync(this SubscriptionResource subscriptionResource, string statusOnly = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachinesAsync(statusOnly, cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineResource> GetVirtualMachines(this SubscriptionResource subscriptionResource, string statusOnly = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachines(statusOnly, cancellationToken);
        }

        /// <summary>
        /// This API is deprecated. Use [Resources Skus](https://docs.microsoft.com/en-us/rest/api/compute/resourceskus/list)
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/vmSizes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineSizes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineSize" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineSize> GetVirtualMachineSizesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineSizesAsync(location, cancellationToken);
        }

        /// <summary>
        /// This API is deprecated. Use [Resources Skus](https://docs.microsoft.com/en-us/rest/api/compute/resourceskus/list)
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/vmSizes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineSizes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineSize" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineSize> GetVirtualMachineSizes(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineSizes(location, cancellationToken);
        }

        /// <summary>
        /// Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ImageResource> GetImagesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetImagesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ImageResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ImageResource> GetImages(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetImages(cancellationToken);
        }

        /// <summary>
        /// Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineScaleSetsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineScaleSetResource> GetVirtualMachineScaleSets(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineScaleSets(cancellationToken);
        }

        /// <summary>
        /// Export logs that show Api requests made by this subscription in the given time window to show throttling activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportRequestRateByInterval</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static async Task<ArmOperation<LogAnalytics>> ExportRequestRateByIntervalLogAnalyticAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, RequestRateByIntervalContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return await GetSubscriptionResourceExtensionClient(subscriptionResource).ExportRequestRateByIntervalLogAnalyticAsync(waitUntil, location, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Export logs that show Api requests made by this subscription in the given time window to show throttling activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportRequestRateByInterval</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static ArmOperation<LogAnalytics> ExportRequestRateByIntervalLogAnalytic(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, RequestRateByIntervalContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).ExportRequestRateByIntervalLogAnalytic(waitUntil, location, content, cancellationToken);
        }

        /// <summary>
        /// Export logs that show total throttled Api requests for this subscription in the given time window.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportThrottledRequests</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static async Task<ArmOperation<LogAnalytics>> ExportThrottledRequestsLogAnalyticAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, ThrottledRequestsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return await GetSubscriptionResourceExtensionClient(subscriptionResource).ExportThrottledRequestsLogAnalyticAsync(waitUntil, location, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Export logs that show total throttled Api requests for this subscription in the given time window.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportThrottledRequests</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static ArmOperation<LogAnalytics> ExportThrottledRequestsLogAnalytic(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, ThrottledRequestsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).ExportThrottledRequestsLogAnalytic(waitUntil, location, content, cancellationToken);
        }
    }
}
