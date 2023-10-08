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
using MgmtOperations.Mocking;
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> A class to add extension methods to MgmtOperations. </summary>
    public static partial class MgmtOperationsExtensions
    {
        private static MgmtOperationsArmClientMockingExtension GetMgmtOperationsArmClientMockingExtension(ArmClient client)
        {
            return client.GetCachedClient(client =>
            {
                return new MgmtOperationsArmClientMockingExtension(client);
            });
        }

        private static MgmtOperationsResourceGroupMockingExtension GetMgmtOperationsResourceGroupMockingExtension(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new MgmtOperationsResourceGroupMockingExtension(client, resource.Id);
            });
        }

        /// <summary>
        /// Gets an object representing an <see cref="AvailabilitySetResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AvailabilitySetResource.CreateResourceIdentifier" /> to create an <see cref="AvailabilitySetResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetResource" /> object. </returns>
        public static AvailabilitySetResource GetAvailabilitySetResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtOperationsArmClientMockingExtension(client).GetAvailabilitySetResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="AvailabilitySetChildResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AvailabilitySetChildResource.CreateResourceIdentifier" /> to create an <see cref="AvailabilitySetChildResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetChildResource" /> object. </returns>
        public static AvailabilitySetChildResource GetAvailabilitySetChildResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtOperationsArmClientMockingExtension(client).GetAvailabilitySetChildResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="AvailabilitySetGrandChildResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AvailabilitySetGrandChildResource.CreateResourceIdentifier" /> to create an <see cref="AvailabilitySetGrandChildResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetGrandChildResource" /> object. </returns>
        public static AvailabilitySetGrandChildResource GetAvailabilitySetGrandChildResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtOperationsArmClientMockingExtension(client).GetAvailabilitySetGrandChildResource(id);
        }

        /// <summary>
        /// Gets an object representing an <see cref="UnpatchableResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="UnpatchableResource.CreateResourceIdentifier" /> to create an <see cref="UnpatchableResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="UnpatchableResource" /> object. </returns>
        public static UnpatchableResource GetUnpatchableResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtOperationsArmClientMockingExtension(client).GetUnpatchableResource(id);
        }

        /// <summary> Gets a collection of AvailabilitySetResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of AvailabilitySetResources and their operations over a AvailabilitySetResource. </returns>
        public static AvailabilitySetCollection GetAvailabilitySets(this ResourceGroupResource resourceGroupResource)
        {
            return GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).GetAvailabilitySets();
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
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<AvailabilitySetResource>> GetAvailabilitySetAsync(this ResourceGroupResource resourceGroupResource, string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).GetAvailabilitySetAsync(availabilitySetName, expand, cancellationToken).ConfigureAwait(false);
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
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<AvailabilitySetResource> GetAvailabilitySet(this ResourceGroupResource resourceGroupResource, string availabilitySetName, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).GetAvailabilitySet(availabilitySetName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of UnpatchableResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of UnpatchableResources and their operations over a UnpatchableResource. </returns>
        public static UnpatchableResourceCollection GetUnpatchableResources(this ResourceGroupResource resourceGroupResource)
        {
            return GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).GetUnpatchableResources();
        }

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UnpatchableResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<UnpatchableResource>> GetUnpatchableResourceAsync(this ResourceGroupResource resourceGroupResource, string name, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).GetUnpatchableResourceAsync(name, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UnpatchableResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<UnpatchableResource> GetUnpatchableResource(this ResourceGroupResource resourceGroupResource, string name, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).GetUnpatchableResource(name, expand, cancellationToken);
        }

        /// <summary>
        /// Update an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_TestLROMethod</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtOperationsResourceGroupMockingExtension.TestLROMethodAvailabilitySet(WaitUntil,AvailabilitySetUpdate,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetUpdate"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetUpdate"/> is null. </exception>
        public static async Task<ArmOperation<TestAvailabilitySet>> TestLROMethodAvailabilitySetAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AvailabilitySetUpdate availabilitySetUpdate, CancellationToken cancellationToken = default)
        {
            return await GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).TestLROMethodAvailabilitySetAsync(waitUntil, availabilitySetUpdate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_TestLROMethod</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtOperationsResourceGroupMockingExtension.TestLROMethodAvailabilitySet(WaitUntil,AvailabilitySetUpdate,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetUpdate"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetUpdate"/> is null. </exception>
        public static ArmOperation<TestAvailabilitySet> TestLROMethodAvailabilitySet(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AvailabilitySetUpdate availabilitySetUpdate, CancellationToken cancellationToken = default)
        {
            return GetMgmtOperationsResourceGroupMockingExtension(resourceGroupResource).TestLROMethodAvailabilitySet(waitUntil, availabilitySetUpdate, cancellationToken);
        }
    }
}
