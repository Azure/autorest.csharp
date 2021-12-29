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
using NoTypeReplacement.Models;

namespace NoTypeReplacement
{
    /// <summary> A class representing collection of NoTypeReplacementModel2 and their operations over its parent. </summary>
    public partial class NoTypeReplacementModel2Collection : ArmCollection, IEnumerable<NoTypeReplacementModel2>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly NoTypeReplacementModel2SRestOperations _noTypeReplacementModel2sRestClient;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel2Collection"/> class for mocking. </summary>
        protected NoTypeReplacementModel2Collection()
        {
        }

        /// <summary> Initializes a new instance of NoTypeReplacementModel2Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal NoTypeReplacementModel2Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _noTypeReplacementModel2sRestClient = new NoTypeReplacementModel2SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="parameters"> The NoTypeReplacementModel2 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual NoTypeReplacementModel2SPutOperation CreateOrUpdate(string noTypeReplacementModel2SName, NoTypeReplacementModel2Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, parameters, cancellationToken);
                var operation = new NoTypeReplacementModel2SPutOperation(Parent, response);
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

        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="parameters"> The NoTypeReplacementModel2 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<NoTypeReplacementModel2SPutOperation> CreateOrUpdateAsync(string noTypeReplacementModel2SName, NoTypeReplacementModel2Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NoTypeReplacementModel2SPutOperation(Parent, response);
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

        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel2> Get(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public async virtual Task<Response<NoTypeReplacementModel2>> GetAsync(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NoTypeReplacementModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel2> GetIfExists(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<NoTypeReplacementModel2>(null, response.GetRawResponse())
                    : Response.FromValue(new NoTypeReplacementModel2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public async virtual Task<Response<NoTypeReplacementModel2>> GetIfExistsAsync(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<NoTypeReplacementModel2>(null, response.GetRawResponse())
                    : Response.FromValue(new NoTypeReplacementModel2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public virtual Response<bool> Exists(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(noTypeReplacementModel2SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel2SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(noTypeReplacementModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<NoTypeReplacementModel2>> GetAll(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.GetAll");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2sRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(value => new NoTypeReplacementModel2(Parent, value)).ToArray() as IReadOnlyList<NoTypeReplacementModel2>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<IReadOnlyList<NoTypeReplacementModel2>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.GetAll");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2sRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(value => new NoTypeReplacementModel2(Parent, value)).ToArray() as IReadOnlyList<NoTypeReplacementModel2>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="NoTypeReplacementModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(NoTypeReplacementModel2.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="NoTypeReplacementModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(NoTypeReplacementModel2.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NoTypeReplacementModel2> IEnumerable<NoTypeReplacementModel2>.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, NoTypeReplacementModel2, NoTypeReplacementModel2Data> Construct() { }
    }
}
