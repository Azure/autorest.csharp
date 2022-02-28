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
    /// <summary> A class representing collection of ResGrpParentWithAncestorWithNonResChWithLoc and their operations over its parent. </summary>
    public partial class ResGrpParentWithAncestorWithNonResChWithLocCollection : ArmCollection, IEnumerable<ResGrpParentWithAncestorWithNonResChWithLoc>, IAsyncEnumerable<ResGrpParentWithAncestorWithNonResChWithLoc>
    {
        private readonly ClientDiagnostics _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics;
        private readonly ResGrpParentWithAncestorWithNonResChWithLocsRestOperations _resGrpParentWithAncestorWithNonResChWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChWithLocCollection"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorWithNonResChWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResGrpParentWithAncestorWithNonResChWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithNonResChWithLoc.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResGrpParentWithAncestorWithNonResChWithLoc.ResourceType, out string resGrpParentWithAncestorWithNonResChWithLocApiVersion);
            _resGrpParentWithAncestorWithNonResChWithLocRestClient = new ResGrpParentWithAncestorWithNonResChWithLocsRestOperations(_resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, resGrpParentWithAncestorWithNonResChWithLocApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ResGrpParentWithAncestorWithNonResChWithLoc>> CreateOrUpdateAsync(bool waitForCompletion, string resGrpParentWithAncestorWithNonResChWithLocName, ResGrpParentWithAncestorWithNonResChWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResChWithLoc>(Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLoc(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ResGrpParentWithAncestorWithNonResChWithLoc> CreateOrUpdate(bool waitForCompletion, string resGrpParentWithAncestorWithNonResChWithLocName, ResGrpParentWithAncestorWithNonResChWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestorWithNonResChWithLoc>(Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLoc(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<ResGrpParentWithAncestorWithNonResChWithLoc>> GetAsync(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResChWithLoc> Get(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestorWithNonResChWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.ListTestAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResChWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithAncestorWithNonResChWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.ListTestNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResChWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResChWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestorWithNonResChWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.ListTest(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResChWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithAncestorWithNonResChWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.ListTestNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResChWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<ResGrpParentWithAncestorWithNonResChWithLoc>> GetIfExistsAsync(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestorWithNonResChWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs/{resGrpParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: ResGrpParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResChWithLoc> GetIfExists(string resGrpParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorWithNonResChWithLocName, nameof(resGrpParentWithAncestorWithNonResChWithLocName));

            using var scope = _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestorWithNonResChWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithAncestorWithNonResChWithLoc> IEnumerable<ResGrpParentWithAncestorWithNonResChWithLoc>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithAncestorWithNonResChWithLoc> IAsyncEnumerable<ResGrpParentWithAncestorWithNonResChWithLoc>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
