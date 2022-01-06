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
using MgmtHierarchicalNonResource.Models;

namespace MgmtHierarchicalNonResource
{
    /// <summary> A class representing collection of SharedGallery and their operations over its parent. </summary>
    public partial class SharedGalleryCollection : ArmCollection, IEnumerable<SharedGallery>, IAsyncEnumerable<SharedGallery>

    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SharedGalleriesRestOperations _sharedGalleriesRestClient;
        private readonly string _location;

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryCollection"/> class for mocking. </summary>
        protected SharedGalleryCollection()
        {
        }

        /// <summary> Initializes a new instance of SharedGalleryCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        internal SharedGalleryCollection(ArmResource parent, string location) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _sharedGalleriesRestClient = new SharedGalleriesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
            _location = location;
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Subscription.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SharedGalleries_Get
        /// <summary> Get a shared gallery by subscription id or tenant id. </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<SharedGallery> Get(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            if (galleryUniqueName == null)
            {
                throw new ArgumentNullException(nameof(galleryUniqueName));
            }

            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.Get");
            scope.Start();
            try
            {
                var response = _sharedGalleriesRestClient.Get(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SharedGallery(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SharedGalleries_Get
        /// <summary> Get a shared gallery by subscription id or tenant id. </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public async virtual Task<Response<SharedGallery>> GetAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            if (galleryUniqueName == null)
            {
                throw new ArgumentNullException(nameof(galleryUniqueName));
            }

            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.Get");
            scope.Start();
            try
            {
                var response = await _sharedGalleriesRestClient.GetAsync(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SharedGallery(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<SharedGallery> GetIfExists(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            if (galleryUniqueName == null)
            {
                throw new ArgumentNullException(nameof(galleryUniqueName));
            }

            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sharedGalleriesRestClient.Get(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<SharedGallery>(null, response.GetRawResponse())
                    : Response.FromValue(new SharedGallery(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public async virtual Task<Response<SharedGallery>> GetIfExistsAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            if (galleryUniqueName == null)
            {
                throw new ArgumentNullException(nameof(galleryUniqueName));
            }

            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _sharedGalleriesRestClient.GetAsync(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<SharedGallery>(null, response.GetRawResponse())
                    : Response.FromValue(new SharedGallery(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<bool> Exists(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            if (galleryUniqueName == null)
            {
                throw new ArgumentNullException(nameof(galleryUniqueName));
            }

            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(galleryUniqueName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            if (galleryUniqueName == null)
            {
                throw new ArgumentNullException(nameof(galleryUniqueName));
            }

            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(galleryUniqueName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SharedGalleries_List
        /// <summary> List shared galleries by subscription id or tenant id. </summary>
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SharedGallery" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SharedGallery> GetAll(SharedToValues? sharedTo = null, CancellationToken cancellationToken = default)
        {
            Page<SharedGallery> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sharedGalleriesRestClient.List(Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SharedGallery(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SharedGallery> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sharedGalleriesRestClient.ListNextPage(nextLink, Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SharedGallery(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: SharedGalleries_List
        /// <summary> List shared galleries by subscription id or tenant id. </summary>
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SharedGallery" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SharedGallery> GetAllAsync(SharedToValues? sharedTo = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SharedGallery>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sharedGalleriesRestClient.ListAsync(Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SharedGallery(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SharedGallery>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sharedGalleriesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SharedGallery(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="SharedGallery" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SharedGallery.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SharedGallery" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SharedGalleryCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SharedGallery.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SharedGallery> IEnumerable<SharedGallery>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SharedGallery> IAsyncEnumerable<SharedGallery>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, SharedGallery, SharedGalleryData> Construct() { }
    }
}
