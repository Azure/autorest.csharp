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

namespace NoTypeReplacement
{
    /// <summary> A Class representing a NoTypeReplacementModel3Resource along with the instance operations that can be performed on it. </summary>
    public partial class NoTypeReplacementModel3Resource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="NoTypeReplacementModel3Resource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string noTypeReplacementModel3SName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3SName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _noTypeReplacementModel3ResourceNoTypeReplacementModel3sClientDiagnostics;
        private readonly NoTypeReplacementModel3SRestOperations _noTypeReplacementModel3ResourceNoTypeReplacementModel3sRestClient;
        private readonly NoTypeReplacementModel3ResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel3Resource"/> class for mocking. </summary>
        protected NoTypeReplacementModel3Resource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "NoTypeReplacementModel3Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal NoTypeReplacementModel3Resource(ArmClient client, NoTypeReplacementModel3ResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel3Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal NoTypeReplacementModel3Resource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _noTypeReplacementModel3ResourceNoTypeReplacementModel3sClientDiagnostics = new ClientDiagnostics("NoTypeReplacement", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string noTypeReplacementModel3ResourceNoTypeReplacementModel3sApiVersion);
            _noTypeReplacementModel3ResourceNoTypeReplacementModel3sRestClient = new NoTypeReplacementModel3SRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, noTypeReplacementModel3ResourceNoTypeReplacementModel3sApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/noTypeReplacementModel3s";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual NoTypeReplacementModel3ResourceData Data
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3SName}
        /// Operation Id: NoTypeReplacementModel3s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NoTypeReplacementModel3Resource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _noTypeReplacementModel3ResourceNoTypeReplacementModel3sClientDiagnostics.CreateScope("NoTypeReplacementModel3Resource.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel3ResourceNoTypeReplacementModel3sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel3Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel3s/{noTypeReplacementModel3SName}
        /// Operation Id: NoTypeReplacementModel3s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NoTypeReplacementModel3Resource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _noTypeReplacementModel3ResourceNoTypeReplacementModel3sClientDiagnostics.CreateScope("NoTypeReplacementModel3Resource.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel3ResourceNoTypeReplacementModel3sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel3Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
