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
using OmitOperationGroups.Models;

namespace OmitOperationGroups
{
    /// <summary> A Class representing a Model2Resource along with the instance operations that can be performed on it. </summary>
    public partial class Model2Resource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Model2Resource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string model2SName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _model2ResourceModel2sClientDiagnostics;
        private readonly Model2SRestOperations _model2ResourceModel2sRestClient;
        private readonly ClientDiagnostics _model4sClientDiagnostics;
        private readonly Model4SRestOperations _model4sRestClient;
        private readonly Model2ResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="Model2Resource"/> class for mocking. </summary>
        protected Model2Resource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Model2Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Model2Resource(ArmClient client, Model2ResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Model2Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Model2Resource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _model2ResourceModel2sClientDiagnostics = new ClientDiagnostics("OmitOperationGroups", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string model2ResourceModel2sApiVersion);
            _model2ResourceModel2sRestClient = new Model2SRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, model2ResourceModel2sApiVersion);
            _model4sClientDiagnostics = new ClientDiagnostics("OmitOperationGroups", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _model4sRestClient = new Model4SRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/model2s";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual Model2ResourceData Data
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Model2Resource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _model2ResourceModel2sClientDiagnostics.CreateScope("Model2Resource.Get");
            scope.Start();
            try
            {
                var response = await _model2ResourceModel2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// Operation Id: Model2s_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Model2Resource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _model2ResourceModel2sClientDiagnostics.CreateScope("Model2Resource.Get");
            scope.Start();
            try
            {
                var response = _model2ResourceModel2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}/model4s/default
        /// Operation Id: Model4s_GetDefault
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Model4>> GetDefaultModel4Async(CancellationToken cancellationToken = default)
        {
            using var scope = _model4sClientDiagnostics.CreateScope("Model2Resource.GetDefaultModel4");
            scope.Start();
            try
            {
                var response = await _model4sRestClient.GetDefaultAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}/model4s/default
        /// Operation Id: Model4s_GetDefault
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Model4> GetDefaultModel4(CancellationToken cancellationToken = default)
        {
            using var scope = _model4sClientDiagnostics.CreateScope("Model2Resource.GetDefaultModel4");
            scope.Start();
            try
            {
                var response = _model4sRestClient.GetDefault(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
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
