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
    public partial class TenantParentWithNonResChCollection : ArmCollection, IEnumerable<TenantParentWithNonResCh>, IAsyncEnumerable<TenantParentWithNonResCh>
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
            _tenantParentWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", TenantParentWithNonResCh.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(TenantParentWithNonResCh.ResourceType, out string tenantParentWithNonResChApiVersion);
            _tenantParentWithNonResChRestClient = new TenantParentWithNonResChesRestOperations(_tenantParentWithNonResChClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, tenantParentWithNonResChApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantTest.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantTest.ResourceType), nameof(id));
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<TenantParentWithNonResCh>> CreateOrUpdateAsync(bool waitForCompletion, string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChRestClient.CreateOrUpdateAsync(Id.Name, tenantParentWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResCh>(Response.FromValue(new TenantParentWithNonResCh(Client, response), response.GetRawResponse()));
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<TenantParentWithNonResCh> CreateOrUpdate(bool waitForCompletion, string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChRestClient.CreateOrUpdate(Id.Name, tenantParentWithNonResChName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResCh>(Response.FromValue(new TenantParentWithNonResCh(Client, response), response.GetRawResponse()));
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<TenantParentWithNonResCh>> GetAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChRestClient.GetAsync(Id.Name, tenantParentWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _tenantParentWithNonResChClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TenantParentWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual Response<TenantParentWithNonResCh> Get(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChRestClient.Get(Id.Name, tenantParentWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw _tenantParentWithNonResChClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParentWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantParentWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentWithNonResChRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantParentWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentWithNonResChRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParentWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TenantParentWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentWithNonResChRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantParentWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentWithNonResChRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<TenantParentWithNonResCh>> GetIfExistsAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChRestClient.GetAsync(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TenantParentWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChes/{tenantParentWithNonResChName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParentWithNonResChes_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithNonResChName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> is null. </exception>
        public virtual Response<TenantParentWithNonResCh> GetIfExists(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithNonResChName, nameof(tenantParentWithNonResChName));

            using var scope = _tenantParentWithNonResChClientDiagnostics.CreateScope("TenantParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChRestClient.Get(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TenantParentWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantParentWithNonResCh> IEnumerable<TenantParentWithNonResCh>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantParentWithNonResCh> IAsyncEnumerable<TenantParentWithNonResCh>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
