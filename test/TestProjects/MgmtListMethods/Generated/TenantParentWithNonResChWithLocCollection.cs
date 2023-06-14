// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="TenantParentWithNonResChWithLocResource" /> and their operations.
    /// Each <see cref="TenantParentWithNonResChWithLocResource" /> in the collection will belong to the same instance of <see cref="TenantTestResource" />.
    /// To get a <see cref="TenantParentWithNonResChWithLocCollection" /> instance call the GetTenantParentWithNonResChWithLocs method from an instance of <see cref="TenantTestResource" />.
    /// </summary>
    public partial class TenantParentWithNonResChWithLocCollection : ArmCollection, IEnumerable<TenantParentWithNonResChWithLocResource>, IAsyncEnumerable<TenantParentWithNonResChWithLocResource>
    {
        private readonly ClientDiagnostics _tenantParentWithNonResChWithLocClientDiagnostics;
        private readonly TenantParentWithNonResChWithLocsRestOperations _tenantParentWithNonResChWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithNonResChWithLocCollection"/> class for mocking. </summary>
        protected TenantParentWithNonResChWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithNonResChWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TenantParentWithNonResChWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tenantParentWithNonResChWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", TenantParentWithNonResChWithLocResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TenantParentWithNonResChWithLocResource.ResourceType, out string tenantParentWithNonResChWithLocApiVersion);
            _tenantParentWithNonResChWithLocRestClient = new TenantParentWithNonResChWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, tenantParentWithNonResChWithLocApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TenantParentWithNonResChWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string tenantParentWithNonResChWithLocName, TenantParentWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChWithLocName, nameof(tenantParentWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChWithLocRestClient.CreateOrUpdateAsync(Id.Name, tenantParentWithNonResChWithLocName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResChWithLocResource>(Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TenantParentWithNonResChWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string tenantParentWithNonResChWithLocName, TenantParentWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChWithLocName, nameof(tenantParentWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChWithLocRestClient.CreateOrUpdate(Id.Name, tenantParentWithNonResChWithLocName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResChWithLocResource>(Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<TenantParentWithNonResChWithLocResource>> GetAsync(string tenantParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChWithLocName, nameof(tenantParentWithNonResChWithLocName));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChWithLocRestClient.GetAsync(Id.Name, tenantParentWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<TenantParentWithNonResChWithLocResource> Get(string tenantParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChWithLocName, nameof(tenantParentWithNonResChWithLocName));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChWithLocRestClient.Get(Id.Name, tenantParentWithNonResChWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantParentWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParentWithNonResChWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantParentWithNonResChWithLocRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantParentWithNonResChWithLocRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new TenantParentWithNonResChWithLocResource(Client, TenantParentWithNonResChWithLocData.DeserializeTenantParentWithNonResChWithLocData(e)), _tenantParentWithNonResChWithLocClientDiagnostics, Pipeline, "TenantParentWithNonResChWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantParentWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParentWithNonResChWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantParentWithNonResChWithLocRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantParentWithNonResChWithLocRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new TenantParentWithNonResChWithLocResource(Client, TenantParentWithNonResChWithLocData.DeserializeTenantParentWithNonResChWithLocData(e)), _tenantParentWithNonResChWithLocClientDiagnostics, Pipeline, "TenantParentWithNonResChWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string tenantParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChWithLocName, nameof(tenantParentWithNonResChWithLocName));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChWithLocRestClient.GetAsync(Id.Name, tenantParentWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string tenantParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChWithLocName, nameof(tenantParentWithNonResChWithLocName));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChWithLocRestClient.Get(Id.Name, tenantParentWithNonResChWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantParentWithNonResChWithLocResource> IEnumerable<TenantParentWithNonResChWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantParentWithNonResChWithLocResource> IAsyncEnumerable<TenantParentWithNonResChWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
