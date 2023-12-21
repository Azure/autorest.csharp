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

namespace MgmtSingletonResource
{
    /// <summary>
    /// A Class representing an Ignition along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="IgnitionResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetIgnitionResource method.
    /// Otherwise you can get one from its parent resource <see cref="CarResource"/> using the GetIgnition method.
    /// </summary>
    public partial class IgnitionResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="IgnitionResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="carName"> The carName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string carName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/ignitions/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _ignitionClientDiagnostics;
        private readonly IgnitionsRestOperations _ignitionRestClient;
        private readonly IgnitionData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/cars/ignitions";

        /// <summary> Initializes a new instance of the <see cref="IgnitionResource"/> class for mocking. </summary>
        protected IgnitionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="IgnitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal IgnitionResource(ArmClient client, IgnitionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="IgnitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal IgnitionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _ignitionClientDiagnostics = new ClientDiagnostics("MgmtSingletonResource", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string ignitionApiVersion);
            _ignitionRestClient = new IgnitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, ignitionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/ignitions/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Ignitions_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/cars/ignitions</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IgnitionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _ignitionClientDiagnostics.CreateScope("IgnitionResource.Get");
            scope.Start();
            try
            {
                var response = await _ignitionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IgnitionResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}/ignitions/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Ignitions_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Compute/cars/ignitions</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IgnitionResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _ignitionClientDiagnostics.CreateScope("IgnitionResource.Get");
            scope.Start();
            try
            {
                var response = _ignitionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IgnitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
