// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing a collection of <see cref="DedicatedHostResource"/> and their operations.
    /// Each <see cref="DedicatedHostResource"/> in the collection will belong to the same instance of <see cref="DedicatedHostGroupResource"/>.
    /// To get a <see cref="DedicatedHostCollection"/> instance call the GetDedicatedHosts method from an instance of <see cref="DedicatedHostGroupResource"/>.
    /// </summary>
    public partial class DedicatedHostCollection : ArmCollection, IEnumerable<DedicatedHostResource>, IAsyncEnumerable<DedicatedHostResource>
    {
        private readonly TelemetrySource _dedicatedHostClientDiagnostics;
        private readonly DedicatedHostsRestOperations _dedicatedHostRestClient;

        /// <summary> Initializes a new instance of the <see cref="DedicatedHostCollection"/> class for mocking. </summary>
        protected DedicatedHostCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DedicatedHostCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DedicatedHostCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dedicatedHostClientDiagnostics = new TelemetrySource("Azure.ResourceManager.Sample", DedicatedHostResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DedicatedHostResource.ResourceType, out string dedicatedHostApiVersion);
            _dedicatedHostRestClient = new DedicatedHostsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dedicatedHostApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != DedicatedHostGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, DedicatedHostGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update a dedicated host .
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="data"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DedicatedHostResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string hostName, DedicatedHostData data, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));
            ClientUtilities.AssertNotNull(data, nameof(data));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var result = await _dedicatedHostRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation<DedicatedHostResource>(new DedicatedHostOperationSource(Client), _dedicatedHostClientDiagnostics, Pipeline, _dedicatedHostRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, data).Request, result, OperationFinalStateVia.Location);
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
        /// Create or update a dedicated host .
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="data"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DedicatedHostResource> CreateOrUpdate(WaitUntil waitUntil, string hostName, DedicatedHostData data, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));
            ClientUtilities.AssertNotNull(data, nameof(data));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var result = _dedicatedHostRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, data, cancellationToken);
                var operation = new SampleArmOperation<DedicatedHostResource>(new DedicatedHostOperationSource(Client), _dedicatedHostClientDiagnostics, Pipeline, _dedicatedHostRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, data).Request, result, OperationFinalStateVia.Location);
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
        /// Retrieves information about a dedicated host.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual async Task<Result<DedicatedHostResource>> GetAsync(string hostName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.Get");
            scope.Start();
            try
            {
                var result = await _dedicatedHostRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, expand, cancellationToken).ConfigureAwait(false);
                if (result.Value == null)
                    throw new MessageFailedException(result.GetRawResponse());
                return Result.FromValue(new DedicatedHostResource(Client, result.Value), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about a dedicated host.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Result<DedicatedHostResource> Get(string hostName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.Get");
            scope.Start();
            try
            {
                var result = _dedicatedHostRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, expand, cancellationToken);
                if (result.Value == null)
                    throw new MessageFailedException(result.GetRawResponse());
                return Result.FromValue(new DedicatedHostResource(Client, result.Value), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the dedicated hosts in the specified dedicated host group. Use the nextLink property in the response to get the next page of dedicated hosts.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_ListByHostGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DedicatedHostResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DedicatedHostResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            PipelineMessage FirstPageRequest(int? pageSizeHint) => _dedicatedHostRestClient.CreateListByHostGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            PipelineMessage NextPageRequest(int? pageSizeHint, string nextLink) => _dedicatedHostRestClient.CreateListByHostGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DedicatedHostResource(Client, DedicatedHostData.DeserializeDedicatedHostData(e)), _dedicatedHostClientDiagnostics, Pipeline, "DedicatedHostCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the dedicated hosts in the specified dedicated host group. Use the nextLink property in the response to get the next page of dedicated hosts.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_ListByHostGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DedicatedHostResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DedicatedHostResource> GetAll(CancellationToken cancellationToken = default)
        {
            PipelineMessage FirstPageRequest(int? pageSizeHint) => _dedicatedHostRestClient.CreateListByHostGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            PipelineMessage NextPageRequest(int? pageSizeHint, string nextLink) => _dedicatedHostRestClient.CreateListByHostGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DedicatedHostResource(Client, DedicatedHostData.DeserializeDedicatedHostData(e)), _dedicatedHostClientDiagnostics, Pipeline, "DedicatedHostCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual async Task<Result<bool>> ExistsAsync(string hostName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.Exists");
            scope.Start();
            try
            {
                var result = await _dedicatedHostRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Result.FromValue(result.Value != null, result.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Result<bool> Exists(string hostName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.Exists");
            scope.Start();
            try
            {
                var result = _dedicatedHostRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, expand, cancellationToken: cancellationToken);
                return Result.FromValue(result.Value != null, result.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual async Task<NullableResponse<DedicatedHostResource>> GetIfExistsAsync(string hostName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.GetIfExists");
            scope.Start();
            try
            {
                var result = await _dedicatedHostRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (result.Value == null)
                    return new NoValueResponse<DedicatedHostResource>(result.GetRawResponse());
                return Result.FromValue(new DedicatedHostResource(Client, result.Value), result.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}/hosts/{hostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHosts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual NullableResponse<DedicatedHostResource> GetIfExists(string hostName, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _dedicatedHostClientDiagnostics.CreateSpan("DedicatedHostCollection.GetIfExists");
            scope.Start();
            try
            {
                var result = _dedicatedHostRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, expand, cancellationToken: cancellationToken);
                if (result.Value == null)
                    return new NoValueResponse<DedicatedHostResource>(result.GetRawResponse());
                return Result.FromValue(new DedicatedHostResource(Client, result.Value), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DedicatedHostResource> IEnumerable<DedicatedHostResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DedicatedHostResource> IAsyncEnumerable<DedicatedHostResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
