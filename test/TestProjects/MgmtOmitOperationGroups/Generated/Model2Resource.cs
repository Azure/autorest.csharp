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
using Azure.ResourceManager.Resources;
using MgmtOmitOperationGroups.Models;

namespace MgmtOmitOperationGroups
{
    /// <summary>
    /// A Class representing a Model2 along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="Model2Resource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetModel2Resource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetModel2 method.
    /// </summary>
    public partial class Model2Resource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Model2Resource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="model2SName"> The model2SName. </param>
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

        /// <summary> Initializes a new instance of the <see cref="Model2Resource"/> class for mocking. </summary>
        protected Model2Resource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="Model2Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Model2Resource(ArmClient client, Model2Data data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Model2Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Model2Resource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _model2ClientDiagnostics = new ClientDiagnostics("MgmtOmitOperationGroups", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string model2ApiVersion);
            _model2RestClient = new Model2SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, model2ApiVersion);
            _model4sClientDiagnostics = new ClientDiagnostics("MgmtOmitOperationGroups", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _model4sRestClient = new Model4SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
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

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Model2Resource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _model2ClientDiagnostics.CreateScope("Model2Resource.Get");
            scope.Start();
            try
            {
                var response = await _model2RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Model2Resource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _model2ClientDiagnostics.CreateScope("Model2Resource.Get");
            scope.Start();
            try
            {
                var response = _model2RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<Model2Resource>> UpdateAsync(WaitUntil waitUntil, Model2Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Resource.Update");
            scope.Start();
            try
            {
                var response = await _model2RestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOmitOperationGroupsArmOperation<Model2Resource>(Response.FromValue(new Model2Resource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The Model2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<Model2Resource> Update(WaitUntil waitUntil, Model2Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _model2ClientDiagnostics.CreateScope("Model2Resource.Update");
            scope.Start();
            try
            {
                var response = _model2RestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                var operation = new MgmtOmitOperationGroupsArmOperation<Model2Resource>(Response.FromValue(new Model2Resource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}/model4s/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model4s_GetDefault</description>
        /// </item>
        /// </list>
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}/model4s/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model4s_GetDefault</description>
        /// </item>
        /// </list>
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
