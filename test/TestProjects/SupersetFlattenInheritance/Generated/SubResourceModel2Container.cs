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
using SupersetFlattenInheritance.Models;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of SubResourceModel2 and their operations over a ResourceGroup. </summary>
    public partial class SubResourceModel2Container : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SubResourceModel2SRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="SubResourceModel2Container"/> class for mocking. </summary>
        protected SubResourceModel2Container()
        {
        }

        /// <summary> Initializes a new instance of SubResourceModel2Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubResourceModel2Container(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new SubResourceModel2SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Container level operations.

        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<SubResourceModel2> CreateOrUpdate(string subResourceModel2SName, SubResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(subResourceModel2SName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<SubResourceModel2>> CreateOrUpdateAsync(string subResourceModel2SName, SubResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(subResourceModel2SName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SubResourceModel2PutOperation StartCreateOrUpdate(string subResourceModel2SName, SubResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, subResourceModel2SName, parameters, cancellationToken);
                return new SubResourceModel2PutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SubResourceModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subResourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SubResourceModel2PutOperation> StartCreateOrUpdateAsync(string subResourceModel2SName, SubResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            if (subResourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(subResourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, subResourceModel2SName, parameters, cancellationToken).ConfigureAwait(false);
                return new SubResourceModel2PutOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<SubResourceModel2> Get(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.Get");
            scope.Start();
            try
            {
                if (subResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, subResourceModel2SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<SubResourceModel2>> GetAsync(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.Get");
            scope.Start();
            try
            {
                if (subResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, subResourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SubResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<SubResourceModel2> GetIfExists(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.GetIfExists");
            scope.Start();
            try
            {
                if (subResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, subResourceModel2SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<SubResourceModel2>(null, response.GetRawResponse())
                    : Response.FromValue(new SubResourceModel2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<SubResourceModel2>> GetIfExistsAsync(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.GetIfExists");
            scope.Start();
            try
            {
                if (subResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, subResourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<SubResourceModel2>(null, response.GetRawResponse())
                    : Response.FromValue(new SubResourceModel2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.CheckIfExists");
            scope.Start();
            try
            {
                if (subResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel2SName));
                }

                var response = GetIfExists(subResourceModel2SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string subResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.CheckIfExists");
            scope.Start();
            try
            {
                if (subResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(subResourceModel2SName));
                }

                var response = await GetIfExistsAsync(subResourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SubResourceModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubResourceModel2.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SubResourceModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubResourceModel2Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubResourceModel2.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, SubResourceModel2, SubResourceModel2Data> Construct() { }
    }
}
