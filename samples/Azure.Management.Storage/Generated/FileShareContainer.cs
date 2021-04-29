// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
    /// <summary> A class representing collection of FileShare and their operations over a StorageAccount. </summary>
    public partial class FileShareContainer : ResourceContainerBase<TenantResourceIdentifier, FileShare, FileShareData>
    {
        /// <summary> Initializes a new instance of the <see cref="FileShareContainer"/> class for mocking. </summary>
        protected FileShareContainer()
        {
        }

        /// <summary> Initializes a new instance of FileShareContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FileShareContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private FileSharesRestOperations Operations => new FileSharesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => StorageAccountOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<FileShare> CreateOrUpdate(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                return StartCreateOrUpdate(shareName, fileShare, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<FileShare>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<FileShare>> CreateOrUpdateAsync(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.CreateOrUpdateAsync");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(shareName, fileShare, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<FileShare>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<FileShare> StartCreateOrUpdate(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = Operations.Create(Id.ResourceGroupName, Id.Name, shareName, fileShare, cancellationToken: cancellationToken);
                return new PhArmOperation<FileShare, FileShareData>(
                originalResponse,
                data => new FileShare(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="fileShare"> Properties of the file share to create. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<FileShare>> StartCreateOrUpdateAsync(string shareName, FileShareData fileShare, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.StartCreateOrUpdateAsync");
            scope.Start();
            try
            {
                var originalResponse = await Operations.CreateAsync(Id.ResourceGroupName, Id.Name, shareName, fileShare, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<FileShare, FileShareData>(
                originalResponse,
                data => new FileShare(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<FileShare> Get(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.Get");
            scope.Start();
            try
            {
                return new PhArmResponse<FileShare, FileShareData>(
                Operations.Get(Id.ResourceGroupName, Id.Name, shareName, cancellationToken: cancellationToken),
                data => new FileShare(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<FileShare>> GetAsync(string shareName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.GetAsync");
            scope.Start();
            try
            {
                return new PhArmResponse<FileShare, FileShareData>(
                await Operations.GetAsync(Id.ResourceGroupName, Id.Name, shareName, cancellationToken: cancellationToken),
                data => new FileShare(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of FileShare for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FileShareOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of FileShare for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.ListAsGenericResourceAsync");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FileShareOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="FileShare" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="FileShare" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<FileShare> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, FileShare>(results, genericResource => new FileShareOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="FileShare" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="FileShare" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<FileShare> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FileShareContainer.ListAsync");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, FileShare>(results, genericResource => new FileShareOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, FileShare, FileShareData> Construct() { }
    }
}
