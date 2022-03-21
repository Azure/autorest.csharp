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

namespace MgmtPropertyChooser
{
    /// <summary> A class to add extension methods to MgmtPropertyChooser. </summary>
    public static partial class MgmtPropertyChooserExtensions
    {
        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((client) =>
            {
                return new ResourceGroupExtensionClient(client, resourceGroup.Id);
            }
            );
        }

        /// <summary> Gets a collection of VirtualMachines in the VirtualMachine. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of VirtualMachines and their operations over a VirtualMachine. </returns>
        public static VirtualMachineCollection GetVirtualMachines(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetVirtualMachines();
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// Operation Id: VirtualMachines_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public static async Task<Response<VirtualMachine>> GetVirtualMachineAsync(this ResourceGroup resourceGroup, string vmName, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetVirtualMachines().GetAsync(vmName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// Operation Id: VirtualMachines_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public static Response<VirtualMachine> GetVirtualMachine(this ResourceGroup resourceGroup, string vmName, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetVirtualMachines().Get(vmName, cancellationToken);
        }

        #region VirtualMachine
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachine" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachine.CreateResourceIdentifier" /> to create a <see cref="VirtualMachine" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachine" /> object. </returns>
        public static VirtualMachine GetVirtualMachine(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachine.ValidateResourceId(id);
                return new VirtualMachine(client, id);
            }
            );
        }
        #endregion
    }
}
