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
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtSingletonResource
{
    /// <summary>
    /// A class representing a collection of <see cref="CarResource" /> and their operations.
    /// Each <see cref="CarResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="CarCollection" /> instance call the GetCars method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class CarCollection : ArmCollection, IEnumerable<CarResource>, IAsyncEnumerable<CarResource>
    {
        private readonly ClientDiagnostics _carClientDiagnostics;
        private readonly CarsRestOperations _carRestClient;

        /// <summary> Initializes a new instance of the <see cref="CarCollection"/> class for mocking. </summary>
        protected CarCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CarCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal CarCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _carClientDiagnostics = new ClientDiagnostics("MgmtSingletonResource", CarResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(CarResource.ResourceType, out string carApiVersion);
            _carRestClient = new CarsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, carApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="data"> The CarData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<CarResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string carName, CarData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _carRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtSingletonResourceArmOperation<CarResource>(Response.FromValue(new CarResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="data"> The CarData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<CarResource> CreateOrUpdate(WaitUntil waitUntil, string carName, CarData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _carRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, carName, data, cancellationToken);
                var operation = new MgmtSingletonResourceArmOperation<CarResource>(Response.FromValue(new CarResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual async Task<Response<CarResource>> GetAsync(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.Get");
            scope.Start();
            try
            {
                var response = await _carRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CarResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual Response<CarResource> Get(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.Get");
            scope.Start();
            try
            {
                var response = _carRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CarResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CarResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _carRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new CarResource(Client, CarData.DeserializeCarData(e)), _carClientDiagnostics, Pipeline, "CarCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CarResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _carRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new CarResource(Client, CarData.DeserializeCarData(e)), _carClientDiagnostics, Pipeline, "CarCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.Exists");
            scope.Start();
            try
            {
                var response = await _carRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Cars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual Response<bool> Exists(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.Exists");
            scope.Start();
            try
            {
                var response = _carRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<CarResource> IEnumerable<CarResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CarResource> IAsyncEnumerable<CarResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
