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
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((client) =>
            {
                return new ResourceGroupExtensionClient(client, resourceGroup.Id);
            }
            );
        }

        /// <summary> Gets a collection of AvailabilitySets in the AvailabilitySet. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of AvailabilitySets and their operations over a AvailabilitySet. </returns>
        public static AvailabilitySetCollection GetAvailabilitySets(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetAvailabilitySets();
        }

        /// <summary> Gets a collection of UnpatchableResources in the UnpatchableResource. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of UnpatchableResources and their operations over a UnpatchableResource. </returns>
        public static UnpatchableResourceCollection GetUnpatchableResources(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetUnpatchableResources();
        }

        /// <summary>
        /// Update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets
        /// Operation Id: AvailabilitySets_TestLROMethod
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static async Task<ArmOperation<TestAvailabilitySet>> TestLROMethodAvailabilitySetAsync(this ResourceGroup resourceGroup, WaitUntil waitUntil, AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            return await GetExtensionClient(resourceGroup).TestLROMethodAvailabilitySetAsync(waitUntil, parameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets
        /// Operation Id: AvailabilitySets_TestLROMethod
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static ArmOperation<TestAvailabilitySet> TestLROMethodAvailabilitySet(this ResourceGroup resourceGroup, WaitUntil waitUntil, AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            return GetExtensionClient(resourceGroup).TestLROMethodAvailabilitySet(waitUntil, parameters, cancellationToken);
        }
    }
}
