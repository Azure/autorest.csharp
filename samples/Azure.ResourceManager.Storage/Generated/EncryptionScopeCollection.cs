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

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="EncryptionScopeResource" /> and their operations.
    /// Each <see cref="EncryptionScopeResource" /> in the collection will belong to the same instance of <see cref="StorageAccountResource" />.
    /// To get an <see cref="EncryptionScopeCollection" /> instance call the GetEncryptionScopes method from an instance of <see cref="StorageAccountResource" />.
    /// </summary>
    public partial class EncryptionScopeCollection : ArmCollection, IEnumerable<EncryptionScopeResource>, IAsyncEnumerable<EncryptionScopeResource>
    {
        private readonly ClientDiagnostics _encryptionScopeClientDiagnostics;
        private readonly EncryptionScopesRestOperations _encryptionScopeRestClient;

        /// <summary> Initializes a new instance of the <see cref="EncryptionScopeCollection"/> class for mocking. </summary>
        protected EncryptionScopeCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="EncryptionScopeCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal EncryptionScopeCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _encryptionScopeClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", EncryptionScopeResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(EncryptionScopeResource.ResourceType, out string encryptionScopeApiVersion);
            _encryptionScopeRestClient = new EncryptionScopesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, encryptionScopeApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="data"> Encryption scope properties to be used for the create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<EncryptionScopeResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string encryptionScopeName, EncryptionScopeData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScopeCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _encryptionScopeRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, data, cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="data"> Encryption scope properties to be used for the create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<EncryptionScopeResource> CreateOrUpdate(WaitUntil waitUntil, string encryptionScopeName, EncryptionScopeData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScopeCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _encryptionScopeRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, data, cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual async Task<Response<EncryptionScopeResource>> GetAsync(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScopeCollection.Get");
            scope.Start();
            try
            {
                var response = await _encryptionScopeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual Response<EncryptionScopeResource> Get(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScopeCollection.Get");
            scope.Start();
            try
            {
                var response = _encryptionScopeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EncryptionScopeResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _encryptionScopeRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _encryptionScopeRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new EncryptionScopeResource(Client, EncryptionScopeData.DeserializeEncryptionScopeData(e)), _encryptionScopeClientDiagnostics, Pipeline, "EncryptionScopeCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all the encryption scopes available under the specified storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EncryptionScopeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EncryptionScopeResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _encryptionScopeRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _encryptionScopeRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new EncryptionScopeResource(Client, EncryptionScopeData.DeserializeEncryptionScopeData(e)), _encryptionScopeClientDiagnostics, Pipeline, "EncryptionScopeCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScopeCollection.Exists");
            scope.Start();
            try
            {
                var response = await _encryptionScopeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/encryptionScopes/{encryptionScopeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EncryptionScopes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="encryptionScopeName"> The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="encryptionScopeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="encryptionScopeName"/> is null. </exception>
        public virtual Response<bool> Exists(string encryptionScopeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(encryptionScopeName, nameof(encryptionScopeName));

            using var scope = _encryptionScopeClientDiagnostics.CreateScope("EncryptionScopeCollection.Exists");
            scope.Start();
            try
            {
                var response = _encryptionScopeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionScopeName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
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
