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
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;
using MgmtExtensionResource.Models;

namespace MgmtExtensionResource
{
    /// <summary> A class representing collection of PolicyDefinition and their operations over a Tenant. </summary>
    public partial class PolicyDefinitionContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly PolicyDefinitionsRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="PolicyDefinitionContainer"/> class for mocking. </summary>
        protected PolicyDefinitionContainer()
        {
        }

        /// <summary> Initializes a new instance of PolicyDefinitionContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal PolicyDefinitionContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new PolicyDefinitionsRestOperations(_clientDiagnostics, Pipeline, BaseUri);
        }

        /// <summary> Verify that the input resource Id is a valid container for this type. </summary>
        /// <param name="identifier"> The input resource Id to check. </param>
        protected override void ValidateResourceType(ResourceIdentifier identifier)
        {
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        // Container level operations.

        /// <summary> This operation creates or updates a policy definition in the given subscription with the given name. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to create. </param>
        /// <param name="parameters"> The policy definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<PolicyDefinition> CreateOrUpdate(string policyDefinitionName, PolicyDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (policyDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(policyDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(policyDefinitionName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation creates or updates a policy definition in the given subscription with the given name. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to create. </param>
        /// <param name="parameters"> The policy definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<PolicyDefinition>> CreateOrUpdateAsync(string policyDefinitionName, PolicyDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (policyDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(policyDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(policyDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation creates or updates a policy definition in the given subscription with the given name. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to create. </param>
        /// <param name="parameters"> The policy definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual PolicyDefinitionCreateOrUpdateOperation StartCreateOrUpdate(string policyDefinitionName, PolicyDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (policyDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(policyDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (Id.TryGetSubscriptionId(out _))
                {
                    var response = _restClient.CreateOrUpdate(Id.Name, policyDefinitionName, parameters, cancellationToken);
                    return new PolicyDefinitionCreateOrUpdateOperation(Parent, response);
                }
                else
                {
                    var response = _restClient.CreateOrUpdateAtManagementGroup(Id.Name, policyDefinitionName, parameters, cancellationToken);
                    return new PolicyDefinitionCreateOrUpdateOperation(Parent, response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation creates or updates a policy definition in the given subscription with the given name. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to create. </param>
        /// <param name="parameters"> The policy definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<PolicyDefinitionCreateOrUpdateOperation> StartCreateOrUpdateAsync(string policyDefinitionName, PolicyDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            if (policyDefinitionName == null)
            {
                throw new ArgumentNullException(nameof(policyDefinitionName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (Id.TryGetSubscriptionId(out _))
                {
                    var response = await _restClient.CreateOrUpdateAsync(Id.Name, policyDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                    return new PolicyDefinitionCreateOrUpdateOperation(Parent, response);
                }
                else
                {
                    var response = await _restClient.CreateOrUpdateAtManagementGroupAsync(Id.Name, policyDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                    return new PolicyDefinitionCreateOrUpdateOperation(Parent, response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<PolicyDefinition> Get(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.Get");
            scope.Start();
            try
            {
                if (policyDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(policyDefinitionName));
                }

                if (Id.TryGetSubscriptionId(out _))
                {
                    var response = _restClient.Get(Id.Name, policyDefinitionName, cancellationToken: cancellationToken);
                    if (response.Value == null)
                        throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                    return Response.FromValue(new PolicyDefinition(Parent, response.Value), response.GetRawResponse());
                }
                else
                {
                    var parent = Id;
                    while (parent.Parent != ResourceIdentifier.RootResourceIdentifier)
                    {
                        parent = parent.Parent;
                    }
                    if (parent.ResourceType.Equals(ManagementGroup.ResourceType))
                    {
                        var response = _restClient.GetAtManagementGroup(Id.Name, policyDefinitionName, cancellationToken: cancellationToken);
                        if (response.Value == null)
                            throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                        return Response.FromValue(new PolicyDefinition(Parent, response.Value), response.GetRawResponse());
                    }
                    else
                    {
                        var response = _restClient.GetBuiltIn(policyDefinitionName, cancellationToken: cancellationToken);
                        if (response.Value == null)
                            throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                        return Response.FromValue(new PolicyDefinition(Parent, response.Value), response.GetRawResponse());
                    }
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<PolicyDefinition>> GetAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.Get");
            scope.Start();
            try
            {
                if (policyDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(policyDefinitionName));
                }

                if (Id.TryGetSubscriptionId(out _))
                {
                    var response = await _restClient.GetAsync(Id.Name, policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    if (response.Value == null)
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                    return Response.FromValue(new PolicyDefinition(Parent, response.Value), response.GetRawResponse());
                }
                else
                {
                    var parent = Id;
                    while (parent.Parent != ResourceIdentifier.RootResourceIdentifier)
                    {
                        parent = parent.Parent;
                    }
                    if (parent.ResourceType.Equals(ManagementGroup.ResourceType))
                    {
                        var response = await _restClient.GetAtManagementGroupAsync(Id.Name, policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        if (response.Value == null)
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                        return Response.FromValue(new PolicyDefinition(Parent, response.Value), response.GetRawResponse());
                    }
                    else
                    {
                        var response = await _restClient.GetBuiltInAsync(policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        if (response.Value == null)
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                        return Response.FromValue(new PolicyDefinition(Parent, response.Value), response.GetRawResponse());
                    }
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<PolicyDefinition> GetIfExists(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetIfExists");
            scope.Start();
            try
            {
                if (policyDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(policyDefinitionName));
                }

                var response = _restClient.Get(Id.Name, policyDefinitionName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<PolicyDefinition>(null, response.GetRawResponse())
                    : Response.FromValue(new PolicyDefinition(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<PolicyDefinition>> GetIfExistsAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetIfExists");
            scope.Start();
            try
            {
                if (policyDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(policyDefinitionName));
                }

                var response = await _restClient.GetAsync(Id.Name, policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<PolicyDefinition>(null, response.GetRawResponse())
                    : Response.FromValue(new PolicyDefinition(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (policyDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(policyDefinitionName));
                }

                var response = GetIfExists(policyDefinitionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="policyDefinitionName"> The name of the policy definition to get. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (policyDefinitionName == null)
                {
                    throw new ArgumentNullException(nameof(policyDefinitionName));
                }

                var response = await GetIfExistsAsync(policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> This operation retrieves a list of all the policy definitions in a given subscription that match the optional given $filter. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy definitions associated with the subscription, including those that apply directly or from management groups that contain the given subscription. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given subscription. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyDefinition> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyDefinition> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetAll");
                scope.Start();
                try
                {
                    if (Id.TryGetSubscriptionId(out _))
                    {
                        var response = _restClient.GetAll(Id.Name, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    else
                    {
                        var parent = Id;
                        while (parent.Parent != ResourceIdentifier.RootResourceIdentifier)
                        {
                            parent = parent.Parent;
                        }
                        if (parent.ResourceType.Equals(ManagementGroup.ResourceType))
                        {
                            var response = _restClient.GetByManagementGroup(Id.Name, filter, top, cancellationToken: cancellationToken);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                        else
                        {
                            var response = _restClient.GetBuiltIn(filter, top, cancellationToken: cancellationToken);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PolicyDefinition> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetAll");
                scope.Start();
                try
                {
                    if (Id.TryGetSubscriptionId(out _))
                    {
                        var response = _restClient.GetAllNextPage(nextLink, Id.Name, filter, top, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    else
                    {
                        var parent = Id;
                        while (parent.Parent != ResourceIdentifier.RootResourceIdentifier)
                        {
                            parent = parent.Parent;
                        }
                        if (parent.ResourceType.Equals(ManagementGroup.ResourceType))
                        {
                            var response = _restClient.GetByManagementGroupNextPage(nextLink, Id.Name, filter, top, cancellationToken: cancellationToken);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                        else
                        {
                            var response = _restClient.GetBuiltInNextPage(nextLink, filter, top, cancellationToken: cancellationToken);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> This operation retrieves a list of all the policy definitions in a given subscription that match the optional given $filter. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy definitions associated with the subscription, including those that apply directly or from management groups that contain the given subscription. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given subscription. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyDefinition> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyDefinition>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetAll");
                scope.Start();
                try
                {
                    if (Id.TryGetSubscriptionId(out _))
                    {
                        var response = await _restClient.GetAllAsync(Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    else
                    {
                        var parent = Id;
                        while (parent.Parent != ResourceIdentifier.RootResourceIdentifier)
                        {
                            parent = parent.Parent;
                        }
                        if (parent.ResourceType.Equals(ManagementGroup.ResourceType))
                        {
                            var response = await _restClient.GetByManagementGroupAsync(Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                        else
                        {
                            var response = await _restClient.GetBuiltInAsync(filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PolicyDefinition>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetAll");
                scope.Start();
                try
                {
                    if (Id.TryGetSubscriptionId(out _))
                    {
                        var response = await _restClient.GetAllNextPageAsync(nextLink, Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    else
                    {
                        var parent = Id;
                        while (parent.Parent != ResourceIdentifier.RootResourceIdentifier)
                        {
                            parent = parent.Parent;
                        }
                        if (parent.ResourceType.Equals(ManagementGroup.ResourceType))
                        {
                            var response = await _restClient.GetByManagementGroupNextPageAsync(nextLink, Id.Name, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                        else
                        {
                            var response = await _restClient.GetBuiltInNextPageAsync(nextLink, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                            return Page.FromValues(response.Value.Value.Select(value => new PolicyDefinition(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                        }
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="PolicyDefinition" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(PolicyDefinition.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="PolicyDefinition" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolicyDefinitionContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(PolicyDefinition.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, PolicyDefinition, PolicyDefinitionData> Construct() { }
    }
}
