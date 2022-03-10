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
    /// <summary> A class representing collection of MgmtGroupParent and their operations over its parent. </summary>
    public partial class MgmtGroupParentCollection : ArmCollection, IEnumerable<MgmtGroupParent>, IAsyncEnumerable<MgmtGroupParent>
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
            _mgmtGroupParentClientDiagnostics = new ClientDiagnostics("MgmtListMethods", MgmtGroupParent.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(MgmtGroupParent.ResourceType, out string mgmtGroupParentApiVersion);
            _mgmtGroupParentRestClient = new MgmtGroupParentsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, mgmtGroupParentApiVersion);
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<MgmtGroupParent>> CreateOrUpdateAsync(WaitUntil waitUntil, string mgmtGroupParentName, MgmtGroupParentData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mgmtGroupParentRestClient.CreateOrUpdateAsync(Id.Name, mgmtGroupParentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<MgmtGroupParent>(Response.FromValue(new MgmtGroupParent(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<MgmtGroupParent> CreateOrUpdate(WaitUntil waitUntil, string mgmtGroupParentName, MgmtGroupParentData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mgmtGroupParentRestClient.CreateOrUpdate(Id.Name, mgmtGroupParentName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<MgmtGroupParent>(Response.FromValue(new MgmtGroupParent(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_Get
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual async Task<Response<MgmtGroupParent>> GetAsync(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGroupParentRestClient.GetAsync(Id.Name, mgmtGroupParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGroupParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_Get
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual Response<MgmtGroupParent> Get(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.Get");
            scope.Start();
            try
            {
                var response = _mgmtGroupParentRestClient.Get(Id.Name, mgmtGroupParentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGroupParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents
        /// Operation Id: MgmtGroupParents_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MgmtGroupParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MgmtGroupParent> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<MgmtGroupParent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGroupParentRestClient.ListAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGroupParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<MgmtGroupParent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mgmtGroupParentRestClient.ListNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGroupParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents
        /// Operation Id: MgmtGroupParents_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MgmtGroupParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MgmtGroupParent> GetAll(CancellationToken cancellationToken = default)
        {
            Page<MgmtGroupParent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGroupParentRestClient.List(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGroupParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<MgmtGroupParent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mgmtGroupParentRestClient.ListNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new MgmtGroupParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_Get
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
                var response = await GetIfExistsAsync(mgmtGroupParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_Get
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
                var response = GetIfExists(mgmtGroupParentName, cancellationToken: cancellationToken);
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
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_Get
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual async Task<Response<MgmtGroupParent>> GetIfExistsAsync(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _mgmtGroupParentRestClient.GetAsync(Id.Name, mgmtGroupParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<MgmtGroupParent>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGroupParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}
        /// Operation Id: MgmtGroupParents_Get
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        public virtual Response<MgmtGroupParent> GetIfExists(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mgmtGroupParentName, nameof(mgmtGroupParentName));

            using var scope = _mgmtGroupParentClientDiagnostics.CreateScope("MgmtGroupParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _mgmtGroupParentRestClient.Get(Id.Name, mgmtGroupParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<MgmtGroupParent>(null, response.GetRawResponse());
                return Response.FromValue(new MgmtGroupParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MgmtGroupParent> IEnumerable<MgmtGroupParent>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MgmtGroupParent> IAsyncEnumerable<MgmtGroupParent>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
