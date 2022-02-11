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

namespace MgmtListMethods
{
    /// <summary> A class representing collection of ResGrpParentWithAncestorWithNonResCh and their operations over its parent. </summary>
    public partial class ResGrpParentWithAncestorWithNonResChCollection : ArmCollection, IEnumerable<ResGrpParentWithAncestorWithNonResCh>, IAsyncEnumerable<ResGrpParentWithAncestorWithNonResCh>
    {
        private readonly ClientDiagnostics _resGrpParentWithAncestorWithNonResChClientDiagnostics;
        private readonly ResGrpParentWithAncestorWithNonResChesRestOperations _resGrpParentWithAncestorWithNonResChRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChCollection"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResGrpParentWithAncestorWithNonResChCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resGrpParentWithAncestorWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithNonResCh.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResGrpParentWithAncestorWithNonResCh.ResourceType, out string resGrpParentWithAncestorWithNonResChApiVersion);
            _resGrpParentWithAncestorWithNonResChRestClient = new ResGrpParentWithAncestorWithNonResChesRestOperations(_resGrpParentWithAncestorWithNonResChClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, resGrpParentWithAncestorWithNonResChApiVersion);
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
        /// Create or update.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ResGrpParentWithAncestorWithNonResCh>> CreateOrUpdateAsync(bool waitForCompletion, string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResCh>(Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Client, response), response.GetRawResponse()));
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
        /// Create or update.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ResGrpParentWithAncestorWithNonResCh> CreateOrUpdate(bool waitForCompletion, string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResCh>(Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Client, response), response.GetRawResponse()));
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
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithNonResCh>> GetAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResCh> Get(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestorWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChRestClient.ListTestAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithAncestorWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChRestClient.ListTestNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestorWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChRestClient.ListTest(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithAncestorWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChRestClient.ListTestNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithNonResCh>> GetIfExistsAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestorWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResCh> GetIfExists(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChName, nameof(resGrpParentWithAncestorWithNonResChName));

            using var scope = _resGrpParentWithAncestorWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestorWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithAncestorWithNonResCh> IEnumerable<ResGrpParentWithAncestorWithNonResCh>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithAncestorWithNonResCh> IAsyncEnumerable<ResGrpParentWithAncestorWithNonResCh>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
