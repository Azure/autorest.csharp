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
using MgmtConstants.Mocking;
using MgmtConstants.Models;

namespace MgmtConstants
{
    /// <summary> A class to add extension methods to MgmtConstants. </summary>
    public static partial class MgmtConstantsExtensions
    {
        private static MgmtConstantsArmClientMockingExtension GetMgmtConstantsArmClientMockingExtension(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MgmtConstantsArmClientMockingExtension(client0));
        }

        private static MgmtConstantsResourceGroupMockingExtension GetMgmtConstantsResourceGroupMockingExtension(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MgmtConstantsResourceGroupMockingExtension(client, resource.Id));
        }

        private static MgmtConstantsSubscriptionMockingExtension GetMgmtConstantsSubscriptionMockingExtension(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MgmtConstantsSubscriptionMockingExtension(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing an <see cref="OptionalMachineResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OptionalMachineResource.CreateResourceIdentifier" /> to create an <see cref="OptionalMachineResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="OptionalMachineResource" /> object. </returns>
        public static OptionalMachineResource GetOptionalMachineResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtConstantsArmClientMockingExtension(client).GetOptionalMachineResource(id);
        }

        /// <summary>
        /// Gets a collection of OptionalMachineResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtConstantsResourceGroupMockingExtension.GetOptionalMachines()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of OptionalMachineResources and their operations over a OptionalMachineResource. </returns>
        public static OptionalMachineCollection GetOptionalMachines(this ResourceGroupResource resourceGroupResource)
        {
            return GetMgmtConstantsResourceGroupMockingExtension(resourceGroupResource).GetOptionalMachines();
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtConstantsResourceGroupMockingExtension.GetOptionalMachineAsync(string,OptionalMachineExpand?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<OptionalMachineResource>> GetOptionalMachineAsync(this ResourceGroupResource resourceGroupResource, string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return await GetMgmtConstantsResourceGroupMockingExtension(resourceGroupResource).GetOptionalMachineAsync(name, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtConstantsResourceGroupMockingExtension.GetOptionalMachine(string,OptionalMachineExpand?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<OptionalMachineResource> GetOptionalMachine(this ResourceGroupResource resourceGroupResource, string name, OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtConstantsResourceGroupMockingExtension(resourceGroupResource).GetOptionalMachine(name, expand, cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Constant/optionalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_ListAll</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtConstantsSubscriptionMockingExtension.GetOptionalMachines(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<OptionalMachineResource> GetOptionalMachinesAsync(this SubscriptionResource subscriptionResource, string statusOnly = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtConstantsSubscriptionMockingExtension(subscriptionResource).GetOptionalMachinesAsync(statusOnly, cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Constant/optionalMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_ListAll</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtConstantsSubscriptionMockingExtension.GetOptionalMachines(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OptionalMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<OptionalMachineResource> GetOptionalMachines(this SubscriptionResource subscriptionResource, string statusOnly = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtConstantsSubscriptionMockingExtension(subscriptionResource).GetOptionalMachines(statusOnly, cancellationToken);
        }
    }
}
