// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    /// <summary> A class representing collection of PageSizeIntegerModel and their operations over its parent. </summary>
    public partial class PageSizeIntegerModelCollection : ArmCollection, IEnumerable<PageSizeIntegerModel>, IAsyncEnumerable<PageSizeIntegerModel>
    {
        private readonly ClientDiagnostics _pageSizeIntegerModelClientDiagnostics;
        private readonly PageSizeIntegerModelsRestOperations _pageSizeIntegerModelRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeIntegerModelCollection"/> class for mocking. </summary>
        protected PageSizeIntegerModelCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeIntegerModelCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PageSizeIntegerModelCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeIntegerModelClientDiagnostics = new ClientDiagnostics("Pagination", PageSizeIntegerModel.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(PageSizeIntegerModel.ResourceType, out string pageSizeIntegerModelApiVersion);
            _pageSizeIntegerModelRestClient = new PageSizeIntegerModelsRestOperations(_pageSizeIntegerModelClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, pageSizeIntegerModelApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Put
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeIntegerModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<PageSizeIntegerModelCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string name, PageSizeIntegerModelData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeIntegerModelRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new PageSizeIntegerModelCreateOrUpdateOperation(Client, response);
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

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Put
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeIntegerModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual PageSizeIntegerModelCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string name, PageSizeIntegerModelData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeIntegerModelRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken);
                var operation = new PageSizeIntegerModelCreateOrUpdateOperation(Client, response);
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

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<PageSizeIntegerModel>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeIntegerModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _pageSizeIntegerModelClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PageSizeIntegerModel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeIntegerModel> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeIntegerModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw _pageSizeIntegerModelClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeIntegerModel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel
        /// Operation Id: PageSizeIntegerModels_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeIntegerModel" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeIntegerModel> GetAllAsync(int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PageSizeIntegerModel>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeIntegerModelRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeIntegerModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PageSizeIntegerModel>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeIntegerModelRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeIntegerModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel
        /// Operation Id: PageSizeIntegerModels_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeIntegerModel" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeIntegerModel> GetAll(int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Page<PageSizeIntegerModel> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeIntegerModelRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeIntegerModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PageSizeIntegerModel> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeIntegerModelRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeIntegerModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.Exists");
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

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.Exists");
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

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<PageSizeIntegerModel>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _pageSizeIntegerModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<PageSizeIntegerModel>(null, response.GetRawResponse());
                return Response.FromValue(new PageSizeIntegerModel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/pageSizeIntegerModel/{name}
        /// Operation Id: PageSizeIntegerModels_Get
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeIntegerModel> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeIntegerModelClientDiagnostics.CreateScope("PageSizeIntegerModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _pageSizeIntegerModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<PageSizeIntegerModel>(null, response.GetRawResponse());
                return Response.FromValue(new PageSizeIntegerModel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeIntegerModel> IEnumerable<PageSizeIntegerModel>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeIntegerModel> IAsyncEnumerable<PageSizeIntegerModel>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
