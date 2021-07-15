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
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> A class representing collection of AvailabilitySetChild and their operations over a AvailabilitySet. </summary>
    public partial class AvailabilitySetChildContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, AvailabilitySetChild, AvailabilitySetChildData>
    {
        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetChildContainer"/> class for mocking. </summary>
        protected AvailabilitySetChildContainer()
        {
        }

        /// <summary> Initializes a new instance of AvailabilitySetChildContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AvailabilitySetChildContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private AvailabilitySetChildRestOperations _restClient => new AvailabilitySetChildRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => AvailabilitySetOperations.ResourceType;

        // Container level operations.

        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<AvailabilitySetChild> CreateOrUpdate(string availabilitySetChildName, AvailabilitySetChildData parameters, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(availabilitySetChildName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<AvailabilitySetChild>> CreateOrUpdateAsync(string availabilitySetChildName, AvailabilitySetChildData parameters, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(availabilitySetChildName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual AvailabilitySetChildCreateOrUpdateOperation StartCreateOrUpdate(string availabilitySetChildName, AvailabilitySetChildData parameters, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Name, availabilitySetChildName, parameters, cancellationToken);
                return new AvailabilitySetChildCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update an availability set. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<AvailabilitySetChildCreateOrUpdateOperation> StartCreateOrUpdateAsync(string availabilitySetChildName, AvailabilitySetChildData parameters, CancellationToken cancellationToken = default)
        {
            if (availabilitySetChildName == null)
            {
                throw new ArgumentNullException(nameof(availabilitySetChildName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, availabilitySetChildName, parameters, cancellationToken).ConfigureAwait(false);
                return new AvailabilitySetChildCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<AvailabilitySetChild> Get(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.Get");
            scope.Start();
            try
            {
                if (availabilitySetChildName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetChildName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken: cancellationToken);
                return Response.FromValue(new AvailabilitySetChild(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<AvailabilitySetChild>> GetAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.Get");
            scope.Start();
            try
            {
                if (availabilitySetChildName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetChildName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySetChild(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual AvailabilitySetChild TryGet(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.TryGet");
            scope.Start();
            try
            {
                if (availabilitySetChildName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetChildName));
                }

                return Get(availabilitySetChildName, cancellationToken: cancellationToken).Value;
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
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<AvailabilitySetChild> TryGetAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.TryGet");
            scope.Start();
            try
            {
                if (availabilitySetChildName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetChildName));
                }

                return await GetAsync(availabilitySetChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.DoesExist");
            scope.Start();
            try
            {
                if (availabilitySetChildName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetChildName));
                }

                return TryGet(availabilitySetChildName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.DoesExist");
            scope.Start();
            try
            {
                if (availabilitySetChildName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetChildName));
                }

                return await TryGetAsync(availabilitySetChildName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of AvailabilitySetChild for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AvailabilitySetChildOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of AvailabilitySetChild for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AvailabilitySetChildContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AvailabilitySetChildOperations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, AvailabilitySetChild, AvailabilitySetChildData> Construct() { }
    }
}
