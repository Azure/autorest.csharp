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

namespace MgmtListMethods
{
    /// <summary> A class representing collection of TenantParentWithNonResCh and their operations over its parent. </summary>
    public partial class TenantParentWithNonResChCollection : ArmCollection, IEnumerable<TenantParentWithNonResChResource>, IAsyncEnumerable<TenantParentWithNonResChResource>
    {
        private readonly ClientDiagnostics _tenantParentWithNonResChClientDiagnostics;
        private readonly TenantParentWithNonResChesRestOperations _tenantParentWithNonResChRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithNonResChCollection"/> class for mocking. </summary>
        protected TenantParentWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithNonResChCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TenantParentWithNonResChCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tenantParentWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", TenantParentWithNonResChResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(TenantParentWithNonResChResource.ResourceType, out string tenantParentWithNonResChApiVersion);
            _tenantParentWithNonResChRestClient = new TenantParentWithNonResChesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, tenantParentWithNonResChApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantTestResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantTestResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<TenantParentWithNonResChResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChRestClient.CreateOrUpdateAsync(Id.Name, tenantParentWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResChResource>(Response.FromValue(new TenantParentWithNonResChResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<TenantParentWithNonResChResource> CreateOrUpdate(WaitUntil waitUntil, string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChRestClient.CreateOrUpdate(Id.Name, tenantParentWithNonResChName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResChResource>(Response.FromValue(new TenantParentWithNonResChResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_Get
        /// </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<TenantParentWithNonResChResource>> GetAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChRestClient.GetAsync(Id.Name, tenantParentWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_Get
        /// </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual Response<TenantParentWithNonResChResource> Get(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChRestClient.Get(Id.Name, tenantParentWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes
        /// Operation Id: TenantParentWithNonResChes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantParentWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParentWithNonResChResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantParentWithNonResChResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentWithNonResChRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantParentWithNonResChResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentWithNonResChRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes
        /// Operation Id: TenantParentWithNonResChes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantParentWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParentWithNonResChResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TenantParentWithNonResChResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentWithNonResChRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantParentWithNonResChResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentWithNonResChRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_Get
        /// </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(tenantParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_Get
        /// </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(tenantParentWithNonResChName, cancellationToken: cancellationToken);
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_Get
        /// </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<TenantParentWithNonResChResource>> GetIfExistsAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChRestClient.GetAsync(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TenantParentWithNonResChResource>(null, response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// Operation Id: TenantParentWithNonResChes_Get
        /// </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual Response<TenantParentWithNonResChResource> GetIfExists(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChRestClient.Get(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TenantParentWithNonResChResource>(null, response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantParentWithNonResChResource> IEnumerable<TenantParentWithNonResChResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantParentWithNonResChResource> IAsyncEnumerable<TenantParentWithNonResChResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
