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
using MgmtPropertyChooser.Mocking;
using MgmtPropertyChooser.Models;

namespace MgmtPropertyChooser
{
    /// <summary> A class to add extension methods to MgmtPropertyChooser. </summary>
    public static partial class MgmtPropertyChooserExtensions
    {
        private static MgmtPropertyChooserArmClientMockingExtension GetMgmtPropertyChooserArmClientMockingExtension(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MgmtPropertyChooserArmClientMockingExtension(client0));
        }

        private static MgmtPropertyChooserResourceGroupMockingExtension GetMgmtPropertyChooserResourceGroupMockingExtension(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MgmtPropertyChooserResourceGroupMockingExtension(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineResource" /> object. </returns>
        public static VirtualMachineResource GetVirtualMachineResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtPropertyChooserArmClientMockingExtension(client).GetVirtualMachineResource(id);
        }

        /// <summary>
        /// Gets a collection of VirtualMachineResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtPropertyChooserResourceGroupMockingExtension.GetVirtualMachines()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of VirtualMachineResources and their operations over a VirtualMachineResource. </returns>
        public static VirtualMachineCollection GetVirtualMachines(this ResourceGroupResource resourceGroupResource)
        {
            return GetMgmtPropertyChooserResourceGroupMockingExtension(resourceGroupResource).GetVirtualMachines();
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtPropertyChooserResourceGroupMockingExtension.GetVirtualMachineAsync(string,InstanceViewType?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineResource>> GetVirtualMachineAsync(this ResourceGroupResource resourceGroupResource, string vmName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return await GetMgmtPropertyChooserResourceGroupMockingExtension(resourceGroupResource).GetVirtualMachineAsync(vmName, expand, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtPropertyChooserResourceGroupMockingExtension.GetVirtualMachine(string,InstanceViewType?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineResource> GetVirtualMachine(this ResourceGroupResource resourceGroupResource, string vmName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtPropertyChooserResourceGroupMockingExtension(resourceGroupResource).GetVirtualMachine(vmName, expand, cancellationToken);
        }
    }
}
