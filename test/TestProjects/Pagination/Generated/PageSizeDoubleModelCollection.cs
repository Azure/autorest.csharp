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

namespace Pagination
{
    /// <summary> A class representing collection of PageSizeDoubleModel and their operations over its parent. </summary>
    public partial class PageSizeDoubleModelCollection : ArmCollection, IEnumerable<PageSizeDoubleModel>, IAsyncEnumerable<PageSizeDoubleModel>
    {
        private readonly ClientDiagnostics _pageSizeDoubleModelClientDiagnostics;
        private readonly PageSizeDoubleModelsRestOperations _pageSizeDoubleModelRestClient;

        /// <summary> Initializes a new instance of the <see cref="PageSizeDoubleModelCollection"/> class for mocking. </summary>
        protected PageSizeDoubleModelCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PageSizeDoubleModelCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PageSizeDoubleModelCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _pageSizeDoubleModelClientDiagnostics = new ClientDiagnostics("Pagination", PageSizeDoubleModel.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(PageSizeDoubleModel.ResourceType, out string pageSizeDoubleModelApiVersion);
            _pageSizeDoubleModelRestClient = new PageSizeDoubleModelsRestOperations(_pageSizeDoubleModelClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, pageSizeDoubleModelApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeDoubleModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<PageSizeDoubleModel>> CreateOrUpdateAsync(bool waitForCompletion, string name, PageSizeDoubleModelData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _pageSizeDoubleModelRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new PaginationArmOperation<PageSizeDoubleModel>(Response.FromValue(new PageSizeDoubleModel(Client, response), response.GetRawResponse()));
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

        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> The String to use. </param>
        /// <param name="parameters"> The PageSizeDoubleModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<PageSizeDoubleModel> CreateOrUpdate(bool waitForCompletion, string name, PageSizeDoubleModelData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _pageSizeDoubleModelRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken);
                var operation = new PaginationArmOperation<PageSizeDoubleModel>(Response.FromValue(new PageSizeDoubleModel(Client, response), response.GetRawResponse()));
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<PageSizeDoubleModel>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.Get");
            scope.Start();
            try
            {
                var response = await _pageSizeDoubleModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _pageSizeDoubleModelClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PageSizeDoubleModel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeDoubleModel> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.Get");
            scope.Start();
            try
            {
                var response = _pageSizeDoubleModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw _pageSizeDoubleModelClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PageSizeDoubleModel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PageSizeDoubleModel" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PageSizeDoubleModel> GetAllAsync(double? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PageSizeDoubleModel>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeDoubleModelRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeDoubleModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PageSizeDoubleModel>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _pageSizeDoubleModelRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeDoubleModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PageSizeDoubleModel" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PageSizeDoubleModel> GetAll(double? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            Page<PageSizeDoubleModel> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeDoubleModelRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeDoubleModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PageSizeDoubleModel> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _pageSizeDoubleModelRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, pageSizeHint, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PageSizeDoubleModel(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.Exists");
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

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.Exists");
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
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<Response<PageSizeDoubleModel>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _pageSizeDoubleModelRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<PageSizeDoubleModel>(null, response.GetRawResponse());
                return Response.FromValue(new PageSizeDoubleModel(Client, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="name"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<PageSizeDoubleModel> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _pageSizeDoubleModelClientDiagnostics.CreateScope("PageSizeDoubleModelCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _pageSizeDoubleModelRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<PageSizeDoubleModel>(null, response.GetRawResponse());
                return Response.FromValue(new PageSizeDoubleModel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PageSizeDoubleModel> IEnumerable<PageSizeDoubleModel>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PageSizeDoubleModel> IAsyncEnumerable<PageSizeDoubleModel>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
