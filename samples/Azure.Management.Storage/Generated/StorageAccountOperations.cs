// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A class representing the operations that can be performed over a specific StorageAccount. </summary>
    public partial class StorageAccountOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, StorageAccount>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private StorageAccountsRestOperations _restClient { get; }
        private PrivateLinkResourcesRestOperations _privateLinkResourcesRestClient { get; }

        /// <summary> Initializes a new instance of the <see cref="StorageAccountOperations"/> class for mocking. </summary>
        protected StorageAccountOperations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="StorageAccountOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal StorageAccountOperations(OperationsBase options, ResourceGroupResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new StorageAccountsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
            _privateLinkResourcesRestClient = new PrivateLinkResourcesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts";
        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public async override Task<Response<StorageAccount>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.GetProperties");
            scope.Start();
            try
            {
                var response = await _restClient.GetPropertiesAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StorageAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override Response<StorageAccount> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.GetProperties");
            scope.Start();
            try
            {
                var response = _restClient.GetProperties(Id.ResourceGroupName, Id.Name, null, cancellationToken);
                return Response.FromValue(new StorageAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys. </summary>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<StorageAccount>> GetAsync(StorageAccountExpand? expand, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.GetProperties");
            scope.Start();
            try
            {
                var response = await _restClient.GetPropertiesAsync(Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StorageAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys. </summary>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<StorageAccount> Get(StorageAccountExpand? expand, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.GetProperties");
            scope.Start();
            try
            {
                var response = _restClient.GetProperties(Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                return Response.FromValue(new StorageAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a storage account in Microsoft Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.Delete");
            scope.Start();
            try
            {
                var operation = await StartDeleteAsync(cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a storage account in Microsoft Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.Delete");
            scope.Start();
            try
            {
                var operation = StartDelete(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a storage account in Microsoft Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<StorageAccountsDeleteOperation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.StartDelete");
            scope.Start();
            try
            {
                var response = await _restClient.DeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return new StorageAccountsDeleteOperation(response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a storage account in Microsoft Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public StorageAccountsDeleteOperation StartDelete(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.StartDelete");
            scope.Start();
            try
            {
                var response = _restClient.Delete(Id.ResourceGroupName, Id.Name, cancellationToken);
                return new StorageAccountsDeleteOperation(response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public async Task<Response<StorageAccount>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetPropertiesAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StorageAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public Response<StorageAccount> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResourceOperations.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagContainer.CreateOrUpdate(originalTags.Value.Data, cancellationToken);
                var originalResponse = _restClient.GetProperties(Id.ResourceGroupName, Id.Name, null, cancellationToken);
                return Response.FromValue(new StorageAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public async Task<Response<StorageAccount>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException($"{nameof(tags)} provided cannot be null.", nameof(tags));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.SetTags");
            scope.Start();
            try
            {
                await TagResourceOperations.DeleteAsync(cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetPropertiesAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StorageAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public Response<StorageAccount> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException($"{nameof(tags)} provided cannot be null.", nameof(tags));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.SetTags");
            scope.Start();
            try
            {
                TagResourceOperations.Delete(cancellationToken);
                var originalTags = TagResourceOperations.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagContainer.CreateOrUpdate(originalTags.Value.Data, cancellationToken);
                var originalResponse = _restClient.GetProperties(Id.ResourceGroupName, Id.Name, null, cancellationToken);
                return Response.FromValue(new StorageAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public async Task<Response<StorageAccount>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagContainer.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetPropertiesAsync(Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new StorageAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public Response<StorageAccount> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResourceOperations.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagContainer.CreateOrUpdate(originalTags.Value.Data, cancellationToken);
                var originalResponse = _restClient.GetProperties(Id.ResourceGroupName, Id.Name, null, cancellationToken);
                return Response.FromValue(new StorageAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Checks that the storage account name is valid and is not already in use. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public virtual async Task<Response<Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(StorageAccountCheckNameAvailabilityParameters accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.CheckNameAvailability");
            scope.Start();
            try
            {
                var response = await _restClient.CheckNameAvailabilityAsync(accountName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks that the storage account name is valid and is not already in use. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public virtual Response<Models.CheckNameAvailabilityResult> CheckNameAvailability(StorageAccountCheckNameAvailabilityParameters accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.CheckNameAvailability");
            scope.Start();
            try
            {
                var response = _restClient.CheckNameAvailability(accountName, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Regenerates one of the access keys or Kerberos keys for the specified storage account. </summary>
        /// <param name="regenerateKey"> Specifies name of the key which should be regenerated -- key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="regenerateKey"/> is null. </exception>
        public virtual async Task<Response<StorageAccountListKeysResult>> RegenerateKeyAsync(StorageAccountRegenerateKeyParameters regenerateKey, CancellationToken cancellationToken = default)
        {
            if (regenerateKey == null)
            {
                throw new ArgumentNullException(nameof(regenerateKey));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RegenerateKey");
            scope.Start();
            try
            {
                var response = await _restClient.RegenerateKeyAsync(Id.ResourceGroupName, Id.Name, regenerateKey, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Regenerates one of the access keys or Kerberos keys for the specified storage account. </summary>
        /// <param name="regenerateKey"> Specifies name of the key which should be regenerated -- key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="regenerateKey"/> is null. </exception>
        public virtual Response<StorageAccountListKeysResult> RegenerateKey(StorageAccountRegenerateKeyParameters regenerateKey, CancellationToken cancellationToken = default)
        {
            if (regenerateKey == null)
            {
                throw new ArgumentNullException(nameof(regenerateKey));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RegenerateKey");
            scope.Start();
            try
            {
                var response = _restClient.RegenerateKey(Id.ResourceGroupName, Id.Name, regenerateKey, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Revoke user delegation keys. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RevokeUserDelegationKeysAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RevokeUserDelegationKeys");
            scope.Start();
            try
            {
                var response = await _restClient.RevokeUserDelegationKeysAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Revoke user delegation keys. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RevokeUserDelegationKeys(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RevokeUserDelegationKeys");
            scope.Start();
            try
            {
                var response = _restClient.RevokeUserDelegationKeys(Id.ResourceGroupName, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the private link resources that need to be created for a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<PrivateLinkResource>>> ListPrivateLinkResourcesByStorageAccountAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.ListPrivateLinkResourcesByStorageAccount");
            scope.Start();
            try
            {
                var response = await _privateLinkResourcesRestClient.ListByStorageAccountAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the private link resources that need to be created for a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<PrivateLinkResource>> ListPrivateLinkResourcesByStorageAccount(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.ListPrivateLinkResourcesByStorageAccount");
            scope.Start();
            try
            {
                var response = _privateLinkResourcesRestClient.ListByStorageAccount(Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account&apos;s primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> FailoverAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.Failover");
            scope.Start();
            try
            {
                var operation = await StartFailoverAsync(cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account&apos;s primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Failover(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.Failover");
            scope.Start();
            try
            {
                var operation = StartFailover(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account&apos;s primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<StorageAccountsFailoverOperation> StartFailoverAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.StartFailover");
            scope.Start();
            try
            {
                var response = await _restClient.FailoverAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return new StorageAccountsFailoverOperation(_clientDiagnostics, Pipeline, _restClient.CreateFailoverRequest(Id.ResourceGroupName, Id.Name).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account&apos;s primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public StorageAccountsFailoverOperation StartFailover(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.StartFailover");
            scope.Start();
            try
            {
                var response = _restClient.Failover(Id.ResourceGroupName, Id.Name, cancellationToken);
                return new StorageAccountsFailoverOperation(_clientDiagnostics, Pipeline, _restClient.CreateFailoverRequest(Id.ResourceGroupName, Id.Name).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Restore blobs in the specified blob ranges. </summary>
        /// <param name="parameters"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async Task<Response<BlobRestoreStatus>> RestoreBlobRangesAsync(BlobRestoreParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RestoreBlobRanges");
            scope.Start();
            try
            {
                var operation = await StartRestoreBlobRangesAsync(parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Restore blobs in the specified blob ranges. </summary>
        /// <param name="parameters"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public Response<BlobRestoreStatus> RestoreBlobRanges(BlobRestoreParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.RestoreBlobRanges");
            scope.Start();
            try
            {
                var operation = StartRestoreBlobRanges(parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Restore blobs in the specified blob ranges. </summary>
        /// <param name="parameters"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async Task<StorageAccountsRestoreBlobRangesOperation> StartRestoreBlobRangesAsync(BlobRestoreParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.StartRestoreBlobRanges");
            scope.Start();
            try
            {
                var response = await _restClient.RestoreBlobRangesAsync(Id.ResourceGroupName, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return new StorageAccountsRestoreBlobRangesOperation(_clientDiagnostics, Pipeline, _restClient.CreateRestoreBlobRangesRequest(Id.ResourceGroupName, Id.Name, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Restore blobs in the specified blob ranges. </summary>
        /// <param name="parameters"> The parameters to provide for restore blob ranges. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public StorageAccountsRestoreBlobRangesOperation StartRestoreBlobRanges(BlobRestoreParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountOperations.StartRestoreBlobRanges");
            scope.Start();
            try
            {
                var response = _restClient.RestoreBlobRanges(Id.ResourceGroupName, Id.Name, parameters, cancellationToken);
                return new StorageAccountsRestoreBlobRangesOperation(_clientDiagnostics, Pipeline, _restClient.CreateRestoreBlobRangesRequest(Id.ResourceGroupName, Id.Name, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of BlobServices in the StorageAccount. </summary>
        /// <returns> An object representing collection of BlobServices and their operations over a StorageAccount. </returns>
        public BlobServiceContainer GetBlobServices()
        {
            return new BlobServiceContainer(this);
        }

        /// <summary> Gets a list of BlobContainers in the StorageAccount. </summary>
        /// <returns> An object representing collection of BlobContainers and their operations over a StorageAccount. </returns>
        public BlobContainerContainer GetBlobContainers()
        {
            return new BlobContainerContainer(this);
        }

        /// <summary> Gets a list of FileServices in the StorageAccount. </summary>
        /// <returns> An object representing collection of FileServices and their operations over a StorageAccount. </returns>
        public FileServiceContainer GetFileServices()
        {
            return new FileServiceContainer(this);
        }

        /// <summary> Gets a list of FileShares in the StorageAccount. </summary>
        /// <returns> An object representing collection of FileShares and their operations over a StorageAccount. </returns>
        public FileShareContainer GetFileShares()
        {
            return new FileShareContainer(this);
        }

        /// <summary> Gets a list of ManagementPolicies in the StorageAccount. </summary>
        /// <returns> An object representing collection of ManagementPolicies and their operations over a StorageAccount. </returns>
        public ManagementPolicyContainer GetManagementPolicies()
        {
            return new ManagementPolicyContainer(this);
        }

        /// <summary> Gets a list of PrivateEndpointConnections in the StorageAccount. </summary>
        /// <returns> An object representing collection of PrivateEndpointConnections and their operations over a StorageAccount. </returns>
        public PrivateEndpointConnectionContainer GetPrivateEndpointConnections()
        {
            return new PrivateEndpointConnectionContainer(this);
        }

        /// <summary> Gets a list of ObjectReplicationPolicies in the StorageAccount. </summary>
        /// <returns> An object representing collection of ObjectReplicationPolicies and their operations over a StorageAccount. </returns>
        public ObjectReplicationPolicyContainer GetObjectReplicationPolicies()
        {
            return new ObjectReplicationPolicyContainer(this);
        }

        /// <summary> Gets a list of EncryptionScopes in the StorageAccount. </summary>
        /// <returns> An object representing collection of EncryptionScopes and their operations over a StorageAccount. </returns>
        public EncryptionScopeContainer GetEncryptionScopes()
        {
            return new EncryptionScopeContainer(this);
        }
    }
}
