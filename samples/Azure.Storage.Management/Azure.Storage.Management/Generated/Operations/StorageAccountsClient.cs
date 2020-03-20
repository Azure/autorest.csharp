// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Management.Models;

namespace Azure.Storage.Management
{
    public partial class StorageAccountsClient
    {
        private readonly ClientDiagnostics clientDiagnostics;
        private readonly HttpPipeline pipeline;
        internal StorageAccountsRestClient RestClient { get; }
        /// <summary> Initializes a new instance of StorageAccountsClient for mocking. </summary>
        protected StorageAccountsClient()
        {
        }
        /// <summary> Initializes a new instance of StorageAccountsClient. </summary>
        internal StorageAccountsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string host = "https://management.azure.com", string apiVersion = "2019-06-01")
        {
            RestClient = new StorageAccountsRestClient(clientDiagnostics, pipeline, subscriptionId, host, apiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        /// <summary> Checks that the storage account name is valid and is not already in use. </summary>
        /// <param name="name"> The storage account name. </param>
        /// <param name="type"> The type of resource, Microsoft.Storage/storageAccounts. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(string name, string type = "Microsoft.Storage/storageAccounts", CancellationToken cancellationToken = default)
        {
            return await RestClient.CheckNameAvailabilityAsync(name, type, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks that the storage account name is valid and is not already in use. </summary>
        /// <param name="name"> The storage account name. </param>
        /// <param name="type"> The type of resource, Microsoft.Storage/storageAccounts. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CheckNameAvailabilityResult> CheckNameAvailability(string name, string type = "Microsoft.Storage/storageAccounts", CancellationToken cancellationToken = default)
        {
            return RestClient.CheckNameAvailability(name, type, cancellationToken);
        }

        /// <summary> Deletes a storage account in Microsoft Azure. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return await RestClient.DeleteAsync(resourceGroupName, accountName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes a storage account in Microsoft Azure. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return RestClient.Delete(resourceGroupName, accountName, cancellationToken);
        }

        /// <summary> Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageAccount>> GetPropertiesAsync(string resourceGroupName, string accountName, StorageAccountExpand? expand, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetPropertiesAsync(resourceGroupName, accountName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status. The ListKeys operation should be used to retrieve storage keys. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageAccount> GetProperties(string resourceGroupName, string accountName, StorageAccountExpand? expand, CancellationToken cancellationToken = default)
        {
            return RestClient.GetProperties(resourceGroupName, accountName, expand, cancellationToken);
        }

        /// <summary> The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account. It can also be used to map the account to a custom domain. Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported. In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set. The update of multiple properties is supported. This call does not change the storage keys for the account. If you want to change the storage account keys, use the regenerate keys operation. The location and name of the storage account cannot be changed after creation. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the updated account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageAccount>> UpdateAsync(string resourceGroupName, string accountName, StorageAccountUpdateParameters parameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.UpdateAsync(resourceGroupName, accountName, parameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account. It can also be used to map the account to a custom domain. Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported. In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set. The update of multiple properties is supported. This call does not change the storage keys for the account. If you want to change the storage account keys, use the regenerate keys operation. The location and name of the storage account cannot be changed after creation. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the updated account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageAccount> Update(string resourceGroupName, string accountName, StorageAccountUpdateParameters parameters, CancellationToken cancellationToken = default)
        {
            return RestClient.Update(resourceGroupName, accountName, parameters, cancellationToken);
        }

        /// <summary> Lists the access keys or Kerberos keys (if active directory enabled) for the specified storage account. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageAccountListKeysResult>> ListKeysAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return await RestClient.ListKeysAsync(resourceGroupName, accountName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists the access keys or Kerberos keys (if active directory enabled) for the specified storage account. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageAccountListKeysResult> ListKeys(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return RestClient.ListKeys(resourceGroupName, accountName, cancellationToken);
        }

        /// <summary> Regenerates one of the access keys or Kerberos keys for the specified storage account. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="keyName"> The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageAccountListKeysResult>> RegenerateKeyAsync(string resourceGroupName, string accountName, string keyName, CancellationToken cancellationToken = default)
        {
            return await RestClient.RegenerateKeyAsync(resourceGroupName, accountName, keyName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Regenerates one of the access keys or Kerberos keys for the specified storage account. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="keyName"> The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageAccountListKeysResult> RegenerateKey(string resourceGroupName, string accountName, string keyName, CancellationToken cancellationToken = default)
        {
            return RestClient.RegenerateKey(resourceGroupName, accountName, keyName, cancellationToken);
        }

        /// <summary> List SAS credentials of a storage account. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide to list SAS credentials for the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListAccountSasResponse>> ListAccountSASAsync(string resourceGroupName, string accountName, AccountSasParameters parameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.ListAccountSASAsync(resourceGroupName, accountName, parameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> List SAS credentials of a storage account. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide to list SAS credentials for the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListAccountSasResponse> ListAccountSAS(string resourceGroupName, string accountName, AccountSasParameters parameters, CancellationToken cancellationToken = default)
        {
            return RestClient.ListAccountSAS(resourceGroupName, accountName, parameters, cancellationToken);
        }

        /// <summary> List service SAS credentials of a specific resource. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide to list service SAS credentials. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListServiceSasResponse>> ListServiceSASAsync(string resourceGroupName, string accountName, ServiceSasParameters parameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.ListServiceSASAsync(resourceGroupName, accountName, parameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> List service SAS credentials of a specific resource. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide to list service SAS credentials. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListServiceSasResponse> ListServiceSAS(string resourceGroupName, string accountName, ServiceSasParameters parameters, CancellationToken cancellationToken = default)
        {
            return RestClient.ListServiceSAS(resourceGroupName, accountName, parameters, cancellationToken);
        }

        /// <summary> Revoke user delegation keys. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RevokeUserDelegationKeysAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return await RestClient.RevokeUserDelegationKeysAsync(resourceGroupName, accountName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Revoke user delegation keys. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RevokeUserDelegationKeys(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return RestClient.RevokeUserDelegationKeys(resourceGroupName, accountName, cancellationToken);
        }

        /// <summary> Lists all the storage accounts available under the subscription. Note that storage keys are not returned; use the ListKeys operation for this. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<StorageAccount> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<StorageAccount>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<StorageAccount>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the storage accounts available under the subscription. Note that storage keys are not returned; use the ListKeys operation for this. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<StorageAccount> List(CancellationToken cancellationToken = default)
        {
            Page<StorageAccount> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.List(cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            Page<StorageAccount> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.ListNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the storage accounts available under the given resource group. Note that storage keys are not returned; use the ListKeys operation for this. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<StorageAccount> ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            async Task<Page<StorageAccount>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.ListByResourceGroupAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            async Task<Page<StorageAccount>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.ListByResourceGroupNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the storage accounts available under the given resource group. Note that storage keys are not returned; use the ListKeys operation for this. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<StorageAccount> ListByResourceGroup(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            Page<StorageAccount> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.ListByResourceGroup(resourceGroupName, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            Page<StorageAccount> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.ListByResourceGroupNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        internal Operation<StorageAccount> CreateCreate(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Put, "StorageAccountsClient.Create", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = StorageAccount.DeserializeStorageAccount(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = StorageAccount.DeserializeStorageAccount(document.RootElement);
                return value;
            });
        }

        /// <summary> Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the created account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<Operation<StorageAccount>> StartCreateAsync(string resourceGroupName, string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var originalResponse = await RestClient.CreateAsync(resourceGroupName, accountName, parameters, cancellationToken).ConfigureAwait(false);
            return CreateCreate(originalResponse, () => RestClient.CreateCreateRequest(resourceGroupName, accountName, parameters));
        }

        /// <summary> Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the created account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<StorageAccount> StartCreate(string resourceGroupName, string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var originalResponse = RestClient.Create(resourceGroupName, accountName, parameters, cancellationToken);
            return CreateCreate(originalResponse, () => RestClient.CreateCreateRequest(resourceGroupName, accountName, parameters));
        }

        /// <summary> Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account&apos;s primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        internal Operation<Response> CreateFailover(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "StorageAccountsClient.Failover", OperationFinalStateVia.Location, createOriginalHttpMessage);
        }

        /// <summary> Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account&apos;s primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<Operation<Response>> StartFailoverAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            var originalResponse = await RestClient.FailoverAsync(resourceGroupName, accountName, cancellationToken).ConfigureAwait(false);
            return CreateFailover(originalResponse, () => RestClient.CreateFailoverRequest(resourceGroupName, accountName));
        }

        /// <summary> Failover request can be triggered for a storage account in case of availability issues. The failover occurs from the storage account&apos;s primary cluster to secondary cluster for RA-GRS accounts. The secondary cluster will become primary after failover. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<Response> StartFailover(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            var originalResponse = RestClient.Failover(resourceGroupName, accountName, cancellationToken);
            return CreateFailover(originalResponse, () => RestClient.CreateFailoverRequest(resourceGroupName, accountName));
        }

        /// <summary> Restore blobs in the specified blob ranges. </summary>
        /// <param name="originalResponse"> The original response from starting the operation. </param>
        /// <param name="createOriginalHttpMessage"> Creates the HTTP message used for the original request. </param>
        internal Operation<BlobRestoreStatus> CreateRestoreBlobRanges(Response originalResponse, Func<HttpMessage> createOriginalHttpMessage)
        {
            if (originalResponse == null)
            {
                throw new ArgumentNullException(nameof(originalResponse));
            }
            if (createOriginalHttpMessage == null)
            {
                throw new ArgumentNullException(nameof(createOriginalHttpMessage));
            }

            return ArmOperationHelpers.Create(pipeline, clientDiagnostics, originalResponse, RequestMethod.Post, "StorageAccountsClient.RestoreBlobRanges", OperationFinalStateVia.Location, createOriginalHttpMessage,
            (response, cancellationToken) =>
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var value = BlobRestoreStatus.DeserializeBlobRestoreStatus(document.RootElement);
                return value;
            },
            async (response, cancellationToken) =>
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var value = BlobRestoreStatus.DeserializeBlobRestoreStatus(document.RootElement);
                return value;
            });
        }

        /// <summary> Restore blobs in the specified blob ranges. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="timeToRestore"> Restore blob to the specified time. </param>
        /// <param name="blobRanges"> Blob ranges to restore. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<Operation<BlobRestoreStatus>> StartRestoreBlobRangesAsync(string resourceGroupName, string accountName, DateTimeOffset timeToRestore, IEnumerable<BlobRestoreRange> blobRanges, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (blobRanges == null)
            {
                throw new ArgumentNullException(nameof(blobRanges));
            }

            var originalResponse = await RestClient.RestoreBlobRangesAsync(resourceGroupName, accountName, timeToRestore, blobRanges, cancellationToken).ConfigureAwait(false);
            return CreateRestoreBlobRanges(originalResponse, () => RestClient.CreateRestoreBlobRangesRequest(resourceGroupName, accountName, timeToRestore, blobRanges));
        }

        /// <summary> Restore blobs in the specified blob ranges. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="timeToRestore"> Restore blob to the specified time. </param>
        /// <param name="blobRanges"> Blob ranges to restore. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation<BlobRestoreStatus> StartRestoreBlobRanges(string resourceGroupName, string accountName, DateTimeOffset timeToRestore, IEnumerable<BlobRestoreRange> blobRanges, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (blobRanges == null)
            {
                throw new ArgumentNullException(nameof(blobRanges));
            }

            var originalResponse = RestClient.RestoreBlobRanges(resourceGroupName, accountName, timeToRestore, blobRanges, cancellationToken);
            return CreateRestoreBlobRanges(originalResponse, () => RestClient.CreateRestoreBlobRangesRequest(resourceGroupName, accountName, timeToRestore, blobRanges));
        }
    }
}
