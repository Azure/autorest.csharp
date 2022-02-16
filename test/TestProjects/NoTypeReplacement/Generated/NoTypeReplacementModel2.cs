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
    /// <summary> A Class representing a NoTypeReplacementModel2 along with the instance operations that can be performed on it. </summary>
    public partial class NoTypeReplacementModel2 : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="NoTypeReplacementModel2"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string noTypeReplacementModel2SName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2SName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _noTypeReplacementModel2ClientDiagnostics;
        private readonly NoTypeReplacementModel2SRestOperations _noTypeReplacementModel2RestClient;
        private readonly NoTypeReplacementModel2Data _data;

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel2"/> class for mocking. </summary>
        protected NoTypeReplacementModel2()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "NoTypeReplacementModel2"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal NoTypeReplacementModel2(ArmClient client, NoTypeReplacementModel2Data data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel2"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal NoTypeReplacementModel2(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _noTypeReplacementModel2ClientDiagnostics = new ClientDiagnostics("NoTypeReplacement", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string noTypeReplacementModel2ApiVersion);
            _noTypeReplacementModel2RestClient = new NoTypeReplacementModel2SRestOperations(_noTypeReplacementModel2ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, noTypeReplacementModel2ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/noTypeReplacementModel2s";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual NoTypeReplacementModel2Data Data
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2SName}
        /// Operation Id: NoTypeReplacementModel2s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<NoTypeReplacementModel2>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _noTypeReplacementModel2ClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NoTypeReplacementModel2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel2s/{noTypeReplacementModel2SName}
        /// Operation Id: NoTypeReplacementModel2s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NoTypeReplacementModel2> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _noTypeReplacementModel2ClientDiagnostics.CreateScope("NoTypeReplacementModel2.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _noTypeReplacementModel2ClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
