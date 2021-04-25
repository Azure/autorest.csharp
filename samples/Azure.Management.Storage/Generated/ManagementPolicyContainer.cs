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
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of ManagementPolicy and their operations over a [ParentResource]. </summary>
    public partial class ManagementPolicyContainer : ResourceContainerBase<TenantResourceIdentifier, ManagementPolicy, ManagementPolicyData>
    {
        /// <summary> Initializes a new instance of ManagementPolicyContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ManagementPolicyContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ManagementPoliciesRestOperations Operations => new ManagementPoliciesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => StorageAccountOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="managementPolicyName"> The name of the Storage Account Management Policy. It should always be &apos;default&apos;. </param>
        /// <param name="policy"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<ManagementPolicy> CreateOrUpdate(ManagementPolicyName managementPolicyName, ManagementPolicySchema policy = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                return StartCreateOrUpdate(managementPolicyName, policy, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<ManagementPolicy>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="managementPolicyName"> The name of the Storage Account Management Policy. It should always be &apos;default&apos;. </param>
        /// <param name="policy"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<ManagementPolicy>> CreateOrUpdateAsync(ManagementPolicyName managementPolicyName, ManagementPolicySchema policy = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.CreateOrUpdateAsync");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(managementPolicyName, policy, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<ManagementPolicy>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="managementPolicyName"> The name of the Storage Account Management Policy. It should always be &apos;default&apos;. </param>
        /// <param name="policy"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<ManagementPolicy> StartCreateOrUpdate(ManagementPolicyName managementPolicyName, ManagementPolicySchema policy = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = Operations.CreateOrUpdate(Id.ResourceGroupName, Id.Name, managementPolicyName, policy, cancellationToken: cancellationToken);
                return new PhArmOperation<ManagementPolicy, ManagementPolicyData>(
                originalResponse,
                data => new ManagementPolicy(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="managementPolicyName"> The name of the Storage Account Management Policy. It should always be &apos;default&apos;. </param>
        /// <param name="policy"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<ManagementPolicy>> StartCreateOrUpdateAsync(ManagementPolicyName managementPolicyName, ManagementPolicySchema policy = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.StartCreateOrUpdateAsync");
            scope.Start();
            try
            {
                var originalResponse = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, managementPolicyName, policy, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<ManagementPolicy, ManagementPolicyData>(
                originalResponse,
                data => new ManagementPolicy(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override ArmResponse<ManagementPolicy> CreateOrUpdate(string name, ManagementPolicyData resourceDetails, CancellationToken cancellationToken = default)
        {
            // There is no create or update method in ManagementPoliciesRestOperations that accepts ManagementPolicyData
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<ManagementPolicy>> CreateOrUpdateAsync(string name, ManagementPolicyData resourceDetails, CancellationToken cancellationToken = default)
        {
            // There is no create or update method in ManagementPoliciesRestOperations that accepts ManagementPolicyData
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override ArmOperation<ManagementPolicy> StartCreateOrUpdate(string name, ManagementPolicyData resourceDetails, CancellationToken cancellationToken = default)
        {
            // There is no create or update method in ManagementPoliciesRestOperations that accepts ManagementPolicyData
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmOperation<ManagementPolicy>> StartCreateOrUpdateAsync(string name, ManagementPolicyData resourceDetails, CancellationToken cancellationToken = default)
        {
            // There is no create or update method in ManagementPoliciesRestOperations that accepts ManagementPolicyData
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <param name="managementPolicyName"> The name of the Storage Account Management Policy. It should always be &apos;default&apos;. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<ManagementPolicy> Get(string managementPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.Get");
            scope.Start();
            try
            {
                return new PhArmResponse<ManagementPolicy, ManagementPolicyData>(
                Operations.Get(Id.ResourceGroupName, Id.Name, managementPolicyName, cancellationToken: cancellationToken),
                data => new ManagementPolicy(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="managementPolicyName"> The name of the Storage Account Management Policy. It should always be &apos;default&apos;. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<ManagementPolicy>> GetAsync(string managementPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.GetAsync");
            scope.Start();
            try
            {
                return new PhArmResponse<ManagementPolicy, ManagementPolicyData>(
                await Operations.GetAsync(Id.ResourceGroupName, Id.Name, managementPolicyName, cancellationToken: cancellationToken),
                data => new ManagementPolicy(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ManagementPolicy for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ManagementPolicyData.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ManagementPolicy for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.ListAsGenericResourceAsync");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ManagementPolicyData.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ManagementPolicy" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ManagementPolicy" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ManagementPolicy> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, ManagementPolicy>(results, genericResource => new ManagementPolicyOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ManagementPolicy" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ManagementPolicy" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ManagementPolicy> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ManagementPolicyContainer.ListAsync");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, ManagementPolicy>(results, genericResource => new ManagementPolicyOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, ManagementPolicy, ManagementPolicyData> Construct() { }
    }
}
