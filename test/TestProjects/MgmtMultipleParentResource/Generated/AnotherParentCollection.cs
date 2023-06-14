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
    /// A class representing a collection of <see cref="AnotherParentResource" /> and their operations.
    /// Each <see cref="AnotherParentResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="AnotherParentCollection" /> instance call the GetAnotherParents method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class AnotherParentCollection : ArmCollection, IEnumerable<AnotherParentResource>, IAsyncEnumerable<AnotherParentResource>
    {
        private readonly ClientDiagnostics _anotherParentClientDiagnostics;
        private readonly AnotherParentsRestOperations _anotherParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="AnotherParentCollection"/> class for mocking. </summary>
        protected AnotherParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AnotherParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AnotherParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _anotherParentClientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", AnotherParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AnotherParentResource.ResourceType, out string anotherParentApiVersion);
            _anotherParentRestClient = new AnotherParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, anotherParentApiVersion);
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
        /// The operation to create or update the run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="anotherName"> The name of the virtual machine where the run command should be created or updated. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AnotherParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string anotherName, AnotherParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _anotherParentClientDiagnostics.CreateScope("AnotherParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _anotherParentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, anotherName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMultipleParentResourceArmOperation<AnotherParentResource>(new AnotherParentOperationSource(Client), _anotherParentClientDiagnostics, Pipeline, _anotherParentRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, anotherName, data).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to create or update the run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="anotherName"> The name of the virtual machine where the run command should be created or updated. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AnotherParentResource> CreateOrUpdate(WaitUntil waitUntil, string anotherName, AnotherParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _anotherParentClientDiagnostics.CreateScope("AnotherParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _anotherParentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, anotherName, data, cancellationToken);
                var operation = new MgmtMultipleParentResourceArmOperation<AnotherParentResource>(new AnotherParentOperationSource(Client), _anotherParentClientDiagnostics, Pipeline, _anotherParentRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, anotherName, data).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to get the run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public virtual async Task<Response<AnotherParentResource>> GetAsync(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _anotherParentClientDiagnostics.CreateScope("AnotherParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _anotherParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AnotherParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get the run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public virtual Response<AnotherParentResource> Get(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _anotherParentClientDiagnostics.CreateScope("AnotherParentCollection.Get");
            scope.Start();
            try
            {
                var response = _anotherParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AnotherParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get all run commands of a Virtual Machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AnotherParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AnotherParentResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _anotherParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _anotherParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AnotherParentResource(Client, AnotherParentData.DeserializeAnotherParentData(e)), _anotherParentClientDiagnostics, Pipeline, "AnotherParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The operation to get all run commands of a Virtual Machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AnotherParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AnotherParentResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _anotherParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _anotherParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AnotherParentResource(Client, AnotherParentData.DeserializeAnotherParentData(e)), _anotherParentClientDiagnostics, Pipeline, "AnotherParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _anotherParentClientDiagnostics.CreateScope("AnotherParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _anotherParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AnotherParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="anotherName"> The name of the virtual machine containing the run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="anotherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="anotherName"/> is null. </exception>
        public virtual Response<bool> Exists(string anotherName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anotherName, nameof(anotherName));

            using var scope = _anotherParentClientDiagnostics.CreateScope("AnotherParentCollection.Exists");
            scope.Start();
            try
            {
                var response = _anotherParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, anotherName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AnotherParentResource> IEnumerable<AnotherParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AnotherParentResource> IAsyncEnumerable<AnotherParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
