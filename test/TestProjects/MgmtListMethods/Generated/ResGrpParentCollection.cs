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

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="ResGrpParentResource"/> and their operations.
    /// Each <see cref="ResGrpParentResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="ResGrpParentCollection"/> instance call the GetResGrpParents method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class ResGrpParentCollection : ArmCollection, IEnumerable<ResGrpParentResource>, IAsyncEnumerable<ResGrpParentResource>
    {
        private readonly ClientDiagnostics _resGrpParentClientDiagnostics;
        private readonly ResGrpParentsRestOperations _resGrpParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentCollection"/> class for mocking. </summary>
        protected ResGrpParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResGrpParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resGrpParentClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResGrpParentResource.ResourceType, out string resGrpParentApiVersion);
            _resGrpParentRestClient = new ResGrpParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, resGrpParentApiVersion);
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
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ResGrpParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resGrpParentName, ResGrpParentData data, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, data, cancellationToken).ConfigureAwait(false);
                var uri = _resGrpParentRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), NextLinkOperationImplementation.HeaderSource.None.ToString(), null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtListMethodsArmOperation<ResGrpParentResource>(Response.FromValue(new ResGrpParentResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ResGrpParentResource> CreateOrUpdate(WaitUntil waitUntil, string resGrpParentName, ResGrpParentData data, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, data, cancellationToken);
                var uri = _resGrpParentRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), NextLinkOperationImplementation.HeaderSource.None.ToString(), null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtListMethodsArmOperation<ResGrpParentResource>(Response.FromValue(new ResGrpParentResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual async Task<Response<ResGrpParentResource>> GetAsync(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual Response<ResGrpParentResource> Get(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new ResGrpParentResource(Client, ResGrpParentData.DeserializeResGrpParentData(e)), _resGrpParentClientDiagnostics, Pipeline, "ResGrpParentCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new ResGrpParentResource(Client, ResGrpParentData.DeserializeResGrpParentData(e)), _resGrpParentClientDiagnostics, Pipeline, "ResGrpParentCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _resGrpParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.Exists");
            scope.Start();
            try
            {
                var response = _resGrpParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual async Task<NullableResponse<ResGrpParentResource>> GetIfExistsAsync(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resGrpParentRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<ResGrpParentResource>(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParents/{resGrpParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParents_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResGrpParentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentName"/> is null. </exception>
        public virtual NullableResponse<ResGrpParentResource> GetIfExists(string resGrpParentName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentName));
            }
            if (resGrpParentName.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(resGrpParentName));
            }

            using var scope = _resGrpParentClientDiagnostics.CreateScope("ResGrpParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<ResGrpParentResource>(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentResource> IEnumerable<ResGrpParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentResource> IAsyncEnumerable<ResGrpParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
