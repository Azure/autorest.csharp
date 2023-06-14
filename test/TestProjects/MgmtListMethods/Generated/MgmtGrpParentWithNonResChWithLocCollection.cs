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
using Azure.ResourceManager.ManagementGroups;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="MgmtGrpParentWithNonResChWithLocResource" /> and their operations.
    /// Each <see cref="MgmtGrpParentWithNonResChWithLocResource" /> in the collection will belong to the same instance of <see cref="ManagementGroupResource" />.
    /// To get a <see cref="MgmtGrpParentWithNonResChWithLocCollection" /> instance call the GetMgmtGrpParentWithNonResChWithLocs method from an instance of <see cref="ManagementGroupResource" />.
    /// </summary>
    public partial class MgmtGrpParentWithNonResChWithLocCollection : ArmCollection, IEnumerable<MgmtGrpParentWithNonResChWithLocResource>, IAsyncEnumerable<MgmtGrpParentWithNonResChWithLocResource>
    {
        private readonly ClientDiagnostics _mgmtGrpParentWithNonResChWithLocClientDiagnostics;
        private readonly MgmtGrpParentWithNonResChWithLocsRestOperations _mgmtGrpParentWithNonResChWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithNonResChWithLocCollection"/> class for mocking. </summary>
        protected MgmtGrpParentWithNonResChWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithNonResChWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MgmtGrpParentWithNonResChWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mgmtGrpParentWithNonResChWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", MgmtGrpParentWithNonResChWithLocResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MgmtGrpParentWithNonResChWithLocResource.ResourceType, out string mgmtGrpParentWithNonResChWithLocApiVersion);
            _mgmtGrpParentWithNonResChWithLocRestClient = new MgmtGrpParentWithNonResChWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mgmtGrpParentWithNonResChWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagementGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagementGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MgmtGrpParentWithNonResChWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string mgmtGrpParentWithNonResChWithLocName, MgmtGrpParentWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChWithLocName, nameof(mgmtGrpParentWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGrpParentWithNonResChWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithNonResChWithLocRestClient.CreateOrUpdateAsync(Id.Name, mgmtGrpParentWithNonResChWithLocName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithNonResChWithLocResource>(Response.FromValue(new MgmtGrpParentWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MgmtGrpParentWithNonResChWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string mgmtGrpParentWithNonResChWithLocName, MgmtGrpParentWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChWithLocName, nameof(mgmtGrpParentWithNonResChWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGrpParentWithNonResChWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithNonResChWithLocRestClient.CreateOrUpdate(Id.Name, mgmtGrpParentWithNonResChWithLocName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithNonResChWithLocResource>(Response.FromValue(new MgmtGrpParentWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<MgmtGrpParentWithNonResChWithLocResource>> GetAsync(string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChWithLocName, nameof(mgmtGrpParentWithNonResChWithLocName));

            using var scope = _mgmtGrpParentWithNonResChWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithNonResChWithLocRestClient.GetAsync(Id.Name, mgmtGrpParentWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithNonResChWithLocResource> Get(string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChWithLocName, nameof(mgmtGrpParentWithNonResChWithLocName));

            using var scope = _mgmtGrpParentWithNonResChWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithNonResChWithLocRestClient.Get(Id.Name, mgmtGrpParentWithNonResChWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtGrpParentWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGrpParentWithNonResChWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _mgmtGrpParentWithNonResChWithLocRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mgmtGrpParentWithNonResChWithLocRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new MgmtGrpParentWithNonResChWithLocResource(Client, MgmtGrpParentWithNonResChWithLocData.DeserializeMgmtGrpParentWithNonResChWithLocData(e)), _mgmtGrpParentWithNonResChWithLocClientDiagnostics, Pipeline, "MgmtGrpParentWithNonResChWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtGrpParentWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGrpParentWithNonResChWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _mgmtGrpParentWithNonResChWithLocRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mgmtGrpParentWithNonResChWithLocRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new MgmtGrpParentWithNonResChWithLocResource(Client, MgmtGrpParentWithNonResChWithLocData.DeserializeMgmtGrpParentWithNonResChWithLocData(e)), _mgmtGrpParentWithNonResChWithLocClientDiagnostics, Pipeline, "MgmtGrpParentWithNonResChWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChWithLocName, nameof(mgmtGrpParentWithNonResChWithLocName));

            using var scope = _mgmtGrpParentWithNonResChWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithNonResChWithLocRestClient.GetAsync(Id.Name, mgmtGrpParentWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChWithLocName, nameof(mgmtGrpParentWithNonResChWithLocName));

            using var scope = _mgmtGrpParentWithNonResChWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithNonResChWithLocRestClient.Get(Id.Name, mgmtGrpParentWithNonResChWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MgmtGrpParentWithNonResChWithLocResource> IEnumerable<MgmtGrpParentWithNonResChWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MgmtGrpParentWithNonResChWithLocResource> IAsyncEnumerable<MgmtGrpParentWithNonResChWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
