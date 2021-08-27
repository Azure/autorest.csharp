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
    /// <summary> A class representing collection of ExactMatchModel5 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel5Container : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ExactMatchModel5SRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel5Container"/> class for mocking. </summary>
        protected ExactMatchModel5Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel5Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel5Container(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ExactMatchModel5SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Container level operations.

        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ExactMatchModel5PutOperation CreateOrUpdate(string exactMatchModel5SName, ExactMatchModel5Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken);
                var operation = new ExactMatchModel5PutOperation(Parent, response);
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

        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel5SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ExactMatchModel5PutOperation> CreateOrUpdateAsync(string exactMatchModel5SName, ExactMatchModel5Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (exactMatchModel5SName == null)
            {
                throw new ArgumentNullException(nameof(exactMatchModel5SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ExactMatchModel5PutOperation(Parent, response);
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
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExactMatchModel5> Get(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExactMatchModel5>> GetAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.Get");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ExactMatchModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExactMatchModel5> GetIfExists(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.GetIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ExactMatchModel5>(null, response.GetRawResponse())
                    : Response.FromValue(new ExactMatchModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExactMatchModel5>> GetIfExistsAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.GetIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ExactMatchModel5>(null, response.GetRawResponse())
                    : Response.FromValue(new ExactMatchModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CheckIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = GetIfExists(exactMatchModel5SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string exactMatchModel5SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CheckIfExists");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }

                var response = await GetIfExistsAsync(exactMatchModel5SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, ExactMatchModel5, ExactMatchModel5Data> Construct() { }
    }
}
