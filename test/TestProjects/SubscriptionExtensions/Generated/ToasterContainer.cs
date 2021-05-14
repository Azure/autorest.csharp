// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using SubscriptionExtensions.Models;

namespace SubscriptionExtensions
{
    /// <summary> A class representing collection of Toaster and their operations over a Subscription. </summary>
    public partial class ToasterContainer : ContainerBase<SubscriptionResourceIdentifier>
    {
        /// <summary> Initializes a new instance of the <see cref="ToasterContainer"/> class for mocking. </summary>
        protected ToasterContainer()
        {
        }

        /// <summary> Initializes a new instance of ToasterContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ToasterContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ToastersRestOperations _restClient => new ToastersRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => SubscriptionOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<Toaster> CreateOrUpdate(string availabilitySetName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (availabilitySetName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(availabilitySetName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as Response<Toaster>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<Toaster>> CreateOrUpdateAsync(string availabilitySetName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (availabilitySetName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(availabilitySetName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as Response<Toaster>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Operation<Toaster> StartCreateOrUpdate(string availabilitySetName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (availabilitySetName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, availabilitySetName, parameters, cancellationToken: cancellationToken);
                return new ToastersCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Operation<Toaster>> StartCreateOrUpdateAsync(string availabilitySetName, ToasterData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (availabilitySetName == null)
                {
                    throw new ArgumentNullException(nameof(availabilitySetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, availabilitySetName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ToastersCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of Toaster for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ToasterOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of Toaster for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ToasterContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ToasterOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Toaster" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="Toaster" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<Toaster> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, Toaster>(results, genericResource => new ToasterOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="Toaster" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="Toaster" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<Toaster> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, Toaster>(results, genericResource => new ToasterOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<SubscriptionResourceIdentifier, Toaster, ToasterData> Construct() { }
    }
}
