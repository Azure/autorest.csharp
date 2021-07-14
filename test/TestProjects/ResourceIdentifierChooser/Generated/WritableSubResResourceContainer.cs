// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing collection of WritableSubResResource and their operations over a Subscription. </summary>
    public partial class WritableSubResResourceContainer : ResourceContainerBase<SubscriptionResourceIdentifier, WritableSubResResource, WritableSubResResourceData>
    {
        /// <summary> Initializes a new instance of the <see cref="WritableSubResResourceContainer"/> class for mocking. </summary>
        protected WritableSubResResourceContainer()
        {
        }

        /// <summary> Initializes a new instance of WritableSubResResourceContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal WritableSubResResourceContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private WritableSubResResourcesRestOperations _restClient => new WritableSubResResourcesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new SubscriptionResourceIdentifier Id => base.Id as SubscriptionResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        // Container level operations.

        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<WritableSubResResource> CreateOrUpdate(string writableSubResResourcesName, WritableSubResResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(writableSubResResourcesName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<WritableSubResResource>> CreateOrUpdateAsync(string writableSubResResourcesName, WritableSubResResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(writableSubResResourcesName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual WritableSubResResourcesPutOperation StartCreateOrUpdate(string writableSubResResourcesName, WritableSubResResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.Name, writableSubResResourcesName, parameters, cancellationToken);
                return new WritableSubResResourcesPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubResResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubResResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<WritableSubResResourcesPutOperation> StartCreateOrUpdateAsync(string writableSubResResourcesName, WritableSubResResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubResResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubResResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.Name, writableSubResResourcesName, parameters, cancellationToken).ConfigureAwait(false);
                return new WritableSubResResourcesPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<WritableSubResResource> Get(string writableSubResResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.Get");
            scope.Start();
            try
            {
                if (writableSubResResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResResourcesName));
                }

                var response = _restClient.Get(Id.Name, writableSubResResourcesName, cancellationToken: cancellationToken);
                return Response.FromValue(new WritableSubResResource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<WritableSubResResource>> GetAsync(string writableSubResResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.Get");
            scope.Start();
            try
            {
                if (writableSubResResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResResourcesName));
                }

                var response = await _restClient.GetAsync(Id.Name, writableSubResResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new WritableSubResResource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public WritableSubResResource TryGet(string writableSubResResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (writableSubResResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResResourcesName));
                }

                return Get(writableSubResResourcesName, cancellationToken: cancellationToken).Value;
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
        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<WritableSubResResource> TryGetAsync(string writableSubResResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (writableSubResResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResResourcesName));
                }

                return await GetAsync(writableSubResResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public bool DoesExist(string writableSubResResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (writableSubResResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResResourcesName));
                }

                return TryGet(writableSubResResourcesName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubResResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<bool> DoesExistAsync(string writableSubResResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (writableSubResResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubResResourcesName));
                }

                return await TryGetAsync(writableSubResResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of WritableSubResResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubResResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of WritableSubResResource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubResResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubResResourceOperations.ResourceType);
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
        // public ArmBuilder<SubscriptionResourceIdentifier, WritableSubResResource, WritableSubResResourceData> Construct() { }
    }
}
