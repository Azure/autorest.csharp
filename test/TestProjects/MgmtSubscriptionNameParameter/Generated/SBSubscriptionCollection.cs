// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtSubscriptionNameParameter
{
    /// <summary>
    /// A class representing a collection of <see cref="SBSubscriptionResource" /> and their operations.
    /// Each <see cref="SBSubscriptionResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="SBSubscriptionCollection" /> instance call the GetSBSubscriptions method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class SBSubscriptionCollection : ArmCollection, IEnumerable<SBSubscriptionResource>, IAsyncEnumerable<SBSubscriptionResource>
    {
        private readonly ClientDiagnostics _sbSubscriptionSubscriptionsClientDiagnostics;
        private readonly SubscriptionsRestOperations _sbSubscriptionSubscriptionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SBSubscriptionCollection"/> class for mocking. </summary>
        protected SBSubscriptionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SBSubscriptionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SBSubscriptionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sbSubscriptionSubscriptionsClientDiagnostics = new ClientDiagnostics("MgmtSubscriptionNameParameter", SBSubscriptionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SBSubscriptionResource.ResourceType, out string sbSubscriptionSubscriptionsApiVersion);
            _sbSubscriptionSubscriptionsRestClient = new SubscriptionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sbSubscriptionSubscriptionsApiVersion);
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
        /// Creates a topic subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="data"> Parameters supplied to create a subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SBSubscriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string subscriptionName, SBSubscriptionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _sbSubscriptionSubscriptionsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtSubscriptionNameParameterArmOperation<SBSubscriptionResource>(Response.FromValue(new SBSubscriptionResource(Client, response), response.GetRawResponse()));
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
        /// Creates a topic subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="data"> Parameters supplied to create a subscription resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SBSubscriptionResource> CreateOrUpdate(WaitUntil waitUntil, string subscriptionName, SBSubscriptionData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _sbSubscriptionSubscriptionsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, data, cancellationToken);
                var operation = new MgmtSubscriptionNameParameterArmOperation<SBSubscriptionResource>(Response.FromValue(new SBSubscriptionResource(Client, response), response.GetRawResponse()));
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
        /// Returns a subscription description for the specified topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> is null. </exception>
        public virtual async Task<Response<SBSubscriptionResource>> GetAsync(string subscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.Get");
            scope.Start();
            try
            {
                var response = await _sbSubscriptionSubscriptionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SBSubscriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a subscription description for the specified topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> is null. </exception>
        public virtual Response<SBSubscriptionResource> Get(string subscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.Get");
            scope.Start();
            try
            {
                var response = _sbSubscriptionSubscriptionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, cancellationToken);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new SBSubscriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all the subscriptions under a specified topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_ListByTopic</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Skip is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skip parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N usageDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SBSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SBSubscriptionResource> GetAllAsync(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _sbSubscriptionSubscriptionsRestClient.CreateListByTopicRequest(Id.SubscriptionId, Id.ResourceGroupName, skip, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _sbSubscriptionSubscriptionsRestClient.CreateListByTopicNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, skip, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SBSubscriptionResource(Client, SBSubscriptionData.DeserializeSBSubscriptionData(e)), _sbSubscriptionSubscriptionsClientDiagnostics, Pipeline, "SBSubscriptionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List all the subscriptions under a specified topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_ListByTopic</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Skip is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skip parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N usageDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SBSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SBSubscriptionResource> GetAll(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _sbSubscriptionSubscriptionsRestClient.CreateListByTopicRequest(Id.SubscriptionId, Id.ResourceGroupName, skip, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _sbSubscriptionSubscriptionsRestClient.CreateListByTopicNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, skip, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SBSubscriptionResource(Client, SBSubscriptionData.DeserializeSBSubscriptionData(e)), _sbSubscriptionSubscriptionsClientDiagnostics, Pipeline, "SBSubscriptionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string subscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.Exists");
            scope.Start();
            try
            {
                var response = await _sbSubscriptionSubscriptionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> is null. </exception>
        public virtual Response<bool> Exists(string subscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.Exists");
            scope.Start();
            try
            {
                var response = _sbSubscriptionSubscriptionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> is null. </exception>
        public virtual async Task<NullableResponse<SBSubscriptionResource>> GetIfExistsAsync(string subscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sbSubscriptionSubscriptionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<SBSubscriptionResource>(response.GetRawResponse());
                return Response.FromValue(new SBSubscriptionResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/subscriptions/{subscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Subscriptions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionName"> The subscription name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionName"/> is null. </exception>
        public virtual NullableResponse<SBSubscriptionResource> GetIfExists(string subscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionName, nameof(subscriptionName));

            using var scope = _sbSubscriptionSubscriptionsClientDiagnostics.CreateScope("SBSubscriptionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sbSubscriptionSubscriptionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, subscriptionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<SBSubscriptionResource>(response.GetRawResponse());
                return Response.FromValue(new SBSubscriptionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SBSubscriptionResource> IEnumerable<SBSubscriptionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SBSubscriptionResource> IAsyncEnumerable<SBSubscriptionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
