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
using ExactMatchFlattenInheritance.Models;

namespace ExactMatchFlattenInheritance
{
    /// <summary> A class representing collection of AzureResourceFlattenModel5 and their operations over a ResourceGroup. </summary>
    public partial class AzureResourceFlattenModel5Collection : ArmCollection, IEnumerable<AzureResourceFlattenModel5>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AzureResourceFlattenModel5SRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="AzureResourceFlattenModel5Collection"/> class for mocking. </summary>
        protected AzureResourceFlattenModel5Collection()
        {
        }

        /// <summary> Initializes a new instance of AzureResourceFlattenModel5Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AzureResourceFlattenModel5Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new AzureResourceFlattenModel5SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        IEnumerator<AzureResourceFlattenModel5> IEnumerable<AzureResourceFlattenModel5>.GetEnumerator()
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

        /// <summary> Create or update an AzureResourceFlattenModel5. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual AzureResourceFlattenModel5PutOperation CreateOrUpdate(string name, int? foo = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, name, foo, cancellationToken);
                var operation = new AzureResourceFlattenModel5PutOperation(Parent, response);
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

        /// <summary> Create or update an AzureResourceFlattenModel5. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async virtual Task<AzureResourceFlattenModel5PutOperation> CreateOrUpdateAsync(string name, int? foo = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, name, foo, cancellationToken).ConfigureAwait(false);
                var operation = new AzureResourceFlattenModel5PutOperation(Parent, response);
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
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<AzureResourceFlattenModel5> Get(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.Get");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = _restClient.Get(Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AzureResourceFlattenModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<AzureResourceFlattenModel5>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.Get");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new AzureResourceFlattenModel5(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<AzureResourceFlattenModel5> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.GetIfExists");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = _restClient.Get(Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<AzureResourceFlattenModel5>(null, response.GetRawResponse())
                    : Response.FromValue(new AzureResourceFlattenModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<AzureResourceFlattenModel5>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.GetIfExists");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<AzureResourceFlattenModel5>(null, response.GetRawResponse())
                    : Response.FromValue(new AzureResourceFlattenModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.CheckIfExists");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = GetIfExists(name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.CheckIfExists");
            scope.Start();
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                var response = await GetIfExistsAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an AzureResourceFlattenModel5. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<AzureResourceFlattenModel5>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.GetAll");
            scope.Start();
            try
            {
                var response = await _restClient.GetAllAsync(Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(data => new AzureResourceFlattenModel5(Parent, data)).ToArray() as IReadOnlyList<AzureResourceFlattenModel5>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an AzureResourceFlattenModel5. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<AzureResourceFlattenModel5>> GetAll(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.GetAll");
            scope.Start();
            try
            {
                var response = _restClient.GetAll(Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(data => new AzureResourceFlattenModel5(Parent, data)).ToArray() as IReadOnlyList<AzureResourceFlattenModel5>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="AzureResourceFlattenModel5" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AzureResourceFlattenModel5.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="AzureResourceFlattenModel5" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AzureResourceFlattenModel5Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AzureResourceFlattenModel5.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, AzureResourceFlattenModel5, AzureResourceFlattenModel5Data> Construct() { }
    }
}
