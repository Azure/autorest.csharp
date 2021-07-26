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

namespace SupersetInheritance
{
    /// <summary> A class representing collection of SupersetModel1 and their operations over a ResourceGroup. </summary>
    public partial class SupersetModel1Container : ResourceContainerBase<ResourceGroupResourceIdentifier, SupersetModel1, SupersetModel1Data>
    {
        /// <summary> Initializes a new instance of the <see cref="SupersetModel1Container"/> class for mocking. </summary>
        protected SupersetModel1Container()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel1Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SupersetModel1Container(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private SupersetModel1SRestOperations _restClient => new SupersetModel1SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<SupersetModel1> CreateOrUpdate(string supersetModel1SName, SupersetModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (supersetModel1SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(supersetModel1SName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<SupersetModel1>> CreateOrUpdateAsync(string supersetModel1SName, SupersetModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (supersetModel1SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(supersetModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SupersetModel1SPutOperation StartCreateOrUpdate(string supersetModel1SName, SupersetModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (supersetModel1SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, supersetModel1SName, parameters, cancellationToken);
                return new SupersetModel1SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SupersetModel1SPutOperation> StartCreateOrUpdateAsync(string supersetModel1SName, SupersetModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (supersetModel1SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, supersetModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return new SupersetModel1SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<SupersetModel1> Get(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.Get");
            scope.Start();
            try
            {
                if (supersetModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel1SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, supersetModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(new SupersetModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<SupersetModel1>> GetAsync(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.Get");
            scope.Start();
            try
            {
                if (supersetModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel1SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, supersetModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SupersetModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual SupersetModel1 TryGet(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.TryGet");
            scope.Start();
            try
            {
                if (supersetModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel1SName));
                }

                return Get(supersetModel1SName, cancellationToken: cancellationToken).Value;
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
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<SupersetModel1> TryGetAsync(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.TryGet");
            scope.Start();
            try
            {
                if (supersetModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel1SName));
                }

                return await GetAsync(supersetModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.DoesExist");
            scope.Start();
            try
            {
                if (supersetModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel1SName));
                }

                return TryGet(supersetModel1SName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.DoesExist");
            scope.Start();
            try
            {
                if (supersetModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel1SName));
                }

                return await TryGetAsync(supersetModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SupersetModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel1Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SupersetModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel1Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, SupersetModel1, SupersetModel1Data> Construct() { }
    }
}
