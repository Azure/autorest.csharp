// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of ResGrpParent and their operations over its parent. </summary>
    public partial class ResGrpParentCollection : ArmCollection, IEnumerable<ResGrpParent>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResGrpParentsRestOperations _resGrpParentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentCollection"/> class for mocking. </summary>
        protected ResGrpParentCollection()
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResGrpParentCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resGrpParentsRestClient = new ResGrpParentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResGrpParentCreateOrUpdateOperation CreateOrUpdate(string resGrpParentName, ResGrpParentData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, parameters, cancellationToken);
                var operation = new ResGrpParentCreateOrUpdateOperation(Parent, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResGrpParentCreateOrUpdateOperation> CreateOrUpdateAsync(string resGrpParentName, ResGrpParentData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResGrpParentCreateOrUpdateOperation(Parent, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual Response<ResGrpParent> Get(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParent>> GetAsync(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual Response<ResGrpParent> GetIfExists(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ResGrpParent>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParent>> GetIfExistsAsync(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _resGrpParentsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ResGrpParent>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resGrpParentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParents_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<ResGrpParent>> GetAll(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.GetAll");
            scope.Start();
            try
            {
                var response = _resGrpParentsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(value => new ResGrpParent(Parent, value)).ToArray() as IReadOnlyList<ResGrpParent>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParents_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<IReadOnlyList<ResGrpParent>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.GetAll");
            scope.Start();
            try
            {
                var response = await _resGrpParentsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(value => new ResGrpParent(Parent, value)).ToArray() as IReadOnlyList<ResGrpParent>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResGrpParent" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParent.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResGrpParent" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParent.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParent> IEnumerable<ResGrpParent>.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, ResGrpParent, ResGrpParentData> Construct() { }
    }
}
