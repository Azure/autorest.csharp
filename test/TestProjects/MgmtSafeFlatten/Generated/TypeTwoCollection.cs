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

namespace MgmtSafeFlatten
{
    /// <summary>
    /// A class representing a collection of <see cref="TypeTwoResource" /> and their operations.
    /// Each <see cref="TypeTwoResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="TypeTwoCollection" /> instance call the GetTypeTwos method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class TypeTwoCollection : ArmCollection, IEnumerable<TypeTwoResource>, IAsyncEnumerable<TypeTwoResource>
    {
        private readonly ClientDiagnostics _typeTwoCommonClientDiagnostics;
        private readonly CommonRestOperations _typeTwoCommonRestClient;

        /// <summary> Initializes a new instance of the <see cref="TypeTwoCollection"/> class for mocking. </summary>
        protected TypeTwoCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TypeTwoCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TypeTwoCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _typeTwoCommonClientDiagnostics = new ClientDiagnostics("MgmtSafeFlatten", TypeTwoResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TypeTwoResource.ResourceType, out string typeTwoCommonApiVersion);
            _typeTwoCommonRestClient = new CommonRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, typeTwoCommonApiVersion);
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
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_CreateOrUpdateTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="data"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TypeTwoResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string typeTwoName, TypeTwoData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _typeTwoCommonRestClient.CreateOrUpdateTypeTwoAsync(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtSafeFlattenArmOperation<TypeTwoResource>(Response.FromValue(new TypeTwoResource(Client, response), response.GetRawResponse()));
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
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_CreateOrUpdateTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="data"> Information to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TypeTwoResource> CreateOrUpdate(WaitUntil waitUntil, string typeTwoName, TypeTwoData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _typeTwoCommonRestClient.CreateOrUpdateTypeTwo(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, data, cancellationToken);
                var operation = new MgmtSafeFlattenArmOperation<TypeTwoResource>(Response.FromValue(new TypeTwoResource(Client, response), response.GetRawResponse()));
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
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual async Task<Response<TypeTwoResource>> GetAsync(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Get");
            scope.Start();
            try
            {
                var response = await _typeTwoCommonRestClient.GetTypeTwoAsync(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TypeTwoResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual Response<TypeTwoResource> Get(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Get");
            scope.Start();
            try
            {
                var response = _typeTwoCommonRestClient.GetTypeTwo(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new TypeTwoResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeTwos</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeTwoResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _typeTwoCommonRestClient.CreateListTypeTwosRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new TypeTwoResource(Client, TypeTwoData.DeserializeTypeTwoData(e)), _typeTwoCommonClientDiagnostics, Pipeline, "TypeTwoCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeTwos</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeTwoResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _typeTwoCommonRestClient.CreateListTypeTwosRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new TypeTwoResource(Client, TypeTwoData.DeserializeTypeTwoData(e)), _typeTwoCommonClientDiagnostics, Pipeline, "TypeTwoCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Exists");
            scope.Start();
            try
            {
                var response = await _typeTwoCommonRestClient.GetTypeTwoAsync(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual Response<bool> Exists(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.Exists");
            scope.Start();
            try
            {
                var response = _typeTwoCommonRestClient.GetTypeTwo(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual async Task<NullableResponse<TypeTwoResource>> GetIfExistsAsync(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _typeTwoCommonRestClient.GetTypeTwoAsync(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<TypeTwoResource>(response.GetRawResponse());
                return Response.FromValue(new TypeTwoResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public virtual NullableResponse<TypeTwoResource> GetIfExists(string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(typeTwoName, nameof(typeTwoName));

            using var scope = _typeTwoCommonClientDiagnostics.CreateScope("TypeTwoCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _typeTwoCommonRestClient.GetTypeTwo(Id.SubscriptionId, Id.ResourceGroupName, typeTwoName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<TypeTwoResource>(response.GetRawResponse());
                return Response.FromValue(new TypeTwoResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TypeTwoResource> IEnumerable<TypeTwoResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TypeTwoResource> IAsyncEnumerable<TypeTwoResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
