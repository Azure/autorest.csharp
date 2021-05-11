// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of ProximityPlacementGroup and their operations over a ResourceGroup. </summary>
    public partial class ProximityPlacementGroupContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ProximityPlacementGroup, ProximityPlacementGroupData>
    {
        /// <summary> Initializes a new instance of the <see cref="ProximityPlacementGroupContainer"/> class for mocking. </summary>
        protected ProximityPlacementGroupContainer()
        {
        }

        /// <summary> Initializes a new instance of ProximityPlacementGroupContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ProximityPlacementGroupContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ProximityPlacementGroupsRestOperations _restClient => new ProximityPlacementGroupsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<ProximityPlacementGroup> CreateOrUpdate(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(proximityPlacementGroupName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<ProximityPlacementGroup>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<ProximityPlacementGroup>> CreateOrUpdateAsync(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(proximityPlacementGroupName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<ProximityPlacementGroup>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<ProximityPlacementGroup> StartCreateOrUpdate(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken: cancellationToken);
                return new PhArmOperation<ProximityPlacementGroup, ProximityPlacementGroupData>(
                originalResponse,
                data => new ProximityPlacementGroup(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Proximity Placement Group operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<ProximityPlacementGroup>> StartCreateOrUpdateAsync(string proximityPlacementGroupName, ProximityPlacementGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, proximityPlacementGroupName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<ProximityPlacementGroup, ProximityPlacementGroupData>(
                originalResponse,
                data => new ProximityPlacementGroup(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<ProximityPlacementGroup> Get(string proximityPlacementGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.Get");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, proximityPlacementGroupName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new ProximityPlacementGroup(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="proximityPlacementGroupName"> The name of the proximity placement group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<ProximityPlacementGroup>> GetAsync(string proximityPlacementGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.Get");
            scope.Start();
            try
            {
                if (proximityPlacementGroupName == null)
                {
                    throw new ArgumentNullException(nameof(proximityPlacementGroupName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, proximityPlacementGroupName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new ProximityPlacementGroup(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ProximityPlacementGroup for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ProximityPlacementGroupOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ProximityPlacementGroup for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ProximityPlacementGroupOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ProximityPlacementGroup" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ProximityPlacementGroup" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ProximityPlacementGroup> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                Page<ProximityPlacementGroup> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<ProximityPlacementGroup> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, ProximityPlacementGroup>(results, genericResource => new ProximityPlacementGroupOperations(genericResource).Get().Value);
            }
        }

        /// <summary> Filters the list of <see cref="ProximityPlacementGroup" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ProximityPlacementGroup" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ProximityPlacementGroup> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                async Task<Page<ProximityPlacementGroup>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<ProximityPlacementGroup>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("ProximityPlacementGroupContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new ProximityPlacementGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, ProximityPlacementGroup>(results, genericResource => new ProximityPlacementGroupOperations(genericResource).Get().Value);
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, ProximityPlacementGroup, ProximityPlacementGroupData> Construct() { }
    }
}
