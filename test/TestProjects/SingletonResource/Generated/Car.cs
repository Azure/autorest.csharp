// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace SingletonResource
{
    /// <summary> A Class representing a Car along with the instance operations that can be performed on it. </summary>
    public partial class Car : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Car"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string carName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _carClientDiagnostics;
        private readonly CarsRestOperations _carRestClient;
        private readonly CarData _data;

        /// <summary> Initializes a new instance of the <see cref="Car"/> class for mocking. </summary>
        protected Car()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Car"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Car(ArmClient client, CarData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Car"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Car(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _carClientDiagnostics = new ClientDiagnostics("SingletonResource", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string carApiVersion);
            _carRestClient = new CarsRestOperations(_carClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, carApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/cars";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual CarData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets an object representing a Ignition along with the instance operations that can be performed on it in the Car. </summary>
        /// <returns> Returns a <see cref="Ignition" /> object. </returns>
        public virtual Ignition GetIgnition()
        {
            return new Ignition(Client, new ResourceIdentifier(Id.ToString() + "/ignitions/default"));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Car>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _carClientDiagnostics.CreateScope("Car.Get");
            scope.Start();
            try
            {
                var response = await _carRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
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

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Car> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _carClientDiagnostics.CreateScope("Car.Get");
            scope.Start();
            try
            {
                var response = _carRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
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
    }
}
