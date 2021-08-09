// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using OmitOperationGroups.Models;

namespace OmitOperationGroups
{
    /// <summary> A class representing collection of Model2 and their operations over a ResourceGroup. </summary>
    public partial class Model2Container : ResourceContainer
    {
        /// <summary> Initializes a new instance of the <see cref="Model2Container"/> class for mocking. </summary>
        protected Model2Container()
        {
        }

        /// <summary> Initializes a new instance of Model2Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal Model2Container(ResourceOperations parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private Model2SRestOperations _restClient => new Model2SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<Model2> CreateOrUpdate(string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(model2SName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<Model2>> CreateOrUpdateAsync(string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(model2SName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Model2CreateOrUpdateOperation StartCreateOrUpdate(string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, model2SName, parameters, cancellationToken);
                return new Model2CreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Model2CreateOrUpdateOperation> StartCreateOrUpdateAsync(string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, model2SName, parameters, cancellationToken).ConfigureAwait(false);
                return new Model2CreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<Model2> Get(string model2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.Get");
            scope.Start();
            try
            {
                if (model2SName == null)
                {
                    throw new ArgumentNullException(nameof(model2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<Model2>> GetAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.Get");
            scope.Start();
            try
            {
                if (model2SName == null)
                {
                    throw new ArgumentNullException(nameof(model2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Model2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<Model2> GetIfExists(string model2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.GetIfExists");
            scope.Start();
            try
            {
                if (model2SName == null)
                {
                    throw new ArgumentNullException(nameof(model2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Model2>(null, response.GetRawResponse())
                    : Response.FromValue(new Model2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<Model2>> GetIfExistsAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.GetIfExists");
            scope.Start();
            try
            {
                if (model2SName == null)
                {
                    throw new ArgumentNullException(nameof(model2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Model2>(null, response.GetRawResponse())
                    : Response.FromValue(new Model2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string model2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.CheckIfExists");
            scope.Start();
            try
            {
                if (model2SName == null)
                {
                    throw new ArgumentNullException(nameof(model2SName));
                }

                var response = GetIfExists(model2SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.CheckIfExists");
            scope.Start();
            try
            {
                if (model2SName == null)
                {
                    throw new ArgumentNullException(nameof(model2SName));
                }

                var response = await GetIfExistsAsync(model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Model2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResourceExpanded> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Model2Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Model2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResourceExpanded> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Model2Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, Model2, Model2Data> Construct() { }
    }
}
