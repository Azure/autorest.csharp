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
using Azure.ResourceManager.Resources;

namespace MgmtNoTypeReplacement
{
    /// <summary>
    /// A class representing a collection of <see cref="NoTypeReplacementModel1Resource" /> and their operations.
    /// Each <see cref="NoTypeReplacementModel1Resource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="NoTypeReplacementModel1Collection" /> instance call the GetNoTypeReplacementModel1s method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class NoTypeReplacementModel1Collection : ArmCollection, IEnumerable<NoTypeReplacementModel1Resource>, IAsyncEnumerable<NoTypeReplacementModel1Resource>
    {
        private readonly ClientDiagnostics _noTypeReplacementModel1ClientDiagnostics;
        private readonly NoTypeReplacementModel1SRestOperations _noTypeReplacementModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Collection"/> class for mocking. </summary>
        protected NoTypeReplacementModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NoTypeReplacementModel1Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _noTypeReplacementModel1ClientDiagnostics = new ClientDiagnostics("MgmtNoTypeReplacement", NoTypeReplacementModel1Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(NoTypeReplacementModel1Resource.ResourceType, out string noTypeReplacementModel1ApiVersion);
            _noTypeReplacementModel1RestClient = new NoTypeReplacementModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, noTypeReplacementModel1ApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="data"> The NoTypeReplacementModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NoTypeReplacementModel1Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string noTypeReplacementModel1SName, NoTypeReplacementModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel1Resource>(Response.FromValue(new NoTypeReplacementModel1Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="data"> The NoTypeReplacementModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NoTypeReplacementModel1Resource> CreateOrUpdate(WaitUntil waitUntil, string noTypeReplacementModel1SName, NoTypeReplacementModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, data, cancellationToken);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel1Resource>(Response.FromValue(new NoTypeReplacementModel1Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual async Task<Response<NoTypeReplacementModel1Resource>> GetAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel1Resource> Get(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NoTypeReplacementModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NoTypeReplacementModel1Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _noTypeReplacementModel1RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new NoTypeReplacementModel1Resource(Client, NoTypeReplacementModel1Data.DeserializeNoTypeReplacementModel1Data(e)), _noTypeReplacementModel1ClientDiagnostics, Pipeline, "NoTypeReplacementModel1Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NoTypeReplacementModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NoTypeReplacementModel1Resource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _noTypeReplacementModel1RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new NoTypeReplacementModel1Resource(Client, NoTypeReplacementModel1Data.DeserializeNoTypeReplacementModel1Data(e)), _noTypeReplacementModel1ClientDiagnostics, Pipeline, "NoTypeReplacementModel1Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string noTypeReplacementModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel1SName, nameof(noTypeReplacementModel1SName));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NoTypeReplacementModel1Resource> IEnumerable<NoTypeReplacementModel1Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NoTypeReplacementModel1Resource> IAsyncEnumerable<NoTypeReplacementModel1Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
