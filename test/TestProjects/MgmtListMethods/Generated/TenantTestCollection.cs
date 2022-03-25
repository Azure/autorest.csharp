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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Get
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Get
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests
        /// Operation Id: TenantTests_List
        /// </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantTestResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantTestResource> GetAllAsync(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantTestResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantTestRestClient.ListAsync(optionalParam, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTestResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantTestResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantTestRestClient.ListNextPageAsync(nextLink, optionalParam, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTestResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all fakes in a resource group.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests
        /// Operation Id: TenantTests_List
        /// </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantTestResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantTestResource> GetAll(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            Page<TenantTestResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantTestRestClient.List(optionalParam, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTestResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantTestResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantTestRestClient.ListNextPage(nextLink, optionalParam, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTestResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Get
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
                var response = await GetIfExistsAsync(tenantTestName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Get
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
                var response = GetIfExists(tenantTestName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Get
        /// </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual async Task<Response<TenantTestResource>> GetIfExistsAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _tenantTestRestClient.GetAsync(tenantTestName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TenantTestResource>(null, response.GetRawResponse());
                return Response.FromValue(new TenantTestResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// Operation Id: TenantTests_Get
        /// </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantTestName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual Response<TenantTestResource> GetIfExists(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantTestName, nameof(tenantTestName));

            using var scope = _tenantTestClientDiagnostics.CreateScope("TenantTestCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantTestRestClient.Get(tenantTestName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TenantTestResource>(null, response.GetRawResponse());
                return Response.FromValue(new TenantTestResource(Client, response.Value), response.GetRawResponse());
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
