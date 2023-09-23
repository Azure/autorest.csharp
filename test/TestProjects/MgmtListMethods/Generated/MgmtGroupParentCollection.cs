// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="MgmtGroupParentResource" /> and their operations.
    /// Each <see cref="MgmtGroupParentResource" /> in the collection will belong to the same instance of <see cref="ManagementGroupResource" />.
    /// To get a <see cref="MgmtGroupParentCollection" /> instance call the GetMgmtGroupParents method from an instance of <see cref="ManagementGroupResource" />.
    /// </summary>
    public partial class MgmtGroupParentCollection : ArmCollection, IEnumerable<MgmtGroupParentResource>, IAsyncEnumerable<MgmtGroupParentResource>
    {
        private readonly ClientDiagnostics _mgmtGroupParentClientDiagnostics;
        private readonly MgmtGroupParentsRestOperations _mgmtGroupParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtGroupParentCollection"/> class for mocking. </summary>
        protected MgmtGroupParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGroupParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MgmtGroupParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mgmtGroupParentClientDiagnostics = new ClientDiagnostics("MgmtListMethods", MgmtGroupParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MgmtGroupParentResource.ResourceType, out string mgmtGroupParentApiVersion);
            _mgmtGroupParentRestClient = new MgmtGroupParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mgmtGroupParentApiVersion);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MgmtGroupParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string mgmtGroupParentName, MgmtGroupParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mgmtGroupParentRestClient.CreateOrUpdateAsync(Id.Name, mgmtGroupParentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<MgmtGroupParentResource>(Response.FromValue(new MgmtGroupParentResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MgmtGroupParentResource> CreateOrUpdate(WaitUntil waitUntil, string mgmtGroupParentName, MgmtGroupParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mgmtGroupParentRestClient.CreateOrUpdate(Id.Name, mgmtGroupParentName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<MgmtGroupParentResource>(Response.FromValue(new MgmtGroupParentResource(Client, response), response.GetRawResponse()));
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual async Task<Response<MgmtGroupParentResource>> GetAsync(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGroupParentRestClient.GetAsync(Id.Name, mgmtGroupParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MgmtGroupParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual Response<MgmtGroupParentResource> Get(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.Get");
            scope.Start();
            try
            {
                var response = _mgmtGroupParentRestClient.Get(Id.Name, mgmtGroupParentName, cancellationToken);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MgmtGroupParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtGroupParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGroupParentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _mgmtGroupParentRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mgmtGroupParentRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new MgmtGroupParentResource(Client, MgmtGroupParentData.DeserializeMgmtGroupParentData(e)), _mgmtGroupParentClientDiagnostics, Pipeline, "MgmtGroupParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtGroupParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGroupParentResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _mgmtGroupParentRestClient.CreateListRequest(Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _mgmtGroupParentRestClient.CreateListNextPageRequest(nextLink, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new MgmtGroupParentResource(Client, MgmtGroupParentData.DeserializeMgmtGroupParentData(e)), _mgmtGroupParentClientDiagnostics, Pipeline, "MgmtGroupParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _mgmtGroupParentRestClient.GetAsync(Id.Name, mgmtGroupParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.Exists");
            scope.Start();
            try
            {
                var response = _mgmtGroupParentRestClient.Get(Id.Name, mgmtGroupParentName, cancellationToken: cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual async Task<NullableResponse<MgmtGroupParentResource>> GetIfExistsAsync(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _mgmtGroupParentRestClient.GetAsync(Id.Name, mgmtGroupParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<MgmtGroupParentResource>(response.GetRawResponse());
                return Response.FromValue(new MgmtGroupParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual NullableResponse<MgmtGroupParentResource> GetIfExists(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _mgmtGroupParentRestClient.Get(Id.Name, mgmtGroupParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<MgmtGroupParentResource>(response.GetRawResponse());
                return Response.FromValue(new MgmtGroupParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MgmtGroupParentResource> IEnumerable<MgmtGroupParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MgmtGroupParentResource> IAsyncEnumerable<MgmtGroupParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
