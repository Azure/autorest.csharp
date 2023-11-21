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

namespace MgmtNonStringPathVariable
{
    /// <summary>
    /// A class representing a collection of <see cref="BarResource"/> and their operations.
    /// Each <see cref="BarResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="BarCollection"/> instance call the GetBars method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class BarCollection : ArmCollection
    {
        private readonly ClientDiagnostics _barClientDiagnostics;
        private readonly BarsRestOperations _barRestClient;

        /// <summary> Initializes a new instance of the <see cref="BarCollection"/> class for mocking. </summary>
        protected BarCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BarCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal BarCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _barClientDiagnostics = new ClientDiagnostics("MgmtNonStringPathVariable", BarResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(BarResource.ResourceType, out string barApiVersion);
            _barRestClient = new BarsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, barApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="barName"> The name of the bar. </param>
        /// <param name="data"> The BarData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BarResource>> CreateOrUpdateAsync(WaitUntil waitUntil, int barName, BarData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _barRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtNonStringPathVariableArmOperation<BarResource>(new BarOperationSource(Client), _barClientDiagnostics, Pipeline, _barRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, barName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="barName"> The name of the bar. </param>
        /// <param name="data"> The BarData to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BarResource> CreateOrUpdate(WaitUntil waitUntil, int barName, BarData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _barClientDiagnostics.CreateScope("BarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _barRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, barName, data, cancellationToken);
                var operation = new MgmtNonStringPathVariableArmOperation<BarResource>(new BarOperationSource(Client), _barClientDiagnostics, Pipeline, _barRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, barName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BarResource>> GetAsync(int barName, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Get");
            scope.Start();
            try
            {
                var response = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BarResource> Get(int barName, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Get");
            scope.Start();
            try
            {
                var response = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(int barName, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Exists");
            scope.Start();
            try
            {
                var response = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(int barName, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarCollection.Exists");
            scope.Start();
            try
            {
                var response = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<BarResource>> GetIfExistsAsync(int barName, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<BarResource>(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<BarResource> GetIfExists(int barName, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<BarResource>(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
