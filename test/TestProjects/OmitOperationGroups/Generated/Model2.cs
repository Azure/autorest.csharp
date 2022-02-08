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
    /// <summary> A Class representing a Model2 along with the instance operations that can be performed on it. </summary>
    public partial class Model2 : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Model2"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string model2SName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _model2ClientDiagnostics;
        private readonly Model2SRestOperations _model2RestClient;
        private readonly ClientDiagnostics _model4sClientDiagnostics;
        private readonly Model4SRestOperations _model4sRestClient;
        private readonly Model2Data _data;

        /// <summary> Initializes a new instance of the <see cref="Model2"/> class for mocking. </summary>
        protected Model2()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Model2"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Model2(ArmClient client, Model2Data data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Model2"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Model2(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _model2ClientDiagnostics = new ClientDiagnostics("OmitOperationGroups", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string model2ApiVersion);
            _model2RestClient = new Model2SRestOperations(_model2ClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, model2ApiVersion);
            _model4sClientDiagnostics = new ClientDiagnostics("OmitOperationGroups", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _model4sRestClient = new Model4SRestOperations(_model4sClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
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
        public virtual Model2Data Data
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// OperationId: Model2s_Get
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<Model2>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _model2ClientDiagnostics.CreateScope("Model2.Get");
            scope.Start();
            try
            {
                var response = await _model2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _model2ClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Model2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// OperationId: Model2s_Get
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Model2> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _model2ClientDiagnostics.CreateScope("Model2.Get");
            scope.Start();
            try
            {
                var response = _model2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _model2ClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}/model4s/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// OperationId: Model4s_GetDefault
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<Model4>> GetDefaultModel4Async(CancellationToken cancellationToken = default)
        {
            using var scope = _model4sClientDiagnostics.CreateScope("Model2.GetDefaultModel4");
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2SName}/model4s/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// OperationId: Model4s_GetDefault
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Model4> GetDefaultModel4(CancellationToken cancellationToken = default)
        {
            using var scope = _model4sClientDiagnostics.CreateScope("Model2.GetDefaultModel4");
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
