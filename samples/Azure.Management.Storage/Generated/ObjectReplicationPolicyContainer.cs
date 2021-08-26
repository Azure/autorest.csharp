// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Management.Storage.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of ObjectReplicationPolicy and their operations over a StorageAccount. </summary>
    public partial class ObjectReplicationPolicyContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ObjectReplicationPoliciesRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="ObjectReplicationPolicyContainer"/> class for mocking. </summary>
        protected ObjectReplicationPolicyContainer()
        {
        }

        /// <summary> Initializes a new instance of ObjectReplicationPolicyContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ObjectReplicationPolicyContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ObjectReplicationPoliciesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => StorageAccount.ResourceType;

        // Container level operations.

        /// <summary> Create or update the object replication policy of the storage account. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> or <paramref name="properties"/> is null. </exception>
        public virtual ObjectReplicationPolicyCreateOrUpdateOperation CreateOrUpdate(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken);
                var operation = new ObjectReplicationPolicyCreateOrUpdateOperation(Parent, response);
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

        /// <summary> Create or update the object replication policy of the storage account. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> or <paramref name="properties"/> is null. </exception>
        public async virtual Task<ObjectReplicationPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken).ConfigureAwait(false);
                var operation = new ObjectReplicationPolicyCreateOrUpdateOperation(Parent, response);
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

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ObjectReplicationPolicy> Get(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.Get");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ObjectReplicationPolicy(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ObjectReplicationPolicy>> GetAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.Get");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ObjectReplicationPolicy(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ObjectReplicationPolicy> GetIfExists(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.GetIfExists");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ObjectReplicationPolicy>(null, response.GetRawResponse())
                    : Response.FromValue(new ObjectReplicationPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ObjectReplicationPolicy>> GetIfExistsAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.GetIfExists");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ObjectReplicationPolicy>(null, response.GetRawResponse())
                    : Response.FromValue(new ObjectReplicationPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = GetIfExists(objectReplicationPolicyId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = await GetIfExistsAsync(objectReplicationPolicyId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List the object replication policies associated with the storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ObjectReplicationPolicy> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ObjectReplicationPolicy> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ObjectReplicationPolicy(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> List the object replication policies associated with the storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ObjectReplicationPolicy> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ObjectReplicationPolicy>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ObjectReplicationPolicy(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="ObjectReplicationPolicy" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ObjectReplicationPolicy.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ObjectReplicationPolicy" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ObjectReplicationPolicy.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, ObjectReplicationPolicy, ObjectReplicationPolicyData> Construct() { }
    }
}
