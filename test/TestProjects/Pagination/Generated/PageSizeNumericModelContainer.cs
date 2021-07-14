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
using Azure.ResourceManager.Core;
using Pagination.Models;

namespace Pagination
{
    /// <summary> A class representing collection of PageSizeNumericModel and their operations over a ResourceGroup. </summary>
    public partial class PageSizeNumericModelContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, PageSizeNumericModel, PageSizeNumericModelData>
    {
        /// <summary> Initializes a new instance of the <see cref="PageSizeNumericModelContainer"/> class for mocking. </summary>
        protected PageSizeNumericModelContainer()
        {
        }

        /// <summary> Initializes a new instance of PageSizeNumericModelContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal PageSizeNumericModelContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private PageSizeNumericModelsRestOperations _restClient => new PageSizeNumericModelsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a PageSizeNumericModel. Please note some properties can be set only during creation. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeNumericModel to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<PageSizeNumericModel> CreateOrUpdate(string name, PageSizeNumericModelData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(name, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a PageSizeNumericModel. Please note some properties can be set only during creation. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeNumericModel to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<PageSizeNumericModel>> CreateOrUpdateAsync(string name, PageSizeNumericModelData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(name, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a PageSizeNumericModel. Please note some properties can be set only during creation. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeNumericModel to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual PageSizeNumericModelsPutOperation StartCreateOrUpdate(string name, PageSizeNumericModelData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, name, parameters, cancellationToken: cancellationToken);
                return new PageSizeNumericModelsPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a PageSizeNumericModel. Please note some properties can be set only during creation. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeNumericModel to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<PageSizeNumericModelsPutOperation> StartCreateOrUpdateAsync(string name, PageSizeNumericModelData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, name, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PageSizeNumericModelsPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<PageSizeNumericModel> Get(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.Get");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = _restClient.Get(Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                return Response.FromValue(new PageSizeNumericModel(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<PageSizeNumericModel>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.Get");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new PageSizeNumericModel(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual PageSizeNumericModel TryGet(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.TryGet");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return Get(name, cancellationToken: cancellationToken).Value;
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
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<PageSizeNumericModel> TryGetAsync(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.TryGet");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return await GetAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.DoesExist");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return TryGet(name, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.DoesExist");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return await TryGetAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeNumericModel" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<PageSizeNumericModel> List(CancellationToken cancellationToken = default)
        {
            Page<PageSizeNumericModel> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.List(Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PageSizeNumericModel> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.ListNextPage(nextLink, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeNumericModel" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<PageSizeNumericModel> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PageSizeNumericModel>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListAsync(Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PageSizeNumericModel>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListNextPageAsync(nextLink, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of PageSizeNumericModel for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(PageSizeNumericModelOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of PageSizeNumericModel for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(PageSizeNumericModelOperations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, PageSizeNumericModel, PageSizeNumericModelData> Construct() { }
    }
}
