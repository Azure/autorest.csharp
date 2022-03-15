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
    public partial class MgmtGrpParentWithLocCollection : ArmCollection, IEnumerable<MgmtGrpParentWithLocResource>, IAsyncEnumerable<MgmtGrpParentWithLocResource>
    {
        private readonly ClientDiagnostics _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics;
        private readonly MgmtGrpParentWithLocsRestOperations _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocCollection"/> class for mocking. </summary>
        protected MgmtGrpParentWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MgmtGrpParentWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics = new ClientDiagnostics("MgmtListMethods", MgmtGrpParentWithLocResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(MgmtGrpParentWithLocResource.ResourceType, out string mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsApiVersion);
            _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient = new MgmtGrpParentWithLocsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsApiVersion);
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
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<MgmtGrpParentWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string mgmtGrpParentWithLocName, MgmtGrpParentWithLocResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.CreateOrUpdateAsync(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithLocResource>(Response.FromValue(new MgmtGrpParentWithLocResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<MgmtGrpParentWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string mgmtGrpParentWithLocName, MgmtGrpParentWithLocResourceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.CreateOrUpdate(Id.Name, mgmtGrpParentWithLocName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithLocResource>(Response.FromValue(new MgmtGrpParentWithLocResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}
        /// Operation Id: MgmtGrpParentWithLocs_Get
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        public virtual async Task<Response<MgmtGrpParentWithLocResource>> GetAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLocResource(Client, response.Value), response.GetRawResponse());
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
        public virtual Response<MgmtGrpParentWithLocResource> Get(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="MgmtGrpParentWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGrpParentWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<MgmtGrpParentWithLocResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<MgmtGrpParentWithLocResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> A collection of <see cref="MgmtGrpParentWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGrpParentWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<MgmtGrpParentWithLocResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<MgmtGrpParentWithLocResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        public virtual async Task<Response<bool>> ExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Exists");
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

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.Exists");
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
        public virtual async Task<Response<MgmtGrpParentWithLocResource>> GetIfExistsAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.GetAsync(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<MgmtGrpParentWithLocResource>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLocResource(Client, response.Value), response.GetRawResponse());
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
        public virtual Response<MgmtGrpParentWithLocResource> GetIfExists(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithLocName, nameof(mgmtGrpParentWithLocName));

            using var scope = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsClientDiagnostics.CreateScope("MgmtGrpParentWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocResourceMgmtGrpParentWithLocsRestClient.Get(Id.Name, mgmtGrpParentWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<MgmtGrpParentWithLocResource>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MgmtGrpParentWithLocResource> IEnumerable<MgmtGrpParentWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MgmtGrpParentWithLocResource> IAsyncEnumerable<MgmtGrpParentWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
