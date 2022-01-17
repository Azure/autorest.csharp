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
using Azure.ResourceManager.Management;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of MgmtGrpParentWithLoc and their operations over its parent. </summary>
    public partial class MgmtGrpParentWithLocCollection : ArmCollection, IEnumerable<MgmtGrpParentWithLoc>, IAsyncEnumerable<MgmtGrpParentWithLoc>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly MgmtGrpParentWithLocsRestOperations _mgmtGrpParentWithLocsRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocCollection"/> class for mocking. </summary>
        protected MgmtGrpParentWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal MgmtGrpParentWithLocCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(MgmtGrpParentWithLoc.ResourceType, out string apiVersion);
            _mgmtGrpParentWithLocsRestClient = new MgmtGrpParentWithLocsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagementGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagementGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: MgmtGrpParentWithLocs_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual MgmtGrpParentWithLocCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string mgmtGrpParentWithLocName, MgmtGrpParentWithLocData parameters, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocsRestClient.CreateOrUpdate(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken);
                var operation = new MgmtGrpParentWithLocCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: MgmtGrpParentWithLocs_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<MgmtGrpParentWithLocCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string mgmtGrpParentWithLocName, MgmtGrpParentWithLocData parameters, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocsRestClient.CreateOrUpdateAsync(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtGrpParentWithLocCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: MgmtGrpParentWithLocs_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithLoc> Get(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocsRestClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: MgmtGrpParentWithLocs_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<MgmtGrpParentWithLoc>> GetAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocsRestClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new MgmtGrpParentWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithLoc> GetIfExists(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocsRestClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<MgmtGrpParentWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<MgmtGrpParentWithLoc>> GetIfExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocsRestClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<MgmtGrpParentWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(mgmtGrpParentWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            if (mgmtGrpParentWithLocName == null)
            {
                throw new ArgumentNullException(nameof(mgmtGrpParentWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(mgmtGrpParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: MgmtGrpParentWithLocs_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtGrpParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGrpParentWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<MgmtGrpParentWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithLocsRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<MgmtGrpParentWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithLocsRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{managementGroupId}
        /// OperationId: MgmtGrpParentWithLocs_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtGrpParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGrpParentWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<MgmtGrpParentWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithLocsRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<MgmtGrpParentWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithLocsRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<MgmtGrpParentWithLoc> IEnumerable<MgmtGrpParentWithLoc>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MgmtGrpParentWithLoc> IAsyncEnumerable<MgmtGrpParentWithLoc>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, MgmtGrpParentWithLoc, MgmtGrpParentWithLocData> Construct() { }
    }
}
