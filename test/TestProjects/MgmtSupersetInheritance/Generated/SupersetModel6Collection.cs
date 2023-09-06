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

namespace MgmtSupersetInheritance
{
    /// <summary>
    /// A class representing a collection of <see cref="SupersetModel6Resource" /> and their operations.
    /// Each <see cref="SupersetModel6Resource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="SupersetModel6Collection" /> instance call the GetSupersetModel6s method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class SupersetModel6Collection : ArmCollection, IEnumerable<SupersetModel6Resource>, IAsyncEnumerable<SupersetModel6Resource>
    {
        private readonly ClientDiagnostics _supersetModel6ClientDiagnostics;
        private readonly SupersetModel6SRestOperations _supersetModel6RestClient;

        /// <summary> Initializes a new instance of the <see cref="SupersetModel6Collection"/> class for mocking. </summary>
        protected SupersetModel6Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SupersetModel6Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SupersetModel6Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _supersetModel6ClientDiagnostics = new ClientDiagnostics("MgmtSupersetInheritance", SupersetModel6Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SupersetModel6Resource.ResourceType, out string supersetModel6ApiVersion);
            _supersetModel6RestClient = new SupersetModel6SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, supersetModel6ApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="data"> The SupersetModel6 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SupersetModel6Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string supersetModel6SName, SupersetModel6Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _supersetModel6RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtSupersetInheritanceArmOperation<SupersetModel6Resource>(Response.FromValue(new SupersetModel6Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="data"> The SupersetModel6 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SupersetModel6Resource> CreateOrUpdate(WaitUntil waitUntil, string supersetModel6SName, SupersetModel6Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _supersetModel6RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, data, cancellationToken);
                var operation = new MgmtSupersetInheritanceArmOperation<SupersetModel6Resource>(Response.FromValue(new SupersetModel6Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel6Resource>> GetAsync(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Get");
            scope.Start();
            try
            {
                var response = await _supersetModel6RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel6Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual Response<SupersetModel6Resource> Get(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Get");
            scope.Start();
            try
            {
                var response = _supersetModel6RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel6Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SupersetModel6Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupersetModel6Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _supersetModel6RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new SupersetModel6Resource(Client, SupersetModel6Data.DeserializeSupersetModel6Data(e)), _supersetModel6ClientDiagnostics, Pipeline, "SupersetModel6Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupersetModel6Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupersetModel6Resource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _supersetModel6RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new SupersetModel6Resource(Client, SupersetModel6Data.DeserializeSupersetModel6Data(e)), _supersetModel6ClientDiagnostics, Pipeline, "SupersetModel6Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Exists");
            scope.Start();
            try
            {
                var response = await _supersetModel6RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel6s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel6SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel6SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel6SName"/> is null. </exception>
        public virtual Response<bool> Exists(string supersetModel6SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel6SName, nameof(supersetModel6SName));

            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.Exists");
            scope.Start();
            try
            {
                var response = _supersetModel6RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel6SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SupersetModel6Resource> IEnumerable<SupersetModel6Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SupersetModel6Resource> IAsyncEnumerable<SupersetModel6Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
