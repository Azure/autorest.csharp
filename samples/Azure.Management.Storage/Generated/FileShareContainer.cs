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
    /// <summary> A class representing collection of FileShare and their operations over a StorageAccount. </summary>
    public partial class FileShareContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, FileShare, FileShareData>
    {
        /// <summary> Initializes a new instance of the <see cref="FileShareContainer"/> class for mocking. </summary>
        protected FileShareContainer()
        {
        }

        /// <summary> Initializes a new instance of FileShareContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FileShareContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private FileSharesRestOperations _restClient => new FileSharesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => StorageAccountOperations.ResourceType;

        // Container level operations.

        /// <summary> Creates a new share under the specified account as described by request body. The share resource includes metadata and properties for that share. It does not include a list of the files contained by the share. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> or <paramref name="fileShare"/> is null. </exception>
        public virtual Response<FileShare> CreateOrUpdate(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            if (shareName == null)
            {
                throw new ArgumentNullException(nameof(shareName));
            }
            if (fileShare == null)
            {
                throw new ArgumentNullException(nameof(fileShare));
            }

            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(shareName, fileShare, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new share under the specified account as described by request body. The share resource includes metadata and properties for that share. It does not include a list of the files contained by the share. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> or <paramref name="fileShare"/> is null. </exception>
        public async virtual Task<Response<FileShare>> CreateOrUpdateAsync(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            if (shareName == null)
            {
                throw new ArgumentNullException(nameof(shareName));
            }
            if (fileShare == null)
            {
                throw new ArgumentNullException(nameof(fileShare));
            }

            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(shareName, fileShare, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new share under the specified account as described by request body. The share resource includes metadata and properties for that share. It does not include a list of the files contained by the share. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> or <paramref name="fileShare"/> is null. </exception>
        public virtual FileSharesCreateOperation StartCreateOrUpdate(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            if (shareName == null)
            {
                throw new ArgumentNullException(nameof(shareName));
            }
            if (fileShare == null)
            {
                throw new ArgumentNullException(nameof(fileShare));
            }

            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Create(Id.ResourceGroupName, Id.Name, shareName, fileShare, cancellationToken);
                return new FileSharesCreateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new share under the specified account as described by request body. The share resource includes metadata and properties for that share. It does not include a list of the files contained by the share. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> or <paramref name="fileShare"/> is null. </exception>
        public async virtual Task<FileSharesCreateOperation> StartCreateOrUpdateAsync(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            if (shareName == null)
            {
                throw new ArgumentNullException(nameof(shareName));
            }
            if (fileShare == null)
            {
                throw new ArgumentNullException(nameof(fileShare));
            }

            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateAsync(Id.ResourceGroupName, Id.Name, shareName, fileShare, cancellationToken).ConfigureAwait(false);
                return new FileSharesCreateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<FileShare> Get(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.Get");
            scope.Start();
            try
            {
                if (shareName == null)
                {
                    throw new ArgumentNullException(nameof(shareName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, shareName, cancellationToken: cancellationToken);
                return Response.FromValue(new FileShare(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<FileShare>> GetAsync(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.Get");
            scope.Start();
            try
            {
                if (shareName == null)
                {
                    throw new ArgumentNullException(nameof(shareName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, shareName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FileShare(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual FileShare TryGet(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.TryGet");
            scope.Start();
            try
            {
                if (shareName == null)
                {
                    throw new ArgumentNullException(nameof(shareName));
                }

                return Get(shareName, cancellationToken: cancellationToken).Value;
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<FileShare> TryGetAsync(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.TryGet");
            scope.Start();
            try
            {
                if (shareName == null)
                {
                    throw new ArgumentNullException(nameof(shareName));
                }

                return await GetAsync(shareName, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.DoesExist");
            scope.Start();
            try
            {
                if (shareName == null)
                {
                    throw new ArgumentNullException(nameof(shareName));
                }

                return TryGet(shareName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.DoesExist");
            scope.Start();
            try
            {
                if (shareName == null)
                {
                    throw new ArgumentNullException(nameof(shareName));
                }

                return await TryGetAsync(shareName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all shares. </summary>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FileShare" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<FileShare> List(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<FileShare> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FileShareContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.List(Id.ResourceGroupName, Id.Name, pageSizeHint, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShare(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FileShare> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FileShareContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListNextPage(nextLink, Id.ResourceGroupName, Id.Name, pageSizeHint, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShare(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all shares. </summary>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FileShare" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<FileShare> ListAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<FileShare>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FileShareContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListAsync(Id.ResourceGroupName, Id.Name, pageSizeHint, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShare(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FileShare>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FileShareContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListNextPageAsync(nextLink, Id.ResourceGroupName, Id.Name, pageSizeHint, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShare(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="FileShare" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FileShareOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="FileShare" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FileShareOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, FileShare, FileShareData> Construct() { }
    }
}
