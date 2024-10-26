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

namespace _Azure.ResourceManager.Models.CommonTypes.ManagedIdentity
{
    /// <summary>
    /// A class representing a collection of <see cref="ManagedIdentityTrackedResource"/> and their operations.
    /// Each <see cref="ManagedIdentityTrackedResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="ManagedIdentityTrackedResourceCollection"/> instance call the GetManagedIdentityTrackedResources method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class ManagedIdentityTrackedResourceCollection : ArmCollection
    {
        private readonly ClientDiagnostics _managedIdentityTrackedResourceClientDiagnostics;
        private readonly ManagedIdentityTrackedResourcesRestOperations _managedIdentityTrackedResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedIdentityTrackedResourceCollection"/> class for mocking. </summary>
        protected ManagedIdentityTrackedResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedIdentityTrackedResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagedIdentityTrackedResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedIdentityTrackedResourceClientDiagnostics = new ClientDiagnostics("_Azure.ResourceManager.Models.CommonTypes.ManagedIdentity", ManagedIdentityTrackedResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ManagedIdentityTrackedResource.ResourceType, out string managedIdentityTrackedResourceApiVersion);
            _managedIdentityTrackedResourceRestClient = new ManagedIdentityTrackedResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, managedIdentityTrackedResourceApiVersion);
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
        /// Create a ManagedIdentityTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_CreateWithSystemAssigned</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ManagedIdentityTrackedResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string managedIdentityTrackedResourceName, ManagedIdentityTrackedResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managedIdentityTrackedResourceRestClient.CreateWithSystemAssignedAsync(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, data, cancellationToken).ConfigureAwait(false);
                var uri = _managedIdentityTrackedResourceRestClient.CreateCreateWithSystemAssignedRequestUri(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new ManagedIdentityArmOperation<ManagedIdentityTrackedResource>(Response.FromValue(new ManagedIdentityTrackedResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Create a ManagedIdentityTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_CreateWithSystemAssigned</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ManagedIdentityTrackedResource> CreateOrUpdate(WaitUntil waitUntil, string managedIdentityTrackedResourceName, ManagedIdentityTrackedResourceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managedIdentityTrackedResourceRestClient.CreateWithSystemAssigned(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, data, cancellationToken);
                var uri = _managedIdentityTrackedResourceRestClient.CreateCreateWithSystemAssignedRequestUri(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new ManagedIdentityArmOperation<ManagedIdentityTrackedResource>(Response.FromValue(new ManagedIdentityTrackedResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Get a ManagedIdentityTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        public virtual async Task<Response<ManagedIdentityTrackedResource>> GetAsync(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedIdentityTrackedResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedIdentityTrackedResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a ManagedIdentityTrackedResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        public virtual Response<ManagedIdentityTrackedResource> Get(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _managedIdentityTrackedResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedIdentityTrackedResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await _managedIdentityTrackedResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        public virtual Response<bool> Exists(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = _managedIdentityTrackedResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        public virtual async Task<NullableResponse<ManagedIdentityTrackedResource>> GetIfExistsAsync(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedIdentityTrackedResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<ManagedIdentityTrackedResource>(response.GetRawResponse());
                return Response.FromValue(new ManagedIdentityTrackedResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/{managedIdentityTrackedResourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedIdentityTrackedResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ManagedIdentityTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managedIdentityTrackedResourceName"> arm resource name for path. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="managedIdentityTrackedResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="managedIdentityTrackedResourceName"/> is null. </exception>
        public virtual NullableResponse<ManagedIdentityTrackedResource> GetIfExists(string managedIdentityTrackedResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managedIdentityTrackedResourceName, nameof(managedIdentityTrackedResourceName));

            using var scope = _managedIdentityTrackedResourceClientDiagnostics.CreateScope("ManagedIdentityTrackedResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedIdentityTrackedResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, managedIdentityTrackedResourceName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<ManagedIdentityTrackedResource>(response.GetRawResponse());
                return Response.FromValue(new ManagedIdentityTrackedResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
