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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace SingletonResource
{
    /// <summary> A class representing collection of Car and their operations over its parent. </summary>
    public partial class CarCollection : ArmCollection, IEnumerable<Car>, IAsyncEnumerable<Car>
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
            _carClientDiagnostics = new ClientDiagnostics("SingletonResource", Car.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(Car.ResourceType, out string carApiVersion);
            _carRestClient = new CarsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, carApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="parameters"> The Car to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<Car>> CreateOrUpdateAsync(WaitUntil waitUntil, string carName, CarData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _carRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SingletonResourceArmOperation<Car>(Response.FromValue(new Car(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Put
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="parameters"> The Car to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<Car> CreateOrUpdate(WaitUntil waitUntil, string carName, CarData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _carRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, carName, parameters, cancellationToken);
                var operation = new SingletonResourceArmOperation<Car>(Response.FromValue(new Car(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual async Task<Response<Car>> GetAsync(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.Get");
            scope.Start();
            try
            {
                var response = await _carRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Car(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual Response<Car> Get(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.Get");
            scope.Start();
            try
            {
                var response = _carRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Car(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars
        /// Operation Id: Cars_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Car" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Car> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Car>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _carClientDiagnostics.CreateScope("CarCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _carRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Car(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars
        /// Operation Id: Cars_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Car" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Car> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Car> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _carClientDiagnostics.CreateScope("CarCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _carRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Car(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
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
                var response = await GetIfExistsAsync(carName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
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
                var response = GetIfExists(carName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual async Task<Response<Car>> GetIfExistsAsync(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _carRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Car>(null, response.GetRawResponse());
                return Response.FromValue(new Car(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public virtual Response<Car> GetIfExists(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _carRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Car>(null, response.GetRawResponse());
                return Response.FromValue(new Car(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Car> IEnumerable<Car>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Car> IAsyncEnumerable<Car>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
