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
using Azure.ResourceManager.Resources;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="TenantTestResource" /> and their operations.
    /// Each <see cref="TenantTestResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="TenantTestCollection" /> instance call the GetTenantTests method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class TenantTestCollection : ArmCollection, IEnumerable<TenantTestResource>, IAsyncEnumerable<TenantTestResource>
    {
        private readonly ClientDiagnostics _tenantTestClientDiagnostics;
        private readonly TenantTestsRestOperations _tenantTestRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantTestCollection"/> class for mocking. </summary>
        protected TenantTestCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantTestCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TenantTestCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tenantTestClientDiagnostics = new ClientDiagnostics("MgmtListMethods", TenantTestResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TenantTestResource.ResourceType, out string tenantTestApiVersion);
            _tenantTestRestClient = new TenantTestsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, tenantTestApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="data"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TenantTestResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string tenantTestName, TenantTestData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantTestRestClient.CreateAsync(tenantTestName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantTestResource>(new TenantTestOperationSource(Client), _tenantTestClientDiagnostics, Pipeline, _tenantTestRestClient.CreateCreateRequest(tenantTestName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="data"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TenantTestResource> CreateOrUpdate(WaitUntil waitUntil, string tenantTestName, TenantTestData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantTestRestClient.Create(tenantTestName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantTestResource>(new TenantTestOperationSource(Client), _tenantTestClientDiagnostics, Pipeline, _tenantTestRestClient.CreateCreateRequest(tenantTestName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets a billing account by its ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual async Task<Response<TenantTestResource>> GetAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantTestRestClient.GetAsync(tenantTestName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantTestResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual Response<TenantTestResource> Get(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantTestRestClient.Get(tenantTestName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantTestResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all fakes in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantTestResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantTestResource> GetAllAsync(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantTestRestClient.CreateListRequest(optionalParam);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantTestRestClient.CreateListNextPageRequest(nextLink, optionalParam);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new TenantTestResource(Client, TenantTestData.DeserializeTenantTestData(e)), _tenantTestClientDiagnostics, Pipeline, "TenantTestCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all fakes in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantTestResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantTestResource> GetAll(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _tenantTestRestClient.CreateListRequest(optionalParam);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _tenantTestRestClient.CreateListNextPageRequest(nextLink, optionalParam);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new TenantTestResource(Client, TenantTestData.DeserializeTenantTestData(e)), _tenantTestClientDiagnostics, Pipeline, "TenantTestCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.Exists");
            scope.Start();
            try
            {
                var response = await _tenantTestRestClient.GetAsync(tenantTestName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Tenant/tenantTests/{tenantTestName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantTests_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual Response<bool> Exists(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.Exists");
            scope.Start();
            try
            {
                var response = _tenantTestRestClient.Get(tenantTestName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantTestResource> IEnumerable<TenantTestResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantTestResource> IAsyncEnumerable<TenantTestResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
