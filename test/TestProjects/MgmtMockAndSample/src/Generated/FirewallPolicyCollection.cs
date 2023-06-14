// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing a collection of <see cref="FirewallPolicyResource" /> and their operations.
    /// Each <see cref="FirewallPolicyResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="FirewallPolicyCollection" /> instance call the GetFirewallPolicies method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class FirewallPolicyCollection : ArmCollection, IEnumerable<FirewallPolicyResource>, IAsyncEnumerable<FirewallPolicyResource>
    {
        private readonly ClientDiagnostics _firewallPolicyClientDiagnostics;
        private readonly FirewallPoliciesRestOperations _firewallPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="FirewallPolicyCollection"/> class for mocking. </summary>
        protected FirewallPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FirewallPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FirewallPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _firewallPolicyClientDiagnostics = new ClientDiagnostics("MgmtMockAndSample", FirewallPolicyResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FirewallPolicyResource.ResourceType, out string firewallPolicyApiVersion);
            _firewallPolicyRestClient = new FirewallPoliciesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, firewallPolicyApiVersion);
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
        /// Creates or updates the specified Firewall Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="data"> Parameters supplied to the create or update Firewall Policy operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FirewallPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string firewallPolicyName, FirewallPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(firewallPolicyName, nameof(firewallPolicyName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _firewallPolicyClientDiagnostics.CreateScope("FirewallPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMockAndSampleArmOperation<FirewallPolicyResource>(new FirewallPolicyOperationSource(Client), _firewallPolicyClientDiagnostics, Pipeline, _firewallPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates the specified Firewall Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="data"> Parameters supplied to the create or update Firewall Policy operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FirewallPolicyResource> CreateOrUpdate(WaitUntil waitUntil, string firewallPolicyName, FirewallPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(firewallPolicyName, nameof(firewallPolicyName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _firewallPolicyClientDiagnostics.CreateScope("FirewallPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _firewallPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, data, cancellationToken);
                var operation = new MgmtMockAndSampleArmOperation<FirewallPolicyResource>(new FirewallPolicyOperationSource(Client), _firewallPolicyClientDiagnostics, Pipeline, _firewallPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets the specified Firewall Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> is null. </exception>
        public virtual async Task<Response<FirewallPolicyResource>> GetAsync(string firewallPolicyName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(firewallPolicyName, nameof(firewallPolicyName));

            using var scope = _firewallPolicyClientDiagnostics.CreateScope("FirewallPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified Firewall Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> is null. </exception>
        public virtual Response<FirewallPolicyResource> Get(string firewallPolicyName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(firewallPolicyName, nameof(firewallPolicyName));

            using var scope = _firewallPolicyClientDiagnostics.CreateScope("FirewallPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _firewallPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all Firewall Policies in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FirewallPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FirewallPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _firewallPolicyRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _firewallPolicyRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FirewallPolicyResource(Client, FirewallPolicyData.DeserializeFirewallPolicyData(e)), _firewallPolicyClientDiagnostics, Pipeline, "FirewallPolicyCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all Firewall Policies in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FirewallPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FirewallPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _firewallPolicyRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _firewallPolicyRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FirewallPolicyResource(Client, FirewallPolicyData.DeserializeFirewallPolicyData(e)), _firewallPolicyClientDiagnostics, Pipeline, "FirewallPolicyCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string firewallPolicyName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(firewallPolicyName, nameof(firewallPolicyName));

            using var scope = _firewallPolicyClientDiagnostics.CreateScope("FirewallPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> is null. </exception>
        public virtual Response<bool> Exists(string firewallPolicyName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(firewallPolicyName, nameof(firewallPolicyName));

            using var scope = _firewallPolicyClientDiagnostics.CreateScope("FirewallPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = _firewallPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, firewallPolicyName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FirewallPolicyResource> IEnumerable<FirewallPolicyResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FirewallPolicyResource> IAsyncEnumerable<FirewallPolicyResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
