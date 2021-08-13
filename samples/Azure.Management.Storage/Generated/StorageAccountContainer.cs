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
    /// <summary> A class representing collection of StorageAccount and their operations over a ResourceGroup. </summary>
    public partial class StorageAccountContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly StorageAccountsRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="StorageAccountContainer"/> class for mocking. </summary>
        protected StorageAccountContainer()
        {
        }

        /// <summary> Initializes a new instance of StorageAccountContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal StorageAccountContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new StorageAccountsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Container level operations.

        /// <summary> Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the created account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<StorageAccount> CreateOrUpdate(string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(accountName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the created account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<StorageAccount>> CreateOrUpdateAsync(string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(accountName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the created account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual StorageAccountCreateOperation StartCreateOrUpdate(string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Create(Id.ResourceGroupName, accountName, parameters, cancellationToken);
                return new StorageAccountCreateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateRequest(Id.ResourceGroupName, accountName, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Asynchronously creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The parameters to provide for the created account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<StorageAccountCreateOperation> StartCreateOrUpdateAsync(string accountName, StorageAccountCreateParameters parameters, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateAsync(Id.ResourceGroupName, accountName, parameters, cancellationToken).ConfigureAwait(false);
                return new StorageAccountCreateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateRequest(Id.ResourceGroupName, accountName, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<StorageAccount> Get(string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.Get");
            scope.Start();
            try
            {
                if (accountName == null)
                {
                    throw new ArgumentNullException(nameof(accountName));
                }

                var response = _restClient.GetProperties(Id.ResourceGroupName, accountName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new StorageAccount(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<StorageAccount>> GetAsync(string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.Get");
            scope.Start();
            try
            {
                if (accountName == null)
                {
                    throw new ArgumentNullException(nameof(accountName));
                }

                var response = await _restClient.GetPropertiesAsync(Id.ResourceGroupName, accountName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new StorageAccount(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<StorageAccount> GetIfExists(string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.GetIfExists");
            scope.Start();
            try
            {
                if (accountName == null)
                {
                    throw new ArgumentNullException(nameof(accountName));
                }

                var response = _restClient.GetProperties(Id.ResourceGroupName, accountName, expand, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<StorageAccount>(null, response.GetRawResponse())
                    : Response.FromValue(new StorageAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<StorageAccount>> GetIfExistsAsync(string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.GetIfExists");
            scope.Start();
            try
            {
                if (accountName == null)
                {
                    throw new ArgumentNullException(nameof(accountName));
                }

                var response = await _restClient.GetPropertiesAsync(Id.ResourceGroupName, accountName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<StorageAccount>(null, response.GetRawResponse())
                    : Response.FromValue(new StorageAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (accountName == null)
                {
                    throw new ArgumentNullException(nameof(accountName));
                }

                var response = GetIfExists(accountName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="expand"> May be used to expand the properties within account&apos;s properties. By default, data is not included when fetching properties. Currently we only support geoReplicationStats and blobRestoreStatus. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string accountName, StorageAccountExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (accountName == null)
                {
                    throw new ArgumentNullException(nameof(accountName));
                }

                var response = await GetIfExistsAsync(accountName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all the storage accounts available under the given resource group. Note that storage keys are not returned; use the ListKeys operation for this. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StorageAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StorageAccount> GetAll(CancellationToken cancellationToken = default)
        {
            Page<StorageAccount> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new StorageAccount(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Lists all the storage accounts available under the given resource group. Note that storage keys are not returned; use the ListKeys operation for this. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StorageAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StorageAccount> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<StorageAccount>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new StorageAccount(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="StorageAccount" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(StorageAccount.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="StorageAccount" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("StorageAccountContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(StorageAccount.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, StorageAccount, StorageAccountData> Construct() { }
    }
}
