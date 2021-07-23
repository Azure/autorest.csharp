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

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of ResourceModel2 and their operations over a ResourceGroup. </summary>
    public partial class ResourceModel2Container : ResourceContainerBase<ResourceGroupResourceIdentifier, ResourceModel2, ResourceModel2Data>
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceModel2Container"/> class for mocking. </summary>
        protected ResourceModel2Container()
        {
        }

        /// <summary> Initializes a new instance of ResourceModel2Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResourceModel2Container(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ResourceModel2SRestOperations _restClient => new ResourceModel2SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<ResourceModel2> CreateOrUpdate(string resourceModel2SName, ResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (resourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(resourceModel2SName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<ResourceModel2>> CreateOrUpdateAsync(string resourceModel2SName, ResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (resourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(resourceModel2SName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResourceModel2SPutOperation StartCreateOrUpdate(string resourceModel2SName, ResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (resourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, resourceModel2SName, parameters, cancellationToken);
                return new ResourceModel2SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResourceModel2SPutOperation> StartCreateOrUpdateAsync(string resourceModel2SName, ResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (resourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, resourceModel2SName, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourceModel2SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ResourceModel2> Get(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.Get");
            scope.Start();
            try
            {
                if (resourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(resourceModel2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, resourceModel2SName, cancellationToken: cancellationToken);
                return Response.FromValue(new ResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ResourceModel2>> GetAsync(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.Get");
            scope.Start();
            try
            {
                if (resourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(resourceModel2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, resourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ResourceModel2 TryGet(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.TryGet");
            scope.Start();
            try
            {
                if (resourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(resourceModel2SName));
                }

                return Get(resourceModel2SName, cancellationToken: cancellationToken).Value;
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
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ResourceModel2> TryGetAsync(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.TryGet");
            scope.Start();
            try
            {
                if (resourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(resourceModel2SName));
                }

                return await GetAsync(resourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.DoesExist");
            scope.Start();
            try
            {
                if (resourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(resourceModel2SName));
                }

                return TryGet(resourceModel2SName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string resourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.DoesExist");
            scope.Start();
            try
            {
                if (resourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(resourceModel2SName));
                }

                return await TryGetAsync(resourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResourceModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResourceModel2Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResourceModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel2Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResourceModel2Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ResourceModel2, ResourceModel2Data> Construct() { }
    }
}
