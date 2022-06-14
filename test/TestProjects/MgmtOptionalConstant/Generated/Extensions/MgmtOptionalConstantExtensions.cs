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
using MgmtOptionalConstant.Models;

namespace MgmtOptionalConstant
{
    /// <summary> A class to add extension methods to MgmtOptionalConstant. </summary>
    public static partial class MgmtOptionalConstantExtensions
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
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Constant/optionalMachines
        /// Operation Id: Optionals_ListAll
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<OptionalMachineResource> GetOptionalMachinesAsync(this SubscriptionResource subscriptionResource, string statusOnly = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetOptionalMachinesAsync(statusOnly, cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Constant/optionalMachines
        /// Operation Id: Optionals_ListAll
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<OptionalMachineResource> GetOptionalMachines(this SubscriptionResource subscriptionResource, string statusOnly = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetOptionalMachines(statusOnly, cancellationToken);
        }

        private static ResourceGroupResourceExtensionClient GetExtensionClient(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient((client) =>
            {
                return new ResourceGroupResourceExtensionClient(client, resourceGroupResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of OptionalMachineResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of OptionalMachineResources and their operations over a OptionalMachineResource. </returns>
        public static OptionalMachineCollection GetOptionalMachines(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetOptionalMachines();
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<OptionalMachineResource>> GetOptionalMachineAsync(this ResourceGroupResource resourceGroupResource, string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetOptionalMachines().GetAsync(name, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}
        /// Operation Id: Optionals_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<OptionalMachineResource> GetOptionalMachine(this ResourceGroupResource resourceGroupResource, string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetOptionalMachines().Get(name, expand, cancellationToken);
        }

        #region OptionalMachineResource
        /// <summary>
        /// Gets an object representing an <see cref="OptionalMachineResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OptionalMachineResource.CreateResourceIdentifier" /> to create an <see cref="OptionalMachineResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="OptionalMachineResource" /> object. </returns>
        public static OptionalMachineResource GetOptionalMachineResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                OptionalMachineResource.ValidateResourceId(id);
                return new OptionalMachineResource(client, id);
            }
            );
        }
        #endregion
    }
}
