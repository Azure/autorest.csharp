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

namespace Azure.Management.Storage
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _skusClientDiagnostics;
        private SkusRestOperations _skusRestClient;
        private ClientDiagnostics _storageAccountClientDiagnostics;
        private StorageAccountsRestOperations _storageAccountRestClient;
        private ClientDiagnostics _usagesClientDiagnostics;
        private UsagesRestOperations _usagesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class for mocking. </summary>
        protected SubscriptionExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics SkusClientDiagnostics => _skusClientDiagnostics ??= new ClientDiagnostics("Azure.Management.Storage", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private SkusRestOperations SkusRestClient => _skusRestClient ??= new SkusRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
        private ClientDiagnostics StorageAccountClientDiagnostics => _storageAccountClientDiagnostics ??= new ClientDiagnostics("Azure.Management.Storage", StorageAccount.ResourceType.Namespace, DiagnosticOptions);
        private StorageAccountsRestOperations StorageAccountRestClient => _storageAccountRestClient ??= new StorageAccountsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(StorageAccount.ResourceType));
        private ClientDiagnostics UsagesClientDiagnostics => _usagesClientDiagnostics ??= new ClientDiagnostics("Azure.Management.Storage", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private UsagesRestOperations UsagesRestClient => _usagesRestClient ??= new UsagesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of DeletedAccounts in the Subscription. </summary>
        /// <returns> An object representing collection of DeletedAccounts and their operations over a DeletedAccount. </returns>
        public virtual DeletedAccountCollection GetDeletedAccounts()
        {
            return GetCachedClient(Client => new DeletedAccountCollection(Client, Id));
        }

        /// <summary>
        /// Lists the available SKUs supported by Microsoft.Storage for given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus
        /// Operation Id: Skus_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StorageSkuInformation" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StorageSkuInformation> GetSkusAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<StorageSkuInformation>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = SkusClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetSkus");
                scope.Start();
                try
                {
                    var response = await SkusRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Lists the available SKUs supported by Microsoft.Storage for given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/skus
        /// Operation Id: Skus_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageSkuInformation" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StorageSkuInformation> GetSkus(CancellationToken cancellationToken = default)
        {
            Page<StorageSkuInformation> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = SkusClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetSkus");
                scope.Start();
                try
                {
                    var response = SkusRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Lists all the storage accounts available under the subscription. Note that storage keys are not returned; use the ListKeys operation for this.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts
        /// Operation Id: StorageAccounts_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StorageAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StorageAccount> GetStorageAccountsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<StorageAccount>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = StorageAccountClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetStorageAccounts");
                scope.Start();
                try
                {
                    var response = await StorageAccountRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new StorageAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<StorageAccount>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = StorageAccountClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetStorageAccounts");
                scope.Start();
                try
                {
                    var response = await StorageAccountRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new StorageAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the storage accounts available under the subscription. Note that storage keys are not returned; use the ListKeys operation for this.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/storageAccounts
        /// Operation Id: StorageAccounts_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StorageAccount> GetStorageAccounts(CancellationToken cancellationToken = default)
        {
            Page<StorageAccount> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = StorageAccountClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetStorageAccounts");
                scope.Start();
                try
                {
                    var response = StorageAccountRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new StorageAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<StorageAccount> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = StorageAccountClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetStorageAccounts");
                scope.Start();
                try
                {
                    var response = StorageAccountRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new StorageAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets the current usage count and the limit for the resources of the location under the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages
        /// Operation Id: Usages_ListByLocation
        /// </summary>
        /// <param name="location"> The location of the Azure Storage resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StorageUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StorageUsage> GetUsagesByLocationAsync(string location, CancellationToken cancellationToken = default)
        {
            async Task<Page<StorageUsage>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = UsagesClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetUsagesByLocation");
                scope.Start();
                try
                {
                    var response = await UsagesRestClient.ListByLocationAsync(Id.SubscriptionId, location, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets the current usage count and the limit for the resources of the location under the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/usages
        /// Operation Id: Usages_ListByLocation
        /// </summary>
        /// <param name="location"> The location of the Azure Storage resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StorageUsage> GetUsagesByLocation(string location, CancellationToken cancellationToken = default)
        {
            Page<StorageUsage> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = UsagesClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetUsagesByLocation");
                scope.Start();
                try
                {
                    var response = UsagesRestClient.ListByLocation(Id.SubscriptionId, location, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
