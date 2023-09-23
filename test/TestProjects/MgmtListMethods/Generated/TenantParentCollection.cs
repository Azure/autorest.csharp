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
    /// A class representing a collection of <see cref="TenantParentResource" /> and their operations.
    /// Each <see cref="TenantParentResource" /> in the collection will belong to the same instance of <see cref="TenantTestResource" />.
    /// To get a <see cref="TenantParentCollection" /> instance call the GetTenantParents method from an instance of <see cref="TenantTestResource" />.
    /// </summary>
    public partial class TenantParentCollection : ArmCollection, IEnumerable<TenantParentResource>, IAsyncEnumerable<TenantParentResource>
    {
        private readonly ClientDiagnostics _tenantParentClientDiagnostics;
        private readonly TenantParentsRestOperations _tenantParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantParentCollection"/> class for mocking. </summary>
        protected TenantParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TenantParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tenantParentClientDiagnostics = new ClientDiagnostics("MgmtListMethods", TenantParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TenantParentResource.ResourceType, out string tenantParentApiVersion);
            _tenantParentRestClient = new TenantParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, tenantParentApiVersion);
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TenantParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string tenantParentName, TenantParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantParentRestClient.CreateOrUpdateAsync(Id.Name, tenantParentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantParentResource>(Response.FromValue(new TenantParentResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TenantParentResource> CreateOrUpdate(WaitUntil waitUntil, string tenantParentName, TenantParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantParentRestClient.CreateOrUpdate(Id.Name, tenantParentName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantParentResource>(Response.FromValue(new TenantParentResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual async Task<Response<TenantParentResource>> GetAsync(string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentRestClient.GetAsync(Id.Name, tenantParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TenantParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual Response<TenantParentResource> Get(string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantParentRestClient.Get(Id.Name, tenantParentName, cancellationToken);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TenantParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantParentRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantParentRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new TenantParentResource(Client, TenantParentData.DeserializeTenantParentData(e)), _tenantParentClientDiagnostics, Pipeline, "TenantParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParentResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantParentRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantParentRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new TenantParentResource(Client, TenantParentData.DeserializeTenantParentData(e)), _tenantParentClientDiagnostics, Pipeline, "TenantParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _tenantParentRestClient.GetAsync(Id.Name, tenantParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.Exists");
            scope.Start();
            try
            {
                var response = _tenantParentRestClient.Get(Id.Name, tenantParentName, cancellationToken: cancellationToken);
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual async Task<NullableResponse<TenantParentResource>> GetIfExistsAsync(string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _tenantParentRestClient.GetAsync(Id.Name, tenantParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<TenantParentResource>(response.GetRawResponse());
                return Response.FromValue(new TenantParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual NullableResponse<TenantParentResource> GetIfExists(string tenantParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentName, nameof(tenantParentName));

            using var scope = _tenantParentClientDiagnostics.CreateScope("TenantParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantParentRestClient.Get(Id.Name, tenantParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<TenantParentResource>(response.GetRawResponse());
                return Response.FromValue(new TenantParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantParentResource> IEnumerable<TenantParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantParentResource> IAsyncEnumerable<TenantParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
