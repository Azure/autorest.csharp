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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of TenantTest and their operations over its parent. </summary>
    public partial class TenantTestCollection : ArmCollection, IEnumerable<TenantTest>, IAsyncEnumerable<TenantTest>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TenantTestsRestOperations _tenantTestsRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantTestCollection"/> class for mocking. </summary>
        protected TenantTestCollection()
        {
        }

        /// <summary> Initializes a new instance of TenantTestCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TenantTestCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _tenantTestsRestClient = new TenantTestsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Tenant.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Tenant.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// ContextualPath: /
        /// OperationId: TenantTests_Create
        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual TenantTestCreateOperation CreateOrUpdate(bool waitForCompletion, string tenantTestName, TenantTestData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantTestsRestClient.Create(tenantTestName, parameters, cancellationToken);
                var operation = new TenantTestCreateOperation(Parent, _clientDiagnostics, Pipeline, _tenantTestsRestClient.CreateCreateRequest(tenantTestName, parameters).Request, response);
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// ContextualPath: /
        /// OperationId: TenantTests_Create
        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TenantTestCreateOperation> CreateOrUpdateAsync(bool waitForCompletion, string tenantTestName, TenantTestData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantTestsRestClient.CreateAsync(tenantTestName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TenantTestCreateOperation(Parent, _clientDiagnostics, Pipeline, _tenantTestsRestClient.CreateCreateRequest(tenantTestName, parameters).Request, response);
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// ContextualPath: /
        /// OperationId: TenantTests_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual Response<TenantTest> Get(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantTestsRestClient.Get(tenantTestName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantTest(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// ContextualPath: /
        /// OperationId: TenantTests_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public async virtual Task<Response<TenantTest>> GetAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantTestsRestClient.GetAsync(tenantTestName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TenantTest(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual Response<TenantTest> GetIfExists(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantTestsRestClient.Get(tenantTestName, expand, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<TenantTest>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantTest(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public async virtual Task<Response<TenantTest>> GetIfExistsAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _tenantTestsRestClient.GetAsync(tenantTestName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<TenantTest>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantTest(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public virtual Response<bool> Exists(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(tenantTestName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(tenantTestName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests
        /// ContextualPath: /
        /// OperationId: TenantTests_List
        /// <summary> Lists all fakes in a resource group. </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantTest" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantTest> GetAll(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            Page<TenantTest> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantTestsRestClient.List(optionalParam, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantTest> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantTestsRestClient.ListNextPage(nextLink, optionalParam, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests
        /// ContextualPath: /
        /// OperationId: TenantTests_List
        /// <summary> Lists all fakes in a resource group. </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantTest" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantTest> GetAllAsync(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantTest>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantTestsRestClient.ListAsync(optionalParam, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantTest>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantTestsRestClient.ListNextPageAsync(nextLink, optionalParam, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<TenantTest> IEnumerable<TenantTest>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantTest> IAsyncEnumerable<TenantTest>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, TenantTest, TenantTestData> Construct() { }
    }
}
