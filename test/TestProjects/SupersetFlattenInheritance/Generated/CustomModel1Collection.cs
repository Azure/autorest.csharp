// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary> A class representing collection of CustomModel1 and their operations over a ResourceGroup. </summary>
    public partial class CustomModel1Collection : ArmCollection, IEnumerable<CustomModel1>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly CustomModel1SRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="CustomModel1Collection"/> class for mocking. </summary>
        protected CustomModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of CustomModel1Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal CustomModel1Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new CustomModel1SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        IEnumerator<CustomModel1> IEnumerable<CustomModel1>.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="parameters"> The CustomModel1 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual CustomModel1PutOperation CreateOrUpdate(string customModel1SName, CustomModel1Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (customModel1SName == null)
            {
                throw new ArgumentNullException(nameof(customModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, customModel1SName, parameters, cancellationToken);
                var operation = new CustomModel1PutOperation(Parent, response);
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

        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="parameters"> The CustomModel1 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<CustomModel1PutOperation> CreateOrUpdateAsync(string customModel1SName, CustomModel1Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (customModel1SName == null)
            {
                throw new ArgumentNullException(nameof(customModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, customModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new CustomModel1PutOperation(Parent, response);
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
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<CustomModel1> Get(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.Get");
            scope.Start();
            try
            {
                if (customModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(customModel1SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, customModel1SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CustomModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<CustomModel1>> GetAsync(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.Get");
            scope.Start();
            try
            {
                if (customModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(customModel1SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, customModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new CustomModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<CustomModel1> GetIfExists(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                if (customModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(customModel1SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, customModel1SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<CustomModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new CustomModel1(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<CustomModel1>> GetIfExistsAsync(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                if (customModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(customModel1SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, customModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<CustomModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new CustomModel1(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.CheckIfExists");
            scope.Start();
            try
            {
                if (customModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(customModel1SName));
                }

                var response = GetIfExists(customModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="customModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string customModel1SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.CheckIfExists");
            scope.Start();
            try
            {
                if (customModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(customModel1SName));
                }

                var response = await GetIfExistsAsync(customModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<CustomModel1>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.GetAll");
            scope.Start();
            try
            {
                var response = await _restClient.GetAllAsync(Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(data => new CustomModel1(Parent, data)).ToArray() as IReadOnlyList<CustomModel1>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<CustomModel1>> GetAll(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.GetAll");
            scope.Start();
            try
            {
                var response = _restClient.GetAll(Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(data => new CustomModel1(Parent, data)).ToArray() as IReadOnlyList<CustomModel1>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="CustomModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(CustomModel1.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="CustomModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("CustomModel1Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(CustomModel1.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, CustomModel1, CustomModel1Data> Construct() { }
    }
}
