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
    /// <summary> A class representing collection of TrackedResourceModel2 and their operations over a ResourceGroup. </summary>
    public partial class TrackedResourceModel2Collection : ArmCollection, IEnumerable<TrackedResourceModel2>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TrackedResourceModel2SRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="TrackedResourceModel2Collection"/> class for mocking. </summary>
        protected TrackedResourceModel2Collection()
        {
        }

        /// <summary> Initializes a new instance of TrackedResourceModel2Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TrackedResourceModel2Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new TrackedResourceModel2SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        IEnumerator<TrackedResourceModel2> IEnumerable<TrackedResourceModel2>.GetEnumerator()
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

        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel2 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual TrackedResourceModel2PutOperation CreateOrUpdate(string trackedResourceModel2SName, TrackedResourceModel2Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (trackedResourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(trackedResourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Put(Id.ResourceGroupName, trackedResourceModel2SName, parameters, cancellationToken);
                var operation = new TrackedResourceModel2PutOperation(Parent, response);
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

        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel2 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trackedResourceModel2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TrackedResourceModel2PutOperation> CreateOrUpdateAsync(string trackedResourceModel2SName, TrackedResourceModel2Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (trackedResourceModel2SName == null)
            {
                throw new ArgumentNullException(nameof(trackedResourceModel2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.PutAsync(Id.ResourceGroupName, trackedResourceModel2SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TrackedResourceModel2PutOperation(Parent, response);
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
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<TrackedResourceModel2> Get(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.Get");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TrackedResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<TrackedResourceModel2>> GetAsync(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.Get");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TrackedResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<TrackedResourceModel2> GetIfExists(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.GetIfExists");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<TrackedResourceModel2>(null, response.GetRawResponse())
                    : Response.FromValue(new TrackedResourceModel2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<TrackedResourceModel2>> GetIfExistsAsync(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.GetIfExists");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<TrackedResourceModel2>(null, response.GetRawResponse())
                    : Response.FromValue(new TrackedResourceModel2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.CheckIfExists");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = GetIfExists(trackedResourceModel2SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.CheckIfExists");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = await GetIfExistsAsync(trackedResourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<TrackedResourceModel2>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.GetAll");
            scope.Start();
            try
            {
                var response = await _restClient.GetAllAsync(Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(data => new TrackedResourceModel2(Parent, data)).ToArray() as IReadOnlyList<TrackedResourceModel2>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<TrackedResourceModel2>> GetAll(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.GetAll");
            scope.Start();
            try
            {
                var response = _restClient.GetAll(Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(data => new TrackedResourceModel2(Parent, data)).ToArray() as IReadOnlyList<TrackedResourceModel2>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="TrackedResourceModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TrackedResourceModel2.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="TrackedResourceModel2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TrackedResourceModel2.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, TrackedResourceModel2, TrackedResourceModel2Data> Construct() { }
    }
}
