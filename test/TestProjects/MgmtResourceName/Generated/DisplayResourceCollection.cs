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
using Azure.ResourceManager.Resources;

namespace MgmtResourceName
{
    /// <summary>
    /// A class representing a collection of <see cref="DisplayResource" /> and their operations.
    /// Each <see cref="DisplayResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="DisplayResourceCollection" /> instance call the GetDisplayResources method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class DisplayResourceCollection : ArmCollection, IEnumerable<DisplayResource>, IAsyncEnumerable<DisplayResource>
    {
        private readonly ClientDiagnostics _displayResourceClientDiagnostics;
        private readonly DisplayResourcesRestOperations _displayResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="DisplayResourceCollection"/> class for mocking. </summary>
        protected DisplayResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DisplayResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DisplayResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _displayResourceClientDiagnostics = new ClientDiagnostics("MgmtResourceName", DisplayResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DisplayResource.ResourceType, out string displayResourceApiVersion);
            _displayResourceRestClient = new DisplayResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, displayResourceApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DisplayResources_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="data"> The DisplayResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DisplayResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string displayResourceName, DisplayResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(displayResourceName, nameof(displayResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _displayResourceRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, displayResourceName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtResourceNameArmOperation<DisplayResource>(Response.FromValue(new DisplayResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DisplayResources_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="data"> The DisplayResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DisplayResource> CreateOrUpdate(WaitUntil waitUntil, string displayResourceName, DisplayResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(displayResourceName, nameof(displayResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _displayResourceRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, displayResourceName, data, cancellationToken);
                var operation = new MgmtResourceNameArmOperation<DisplayResource>(Response.FromValue(new DisplayResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>displayResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> is null. </exception>
        public virtual async Task<Response<DisplayResource>> GetAsync(string displayResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(displayResourceName, nameof(displayResourceName));

            using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _displayResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, displayResourceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DisplayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>displayResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> is null. </exception>
        public virtual Response<DisplayResource> Get(string displayResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(displayResourceName, nameof(displayResourceName));

            using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _displayResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, displayResourceName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DisplayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DisplayResources_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DisplayResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DisplayResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DisplayResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _displayResourceRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DisplayResource(Client, value)), null, response.GetRawResponse());
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DisplayResources_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DisplayResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DisplayResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DisplayResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _displayResourceRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DisplayResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>displayResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string displayResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(displayResourceName, nameof(displayResourceName));

            using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await _displayResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, displayResourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/displayResources/{displayResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>displayResources_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="displayResourceName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="displayResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="displayResourceName"/> is null. </exception>
        public virtual Response<bool> Exists(string displayResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(displayResourceName, nameof(displayResourceName));

            using var scope = _displayResourceClientDiagnostics.CreateScope("DisplayResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = _displayResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, displayResourceName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DisplayResource> IEnumerable<DisplayResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DisplayResource> IAsyncEnumerable<DisplayResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
