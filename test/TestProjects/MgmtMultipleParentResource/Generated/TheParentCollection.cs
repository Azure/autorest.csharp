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

namespace MgmtMultipleParentResource
{
    /// <summary>
    /// A class representing a collection of <see cref="TheParentResource" /> and their operations.
    /// Each <see cref="TheParentResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="TheParentCollection" /> instance call the GetTheParents method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class TheParentCollection : ArmCollection, IEnumerable<TheParentResource>, IAsyncEnumerable<TheParentResource>
    {
        private readonly ClientDiagnostics _theParentClientDiagnostics;
        private readonly TheParentsRestOperations _theParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="TheParentCollection"/> class for mocking. </summary>
        protected TheParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TheParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TheParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _theParentClientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", TheParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TheParentResource.ResourceType, out string theParentApiVersion);
            _theParentRestClient = new TheParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, theParentApiVersion);
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
        /// The operation to create or update the VMSS VM run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="theParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TheParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string theParentName, TheParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(theParentName, nameof(theParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _theParentClientDiagnostics.CreateScope("TheParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _theParentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, theParentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMultipleParentResourceArmOperation<TheParentResource>(new TheParentOperationSource(Client), _theParentClientDiagnostics, Pipeline, _theParentRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, theParentName, data).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to create or update the VMSS VM run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="theParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TheParentResource> CreateOrUpdate(WaitUntil waitUntil, string theParentName, TheParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(theParentName, nameof(theParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _theParentClientDiagnostics.CreateScope("TheParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _theParentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, theParentName, data, cancellationToken);
                var operation = new MgmtMultipleParentResourceArmOperation<TheParentResource>(new TheParentOperationSource(Client), _theParentClientDiagnostics, Pipeline, _theParentRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, theParentName, data).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to get the VMSS VM run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="theParentName"/> is null. </exception>
        public virtual async Task<Response<TheParentResource>> GetAsync(string theParentName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(theParentName, nameof(theParentName));

            using var scope = _theParentClientDiagnostics.CreateScope("TheParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _theParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, theParentName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get the VMSS VM run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="theParentName"/> is null. </exception>
        public virtual Response<TheParentResource> Get(string theParentName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(theParentName, nameof(theParentName));

            using var scope = _theParentClientDiagnostics.CreateScope("TheParentCollection.Get");
            scope.Start();
            try
            {
                var response = _theParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, theParentName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get all run commands of an instance in Virtual Machine Scaleset.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TheParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TheParentResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _theParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _theParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new TheParentResource(Client, TheParentData.DeserializeTheParentData(e)), _theParentClientDiagnostics, Pipeline, "TheParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The operation to get all run commands of an instance in Virtual Machine Scaleset.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TheParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TheParentResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _theParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _theParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new TheParentResource(Client, TheParentData.DeserializeTheParentData(e)), _theParentClientDiagnostics, Pipeline, "TheParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="theParentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string theParentName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(theParentName, nameof(theParentName));

            using var scope = _theParentClientDiagnostics.CreateScope("TheParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _theParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, theParentName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TheParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="theParentName"> The name of the VM scale set. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="theParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="theParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string theParentName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(theParentName, nameof(theParentName));

            using var scope = _theParentClientDiagnostics.CreateScope("TheParentCollection.Exists");
            scope.Start();
            try
            {
                var response = _theParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, theParentName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TheParentResource> IEnumerable<TheParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TheParentResource> IAsyncEnumerable<TheParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
