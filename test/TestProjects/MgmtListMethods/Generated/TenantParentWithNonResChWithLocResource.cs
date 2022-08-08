// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary>
    /// A Class representing a TenantParentWithNonResChWithLoc along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="TenantParentWithNonResChWithLocResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetTenantParentWithNonResChWithLocResource method.
    /// Otherwise you can get one from its parent resource <see cref="TenantTestResource" /> using the GetTenantParentWithNonResChWithLoc method.
    /// </summary>
    public partial class TenantParentWithNonResChWithLocResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="TenantParentWithNonResChWithLocResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string tenantTestName, string tenantParentWithNonResChWithLocName)
        {
            var resourceId = $"/providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _tenantParentWithNonResChWithLocClientDiagnostics;
        private readonly TenantParentWithNonResChWithLocsRestOperations _tenantParentWithNonResChWithLocRestClient;
        private readonly TenantParentWithNonResChWithLocData _data;

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithNonResChWithLocResource"/> class for mocking. </summary>
        protected TenantParentWithNonResChWithLocResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TenantParentWithNonResChWithLocResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TenantParentWithNonResChWithLocResource(ArmClient client, TenantParentWithNonResChWithLocData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithNonResChWithLocResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TenantParentWithNonResChWithLocResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _tenantParentWithNonResChWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string tenantParentWithNonResChWithLocApiVersion);
            _tenantParentWithNonResChWithLocRestClient = new TenantParentWithNonResChWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, tenantParentWithNonResChWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Tenant/tenantTests/tenantParentWithNonResChWithLocs";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual TenantParentWithNonResChWithLocData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}
        /// Operation Id: TenantParentWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TenantParentWithNonResChWithLocResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocResource.Get");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChWithLocRestClient.GetAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}
        /// Operation Id: TenantParentWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TenantParentWithNonResChWithLocResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocResource.Get");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChWithLocRestClient.Get(Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}
        /// Operation Id: TenantParentWithNonResChWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TenantParentWithNonResChWithLocResource>> UpdateAsync(WaitUntil waitUntil, TenantParentWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocResource.Update");
            scope.Start();
            try
            {
                var response = await _tenantParentWithNonResChWithLocRestClient.CreateOrUpdateAsync(Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResChWithLocResource>(Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}
        /// Operation Id: TenantParentWithNonResChWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TenantParentWithNonResChWithLocResource> Update(WaitUntil waitUntil, TenantParentWithNonResChWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocResource.Update");
            scope.Start();
            try
            {
                var response = _tenantParentWithNonResChWithLocRestClient.CreateOrUpdate(Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<TenantParentWithNonResChWithLocResource>(Response.FromValue(new TenantParentWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
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
        /// Lists all.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}/nonResourceChild
        /// Operation Id: TenantParentWithNonResChWithLocs_ListNonResourceChild
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NonResourceChild> GetNonResourceChildAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NonResourceChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocResource.GetNonResourceChild");
                scope.Start();
                try
                {
                    var response = await _tenantParentWithNonResChWithLocRestClient.ListNonResourceChildAsync(Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Lists all.
        /// Request Path: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}/tenantParentWithNonResChWithLocs/{tenantParentWithNonResChWithLocName}/nonResourceChild
        /// Operation Id: TenantParentWithNonResChWithLocs_ListNonResourceChild
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NonResourceChild> GetNonResourceChild(CancellationToken cancellationToken = default)
        {
            Page<NonResourceChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _tenantParentWithNonResChWithLocClientDiagnostics.CreateScope("TenantParentWithNonResChWithLocResource.GetNonResourceChild");
                scope.Start();
                try
                {
                    var response = _tenantParentWithNonResChWithLocRestClient.ListNonResourceChild(Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
