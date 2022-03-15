// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of EncryptionScope and their operations over its parent. </summary>
    public partial class EncryptionScopeCollection : ArmCollection, IEnumerable<EncryptionScopeResource>, IAsyncEnumerable<EncryptionScopeResource>
    {
        private readonly ClientDiagnostics _encryptionScopeResourceEncryptionScopesClientDiagnostics;
        private readonly EncryptionScopesRestOperations _encryptionScopeResourceEncryptionScopesRestClient;

        /// <summary> Initializes a new instance of the <see cref="EncryptionScopeCollection"/> class for mocking. </summary>
        protected EncryptionScopeCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="EncryptionScopeCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal EncryptionScopeCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _encryptionScopeResourceEncryptionScopesClientDiagnostics = new ClientDiagnostics("Azure.Management.Storage", EncryptionScopeResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(EncryptionScopeResource.ResourceType, out string encryptionScopeResourceEncryptionScopesApiVersion);
            _encryptionScopeResourceEncryptionScopesRestClient = new EncryptionScopesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, encryptionScopeResourceEncryptionScopesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != StorageAccountResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, StorageAccountResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Synchronously creates or updates an encryption scope under the specified storage account. If an encryption scope is already created and a subsequent request is issued with different properties, the encryption scope properties will be updated per the specified request.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="encryptionScope"> Encryption scope properties to be used for the create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> or <paramref name="encryptionScope"/> is null. </exception>
        public virtual async Task<ArmOperation<EncryptionScopeResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string encryptionScopeName, EncryptionScopeResourceData encryptionScope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));
            Argument.AssertNotNull(encryptionScope, nameof(encryptionScope));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _encryptionScopeResourceEncryptionScopesRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, encryptionScope, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<EncryptionScopeResource>(Response.FromValue(new EncryptionScopeResource(Client, response), response.GetRawResponse()));
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
        /// Synchronously creates or updates an encryption scope under the specified storage account. If an encryption scope is already created and a subsequent request is issued with different properties, the encryption scope properties will be updated per the specified request.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="encryptionScope"> Encryption scope properties to be used for the create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> or <paramref name="encryptionScope"/> is null. </exception>
        public virtual ArmOperation<EncryptionScopeResource> CreateOrUpdate(WaitUntil waitUntil, string encryptionScopeName, EncryptionScopeResourceData encryptionScope, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));
            Argument.AssertNotNull(encryptionScope, nameof(encryptionScope));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _encryptionScopeResourceEncryptionScopesRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, encryptionScope, cancellationToken);
                var operation = new StorageArmOperation<EncryptionScopeResource>(Response.FromValue(new EncryptionScopeResource(Client, response), response.GetRawResponse()));
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
        /// Returns the properties for the specified encryption scope.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual async Task<Response<EncryptionScopeResource>> GetAsync(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.Get");
            scope.Start();
            try
            {
                var response = await _encryptionScopeResourceEncryptionScopesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EncryptionScopeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the properties for the specified encryption scope.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual Response<EncryptionScopeResource> Get(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.Get");
            scope.Start();
            try
            {
                var response = _encryptionScopeResourceEncryptionScopesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new EncryptionScopeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes
        /// Operation Id: EncryptionScopes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EncryptionScopeResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<EncryptionScopeResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _encryptionScopeResourceEncryptionScopesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new EncryptionScopeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<EncryptionScopeResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _encryptionScopeResourceEncryptionScopesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new EncryptionScopeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes
        /// Operation Id: EncryptionScopes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EncryptionScopeResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<EncryptionScopeResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _encryptionScopeResourceEncryptionScopesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new EncryptionScopeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<EncryptionScopeResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _encryptionScopeResourceEncryptionScopesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new EncryptionScopeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(encryptionScopeName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual Response<bool> Exists(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(encryptionScopeName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual async Task<Response<EncryptionScopeResource>> GetIfExistsAsync(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _encryptionScopeResourceEncryptionScopesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<EncryptionScopeResource>(null, response.GetRawResponse());
                return Response.FromValue(new EncryptionScopeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}
        /// Operation Id: EncryptionScopes_Get
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual Response<EncryptionScopeResource> GetIfExists(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeResourceEncryptionScopesClientDiagnostics.CreateScope("EncryptionScopeCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _encryptionScopeResourceEncryptionScopesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<EncryptionScopeResource>(null, response.GetRawResponse());
                return Response.FromValue(new EncryptionScopeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<EncryptionScopeResource> IEnumerable<EncryptionScopeResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<EncryptionScopeResource> IAsyncEnumerable<EncryptionScopeResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
