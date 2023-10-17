// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="TenantParentWithLocResource" /> and their operations.
    /// Each <see cref="TenantParentWithLocResource" /> in the collection will belong to the same instance of <see cref="TenantTestResource" />.
    /// To get a <see cref="TenantParentWithLocCollection" /> instance call the GetTenantParentWithLocs method from an instance of <see cref="TenantTestResource" />.
    /// </summary>
    public partial class TenantParentWithLocCollection : ArmCollection, IEnumerable<TenantParentWithLocResource>, IAsyncEnumerable<TenantParentWithLocResource>
    {
        private readonly ClientDiagnostics _tenantParentWithLocClientDiagnostics;
        private readonly TenantParentWithLocsRestOperations _tenantParentWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithLocCollection"/> class for mocking. </summary>
        protected TenantParentWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TenantParentWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tenantParentWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", TenantParentWithLocResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TenantParentWithLocResource.ResourceType, out string tenantParentWithLocApiVersion);
            _tenantParentWithLocRestClient = new TenantParentWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, tenantParentWithLocApiVersion);
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TenantParentWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string tenantParentWithLocName, TenantParentWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantParentWithLocRestClient.CreateOrUpdateAsync(Id.Name, tenantParentWithLocName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithLocResource>(Response.FromValue(new TenantParentWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TenantParentWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string tenantParentWithLocName, TenantParentWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantParentWithLocRestClient.CreateOrUpdate(Id.Name, tenantParentWithLocName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithLocResource>(Response.FromValue(new TenantParentWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual async Task<Response<TenantParentWithLocResource>> GetAsync(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentWithLocRestClient.GetAsync(Id.Name, tenantParentWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual Response<TenantParentWithLocResource> Get(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantParentWithLocRestClient.Get(Id.Name, tenantParentWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantParentWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParentWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantParentWithLocRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantParentWithLocRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, (e, o) => new TenantParentWithLocResource(Client, TenantParentWithLocData.DeserializeTenantParentWithLocData(e)), _tenantParentWithLocClientDiagnostics, Pipeline, "TenantParentWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantParentWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParentWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantParentWithLocRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantParentWithLocRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, (e, o) => new TenantParentWithLocResource(Client, TenantParentWithLocData.DeserializeTenantParentWithLocData(e)), _tenantParentWithLocClientDiagnostics, Pipeline, "TenantParentWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await _tenantParentWithLocRestClient.GetAsync(Id.Name, tenantParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = _tenantParentWithLocRestClient.Get(Id.Name, tenantParentWithLocName, cancellationToken: cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual async Task<NullableResponse<TenantParentWithLocResource>> GetIfExistsAsync(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _tenantParentWithLocRestClient.GetAsync(Id.Name, tenantParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<TenantParentWithLocResource>(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual NullableResponse<TenantParentWithLocResource> GetIfExists(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantParentWithLocRestClient.Get(Id.Name, tenantParentWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<TenantParentWithLocResource>(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantParentWithLocResource> IEnumerable<TenantParentWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantParentWithLocResource> IAsyncEnumerable<TenantParentWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
