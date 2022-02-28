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

namespace MgmtExtensionResource
{
    /// <summary> A Class representing a SubSingleton along with the instance operations that can be performed on it. </summary>
    public partial class SubSingleton : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SubSingleton"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Singleton/subSingletons/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _subSingletonClientDiagnostics;
        private readonly SubSingletonsRestOperations _subSingletonRestClient;
        private readonly SubSingletonData _data;

        /// <summary> Initializes a new instance of the <see cref="SubSingleton"/> class for mocking. </summary>
        protected SubSingleton()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SubSingleton"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SubSingleton(ArmClient client, SubSingletonData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SubSingleton"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubSingleton(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subSingletonClientDiagnostics = new ClientDiagnostics("MgmtExtensionResource", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string subSingletonApiVersion);
            _subSingletonRestClient = new SubSingletonsRestOperations(_subSingletonClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subSingletonApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Singleton/subSingletons";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SubSingletonData Data
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
        /// Singleton that belongs to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Singleton/subSingletons/default
        /// Operation Id: SubSingletons_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SubSingleton>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _subSingletonClientDiagnostics.CreateScope("SubSingleton.Get");
            scope.Start();
            try
            {
                var response = await _subSingletonRestClient.GetAsync(Id.SubscriptionId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubSingleton(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Singleton that belongs to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Singleton/subSingletons/default
        /// Operation Id: SubSingletons_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SubSingleton> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _subSingletonClientDiagnostics.CreateScope("SubSingleton.Get");
            scope.Start();
            try
            {
                var response = _subSingletonRestClient.Get(Id.SubscriptionId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubSingleton(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Singleton that belongs to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Singleton/subSingletons/default/execute
        /// Operation Id: SubSingletons_Execute
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _subSingletonClientDiagnostics.CreateScope("SubSingleton.Execute");
            scope.Start();
            try
            {
                var response = await _subSingletonRestClient.ExecuteAsync(Id.SubscriptionId, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Singleton that belongs to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Singleton/subSingletons/default/execute
        /// Operation Id: SubSingletons_Execute
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Execute(CancellationToken cancellationToken = default)
        {
            using var scope = _subSingletonClientDiagnostics.CreateScope("SubSingleton.Execute");
            scope.Start();
            try
            {
                var response = _subSingletonRestClient.Execute(Id.SubscriptionId, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
