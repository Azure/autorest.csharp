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
using Azure.ResourceManager.Resources;

namespace MgmtResourceName
{
    /// <summary>
    /// A class representing a collection of <see cref="Disk"/> and their operations.
    /// Each <see cref="Disk"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="DiskCollection"/> instance call the GetDisks method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class DiskCollection : ArmCollection, IEnumerable<Disk>, IAsyncEnumerable<Disk>
    {
        private readonly ClientDiagnostics _diskClientDiagnostics;
        private readonly DisksRestOperations _diskRestClient;

        /// <summary> Initializes a new instance of the <see cref="DiskCollection"/> class for mocking. </summary>
        protected DiskCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DiskCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DiskCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _diskClientDiagnostics = new ClientDiagnostics("MgmtResourceName", Disk.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(Disk.ResourceType, out string diskApiVersion);
            _diskRestClient = new DisksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, diskApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// The Put method
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="DiskData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<Disk>> CreateOrUpdateAsync(WaitUntil waitUntil, string diskResourceName, DiskData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _diskRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtResourceNameArmOperation<Disk>(Response.FromValue(new Disk(Client, response), response.GetRawResponse()));
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
        /// The Put method
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Put</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="DiskData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<Disk> CreateOrUpdate(WaitUntil waitUntil, string diskResourceName, DiskData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _diskRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, data, cancellationToken);
                var operation = new MgmtResourceNameArmOperation<Disk>(Response.FromValue(new Disk(Client, response), response.GetRawResponse()));
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
        /// The Get method
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        public virtual async Task<Response<Disk>> GetAsync(string diskResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.Get");
            scope.Start();
            try
            {
                var response = await _diskRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Disk(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Get method
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        public virtual Response<Disk> Get(string diskResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.Get");
            scope.Start();
            try
            {
                var response = _diskRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Disk(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The List method
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Disk"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Disk> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _diskRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new Disk(Client, DiskData.DeserializeDiskData(e)), _diskClientDiagnostics, Pipeline, "DiskCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// The List method
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Disk"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Disk> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _diskRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new Disk(Client, DiskData.DeserializeDiskData(e)), _diskClientDiagnostics, Pipeline, "DiskCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string diskResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.Exists");
            scope.Start();
            try
            {
                var response = await _diskRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        public virtual Response<bool> Exists(string diskResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.Exists");
            scope.Start();
            try
            {
                var response = _diskRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        public virtual async Task<NullableResponse<Disk>> GetIfExistsAsync(string diskResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _diskRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<Disk>(response.GetRawResponse());
                return Response.FromValue(new Disk(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskResources/{diskResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Disks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="Disk"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="diskResourceName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskResourceName"/> is null. </exception>
        public virtual NullableResponse<Disk> GetIfExists(string diskResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(diskResourceName, nameof(diskResourceName));

            using var scope = _diskClientDiagnostics.CreateScope("DiskCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _diskRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskResourceName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<Disk>(response.GetRawResponse());
                return Response.FromValue(new Disk(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Disk> IEnumerable<Disk>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Disk> IAsyncEnumerable<Disk>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
