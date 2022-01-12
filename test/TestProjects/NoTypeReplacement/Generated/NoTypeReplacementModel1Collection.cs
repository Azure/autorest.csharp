// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using NoTypeReplacement.Models;

namespace NoTypeReplacement
{
    /// <summary> A class representing collection of NoTypeReplacementModel1 and their operations over its parent. </summary>
    public partial class NoTypeReplacementModel1Collection : ArmCollection, IEnumerable<NoTypeReplacementModel1>, IAsyncEnumerable<NoTypeReplacementModel1>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly NoTypeReplacementModel1SRestOperations _noTypeReplacementModel1sRestClient;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Collection"/> class for mocking. </summary>
        protected NoTypeReplacementModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of NoTypeReplacementModel1Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal NoTypeReplacementModel1Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _noTypeReplacementModel1sRestClient = new NoTypeReplacementModel1SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="parameters"> The NoTypeReplacementModel1 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual NoTypeReplacementModel1SPutOperation CreateOrUpdate(bool waitForCompletion, string noTypeReplacementModel1SName, NoTypeReplacementModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, parameters, cancellationToken);
                var operation = new NoTypeReplacementModel1SPutOperation(Parent, response);
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

        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="parameters"> The NoTypeReplacementModel1 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<NoTypeReplacementModel1SPutOperation> CreateOrUpdateAsync(bool waitForCompletion, string noTypeReplacementModel1SName, NoTypeReplacementModel1Data parameters, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NoTypeReplacementModel1SPutOperation(Parent, response);
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

        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel1> Get(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public async virtual Task<Response<NoTypeReplacementModel1>> GetAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NoTypeReplacementModel1(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel1> GetIfExists(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<NoTypeReplacementModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new NoTypeReplacementModel1(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public async virtual Task<Response<NoTypeReplacementModel1>> GetIfExistsAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<NoTypeReplacementModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new NoTypeReplacementModel1(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(noTypeReplacementModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            if (noTypeReplacementModel1SName == null)
            {
                throw new ArgumentNullException(nameof(noTypeReplacementModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(noTypeReplacementModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NoTypeReplacementModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NoTypeReplacementModel1> GetAll(CancellationToken cancellationToken = default)
        {
            Page<NoTypeReplacementModel1> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _noTypeReplacementModel1sRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NoTypeReplacementModel1(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NoTypeReplacementModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NoTypeReplacementModel1> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NoTypeReplacementModel1>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _noTypeReplacementModel1sRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NoTypeReplacementModel1(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="NoTypeReplacementModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(NoTypeReplacementModel1.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="NoTypeReplacementModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(NoTypeReplacementModel1.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NoTypeReplacementModel1> IEnumerable<NoTypeReplacementModel1>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NoTypeReplacementModel1> IAsyncEnumerable<NoTypeReplacementModel1>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, NoTypeReplacementModel1, NoTypeReplacementModel1Data> Construct() { }
    }
}
