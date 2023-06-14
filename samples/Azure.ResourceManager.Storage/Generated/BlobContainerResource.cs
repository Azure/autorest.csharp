// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A Class representing a BlobContainer along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="BlobContainerResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetBlobContainerResource method.
    /// Otherwise you can get one from its parent resource <see cref="BlobServiceResource" /> using the GetBlobContainer method.
    /// </summary>
    public partial class BlobContainerResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BlobContainerResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string containerName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _blobContainerClientDiagnostics;
        private readonly BlobContainersRestOperations _blobContainerRestClient;
        private readonly BlobContainerData _data;

        /// <summary> Initializes a new instance of the <see cref="BlobContainerResource"/> class for mocking. </summary>
        protected BlobContainerResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BlobContainerResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BlobContainerResource(ArmClient client, BlobContainerData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="BlobContainerResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BlobContainerResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _blobContainerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string blobContainerApiVersion);
            _blobContainerRestClient = new BlobContainersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, blobContainerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/blobServices/containers";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BlobContainerData Data
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

        /// <summary> Gets an object representing a ImmutabilityPolicyResource along with the instance operations that can be performed on it in the BlobContainer. </summary>
        /// <returns> Returns a <see cref="ImmutabilityPolicyResource" /> object. </returns>
        public virtual ImmutabilityPolicyResource GetImmutabilityPolicy()
        {
            return new ImmutabilityPolicyResource(Client, Id.AppendChildResource("immutabilityPolicies", "default"));
        }

        /// <summary>
        /// Gets properties of a specified container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BlobContainerResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Get");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets properties of a specified container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BlobContainerResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Get");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes specified container under its account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Delete");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes specified container under its account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Delete");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, cancellationToken);
                var operation = new StorageArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates container properties as specified in request body. Properties not mentioned in the request will be unchanged. Update fails if the specified container doesn't already exist.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Properties to update for the blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<BlobContainerResource>> UpdateAsync(BlobContainerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Update");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BlobContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates container properties as specified in request body. Properties not mentioned in the request will be unchanged. Update fails if the specified container doesn't already exist.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Properties to update for the blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<BlobContainerResource> Update(BlobContainerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Update");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, data, cancellationToken);
                return Response.FromValue(new BlobContainerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets legal hold tags. Setting the same tag results in an idempotent operation. SetLegalHold follows an append pattern and does not clear out the existing tags that are not specified in the request.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/setLegalHold</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_SetLegalHold</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="legalHold"> The LegalHold property that will be set to a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="legalHold"/> is null. </exception>
        public virtual async Task<Response<LegalHold>> SetLegalHoldAsync(LegalHold legalHold, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(legalHold, nameof(legalHold));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.SetLegalHold");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.SetLegalHoldAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, legalHold, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets legal hold tags. Setting the same tag results in an idempotent operation. SetLegalHold follows an append pattern and does not clear out the existing tags that are not specified in the request.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/setLegalHold</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_SetLegalHold</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="legalHold"> The LegalHold property that will be set to a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="legalHold"/> is null. </exception>
        public virtual Response<LegalHold> SetLegalHold(LegalHold legalHold, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(legalHold, nameof(legalHold));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.SetLegalHold");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.SetLegalHold(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, legalHold, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Clears legal hold tags. Clearing the same or non-existent tag results in an idempotent operation. ClearLegalHold clears out only the specified tags in the request.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/clearLegalHold</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_ClearLegalHold</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="legalHold"> The LegalHold property that will be clear from a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="legalHold"/> is null. </exception>
        public virtual async Task<Response<LegalHold>> ClearLegalHoldAsync(LegalHold legalHold, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(legalHold, nameof(legalHold));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.ClearLegalHold");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.ClearLegalHoldAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, legalHold, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Clears legal hold tags. Clearing the same or non-existent tag results in an idempotent operation. ClearLegalHold clears out only the specified tags in the request.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/clearLegalHold</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_ClearLegalHold</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="legalHold"> The LegalHold property that will be clear from a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="legalHold"/> is null. </exception>
        public virtual Response<LegalHold> ClearLegalHold(LegalHold legalHold, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(legalHold, nameof(legalHold));

            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.ClearLegalHold");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.ClearLegalHold(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, legalHold, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Lease Container operation establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/lease</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Lease</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Lease Container request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LeaseContainerResponse>> LeaseAsync(LeaseContainerContent content = null, CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Lease");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.LeaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Lease Container operation establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/lease</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_Lease</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Lease Container request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LeaseContainerResponse> Lease(LeaseContainerContent content = null, CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.Lease");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.Lease(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation migrates a blob container from container level WORM to object level immutability enabled container. Prerequisites require a container level immutability policy either in locked or unlocked state, Account level versioning must be enabled and there should be no Legal hold on the container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/migrate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_ObjectLevelWorm</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> ObjectLevelWormAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.ObjectLevelWorm");
            scope.Start();
            try
            {
                var response = await _blobContainerRestClient.ObjectLevelWormAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation(_blobContainerClientDiagnostics, Pipeline, _blobContainerRestClient.CreateObjectLevelWormRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation migrates a blob container from container level WORM to object level immutability enabled container. Prerequisites require a container level immutability policy either in locked or unlocked state, Account level versioning must be enabled and there should be no Legal hold on the container.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/migrate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobContainers_ObjectLevelWorm</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation ObjectLevelWorm(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerResource.ObjectLevelWorm");
            scope.Start();
            try
            {
                var response = _blobContainerRestClient.ObjectLevelWorm(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name, cancellationToken);
                var operation = new StorageArmOperation(_blobContainerClientDiagnostics, Pipeline, _blobContainerRestClient.CreateObjectLevelWormRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
