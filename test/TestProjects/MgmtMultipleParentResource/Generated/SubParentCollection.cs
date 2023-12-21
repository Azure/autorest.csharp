// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtMultipleParentResource
{
    /// <summary>
    /// A class representing a collection of <see cref="SubParentResource"/> and their operations.
    /// Each <see cref="SubParentResource"/> in the collection will belong to the same instance of <see cref="TheParentResource"/>.
    /// To get a <see cref="SubParentCollection"/> instance call the GetSubParents method from an instance of <see cref="TheParentResource"/>.
    /// </summary>
    public partial class SubParentCollection : ArmCollection, IEnumerable<SubParentResource>, IAsyncEnumerable<SubParentResource>
    {
        private readonly ClientDiagnostics _subParentClientDiagnostics;
        private readonly SubParentsRestOperations _subParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubParentCollection"/> class for mocking. </summary>
        protected SubParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SubParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subParentClientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", SubParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SubParentResource.ResourceType, out string subParentApiVersion);
            _subParentRestClient = new SubParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, subParentApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TheParentResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TheParentResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update the VMSS VM run command.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SubParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string instanceId, SubParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subParentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMultipleParentResourceArmOperation<SubParentResource>(new SubParentOperationSource(Client), _subParentClientDiagnostics, Pipeline, _subParentRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data).Request, response, OperationFinalStateVia.Location);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SubParentResource> CreateOrUpdate(WaitUntil waitUntil, string instanceId, SubParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subParentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data, cancellationToken);
                var operation = new MgmtMultipleParentResourceArmOperation<SubParentResource>(new SubParentOperationSource(Client), _subParentClientDiagnostics, Pipeline, _subParentRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data).Request, response, OperationFinalStateVia.Location);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual async Task<Response<SubParentResource>> GetAsync(string instanceId, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _subParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual Response<SubParentResource> Get(string instanceId, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Get");
            scope.Start();
            try
            {
                var response = _subParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_List</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubParentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubParentResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SubParentResource(Client, SubParentData.DeserializeSubParentData(e)), _subParentClientDiagnostics, Pipeline, "SubParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The operation to get all run commands of an instance in Virtual Machine Scaleset.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_List</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubParentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubParentResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _subParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _subParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SubParentResource(Client, SubParentData.DeserializeSubParentData(e)), _subParentClientDiagnostics, Pipeline, "SubParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string instanceId, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _subParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual Response<bool> Exists(string instanceId, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.Exists");
            scope.Start();
            try
            {
                var response = _subParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual async Task<NullableResponse<SubParentResource>> GetIfExistsAsync(string instanceId, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _subParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<SubParentResource>(response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SubParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/theParents/subParents</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual NullableResponse<SubParentResource> GetIfExists(string instanceId, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _subParentClientDiagnostics.CreateScope("SubParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _subParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<SubParentResource>(response.GetRawResponse());
                return Response.FromValue(new SubParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubParentResource> IEnumerable<SubParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubParentResource> IAsyncEnumerable<SubParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
