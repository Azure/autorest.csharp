// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtSingletonResource.Models;

namespace MgmtSingletonResource
{
    /// <summary>
    /// A Class representing a Brake along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="BrakeResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetBrakeResource method.
    /// Otherwise you can get one from its parent resource <see cref="CarResource" /> using the GetBrake method.
    /// </summary>
    public partial class BrakeResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BrakeResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string carName, BrakeName @default)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/brakes/{@default}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _brakeClientDiagnostics;
        private readonly BrakesRestOperations _brakeRestClient;
        private readonly BrakeData _data;

        /// <summary> Initializes a new instance of the <see cref="BrakeResource"/> class for mocking. </summary>
        protected BrakeResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BrakeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BrakeResource(ArmClient client, BrakeData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="BrakeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BrakeResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _brakeClientDiagnostics = new ClientDiagnostics("MgmtSingletonResource", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string brakeApiVersion);
            _brakeRestClient = new BrakesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, brakeApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/cars/brakes";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BrakeData Data
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/brakes/{default}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Brakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BrakeResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _brakeClientDiagnostics.CreateScope("BrakeResource.Get");
            scope.Start();
            try
            {
                var response = await _brakeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BrakeResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/brakes/{default}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Brakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BrakeResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _brakeClientDiagnostics.CreateScope("BrakeResource.Get");
            scope.Start();
            try
            {
                var response = _brakeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BrakeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
