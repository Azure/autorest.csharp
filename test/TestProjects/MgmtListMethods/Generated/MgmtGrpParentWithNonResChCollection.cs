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
using Azure.ResourceManager.ManagementGroups;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="MgmtGrpParentWithNonResChResource" /> and their operations.
    /// Each <see cref="MgmtGrpParentWithNonResChResource" /> in the collection will belong to the same instance of <see cref="ManagementGroupResource" />.
    /// To get a <see cref="MgmtGrpParentWithNonResChCollection" /> instance call the GetMgmtGrpParentWithNonResChes method from an instance of <see cref="ManagementGroupResource" />.
    /// </summary>
    public partial class MgmtGrpParentWithNonResChCollection : ArmCollection, IEnumerable<MgmtGrpParentWithNonResChResource>, IAsyncEnumerable<MgmtGrpParentWithNonResChResource>
    {
        private readonly ClientDiagnostics _mgmtGrpParentWithNonResChClientDiagnostics;
        private readonly MgmtGrpParentWithNonResChesRestOperations _mgmtGrpParentWithNonResChRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithNonResChCollection"/> class for mocking. </summary>
        protected MgmtGrpParentWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithNonResChCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MgmtGrpParentWithNonResChCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mgmtGrpParentWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", MgmtGrpParentWithNonResChResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MgmtGrpParentWithNonResChResource.ResourceType, out string mgmtGrpParentWithNonResChApiVersion);
            _mgmtGrpParentWithNonResChRestClient = new MgmtGrpParentWithNonResChesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mgmtGrpParentWithNonResChApiVersion);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MgmtGrpParentWithNonResChResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string mgmtGrpParentWithNonResChName, MgmtGrpParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithNonResChRestClient.CreateOrUpdateAsync(Id.Name, mgmtGrpParentWithNonResChName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithNonResChResource>(Response.FromValue(new MgmtGrpParentWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MgmtGrpParentWithNonResChResource> CreateOrUpdate(WaitUntil waitUntil, string mgmtGrpParentWithNonResChName, MgmtGrpParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithNonResChRestClient.CreateOrUpdate(Id.Name, mgmtGrpParentWithNonResChName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithNonResChResource>(Response.FromValue(new MgmtGrpParentWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<MgmtGrpParentWithNonResChResource>> GetAsync(string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithNonResChRestClient.GetAsync(Id.Name, mgmtGrpParentWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithNonResChResource> Get(string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithNonResChRestClient.Get(Id.Name, mgmtGrpParentWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtGrpParentWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGrpParentWithNonResChResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<MgmtGrpParentWithNonResChResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithNonResChRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<MgmtGrpParentWithNonResChResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGrpParentWithNonResChRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtGrpParentWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGrpParentWithNonResChResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<MgmtGrpParentWithNonResChResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithNonResChRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<MgmtGrpParentWithNonResChResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGrpParentWithNonResChRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGrpParentWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithNonResChRestClient.GetAsync(Id.Name, mgmtGrpParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGrpParentWithNonResChName, nameof(mgmtGrpParentWithNonResChName));

            using var scope = _mgmtGrpParentWithNonResChClientDiagnostics.CreateScope("MgmtGrpParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithNonResChRestClient.Get(Id.Name, mgmtGrpParentWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MgmtGrpParentWithNonResChResource> IEnumerable<MgmtGrpParentWithNonResChResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MgmtGrpParentWithNonResChResource> IAsyncEnumerable<MgmtGrpParentWithNonResChResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
