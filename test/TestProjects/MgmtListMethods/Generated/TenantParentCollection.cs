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
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of TenantParent and their operations over its parent. </summary>
    public partial class TenantParentCollection : ArmCollection, IEnumerable<TenantParent>, IAsyncEnumerable<TenantParent>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TenantParentsRestOperations _tenantParentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="TenantParentCollection"/> class for mocking. </summary>
        protected TenantParentCollection()
        {
        }

        /// <summary> Initializes a new instance of TenantParentCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TenantParentCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _tenantParentsRestClient = new TenantParentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantTest.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantTest.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual TenantParentCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string tenantParentName, TenantParentData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantParentsRestClient.CreateOrUpdate(Id.Name, tenantParentName, parameters, cancellationToken);
                var operation = new TenantParentCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TenantParentCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string tenantParentName, TenantParentData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantParentsRestClient.CreateOrUpdateAsync(Id.Name, tenantParentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TenantParentCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual Response<TenantParent> Get(string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantParentsRestClient.Get(Id.Name, tenantParentName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents/{tenantParentName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public async virtual Task<Response<TenantParent>> GetAsync(string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentsRestClient.GetAsync(Id.Name, tenantParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TenantParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual Response<TenantParent> GetIfExists(string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantParentsRestClient.Get(Id.Name, tenantParentName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<TenantParent>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public async virtual Task<Response<TenantParent>> GetIfExistsAsync(string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _tenantParentsRestClient.GetAsync(Id.Name, tenantParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<TenantParent>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(tenantParentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string tenantParentName, CancellationToken cancellationToken = default)
        {
            if (tenantParentName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(tenantParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParents_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParent> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TenantParent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentsRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantParent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentsRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParents
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantParents_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParent> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantParent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentsRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantParent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentsRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<TenantParent> IEnumerable<TenantParent>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantParent> IAsyncEnumerable<TenantParent>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, TenantParent, TenantParentData> Construct() { }
    }
}
