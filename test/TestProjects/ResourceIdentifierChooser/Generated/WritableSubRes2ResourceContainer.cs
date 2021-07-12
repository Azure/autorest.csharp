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
    /// <summary> A class representing collection of WritableSubRes2Resource and their operations over a Tenant. </summary>
    public partial class WritableSubRes2ResourceContainer : ResourceContainerBase<TenantResourceIdentifier, WritableSubRes2Resource, WritableSubRes2ResourceData>
    {
        /// <summary> Initializes a new instance of the <see cref="WritableSubRes2ResourceContainer"/> class for mocking. </summary>
        protected WritableSubRes2ResourceContainer()
        {
        }

        /// <summary> Initializes a new instance of WritableSubRes2ResourceContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal WritableSubRes2ResourceContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private WritableSubRes2ResourcesRestOperations _restClient => new WritableSubRes2ResourcesRestOperations(_clientDiagnostics, Pipeline, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new TenantResourceIdentifier Id => base.Id as TenantResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        // Container level operations.

        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes2Resource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubRes2ResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public Response<WritableSubRes2Resource> Put(string writableSubRes2ResourcesName, WritableSubRes2ResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubRes2ResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.Put");
            scope.Start();
            try
            {
                var operation = StartPut(writableSubRes2ResourcesName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes2Resource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubRes2ResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public async Task<Response<WritableSubRes2Resource>> PutAsync(string writableSubRes2ResourcesName, WritableSubRes2ResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubRes2ResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.Put");
            scope.Start();
            try
            {
                var operation = await StartPutAsync(writableSubRes2ResourcesName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes2Resource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubRes2ResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public WritableSubRes2ResourcesPutOperation StartPut(string writableSubRes2ResourcesName, WritableSubRes2ResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubRes2ResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.StartPut");
            scope.Start();
            try
            {
                var response = _restClient.Put(writableSubRes2ResourcesName, parameters, cancellationToken);
                return new WritableSubRes2ResourcesPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes2Resource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="writableSubRes2ResourcesName"/> or <paramref name="parameters"/> is null. </exception>
        public async Task<WritableSubRes2ResourcesPutOperation> StartPutAsync(string writableSubRes2ResourcesName, WritableSubRes2ResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (writableSubRes2ResourcesName == null)
            {
                throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.StartPut");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(writableSubRes2ResourcesName, parameters, cancellationToken).ConfigureAwait(false);
                return new WritableSubRes2ResourcesPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<WritableSubRes2Resource> Get(string writableSubRes2ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.Get");
            scope.Start();
            try
            {
                if (writableSubRes2ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
                }

                var response = _restClient.Get(writableSubRes2ResourcesName, cancellationToken: cancellationToken);
                return Response.FromValue(new WritableSubRes2Resource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<WritableSubRes2Resource>> GetAsync(string writableSubRes2ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.Get");
            scope.Start();
            try
            {
                if (writableSubRes2ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
                }

                var response = await _restClient.GetAsync(writableSubRes2ResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new WritableSubRes2Resource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public WritableSubRes2Resource TryGet(string writableSubRes2ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (writableSubRes2ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
                }

                return Get(writableSubRes2ResourcesName, cancellationToken: cancellationToken).Value;
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
        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<WritableSubRes2Resource> TryGetAsync(string writableSubRes2ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (writableSubRes2ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
                }

                return await GetAsync(writableSubRes2ResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public bool DoesExist(string writableSubRes2ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (writableSubRes2ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
                }

                return TryGet(writableSubRes2ResourcesName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubRes2ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<bool> DoesExistAsync(string writableSubRes2ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (writableSubRes2ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes2ResourcesName));
                }

                return await TryGetAsync(writableSubRes2ResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of WritableSubRes2Resource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubRes2ResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of WritableSubRes2Resource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes2ResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubRes2ResourceOperations.ResourceType);
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
        // public ArmBuilder<TenantResourceIdentifier, WritableSubRes2Resource, WritableSubRes2ResourceData> Construct() { }
    }
}
