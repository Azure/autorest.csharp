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

namespace MgmtOperations
{
    /// <summary> A class representing collection of UnpatchableResource and their operations over its parent. </summary>
    public partial class UnpatchableResourceCollection : ArmCollection, IEnumerable<UnpatchableResource>, IAsyncEnumerable<UnpatchableResource>
    {
        private readonly ClientDiagnostics _unpatchableResourceClientDiagnostics;
        private readonly UnpatchableResourcesRestOperations _unpatchableResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="UnpatchableResourceCollection"/> class for mocking. </summary>
        protected UnpatchableResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="UnpatchableResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal UnpatchableResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _unpatchableResourceClientDiagnostics = new ClientDiagnostics("MgmtOperations", UnpatchableResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(UnpatchableResource.ResourceType, out string unpatchableResourceApiVersion);
            _unpatchableResourceRestClient = new UnpatchableResourcesRestOperations(_unpatchableResourceClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, unpatchableResourceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update an UnpatchableResource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="parameters"> Parameters supplied to the Create UnpatchableResource operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<UnpatchableResource>> CreateOrUpdateAsync(bool waitForCompletion, string name, UnpatchableResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _unpatchableResourceRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation<UnpatchableResource>(Response.FromValue(new UnpatchableResource(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Create or update an UnpatchableResource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="parameters"> Parameters supplied to the Create UnpatchableResource operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<UnpatchableResource> CreateOrUpdate(bool waitForCompletion, string name, UnpatchableResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _unpatchableResourceRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, name, parameters, cancellationToken);
                var operation = new MgmtOperationsArmOperation<UnpatchableResource>(Response.FromValue(new UnpatchableResource(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_Get
        /// </summary>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<UnpatchableResource>> GetAsync(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _unpatchableResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new UnpatchableResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_Get
        /// </summary>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<UnpatchableResource> Get(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _unpatchableResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new UnpatchableResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources
        /// Operation Id: UnpatchableResources_List
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="UnpatchableResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<UnpatchableResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<UnpatchableResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _unpatchableResourceRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new UnpatchableResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Retrieves information about an UnpatchableResource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources
        /// Operation Id: UnpatchableResources_List
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="UnpatchableResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<UnpatchableResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<UnpatchableResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _unpatchableResourceRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new UnpatchableResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_Get
        /// </summary>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(name, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_Get
        /// </summary>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(name, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_Get
        /// </summary>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<UnpatchableResource>> GetIfExistsAsync(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _unpatchableResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<UnpatchableResource>(null, response.GetRawResponse());
                return Response.FromValue(new UnpatchableResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/unpatchableResources/{name}
        /// Operation Id: UnpatchableResources_Get
        /// </summary>
        /// <param name="name"> The name of the UnpatchableResource. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<UnpatchableResource> GetIfExists(string name, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _unpatchableResourceClientDiagnostics.CreateScope("UnpatchableResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _unpatchableResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<UnpatchableResource>(null, response.GetRawResponse());
                return Response.FromValue(new UnpatchableResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<UnpatchableResource> IEnumerable<UnpatchableResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<UnpatchableResource> IAsyncEnumerable<UnpatchableResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
