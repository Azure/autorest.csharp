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

namespace ExactMatchInheritance
{
    /// <summary> A class representing collection of ExactMatchModel1 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel1Container : ResourceContainerBase<ResourceGroupResourceIdentifier, ExactMatchModel1, ExactMatchModel1Data>
    {
        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel1Container"/> class for mocking. </summary>
        protected ExactMatchModel1Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel1Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel1Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ExactMatchModel1SRestOperations _restClient => new ExactMatchModel1SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public Response<ExactMatchModel1> Put(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel1SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.Put");
            scope.Start();
            try
            {
                var operation = StartPut(exactMatchModel1SName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async Task<Response<ExactMatchModel1>> PutAsync(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel1SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.Put");
            scope.Start();
            try
            {
                var operation = await StartPutAsync(exactMatchModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public ExactMatchModel1SPutOperation StartPut(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel1SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.StartPut");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, exactMatchModel1SName, parameters, cancellationToken);
                return new ExactMatchModel1SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async Task<ExactMatchModel1SPutOperation> StartPutAsync(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel1SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.StartPut");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, exactMatchModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                return new ExactMatchModel1SPutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<ExactMatchModel1> Get(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, exactMatchModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(new ExactMatchModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<ExactMatchModel1>> GetAsync(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, exactMatchModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ExactMatchModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel1Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel1Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ExactMatchModel1, ExactMatchModel1Data> Construct() { }
    }
}
