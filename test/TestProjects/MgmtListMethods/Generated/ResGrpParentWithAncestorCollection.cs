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
    /// <summary> A class representing collection of ResGrpParentWithAncestor and their operations over its parent. </summary>
    public partial class ResGrpParentWithAncestorCollection : ArmCollection, IEnumerable<ResGrpParentWithAncestor>, IAsyncEnumerable<ResGrpParentWithAncestor>
    {
        private readonly ClientDiagnostics _resGrpParentWithAncestorClientDiagnostics;
        private readonly ResGrpParentWithAncestorsRestOperations _resGrpParentWithAncestorRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorCollection"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResGrpParentWithAncestorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resGrpParentWithAncestorClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestor.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResGrpParentWithAncestor.ResourceType, out string resGrpParentWithAncestorApiVersion);
            _resGrpParentWithAncestorRestClient = new ResGrpParentWithAncestorsRestOperations(_resGrpParentWithAncestorClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, resGrpParentWithAncestorApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ResGrpParentWithAncestor>> CreateOrUpdateAsync(bool waitForCompletion, string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestor>(Response.FromValue(new ResGrpParentWithAncestor(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ResGrpParentWithAncestor> CreateOrUpdate(bool waitForCompletion, string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithAncestor>(Response.FromValue(new ResGrpParentWithAncestor(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestor>> GetAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _resGrpParentWithAncestorClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestor> Get(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken);
                if (response.Value == null)
                    throw _resGrpParentWithAncestorClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors
        /// Operation Id: ResGrpParentWithAncestors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithAncestor>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors
        /// Operation Id: ResGrpParentWithAncestors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithAncestor> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resGrpParentWithAncestorName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestor>> GetIfExistsAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestor>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// Operation Id: ResGrpParentWithAncestors_Get
        /// </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestor> GetIfExists(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithAncestorName, nameof(resGrpParentWithAncestorName));

            using var scope = _resGrpParentWithAncestorClientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestor>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithAncestor> IEnumerable<ResGrpParentWithAncestor>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithAncestor> IAsyncEnumerable<ResGrpParentWithAncestor>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
