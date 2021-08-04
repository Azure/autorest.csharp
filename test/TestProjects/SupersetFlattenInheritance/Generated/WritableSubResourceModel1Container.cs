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
using SupersetFlattenInheritance.Models;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of WritableSubResourceModel1 and their operations over a ResourceGroup. </summary>
    public partial class WritableSubResourceModel1Container : ResourceContainer
    {
        /// <summary> Initializes a new instance of the <see cref="WritableSubResourceModel1Container"/> class for mocking. </summary>
        protected WritableSubResourceModel1Container()
        {
        }

        /// <summary> Initializes a new instance of WritableSubResourceModel1Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal WritableSubResourceModel1Container(ResourceOperations parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private WritableSubResourceModel1SRestOperations _restClient => new WritableSubResourceModel1SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<WritableSubResourceModel1> CreateOrUpdate(string writableSubResourceModel1SName, WritableSubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(writableSubResourceModel1SName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<WritableSubResourceModel1>> CreateOrUpdateAsync(string writableSubResourceModel1SName, WritableSubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(writableSubResourceModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual WritableSubResourceModel1PutOperation StartCreateOrUpdate(string writableSubResourceModel1SName, WritableSubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, writableSubResourceModel1SName, parameters, cancellationToken);
                return new WritableSubResourceModel1PutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResourceModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<WritableSubResourceModel1PutOperation> StartCreateOrUpdateAsync(string writableSubResourceModel1SName, WritableSubResourceModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, writableSubResourceModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return new WritableSubResourceModel1PutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<WritableSubResourceModel1> Get(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.Get");
            scope.Start();
            try
            {
                if (writableSubResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, writableSubResourceModel1SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new WritableSubResourceModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<WritableSubResourceModel1>> GetAsync(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.Get");
            scope.Start();
            try
            {
                if (writableSubResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, writableSubResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new WritableSubResourceModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<WritableSubResourceModel1> GetIfExists(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.GetIfExists");
            scope.Start();
            try
            {
                if (writableSubResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, writableSubResourceModel1SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<WritableSubResourceModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new WritableSubResourceModel1(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<WritableSubResourceModel1>> GetIfExistsAsync(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.GetIfExists");
            scope.Start();
            try
            {
                if (writableSubResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, writableSubResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<WritableSubResourceModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new WritableSubResourceModel1(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.CheckIfExists");
            scope.Start();
            try
            {
                if (writableSubResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
                }

                var response = GetIfExists(writableSubResourceModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubResourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string writableSubResourceModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.CheckIfExists");
            scope.Start();
            try
            {
                if (writableSubResourceModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResourceModel1SName));
                }

                var response = await GetIfExistsAsync(writableSubResourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="WritableSubResourceModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubResourceModel1Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="WritableSubResourceModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResourceModel1Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubResourceModel1Operations.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, WritableSubResourceModel1, WritableSubResourceModel1Data> Construct() { }
    }
}
