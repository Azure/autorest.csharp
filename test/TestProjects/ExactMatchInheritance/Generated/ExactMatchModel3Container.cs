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
using ExactMatchInheritance.Models;

namespace ExactMatchInheritance
{
    /// <summary> A class representing collection of ExactMatchModel3 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel3Container : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ExactMatchModel3SRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel3Container"/> class for mocking. </summary>
        protected ExactMatchModel3Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel3Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel3Container(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ExactMatchModel3SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Container level operations.

        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel3 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel3SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ExactMatchModel3PutOperation CreateOrUpdate(string exactMatchModel3SName, ExactMatchModel3Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel3SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel3SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, exactMatchModel3SName, parameters, cancellationToken);
                var operation = new ExactMatchModel3PutOperation(Parent, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel3 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel3SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ExactMatchModel3PutOperation> CreateOrUpdateAsync(string exactMatchModel3SName, ExactMatchModel3Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel3SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel3SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, exactMatchModel3SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ExactMatchModel3PutOperation(Parent, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExactMatchModel3> Get(string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel3SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel3SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, exactMatchModel3SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel3(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExactMatchModel3>> GetAsync(string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel3SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel3SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, exactMatchModel3SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ExactMatchModel3(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExactMatchModel3> GetIfExists(string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.GetIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel3SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel3SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, exactMatchModel3SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ExactMatchModel3>(null, response.GetRawResponse())
                    : Response.FromValue(new ExactMatchModel3(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExactMatchModel3>> GetIfExistsAsync(string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.GetIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel3SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel3SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, exactMatchModel3SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ExactMatchModel3>(null, response.GetRawResponse())
                    : Response.FromValue(new ExactMatchModel3(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.CheckIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel3SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel3SName));
                }

                var response = GetIfExists(exactMatchModel3SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string exactMatchModel3SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.CheckIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel3SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel3SName));
                }

                var response = await GetIfExistsAsync(exactMatchModel3SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel3" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel3.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel3" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel3Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel3.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, ExactMatchModel3, ExactMatchModel3Data> Construct() { }
    }
}
