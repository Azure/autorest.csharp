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
    /// <summary> A class representing collection of WritableSubRes3Resource and their operations over a ResourceGroup. </summary>
    public partial class WritableSubRes3ResourceContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, WritableSubRes3Resource, WritableSubRes3ResourceData>
    {
        /// <summary> Initializes a new instance of the <see cref="WritableSubRes3ResourceContainer"/> class for mocking. </summary>
        protected WritableSubRes3ResourceContainer()
        {
        }

        /// <summary> Initializes a new instance of WritableSubRes3ResourceContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal WritableSubRes3ResourceContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private WritableSubRes3ResourcesRestOperations _restClient => new WritableSubRes3ResourcesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a WritableSubRes3Resource. Please note some properties can be set only during creation. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes3Resource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<WritableSubRes3Resource> CreateOrUpdate(string writableSubRes3ResourcesName, WritableSubRes3ResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(writableSubRes3ResourcesName, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a WritableSubRes3Resource. Please note some properties can be set only during creation. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes3Resource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<WritableSubRes3Resource>> CreateOrUpdateAsync(string writableSubRes3ResourcesName, WritableSubRes3ResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(writableSubRes3ResourcesName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a WritableSubRes3Resource. Please note some properties can be set only during creation. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes3Resource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual WritableSubRes3ResourcesPutOperation StartCreateOrUpdate(string writableSubRes3ResourcesName, WritableSubRes3ResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, writableSubRes3ResourcesName, parameters, cancellationToken: cancellationToken);
                return new WritableSubRes3ResourcesPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a WritableSubRes3Resource. Please note some properties can be set only during creation. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="parameters"> The WritableSubRes3Resource to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<WritableSubRes3ResourcesPutOperation> StartCreateOrUpdateAsync(string writableSubRes3ResourcesName, WritableSubRes3ResourceData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, writableSubRes3ResourcesName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new WritableSubRes3ResourcesPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<WritableSubRes3Resource> Get(string writableSubRes3ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.Get");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, writableSubRes3ResourcesName, cancellationToken: cancellationToken);
                return Response.FromValue(new WritableSubRes3Resource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<WritableSubRes3Resource>> GetAsync(string writableSubRes3ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.Get");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, writableSubRes3ResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new WritableSubRes3Resource(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual WritableSubRes3Resource TryGet(string writableSubRes3ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }

                return Get(writableSubRes3ResourcesName, cancellationToken: cancellationToken).Value;
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
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<WritableSubRes3Resource> TryGetAsync(string writableSubRes3ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.TryGet");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }

                return await GetAsync(writableSubRes3ResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string writableSubRes3ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }

                return TryGet(writableSubRes3ResourcesName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="writableSubRes3ResourcesName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string writableSubRes3ResourcesName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.DoesExist");
            scope.Start();
            try
            {
                if (writableSubRes3ResourcesName == null)
                {
                    throw new ArgumentNullException(nameof(writableSubRes3ResourcesName));
                }

                return await TryGetAsync(writableSubRes3ResourcesName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of WritableSubRes3Resource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubRes3ResourceOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of WritableSubRes3Resource for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("WritableSubRes3ResourceContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(WritableSubRes3ResourceOperations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, WritableSubRes3Resource, WritableSubRes3ResourceData> Construct() { }
    }
}
