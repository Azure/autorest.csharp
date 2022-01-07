// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Pagination.Models;

namespace Pagination
{
    /// <summary> A class representing collection of PageSizeNumericModel and their operations over its parent. </summary>
    public partial class PageSizeNumericModelCollection : ArmCollection, IEnumerable<PageSizeNumericModel>, IAsyncEnumerable<PageSizeNumericModel>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly PageSizeNumericModelsRestOperations _pageSizeNumericModelsRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeNumericModelCollection"/> class for mocking. </summary>
        protected PageSizeNumericModelCollection()
        {
        }

        /// <summary> Initializes a new instance of PageSizeNumericModelCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal PageSizeNumericModelCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pageSizeNumericModelsRestClient = new PageSizeNumericModelsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeNumericModel to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual PageSizeNumericModelPutOperation CreateOrUpdate(string name, PageSizeNumericModelData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeNumericModelsRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken);
                var operation = new PageSizeNumericModelPutOperation(Parent, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeNumericModel to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<PageSizeNumericModelPutOperation> CreateOrUpdateAsync(string name, PageSizeNumericModelData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeNumericModelsRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new PageSizeNumericModelPutOperation(Parent, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeNumericModel> Get(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeNumericModelsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeNumericModel(Parent, new ResourceIdentifier(response.Value.Id), response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<PageSizeNumericModel>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeNumericModelsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PageSizeNumericModel(Parent, new ResourceIdentifier(response.Value.Id), response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeNumericModel> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _pageSizeNumericModelsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<PageSizeNumericModel>(null, response.GetRawResponse())
                    : Response.FromValue(new PageSizeNumericModel(this, new ResourceIdentifier(response.Value.Id), response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<PageSizeNumericModel>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _pageSizeNumericModelsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<PageSizeNumericModel>(null, response.GetRawResponse())
                    : Response.FromValue(new PageSizeNumericModel(this, new ResourceIdentifier(response.Value.Id), response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeNumericModel" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeNumericModel> GetAll(float? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Page<PageSizeNumericModel> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeNumericModelsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, new ResourceIdentifier(value.Id), value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PageSizeNumericModel> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeNumericModelsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, new ResourceIdentifier(value.Id), value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeNumericModel" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeNumericModel> GetAllAsync(float? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PageSizeNumericModel>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeNumericModelsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, new ResourceIdentifier(value.Id), value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PageSizeNumericModel>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeNumericModelsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeNumericModel(Parent, new ResourceIdentifier(value.Id), value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="PageSizeNumericModel" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(PageSizeNumericModel.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="PageSizeNumericModel" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PageSizeNumericModelCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(PageSizeNumericModel.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeNumericModel> IEnumerable<PageSizeNumericModel>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeNumericModel> IAsyncEnumerable<PageSizeNumericModel>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, PageSizeNumericModel, PageSizeNumericModelData> Construct() { }
    }
}
