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
using MgmtHierarchicalNonResource.Models;

namespace MgmtHierarchicalNonResource
{
    /// <summary> A class representing collection of SharedGallery and their operations over its parent. </summary>
    public partial class SharedGalleryCollection : ArmCollection, IEnumerable<SharedGallery>, IAsyncEnumerable<SharedGallery>
    {
        private readonly ClientDiagnostics _sharedGalleryClientDiagnostics;
        private readonly SharedGalleriesRestOperations _sharedGalleryRestClient;
        private readonly string _location;

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryCollection"/> class for mocking. </summary>
        protected SharedGalleryCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SharedGalleryCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        internal SharedGalleryCollection(ArmClient client, ResourceIdentifier id, string location) : base(client, id)
        {
            _location = location;
            _sharedGalleryClientDiagnostics = new ClientDiagnostics("MgmtHierarchicalNonResource", SharedGallery.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SharedGallery.ResourceType, out string sharedGalleryApiVersion);
            _sharedGalleryRestClient = new SharedGalleriesRestOperations(_sharedGalleryClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, sharedGalleryApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// Operation Id: SharedGalleries_Get
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual async Task<Response<SharedGallery>> GetAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Get");
            scope.Start();
            try
            {
                var response = await _sharedGalleryRestClient.GetAsync(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _sharedGalleryClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                response.Value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGallery(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// Operation Id: SharedGalleries_Get
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<SharedGallery> Get(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Get");
            scope.Start();
            try
            {
                var response = _sharedGalleryRestClient.Get(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken);
                if (response.Value == null)
                    throw _sharedGalleryClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                response.Value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGallery(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List shared galleries by subscription id or tenant id.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries
        /// Operation Id: SharedGalleries_List
        /// </summary>
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SharedGallery" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SharedGallery> GetAllAsync(SharedToValues? sharedTo = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SharedGallery>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sharedGalleryRestClient.ListAsync(Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value =>
                    {
                        value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, value.Name);
                        return new SharedGallery(Client, value);
                    }
                    ), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SharedGallery>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sharedGalleryRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value =>
                    {
                        value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, value.Name);
                        return new SharedGallery(Client, value);
                    }
                    ), response.Value.NextLink, response.GetRawResponse());
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
        /// List shared galleries by subscription id or tenant id.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries
        /// Operation Id: SharedGalleries_List
        /// </summary>
        /// <param name="sharedTo"> The query parameter to decide what shared galleries to fetch when doing listing operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SharedGallery" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SharedGallery> GetAll(SharedToValues? sharedTo = null, CancellationToken cancellationToken = default)
        {
            Page<SharedGallery> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sharedGalleryRestClient.List(Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value =>
                    {
                        value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, value.Name);
                        return new SharedGallery(Client, value);
                    }
                    ), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SharedGallery> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sharedGalleryRestClient.ListNextPage(nextLink, Id.SubscriptionId, _location, sharedTo, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value =>
                    {
                        value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, value.Name);
                        return new SharedGallery(Client, value);
                    }
                    ), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// Operation Id: SharedGalleries_Get
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Exists");
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

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// Operation Id: SharedGalleries_Get
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<bool> Exists(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.Exists");
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

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// Operation Id: SharedGalleries_Get
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual async Task<Response<SharedGallery>> GetIfExistsAsync(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sharedGalleryRestClient.GetAsync(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SharedGallery>(null, response.GetRawResponse());
                response.Value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGallery(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}
        /// Operation Id: SharedGalleries_Get
        /// </summary>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryUniqueName"/> is null. </exception>
        public virtual Response<SharedGallery> GetIfExists(string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryUniqueName, nameof(galleryUniqueName));

            using var scope = _sharedGalleryClientDiagnostics.CreateScope("SharedGalleryCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sharedGalleryRestClient.Get(Id.SubscriptionId, _location, galleryUniqueName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SharedGallery>(null, response.GetRawResponse());
                response.Value.Id = SharedGallery.CreateResourceIdentifier(Id.SubscriptionId, _location, galleryUniqueName);
                return Response.FromValue(new SharedGallery(Client, response.Value), response.GetRawResponse());
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
    }
}
