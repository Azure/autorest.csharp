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
using Azure.ResourceManager.Management;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of MgmtGrpParentWithLoc and their operations over its parent. </summary>
    public partial class MgmtGrpParentWithLocCollection : ArmCollection, IEnumerable<MgmtGrpParentWithLoc>, IAsyncEnumerable<MgmtGrpParentWithLoc>
    {
        private readonly ClientDiagnostics _mgmtGrpParentWithLocClientDiagnostics;
        private readonly MgmtGrpParentWithLocsRestOperations _mgmtGrpParentWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocCollection"/> class for mocking. </summary>
        protected MgmtGrpParentWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MgmtGrpParentWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mgmtGrpParentWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", MgmtGrpParentWithLoc.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(MgmtGrpParentWithLoc.ResourceType, out string mgmtGrpParentWithLocApiVersion);
            _mgmtGrpParentWithLocRestClient = new MgmtGrpParentWithLocsRestOperations(_mgmtGrpParentWithLocClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, mgmtGrpParentWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagementGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagementGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<MgmtGrpParentWithLoc>> CreateOrUpdateAsync(bool waitForCompletion, string mgmtGrpParentWithLocName, MgmtGrpParentWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocRestClient.CreateOrUpdateAsync(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithLoc>(Response.FromValue(new MgmtGrpParentWithLoc(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<MgmtGrpParentWithLoc> CreateOrUpdate(bool waitForCompletion, string mgmtGrpParentWithLocName, MgmtGrpParentWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocRestClient.CreateOrUpdate(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithLoc>(Response.FromValue(new MgmtGrpParentWithLoc(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_Get
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<MgmtGrpParentWithLoc>> GetAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocRestClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _mgmtGrpParentWithLocClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new MgmtGrpParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_Get
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithLoc> Get(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocRestClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken);
                if (response.Value == null)
                    throw _mgmtGrpParentWithLocClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs
        /// Operation Id: MgmtGrpParentWithLocs_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtGrpParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGrpParentWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<MgmtGrpParentWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithLocRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<MgmtGrpParentWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithLocRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs
        /// Operation Id: MgmtGrpParentWithLocs_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtGrpParentWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGrpParentWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<MgmtGrpParentWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithLocRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<MgmtGrpParentWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithLocRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLoc(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_Get
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Exists");
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

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_Get
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Exists");
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

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_Get
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public async virtual Task<Response<MgmtGrpParentWithLoc>> GetIfExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocRestClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<MgmtGrpParentWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_Get
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithLoc> GetIfExists(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocRestClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<MgmtGrpParentWithLoc>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
    }
}
