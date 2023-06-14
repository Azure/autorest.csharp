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

namespace MgmtResourceName
{
    /// <summary> A class to add extension methods to MgmtResourceName. </summary>
    public static partial class MgmtResourceNameExtensions
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

        private static TenantResourceExtensionClient GetTenantResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new TenantResourceExtensionClient(client, resource.Id);
            });
        }

        private static TenantResourceExtensionClient GetTenantResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new TenantResourceExtensionClient(client, scope);
            });
        }
        #region MachineResource
        /// <summary>
        /// Gets an object representing a <see cref="MachineResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MachineResource.CreateResourceIdentifier" /> to create a <see cref="MachineResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MachineResource" /> object. </returns>
        public static MachineResource GetMachineResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MachineResource.ValidateResourceId(id);
                return new MachineResource(client, id);
            }
            );
        }
        #endregion

        #region Disk
        /// <summary>
        /// Gets an object representing a <see cref="Disk" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="Disk.CreateResourceIdentifier" /> to create a <see cref="Disk" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Disk" /> object. </returns>
        public static Disk GetDisk(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                Disk.ValidateResourceId(id);
                return new Disk(client, id);
            }
            );
        }
        #endregion

        #region Memory
        /// <summary>
        /// Gets an object representing a <see cref="Memory" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="Memory.CreateResourceIdentifier" /> to create a <see cref="Memory" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Memory" /> object. </returns>
        public static Memory GetMemory(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                Memory.ValidateResourceId(id);
                return new Memory(client, id);
            }
            );
        }
        #endregion

        #region NetworkResource
        /// <summary>
        /// Gets an object representing a <see cref="NetworkResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetworkResource.CreateResourceIdentifier" /> to create a <see cref="NetworkResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetworkResource" /> object. </returns>
        public static NetworkResource GetNetworkResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                NetworkResource.ValidateResourceId(id);
                return new NetworkResource(client, id);
            }
            );
        }
        #endregion

        #region DisplayResource
        /// <summary>
        /// Gets an object representing a <see cref="DisplayResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DisplayResource.CreateResourceIdentifier" /> to create a <see cref="DisplayResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DisplayResource" /> object. </returns>
        public static DisplayResource GetDisplayResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DisplayResource.ValidateResourceId(id);
                return new DisplayResource(client, id);
            }
            );
        }
        #endregion

        #region ProviderOperationResource
        /// <summary>
        /// Gets an object representing a <see cref="ProviderOperationResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ProviderOperationResource.CreateResourceIdentifier" /> to create a <see cref="ProviderOperationResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ProviderOperationResource" /> object. </returns>
        public static ProviderOperationResource GetProviderOperationResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ProviderOperationResource.ValidateResourceId(id);
                return new ProviderOperationResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of MachineResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of MachineResources and their operations over a MachineResource. </returns>
        public static MachineCollection GetMachines(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetMachines();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Machines_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MachineResource>> GetMachineAsync(this ResourceGroupResource resourceGroupResource, string machineName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetMachines().GetAsync(machineName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Machines_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MachineResource> GetMachine(this ResourceGroupResource resourceGroupResource, string machineName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetMachines().Get(machineName, cancellationToken);
        }

        /// <summary> Gets a collection of Disks in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of Disks and their operations over a Disk. </returns>
        public static DiskCollection GetDisks(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetDisks();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="diskResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<Disk>> GetDiskAsync(this ResourceGroupResource resourceGroupResource, string diskResourceName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetDisks().GetAsync(diskResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="diskResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<Disk> GetDisk(this ResourceGroupResource resourceGroupResource, string diskResourceName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDisks().Get(diskResourceName, cancellationToken);
        }

        /// <summary> Gets a collection of Memories in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of Memories and their operations over a Memory. </returns>
        public static MemoryCollection GetMemories(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetMemories();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/memoryResources/{memoryResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MemoryResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<Memory>> GetMemoryAsync(this ResourceGroupResource resourceGroupResource, string memoryResourceName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetMemories().GetAsync(memoryResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/memoryResources/{memoryResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MemoryResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<Memory> GetMemory(this ResourceGroupResource resourceGroupResource, string memoryResourceName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetMemories().Get(memoryResourceName, cancellationToken);
        }

        /// <summary> Gets a collection of NetworkResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of NetworkResources and their operations over a NetworkResource. </returns>
        public static NetworkCollection GetNetworks(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetNetworks();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/networkResources/{networkResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>networkResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="networkResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<NetworkResource>> GetNetworkAsync(this ResourceGroupResource resourceGroupResource, string networkResourceName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetNetworks().GetAsync(networkResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/networkResources/{networkResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>networkResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="networkResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<NetworkResource> GetNetwork(this ResourceGroupResource resourceGroupResource, string networkResourceName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetNetworks().Get(networkResourceName, cancellationToken);
        }

        /// <summary> Gets a collection of DisplayResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DisplayResources and their operations over a DisplayResource. </returns>
        public static DisplayResourceCollection GetDisplayResources(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetDisplayResources();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>displayResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DisplayResource>> GetDisplayResourceAsync(this ResourceGroupResource resourceGroupResource, string displayResourceName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetDisplayResources().GetAsync(displayResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>displayResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DisplayResource> GetDisplayResource(this ResourceGroupResource resourceGroupResource, string displayResourceName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDisplayResources().Get(displayResourceName, cancellationToken);
        }

        /// <summary> Gets a collection of ProviderOperationResources in the TenantResource. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ProviderOperationResources and their operations over a ProviderOperationResource. </returns>
        public static ProviderOperationCollection GetProviderOperations(this TenantResource tenantResource)
        {
            return GetTenantResourceExtensionClient(tenantResource).GetProviderOperations();
        }

        /// <summary>
        /// Gets provider operations metadata for the specified resource provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ProviderOperationResource>> GetProviderOperationAsync(this TenantResource tenantResource, string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            return await tenantResource.GetProviderOperations().GetAsync(resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets provider operations metadata for the specified resource provider.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/providerOperations/{resourceProviderNamespace}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProviderOperations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> Specifies whether to expand the values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ProviderOperationResource> GetProviderOperation(this TenantResource tenantResource, string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            return tenantResource.GetProviderOperations().Get(resourceProviderNamespace, expand, cancellationToken);
        }
    }
}
