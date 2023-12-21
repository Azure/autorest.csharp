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

namespace MgmtSingletonResource
{
    /// <summary>
    /// A class representing a collection of <see cref="ParentResource"/> and their operations.
    /// Each <see cref="ParentResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="ParentResourceCollection"/> instance call the GetParentResources method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class ParentResourceCollection : ArmCollection, IEnumerable<ParentResource>, IAsyncEnumerable<ParentResource>
    {
        private readonly ClientDiagnostics _parentResourceClientDiagnostics;
        private readonly ParentResourcesRestOperations _parentResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="ParentResourceCollection"/> class for mocking. </summary>
        protected ParentResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ParentResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ParentResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _parentResourceClientDiagnostics = new ClientDiagnostics("MgmtSingletonResource", ParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ParentResource.ResourceType, out string parentResourceApiVersion);
            _parentResourceRestClient = new ParentResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, parentResourceApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="ParentResourceData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string parentName, ParentResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _parentResourceRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, parentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtSingletonResourceArmOperation<ParentResource>(Response.FromValue(new ParentResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="ParentResourceData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ParentResource> CreateOrUpdate(WaitUntil waitUntil, string parentName, ParentResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _parentResourceRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, parentName, data, cancellationToken);
                var operation = new MgmtSingletonResourceArmOperation<ParentResource>(Response.FromValue(new ParentResource(Client, response), response.GetRawResponse()));
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
        /// Singleton Test Parent Example.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual async Task<Response<ParentResource>> GetAsync(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _parentResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual Response<ParentResource> Get(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _parentResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_List</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ParentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ParentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _parentResourceRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new ParentResource(Client, ParentResourceData.DeserializeParentResourceData(e)), _parentResourceClientDiagnostics, Pipeline, "ParentResourceCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_List</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ParentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ParentResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _parentResourceRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new ParentResource(Client, ParentResourceData.DeserializeParentResourceData(e)), _parentResourceClientDiagnostics, Pipeline, "ParentResourceCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await _parentResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual Response<bool> Exists(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = _parentResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual async Task<NullableResponse<ParentResource>> GetIfExistsAsync(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _parentResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<ParentResource>(response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ParentResources_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Billing/parentResources</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="parentName"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public virtual NullableResponse<ParentResource> GetIfExists(string parentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(parentName, nameof(parentName));

            using var scope = _parentResourceClientDiagnostics.CreateScope("ParentResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _parentResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, parentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<ParentResource>(response.GetRawResponse());
                return Response.FromValue(new ParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ParentResource> IEnumerable<ParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ParentResource> IAsyncEnumerable<ParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
