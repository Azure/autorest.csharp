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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of BlobContainer and their operations over a StorageAccount. </summary>
    public partial class BlobContainerContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, BlobContainer, BlobContainerData>
    {
        /// <summary> Initializes a new instance of the <see cref="BlobContainerContainer"/> class for mocking. </summary>
        protected BlobContainerContainer()
        {
        }

        /// <summary> Initializes a new instance of BlobContainerContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal BlobContainerContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private BlobContainersRestOperations _restClient => new BlobContainersRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => StorageAccountOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="blobContainer"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<BlobContainer> CreateOrUpdate(string containerName, BlobContainerData blobContainer, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (containerName == null)
                {
                    throw new ArgumentNullException(nameof(containerName));
                }
                if (blobContainer == null)
                {
                    throw new ArgumentNullException(nameof(blobContainer));
                }

                return StartCreateOrUpdate(containerName, blobContainer, cancellationToken: cancellationToken).WaitForCompletion() as Response<BlobContainer>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="blobContainer"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<BlobContainer>> CreateOrUpdateAsync(string containerName, BlobContainerData blobContainer, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (containerName == null)
                {
                    throw new ArgumentNullException(nameof(containerName));
                }
                if (blobContainer == null)
                {
                    throw new ArgumentNullException(nameof(blobContainer));
                }

                var operation = await StartCreateOrUpdateAsync(containerName, blobContainer, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as Response<BlobContainer>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="blobContainer"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Operation<BlobContainer> StartCreateOrUpdate(string containerName, BlobContainerData blobContainer, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (containerName == null)
                {
                    throw new ArgumentNullException(nameof(containerName));
                }
                if (blobContainer == null)
                {
                    throw new ArgumentNullException(nameof(blobContainer));
                }

                var originalResponse = _restClient.Create(Id.ResourceGroupName, Id.Parent.Name, containerName, blobContainer, cancellationToken: cancellationToken);
                return new BlobContainersCreateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="blobContainer"> Properties of the blob container to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Operation<BlobContainer>> StartCreateOrUpdateAsync(string containerName, BlobContainerData blobContainer, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (containerName == null)
                {
                    throw new ArgumentNullException(nameof(containerName));
                }
                if (blobContainer == null)
                {
                    throw new ArgumentNullException(nameof(blobContainer));
                }

                var originalResponse = await _restClient.CreateAsync(Id.ResourceGroupName, Id.Parent.Name, containerName, blobContainer, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new BlobContainersCreateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override Response<BlobContainer> Get(string containerName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.Get");
            scope.Start();
            try
            {
                if (containerName == null)
                {
                    throw new ArgumentNullException(nameof(containerName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken: cancellationToken);
                return Response.FromValue(new BlobContainer(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<Response<BlobContainer>> GetAsync(string containerName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.Get");
            scope.Start();
            try
            {
                if (containerName == null)
                {
                    throw new ArgumentNullException(nameof(containerName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, containerName, cancellationToken: cancellationToken);
                return Response.FromValue(new BlobContainer(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of BlobContainer for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(BlobContainerOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of BlobContainer for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(BlobContainerOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="BlobContainer" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="BlobContainer" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<BlobContainer> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                Page<BlobContainer> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.List(Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<BlobContainer> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListNextPage(nextLink, Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, BlobContainer>(results, genericResource => new BlobContainerOperations(genericResource).Get().Value);
            }
        }

        /// <summary> Filters the list of <see cref="BlobContainer" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="BlobContainer" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<BlobContainer> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                async Task<Page<BlobContainer>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.List");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListAsync(Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<BlobContainer>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("BlobContainerContainer.List");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListNextPageAsync(nextLink, Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new BlobContainer(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, BlobContainer>(results, genericResource => new BlobContainerOperations(genericResource).Get().Value);
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, BlobContainer, BlobContainerData> Construct() { }
    }
}
