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

namespace MgmtOperations
{
    /// <summary>
    /// A class representing a collection of <see cref="UnpatchableResource" /> and their operations.
    /// Each <see cref="UnpatchableResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="UnpatchableResourceCollection" /> instance call the GetUnpatchableResources method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class UnpatchableResourceCollection : ArmCollection, IEnumerable<UnpatchableResource>, IAsyncEnumerable<UnpatchableResource>
    {
        private readonly ClientDiagnostics _unpatchableResourceClientDiagnostics;
        private readonly UnpatchableResourcesRestOperations _unpatchableResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="UnpatchableResourceCollection"/> class for mocking. </summary>
        protected UnpatchableResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="UnpatchableResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal UnpatchableResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _unpatchableResourceClientDiagnostics = new ClientDiagnostics("MgmtOperations", UnpatchableResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(UnpatchableResource.ResourceType, out string unpatchableResourceApiVersion);
            _unpatchableResourceRestClient = new UnpatchableResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, unpatchableResourceApiVersion);
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
        /// Create or update an UnpatchableResource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UnpatchableResources_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="data"> Parameters supplied to the Create UnpatchableResource operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<UnpatchableResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, UnpatchableResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _unpatchableResourceRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation<UnpatchableResource>(Response.FromValue(new UnpatchableResource(Client, response), response.GetRawResponse()));
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
        /// Create or update an UnpatchableResource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UnpatchableResources_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="data"> Parameters supplied to the Create UnpatchableResource operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<UnpatchableResource> CreateOrUpdate(WaitUntil waitUntil, string name, UnpatchableResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _unpatchableResourceRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var operation = new MgmtOperationsArmOperation<UnpatchableResource>(Response.FromValue(new UnpatchableResource(Client, response), response.GetRawResponse()));
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
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<UnpatchableResource>> GetAsync(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _unpatchableResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new UnpatchableResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<UnpatchableResource> Get(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _unpatchableResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new UnpatchableResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UnpatchableResources_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="UnpatchableResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<UnpatchableResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _unpatchableResourceRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new UnpatchableResource(Client, UnpatchableResourceData.DeserializeUnpatchableResourceData(e)), _unpatchableResourceClientDiagnostics, Pipeline, "UnpatchableResourceCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UnpatchableResources_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="UnpatchableResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<UnpatchableResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _unpatchableResourceRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new UnpatchableResource(Client, UnpatchableResourceData.DeserializeUnpatchableResourceData(e)), _unpatchableResourceClientDiagnostics, Pipeline, "UnpatchableResourceCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
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
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await _unpatchableResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UnpatchableResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = _unpatchableResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<UnpatchableResource> IEnumerable<UnpatchableResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<UnpatchableResource> IAsyncEnumerable<UnpatchableResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
