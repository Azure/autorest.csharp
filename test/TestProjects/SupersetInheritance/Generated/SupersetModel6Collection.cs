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

namespace SupersetInheritance
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
            _supersetModel6ClientDiagnostics = new ClientDiagnostics("SupersetInheritance", SupersetModel6Resource.ResourceType.Namespace, Diagnostics);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}
        /// Operation Id: SupersetModel6s_Put
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
                var operation = new SupersetInheritanceArmOperation<SupersetModel6Resource>(Response.FromValue(new SupersetModel6Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}
        /// Operation Id: SupersetModel6s_Put
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
                var operation = new SupersetInheritanceArmOperation<SupersetModel6Resource>(Response.FromValue(new SupersetModel6Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}
        /// Operation Id: SupersetModel6s_Get
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}
        /// Operation Id: SupersetModel6s_Get
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s
        /// Operation Id: SupersetModel6s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SupersetModel6Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupersetModel6Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SupersetModel6Resource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _supersetModel6RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel6Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s
        /// Operation Id: SupersetModel6s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupersetModel6Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupersetModel6Resource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SupersetModel6Resource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _supersetModel6RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel6Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}
        /// Operation Id: SupersetModel6s_Get
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6sName}
        /// Operation Id: SupersetModel6s_Get
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
