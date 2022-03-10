// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace MgmtDiscriminator
{
    /// <summary> A class representing collection of DeliveryRule and their operations over its parent. </summary>
    public partial class DeliveryRuleCollection : ArmCollection, IEnumerable<DeliveryRule>, IAsyncEnumerable<DeliveryRule>
    {
        private readonly ClientDiagnostics _deliveryRuleClientDiagnostics;
        private readonly DeliveryRulesRestOperations _deliveryRuleRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeliveryRuleCollection"/> class for mocking. </summary>
        protected DeliveryRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeliveryRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DeliveryRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deliveryRuleClientDiagnostics = new ClientDiagnostics("MgmtDiscriminator", DeliveryRule.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DeliveryRule.ResourceType, out string deliveryRuleApiVersion);
            _deliveryRuleRestClient = new DeliveryRulesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deliveryRuleApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Create
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="body"> Endpoint properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="body"/> is null. </exception>
        public virtual async Task<ArmOperation<DeliveryRule>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, DeliveryRuleData body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(body, nameof(body));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _deliveryRuleRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, name, body, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtDiscriminatorArmOperation<DeliveryRule>(new DeliveryRuleOperationSource(Client), _deliveryRuleClientDiagnostics, Pipeline, _deliveryRuleRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, body).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a new CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Create
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="body"> Endpoint properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="body"/> is null. </exception>
        public virtual ArmOperation<DeliveryRule> CreateOrUpdate(WaitUntil waitUntil, string name, DeliveryRuleData body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(body, nameof(body));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _deliveryRuleRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, name, body, cancellationToken);
                var operation = new MgmtDiscriminatorArmOperation<DeliveryRule>(new DeliveryRuleOperationSource(Client), _deliveryRuleClientDiagnostics, Pipeline, _deliveryRuleRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, name, body).Request, response, OperationFinalStateVia.Location);
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
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<DeliveryRule>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _deliveryRuleRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeliveryRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<DeliveryRule> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _deliveryRuleRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeliveryRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules
        /// Operation Id: DeliveryRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeliveryRule" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeliveryRule> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DeliveryRule>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deliveryRuleRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeliveryRule(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules
        /// Operation Id: DeliveryRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeliveryRule" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeliveryRule> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DeliveryRule> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deliveryRuleRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeliveryRule(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(name, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<DeliveryRule>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _deliveryRuleRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DeliveryRule>(null, response.GetRawResponse());
                return Response.FromValue(new DeliveryRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}
        /// Operation Id: DeliveryRules_Get
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<DeliveryRule> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deliveryRuleClientDiagnostics.CreateScope("DeliveryRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _deliveryRuleRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DeliveryRule>(null, response.GetRawResponse());
                return Response.FromValue(new DeliveryRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DeliveryRule> IEnumerable<DeliveryRule>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DeliveryRule> IAsyncEnumerable<DeliveryRule>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
