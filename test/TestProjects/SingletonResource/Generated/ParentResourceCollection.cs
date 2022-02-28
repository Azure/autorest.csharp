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

namespace SingletonResource
{
    /// <summary> A class representing collection of ParentResource and their operations over its parent. </summary>
    public partial class ParentResourceCollection : ArmCollection, IEnumerable<ParentResource>, IAsyncEnumerable<ParentResource>
    {
        private readonly ClientDiagnostics _parentResourceClientDiagnostics;
        private readonly ParentResourcesRestOperations _parentResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="ParentResourceCollection"/> class for mocking. </summary>
        protected ParentResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ParentResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ParentResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _parentResourceClientDiagnostics = new ClientDiagnostics("SingletonResource", ParentResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ParentResource.ResourceType, out string parentResourceApiVersion);
            _parentResourceRestClient = new ParentResourcesRestOperations(_parentResourceClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, parentResourceApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="parameters"> The ParentResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ParentResource>> CreateOrUpdateAsync(bool waitForCompletion, string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _parentResourceRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, parentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SingletonResourceArmOperation<ParentResource>(Response.FromValue(new ParentResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="parameters"> The ParentResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ParentResource> CreateOrUpdate(bool waitForCompletion, string parentName, ParentResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _parentResourceRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, parentName, parameters, cancellationToken);
                var operation = new SingletonResourceArmOperation<ParentResource>(Response.FromValue(new ParentResource(Client, response), response.GetRawResponse()));
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
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual async Task<Response<ParentResource>> GetAsync(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _parentResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual Response<ParentResource> Get(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _parentResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources
        /// Operation Id: ParentResources_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ParentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ParentResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _parentResourceRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ParentResource(Client, value)), null, response.GetRawResponse());
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
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources
        /// Operation Id: ParentResources_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ParentResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ParentResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _parentResourceRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ParentResource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(parentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual Response<bool> Exists(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(parentName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual async Task<Response<ParentResource>> GetIfExistsAsync(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _parentResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ParentResource>(null, response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual Response<ParentResource> GetIfExists(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _parentResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ParentResource>(null, response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ParentResource> IEnumerable<ParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ParentResource> IAsyncEnumerable<ParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
