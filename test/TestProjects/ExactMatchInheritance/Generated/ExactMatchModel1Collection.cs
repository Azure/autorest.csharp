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

namespace ExactMatchInheritance
{
    /// <summary>
    /// A class representing a collection of <see cref="ExactMatchModel1Resource" /> and their operations.
    /// Each <see cref="ExactMatchModel1Resource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="ExactMatchModel1Collection" /> instance call the GetExactMatchModel1s method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ExactMatchModel1Collection : ArmCollection, IEnumerable<ExactMatchModel1Resource>, IAsyncEnumerable<ExactMatchModel1Resource>
    {
        private readonly ClientDiagnostics _exactMatchModel1ClientDiagnostics;
        private readonly ExactMatchModel1SRestOperations _exactMatchModel1RestClient;

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel1Collection"/> class for mocking. </summary>
        protected ExactMatchModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel1Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ExactMatchModel1Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _exactMatchModel1ClientDiagnostics = new ClientDiagnostics("ExactMatchInheritance", ExactMatchModel1Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ExactMatchModel1Resource.ResourceType, out string exactMatchModel1ApiVersion);
            _exactMatchModel1RestClient = new ExactMatchModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, exactMatchModel1ApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="data"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ExactMatchModel1Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string exactMatchModel1SName, ExactMatchModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _exactMatchModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel1SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ExactMatchInheritanceArmOperation<ExactMatchModel1Resource>(Response.FromValue(new ExactMatchModel1Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="data"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ExactMatchModel1Resource> CreateOrUpdate(WaitUntil waitUntil, string exactMatchModel1SName, ExactMatchModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _exactMatchModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel1SName, data, cancellationToken);
                var operation = new ExactMatchInheritanceArmOperation<ExactMatchModel1Resource>(Response.FromValue(new ExactMatchModel1Resource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Get
        /// </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        public virtual async Task<Response<ExactMatchModel1Resource>> GetAsync(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _exactMatchModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Get
        /// </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        public virtual Response<ExactMatchModel1Resource> Get(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _exactMatchModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel1SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s
        /// Operation Id: ExactMatchModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExactMatchModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ExactMatchModel1Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ExactMatchModel1Resource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _exactMatchModel1RestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ExactMatchModel1Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s
        /// Operation Id: ExactMatchModel1s_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExactMatchModel1Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ExactMatchModel1Resource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ExactMatchModel1Resource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _exactMatchModel1RestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ExactMatchModel1Resource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Get
        /// </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(exactMatchModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Get
        /// </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(exactMatchModel1SName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Get
        /// </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        public virtual async Task<Response<ExactMatchModel1Resource>> GetIfExistsAsync(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _exactMatchModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ExactMatchModel1Resource>(null, response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}
        /// Operation Id: ExactMatchModel1s_Get
        /// </summary>
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="exactMatchModel1SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exactMatchModel1SName"/> is null. </exception>
        public virtual Response<ExactMatchModel1Resource> GetIfExists(string exactMatchModel1SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(exactMatchModel1SName, nameof(exactMatchModel1SName));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _exactMatchModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, exactMatchModel1SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ExactMatchModel1Resource>(null, response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ExactMatchModel1Resource> IEnumerable<ExactMatchModel1Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ExactMatchModel1Resource> IAsyncEnumerable<ExactMatchModel1Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
