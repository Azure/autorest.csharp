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
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of Image and their operations over its parent. </summary>
    public partial class ImageContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ImagesRestOperations _imagesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ImageContainer"/> class for mocking. </summary>
        protected ImageContainer()
        {
        }

        /// <summary> Initializes a new instance of ImageContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ImageContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _imagesRestClient = new ImagesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Container level operations.

        /// <summary> Create or update an image. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="parameters"> Parameters supplied to the Create Image operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ImageCreateOrUpdateOperation CreateOrUpdate(string imageName, ImageData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _imagesRestClient.CreateOrUpdate(Id.ResourceGroupName, imageName, parameters, cancellationToken);
                var operation = new ImageCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _imagesRestClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, imageName, parameters).Request, response);
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

        /// <summary> Create or update an image. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="parameters"> Parameters supplied to the Create Image operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ImageCreateOrUpdateOperation> CreateOrUpdateAsync(string imageName, ImageData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _imagesRestClient.CreateOrUpdateAsync(Id.ResourceGroupName, imageName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ImageCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _imagesRestClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, imageName, parameters).Request, response);
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

        /// <summary> Gets an image. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        public virtual Response<Image> Get(string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.Get");
            scope.Start();
            try
            {
                var response = _imagesRestClient.Get(Id.ResourceGroupName, imageName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Image(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets an image. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        public async virtual Task<Response<Image>> GetAsync(string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.Get");
            scope.Start();
            try
            {
                var response = await _imagesRestClient.GetAsync(Id.ResourceGroupName, imageName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Image(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        public virtual Response<Image> GetIfExists(string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetIfExists");
            scope.Start();
            try
            {
                var response = _imagesRestClient.Get(Id.ResourceGroupName, imageName, expand, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Image>(null, response.GetRawResponse())
                    : Response.FromValue(new Image(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        public async virtual Task<Response<Image>> GetIfExistsAsync(string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _imagesRestClient.GetAsync(Id.ResourceGroupName, imageName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Image>(null, response.GetRawResponse())
                    : Response.FromValue(new Image(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(imageName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string imageName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (imageName == null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }

            using var scope = _clientDiagnostics.CreateScope("ImageContainer.CheckIfExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(imageName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the list of images under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Image" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Image> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Image> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _imagesRestClient.GetAllByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Image> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _imagesRestClient.GetAllByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the list of images under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Image" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Image> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Image>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _imagesRestClient.GetAllByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Image>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _imagesRestClient.GetAllByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Image(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="Image" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Image.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Image" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImageContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Image.ResourceType);
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
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, Image, ImageData> Construct() { }
    }
}
