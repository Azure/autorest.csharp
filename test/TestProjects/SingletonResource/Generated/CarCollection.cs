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
            Client.TryGetApiVersion(Car.ResourceType, out string carApiVersion);
            _carRestClient = new CarsRestOperations(_carClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, carApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Put
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="parameters"> The Car to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<Car>> CreateOrUpdateAsync(bool waitForCompletion, string carName, CarData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _carRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SingletonResourceArmOperation<Car>(Response.FromValue(new Car(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Put
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="parameters"> The Car to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<Car> CreateOrUpdate(bool waitForCompletion, string carName, CarData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _carRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, carName, parameters, cancellationToken);
                var operation = new SingletonResourceArmOperation<Car>(Response.FromValue(new Car(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Get
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public async virtual Task<Response<Car>> GetAsync(string carName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(carName, nameof(carName));

            using var scope = _carClientDiagnostics.CreateScope("CarCollection.Get");
            scope.Start();
            try
            {
                var response = await _carRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, carName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _carClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Car(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Get
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
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
                    throw _carClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Car(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_List
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_List
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string carName, CancellationToken cancellationToken = default)
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public async virtual Task<Response<Car>> GetIfExistsAsync(string carName, CancellationToken cancellationToken = default)
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Cars_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is empty. </exception>
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
