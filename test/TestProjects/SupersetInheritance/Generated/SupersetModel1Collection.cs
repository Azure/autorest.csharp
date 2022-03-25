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
    /// A class representing a collection of <see cref="SupersetModel1Resource" /> and their operations.
    /// Each <see cref="SupersetModel1Resource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="SupersetModel1Collection" /> instance call the GetSupersetModel1s method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class SupersetModel1Collection : ArmCollection, IEnumerable<SupersetModel1Resource>, IAsyncEnumerable<SupersetModel1Resource>
    {
        private readonly ClientDiagnostics _supersetModel1ClientDiagnostics;
        private readonly SupersetModel1SRestOperations _supersetModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="SupersetModel1Collection"/> class for mocking. </summary>
        protected SupersetModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SupersetModel1Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SupersetModel1Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _supersetModel1ClientDiagnostics = new ClientDiagnostics("SupersetInheritance", SupersetModel1Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SupersetModel1Resource.ResourceType, out string supersetModel1ApiVersion);
            _supersetModel1RestClient = new SupersetModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, supersetModel1ApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="data"> The SupersetModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SupersetModel1Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string supersetModel1SName, SupersetModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _supersetModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel1SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SupersetInheritanceArmOperation<SupersetModel1Resource>(Response.FromValue(new SupersetModel1Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="data"> The SupersetModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SupersetModel1Resource> CreateOrUpdate(WaitUntil waitUntil, string supersetModel1SName, SupersetModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _supersetModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel1SName, data, cancellationToken);
                var operation = new SupersetInheritanceArmOperation<SupersetModel1Resource>(Response.FromValue(new SupersetModel1Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Get
        /// </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel1Resource>> GetAsync(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _supersetModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Get
        /// </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> is null. </exception>
        public virtual Response<SupersetModel1Resource> Get(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _supersetModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel1SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s
        /// Operation Id: SupersetModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SupersetModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupersetModel1Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SupersetModel1Resource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _supersetModel1RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel1Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s
        /// Operation Id: SupersetModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupersetModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupersetModel1Resource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SupersetModel1Resource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _supersetModel1RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SupersetModel1Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Get
        /// </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(supersetModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Get
        /// </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(supersetModel1SName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Get
        /// </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel1Resource>> GetIfExistsAsync(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _supersetModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SupersetModel1Resource>(null, response.GetRawResponse());
                return Response.FromValue(new SupersetModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel1s/{supersetModel1sName}
        /// Operation Id: SupersetModel1s_Get
        /// </summary>
        /// <param name="supersetModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel1SName"/> is null. </exception>
        public virtual Response<SupersetModel1Resource> GetIfExists(string supersetModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel1SName, nameof(supersetModel1SName));

            using var scope = _supersetModel1ClientDiagnostics.CreateScope("SupersetModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _supersetModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel1SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SupersetModel1Resource>(null, response.GetRawResponse());
                return Response.FromValue(new SupersetModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SupersetModel1Resource> IEnumerable<SupersetModel1Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SupersetModel1Resource> IAsyncEnumerable<SupersetModel1Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
