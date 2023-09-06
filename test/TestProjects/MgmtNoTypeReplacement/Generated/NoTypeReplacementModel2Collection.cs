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

namespace MgmtNoTypeReplacement
{
    /// <summary>
    /// A class representing a collection of <see cref="NoTypeReplacementModel2Resource" /> and their operations.
    /// Each <see cref="NoTypeReplacementModel2Resource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="NoTypeReplacementModel2Collection" /> instance call the GetNoTypeReplacementModel2s method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class NoTypeReplacementModel2Collection : ArmCollection, IEnumerable<NoTypeReplacementModel2Resource>, IAsyncEnumerable<NoTypeReplacementModel2Resource>
    {
        private readonly ClientDiagnostics _noTypeReplacementModel2ClientDiagnostics;
        private readonly NoTypeReplacementModel2SRestOperations _noTypeReplacementModel2RestClient;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel2Collection"/> class for mocking. </summary>
        protected NoTypeReplacementModel2Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel2Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NoTypeReplacementModel2Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _noTypeReplacementModel2ClientDiagnostics = new ClientDiagnostics("MgmtNoTypeReplacement", NoTypeReplacementModel2Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(NoTypeReplacementModel2Resource.ResourceType, out string noTypeReplacementModel2ApiVersion);
            _noTypeReplacementModel2RestClient = new NoTypeReplacementModel2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, noTypeReplacementModel2ApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="noTypeReplacementModel2SName"> The string to use. </param>
        /// <param name="data"> The NoTypeReplacementModel2Data to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NoTypeReplacementModel2Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string noTypeReplacementModel2SName, NoTypeReplacementModel2Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel2SName, nameof(noTypeReplacementModel2SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel2Resource>(Response.FromValue(new NoTypeReplacementModel2Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="noTypeReplacementModel2SName"> The string to use. </param>
        /// <param name="data"> The NoTypeReplacementModel2Data to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NoTypeReplacementModel2Resource> CreateOrUpdate(WaitUntil waitUntil, string noTypeReplacementModel2SName, NoTypeReplacementModel2Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel2SName, nameof(noTypeReplacementModel2SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, data, cancellationToken);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel2Resource>(Response.FromValue(new NoTypeReplacementModel2Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel2SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public virtual async Task<Response<NoTypeReplacementModel2Resource>> GetAsync(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel2SName, nameof(noTypeReplacementModel2SName));

            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel2Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel2SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public virtual Response<NoTypeReplacementModel2Resource> Get(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel2SName, nameof(noTypeReplacementModel2SName));

            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel2Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NoTypeReplacementModel2Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NoTypeReplacementModel2Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _noTypeReplacementModel2RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new NoTypeReplacementModel2Resource(Client, NoTypeReplacementModel2Data.DeserializeNoTypeReplacementModel2Data(e)), _noTypeReplacementModel2ClientDiagnostics, Pipeline, "NoTypeReplacementModel2Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NoTypeReplacementModel2Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NoTypeReplacementModel2Resource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _noTypeReplacementModel2RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new NoTypeReplacementModel2Resource(Client, NoTypeReplacementModel2Data.DeserializeNoTypeReplacementModel2Data(e)), _noTypeReplacementModel2ClientDiagnostics, Pipeline, "NoTypeReplacementModel2Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel2SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel2SName, nameof(noTypeReplacementModel2SName));

            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.Exists");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="noTypeReplacementModel2SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="noTypeReplacementModel2SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="noTypeReplacementModel2SName"/> is null. </exception>
        public virtual Response<bool> Exists(string noTypeReplacementModel2SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(noTypeReplacementModel2SName, nameof(noTypeReplacementModel2SName));

            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2Collection.Exists");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, noTypeReplacementModel2SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NoTypeReplacementModel2Resource> IEnumerable<NoTypeReplacementModel2Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NoTypeReplacementModel2Resource> IAsyncEnumerable<NoTypeReplacementModel2Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
