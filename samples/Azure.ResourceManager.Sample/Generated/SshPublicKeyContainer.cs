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
    /// <summary> A class representing collection of SshPublicKey and their operations over a ResourceGroup. </summary>
    public partial class SshPublicKeyContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, SshPublicKey, SshPublicKeyData>
    {
        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyContainer"/> class for mocking. </summary>
        protected SshPublicKeyContainer()
        {
        }

        /// <summary> Initializes a new instance of SshPublicKeyContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SshPublicKeyContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private SshPublicKeysRestOperations _restClient => new SshPublicKeysRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="parameters"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<SshPublicKey> CreateOrUpdate(string sshPublicKeyName, SshPublicKeyData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (sshPublicKeyName == null)
                {
                    throw new ArgumentNullException(nameof(sshPublicKeyName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(sshPublicKeyName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<SshPublicKey>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="parameters"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<SshPublicKey>> CreateOrUpdateAsync(string sshPublicKeyName, SshPublicKeyData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (sshPublicKeyName == null)
                {
                    throw new ArgumentNullException(nameof(sshPublicKeyName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(sshPublicKeyName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<SshPublicKey>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="parameters"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<SshPublicKey> StartCreateOrUpdate(string sshPublicKeyName, SshPublicKeyData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (sshPublicKeyName == null)
                {
                    throw new ArgumentNullException(nameof(sshPublicKeyName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Create(Id.ResourceGroupName, sshPublicKeyName, parameters, cancellationToken: cancellationToken);
                return new PhArmOperation<SshPublicKey, SshPublicKeyData>(
                originalResponse,
                data => new SshPublicKey(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="parameters"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<SshPublicKey>> StartCreateOrUpdateAsync(string sshPublicKeyName, SshPublicKeyData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (sshPublicKeyName == null)
                {
                    throw new ArgumentNullException(nameof(sshPublicKeyName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateAsync(Id.ResourceGroupName, sshPublicKeyName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<SshPublicKey, SshPublicKeyData>(
                originalResponse,
                data => new SshPublicKey(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<SshPublicKey> Get(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.Get");
            scope.Start();
            try
            {
                if (sshPublicKeyName == null)
                {
                    throw new ArgumentNullException(nameof(sshPublicKeyName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new SshPublicKey(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<SshPublicKey>> GetAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.Get");
            scope.Start();
            try
            {
                if (sshPublicKeyName == null)
                {
                    throw new ArgumentNullException(nameof(sshPublicKeyName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new SshPublicKey(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SshPublicKey for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SshPublicKeyOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SshPublicKey for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SshPublicKeyOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SshPublicKey" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="SshPublicKey" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<SshPublicKey> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                Page<SshPublicKey> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<SshPublicKey> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
                return new PhWrappingPageable<GenericResource, SshPublicKey>(results, genericResource => new SshPublicKeyOperations(genericResource).Get().Value);
            }
        }

        /// <summary> Filters the list of <see cref="SshPublicKey" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="SshPublicKey" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<SshPublicKey> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                async Task<Page<SshPublicKey>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<SshPublicKey>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("SshPublicKeyContainer.ListByResourceGroup");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
                return new PhWrappingAsyncPageable<GenericResource, SshPublicKey>(results, genericResource => new SshPublicKeyOperations(genericResource).Get().Value);
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, SshPublicKey, SshPublicKeyData> Construct() { }
    }
}
