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
    /// <summary> A Class representing a Ignition along with the instance operations that can be performed on it. </summary>
    public partial class Ignition : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Ignition"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string carName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/ignitions/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _ignitionClientDiagnostics;
        private readonly IgnitionsRestOperations _ignitionRestClient;
        private readonly IgnitionData _data;

        /// <summary> Initializes a new instance of the <see cref="Ignition"/> class for mocking. </summary>
        protected Ignition()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Ignition"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Ignition(ArmClient client, IgnitionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Ignition"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Ignition(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _ignitionClientDiagnostics = new ClientDiagnostics("SingletonResource", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string ignitionApiVersion);
            _ignitionRestClient = new IgnitionsRestOperations(_ignitionClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, ignitionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/cars/ignitions";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual IgnitionData Data
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

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/ignitions/default
        /// Operation Id: Ignitions_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Ignition>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _ignitionClientDiagnostics.CreateScope("Ignition.Get");
            scope.Start();
            try
            {
                var response = await _ignitionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _ignitionClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Ignition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/ignitions/default
        /// Operation Id: Ignitions_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Ignition> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _ignitionClientDiagnostics.CreateScope("Ignition.Get");
            scope.Start();
            try
            {
                var response = _ignitionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw _ignitionClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Ignition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
