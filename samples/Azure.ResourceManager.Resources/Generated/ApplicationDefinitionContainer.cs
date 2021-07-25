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

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of ApplicationDefinition and their operations over a ResourceGroup. </summary>
    public partial class ApplicationDefinitionContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ApplicationDefinition, ApplicationDefinitionData>
    {
        /// <summary> Initializes a new instance of the <see cref="ApplicationDefinitionContainer"/> class for mocking. </summary>
        protected ApplicationDefinitionContainer()
        {
        }

        /// <summary> Initializes a new instance of ApplicationDefinitionContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ApplicationDefinitionContainer(OperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ApplicationDefinitionsRestOperations _restClient => new ApplicationDefinitionsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> Creates a new managed application definition. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="parameters"> Parameters supplied to the create or update an managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<ApplicationDefinition> CreateOrUpdate(string applicationDefinitionName, ApplicationDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (applicationDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(applicationDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(applicationDefinitionName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new managed application definition. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="parameters"> Parameters supplied to the create or update an managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<ApplicationDefinition>> CreateOrUpdateAsync(string applicationDefinitionName, ApplicationDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (applicationDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(applicationDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(applicationDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new managed application definition. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="parameters"> Parameters supplied to the create or update an managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ApplicationDefinitionsCreateOrUpdateOperation StartCreateOrUpdate(string applicationDefinitionName, ApplicationDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (applicationDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(applicationDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, applicationDefinitionName, parameters, cancellationToken);
                return new ApplicationDefinitionsCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, applicationDefinitionName, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new managed application definition. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="parameters"> Parameters supplied to the create or update an managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ApplicationDefinitionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string applicationDefinitionName, ApplicationDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (applicationDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(applicationDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, applicationDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                return new ApplicationDefinitionsCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, applicationDefinitionName, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ApplicationDefinition> Get(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.Get");
            scope.Start();
            try
            {
                if (applicationDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(applicationDefinitionName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, applicationDefinitionName, cancellationToken: cancellationToken);
                return Response.FromValue(new ApplicationDefinition(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ApplicationDefinition>> GetAsync(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.Get");
            scope.Start();
            try
            {
                if (applicationDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(applicationDefinitionName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, applicationDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ApplicationDefinition(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual ApplicationDefinition TryGet(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.TryGet");
            scope.Start();
            try
            {
                if (applicationDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(applicationDefinitionName));
                }

                return Get(applicationDefinitionName, cancellationToken: cancellationToken).Value;
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
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<ApplicationDefinition> TryGetAsync(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.TryGet");
            scope.Start();
            try
            {
                if (applicationDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(applicationDefinitionName));
                }

                return await GetAsync(applicationDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual bool DoesExist(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.DoesExist");
            scope.Start();
            try
            {
                if (applicationDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(applicationDefinitionName));
                }

                return TryGet(applicationDefinitionName, cancellationToken: cancellationToken) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<bool> DoesExistAsync(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.DoesExist");
            scope.Start();
            try
            {
                if (applicationDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(applicationDefinitionName));
                }

                return await TryGetAsync(applicationDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false) != null;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists the managed application definitions in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApplicationDefinition" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ApplicationDefinition> ListByResourceGroup(CancellationToken cancellationToken = default)
        {
            Page<ApplicationDefinition> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApplicationDefinition> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the managed application definitions in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApplicationDefinition" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ApplicationDefinition> ListByResourceGroupAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ApplicationDefinition>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApplicationDefinition>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="ApplicationDefinition" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<Core.GenericResourceExpanded> ListAsGenericResource(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ApplicationDefinitionOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ApplicationDefinition" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<Core.GenericResourceExpanded> ListAsGenericResourceAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApplicationDefinitionContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ApplicationDefinitionOperations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ApplicationDefinition, ApplicationDefinitionData> Construct() { }
    }
}
