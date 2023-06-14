// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtResourceName
{
    /// <summary>
    /// A class representing a collection of <see cref="Memory" /> and their operations.
    /// Each <see cref="Memory" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="MemoryCollection" /> instance call the GetMemories method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class MemoryCollection : ArmCollection, IEnumerable<Memory>, IAsyncEnumerable<Memory>
    {
        private readonly ClientDiagnostics _memoryMemoryResourcesClientDiagnostics;
        private readonly MemoryResourcesRestOperations _memoryMemoryResourcesRestClient;

        /// <summary> Initializes a new instance of the <see cref="MemoryCollection"/> class for mocking. </summary>
        protected MemoryCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MemoryCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MemoryCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _memoryMemoryResourcesClientDiagnostics = new ClientDiagnostics("MgmtResourceName", Memory.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(Memory.ResourceType, out string memoryMemoryResourcesApiVersion);
            _memoryMemoryResourcesRestClient = new MemoryResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, memoryMemoryResourcesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/memoryResources/{memoryResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MemoryResources_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="data"> The Memory to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<Memory>> CreateOrUpdateAsync(WaitUntil waitUntil, string memoryResourceName, MemoryData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(memoryResourceName, nameof(memoryResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _memoryMemoryResourcesClientDiagnostics.CreateScope("MemoryCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _memoryMemoryResourcesRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, memoryResourceName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtResourceNameArmOperation<Memory>(Response.FromValue(new Memory(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/memoryResources/{memoryResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MemoryResources_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="data"> The Memory to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<Memory> CreateOrUpdate(WaitUntil waitUntil, string memoryResourceName, MemoryData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(memoryResourceName, nameof(memoryResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _memoryMemoryResourcesClientDiagnostics.CreateScope("MemoryCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _memoryMemoryResourcesRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, memoryResourceName, data, cancellationToken);
                var operation = new MgmtResourceNameArmOperation<Memory>(Response.FromValue(new Memory(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> is null. </exception>
        public virtual async Task<Response<Memory>> GetAsync(string memoryResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(memoryResourceName, nameof(memoryResourceName));

            using var scope = _memoryMemoryResourcesClientDiagnostics.CreateScope("MemoryCollection.Get");
            scope.Start();
            try
            {
                var response = await _memoryMemoryResourcesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, memoryResourceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Memory(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> is null. </exception>
        public virtual Response<Memory> Get(string memoryResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(memoryResourceName, nameof(memoryResourceName));

            using var scope = _memoryMemoryResourcesClientDiagnostics.CreateScope("MemoryCollection.Get");
            scope.Start();
            try
            {
                var response = _memoryMemoryResourcesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, memoryResourceName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Memory(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/memoryResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MemoryResources_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Memory" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Memory> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _memoryMemoryResourcesRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new Memory(Client, MemoryData.DeserializeMemoryData(e)), _memoryMemoryResourcesClientDiagnostics, Pipeline, "MemoryCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/memoryResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MemoryResources_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Memory" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Memory> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _memoryMemoryResourcesRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new Memory(Client, MemoryData.DeserializeMemoryData(e)), _memoryMemoryResourcesClientDiagnostics, Pipeline, "MemoryCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string memoryResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(memoryResourceName, nameof(memoryResourceName));

            using var scope = _memoryMemoryResourcesClientDiagnostics.CreateScope("MemoryCollection.Exists");
            scope.Start();
            try
            {
                var response = await _memoryMemoryResourcesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, memoryResourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <param name="memoryResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="memoryResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryResourceName"/> is null. </exception>
        public virtual Response<bool> Exists(string memoryResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(memoryResourceName, nameof(memoryResourceName));

            using var scope = _memoryMemoryResourcesClientDiagnostics.CreateScope("MemoryCollection.Exists");
            scope.Start();
            try
            {
                var response = _memoryMemoryResourcesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, memoryResourceName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Memory> IEnumerable<Memory>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Memory> IAsyncEnumerable<Memory>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
