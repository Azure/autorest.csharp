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
    /// <summary> A class representing collection of TenantParentWithLoc and their operations over its parent. </summary>
    public partial class TenantParentWithLocCollection : ArmCollection, IEnumerable<TenantParentWithLoc>, IAsyncEnumerable<TenantParentWithLoc>
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
            _tenantParentWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", TenantParentWithLoc.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(TenantParentWithLoc.ResourceType, out string tenantParentWithLocApiVersion);
            _tenantParentWithLocRestClient = new TenantParentWithLocsRestOperations(_tenantParentWithLocClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, tenantParentWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantTest.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantTest.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<TenantParentWithLoc>> CreateOrUpdateAsync(bool waitForCompletion, string tenantParentWithLocName, TenantParentWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _tenantParentWithLocRestClient.CreateOrUpdateAsync(Id.Name, tenantParentWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithLoc>(Response.FromValue(new TenantParentWithLoc(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<TenantParentWithLoc> CreateOrUpdate(bool waitForCompletion, string tenantParentWithLocName, TenantParentWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _tenantParentWithLocRestClient.CreateOrUpdate(Id.Name, tenantParentWithLocName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithLoc>(Response.FromValue(new TenantParentWithLoc(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_Get
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual async Task<Response<TenantParentWithLoc>> GetAsync(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentWithLocRestClient.GetAsync(Id.Name, tenantParentWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_Get
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual Response<TenantParentWithLoc> Get(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _tenantParentWithLocRestClient.Get(Id.Name, tenantParentWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs
        /// Operation Id: TenantParentWithLocs_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParentWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantParentWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentWithLocRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantParentWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _tenantParentWithLocRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs
        /// Operation Id: TenantParentWithLocs_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParentWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TenantParentWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentWithLocRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantParentWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _tenantParentWithLocRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_Get
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
                var response = await GetIfExistsAsync(tenantParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_Get
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
                var response = GetIfExists(tenantParentWithLocName, cancellationToken: cancellationToken);
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_Get
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual async Task<Response<TenantParentWithLoc>> GetIfExistsAsync(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _tenantParentWithLocRestClient.GetAsync(Id.Name, tenantParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TenantParentWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithLocs/{tenantParentWithLocName}
        /// Operation Id: TenantParentWithLocs_Get
        /// </summary>
        /// <param name="tenantParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tenantParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithLocName"/> is null. </exception>
        public virtual Response<TenantParentWithLoc> GetIfExists(string tenantParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tenantParentWithLocName, nameof(tenantParentWithLocName));

            using var scope = _tenantParentWithLocClientDiagnostics.CreateScope("TenantParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _tenantParentWithLocRestClient.Get(Id.Name, tenantParentWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TenantParentWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new TenantParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TenantParentWithLoc> IEnumerable<TenantParentWithLoc>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantParentWithLoc> IAsyncEnumerable<TenantParentWithLoc>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
