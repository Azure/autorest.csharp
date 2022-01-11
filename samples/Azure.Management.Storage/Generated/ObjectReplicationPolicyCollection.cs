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
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of ObjectReplicationPolicy and their operations over its parent. </summary>
    public partial class ObjectReplicationPolicyCollection : ArmCollection, IEnumerable<ObjectReplicationPolicy>, IAsyncEnumerable<ObjectReplicationPolicy>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ObjectReplicationPoliciesRestOperations _objectReplicationPoliciesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ObjectReplicationPolicyCollection"/> class for mocking. </summary>
        protected ObjectReplicationPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of ObjectReplicationPolicyCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ObjectReplicationPolicyCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _objectReplicationPoliciesRestClient = new ObjectReplicationPoliciesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != StorageAccount.ResourceType)
                throw new ArgumentException(nameof(id), string.Format("Invalid resource type {0} expected {1}", id.ResourceType, StorageAccount.ResourceType));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// OperationId: ObjectReplicationPolicies_CreateOrUpdate
        /// <summary> Create or update the object replication policy of the storage account. </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
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

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _objectReplicationPoliciesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// OperationId: ObjectReplicationPolicies_CreateOrUpdate
        /// <summary> Create or update the object replication policy of the storage account. </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
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

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _objectReplicationPoliciesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken).ConfigureAwait(false);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// OperationId: ObjectReplicationPolicies_Get
        /// <summary> Get the object replication policy of the storage account by policy ID. </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public virtual Response<ObjectReplicationPolicy> Get(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _objectReplicationPoliciesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ObjectReplicationPolicy(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// OperationId: ObjectReplicationPolicies_Get
        /// <summary> Get the object replication policy of the storage account by policy ID. </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public async virtual Task<Response<ObjectReplicationPolicy>> GetAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _objectReplicationPoliciesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ObjectReplicationPolicy(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public virtual Response<ObjectReplicationPolicy> GetIfExists(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _objectReplicationPoliciesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ObjectReplicationPolicy>(null, response.GetRawResponse())
                    : Response.FromValue(new ObjectReplicationPolicy(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public async virtual Task<Response<ObjectReplicationPolicy>> GetIfExistsAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _objectReplicationPoliciesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ObjectReplicationPolicy>(null, response.GetRawResponse())
                    : Response.FromValue(new ObjectReplicationPolicy(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public virtual Response<bool> Exists(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.Exists");
            scope.Start();
            try
            {
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
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value &apos;default&apos;. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            if (objectReplicationPolicyId == null)
            {
                throw new ArgumentNullException(nameof(objectReplicationPolicyId));
            }

            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(objectReplicationPolicyId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// OperationId: ObjectReplicationPolicies_List
        /// <summary> List the object replication policies associated with the storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ObjectReplicationPolicy> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ObjectReplicationPolicy> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _objectReplicationPoliciesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ObjectReplicationPolicy(Parent, value.Id, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}
        /// OperationId: ObjectReplicationPolicies_List
        /// <summary> List the object replication policies associated with the storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ObjectReplicationPolicy> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ObjectReplicationPolicy>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _objectReplicationPoliciesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ObjectReplicationPolicy(Parent, value.Id, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<ObjectReplicationPolicy> IEnumerable<ObjectReplicationPolicy>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ObjectReplicationPolicy> IAsyncEnumerable<ObjectReplicationPolicy>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, ObjectReplicationPolicy, ObjectReplicationPolicyData> Construct() { }
    }
}
