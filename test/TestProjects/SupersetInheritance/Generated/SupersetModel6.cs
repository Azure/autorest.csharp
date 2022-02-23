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

namespace SupersetInheritance
{
    /// <summary> A Class representing a SupersetModel6 along with the instance operations that can be performed on it. </summary>
    public partial class SupersetModel6 : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SupersetModel6"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string supersetModel6SName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _supersetModel6ClientDiagnostics;
        private readonly SupersetModel6SRestOperations _supersetModel6RestClient;
        private readonly SupersetModel6Data _data;

        /// <summary> Initializes a new instance of the <see cref="SupersetModel6"/> class for mocking. </summary>
        protected SupersetModel6()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SupersetModel6"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SupersetModel6(ArmClient client, SupersetModel6Data data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SupersetModel6"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SupersetModel6(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _supersetModel6ClientDiagnostics = new ClientDiagnostics("SupersetInheritance", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string supersetModel6ApiVersion);
            _supersetModel6RestClient = new SupersetModel6SRestOperations(_supersetModel6ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, supersetModel6ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/supersetModel6s";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SupersetModel6Data Data
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SupersetModel6>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6.Get");
            scope.Start();
            try
            {
                var response = await _supersetModel6RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _supersetModel6ClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SupersetModel6(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel6s/{supersetModel6SName}
        /// Operation Id: SupersetModel6s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SupersetModel6> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _supersetModel6ClientDiagnostics.CreateScope("SupersetModel6.Get");
            scope.Start();
            try
            {
                var response = _supersetModel6RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _supersetModel6ClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel6(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
