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

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A Class representing a BlobService along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="BlobServiceResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetBlobServiceResource method.
    /// Otherwise you can get one from its parent resource <see cref="StorageAccountResource"/> using the GetBlobService method.
    /// </summary>
    public partial class BlobServiceResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BlobServiceResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="accountName"> The accountName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _blobServiceClientDiagnostics;
        private readonly BlobServicesRestOperations _blobServiceRestClient;
        private readonly BlobServiceData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/blobServices";

        /// <summary> Initializes a new instance of the <see cref="BlobServiceResource"/> class for mocking. </summary>
        protected BlobServiceResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BlobServiceResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BlobServiceResource(ArmClient client, BlobServiceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="BlobServiceResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BlobServiceResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _blobServiceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string blobServiceApiVersion);
            _blobServiceRestClient = new BlobServicesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, blobServiceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BlobServiceData Data
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

        /// <summary> Gets a collection of BlobContainerResources in the BlobService. </summary>
        /// <returns> An object representing collection of BlobContainerResources and their operations over a BlobContainerResource. </returns>
        public virtual BlobContainerCollection GetBlobContainers()
        {
            return GetCachedClient(client => new BlobContainerCollection(client, Id));
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
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Storage/storageAccounts/blobServices/containers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<BlobContainerResource>> GetBlobContainerAsync(string containerName, CancellationToken cancellationToken = default)
        {
            return await GetBlobContainers().GetAsync(containerName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Storage/storageAccounts/blobServices/containers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="containerName"> The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="containerName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<BlobContainerResource> GetBlobContainer(string containerName, CancellationToken cancellationToken = default)
        {
            return GetBlobContainers().Get(containerName, cancellationToken);
        }

        /// <summary>
        /// Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobServices_GetServiceProperties</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Storage/storageAccounts/blobServices</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BlobServiceResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _blobServiceClientDiagnostics.CreateScope("BlobServiceResource.Get");
            scope.Start();
            try
            {
                var response = await _blobServiceRestClient.GetServicePropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobServiceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobServices_GetServiceProperties</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Storage/storageAccounts/blobServices</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BlobServiceResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _blobServiceClientDiagnostics.CreateScope("BlobServiceResource.Get");
            scope.Start();
            try
            {
                var response = _blobServiceRestClient.GetServiceProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BlobServiceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobServices_SetServiceProperties</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Storage/storageAccounts/blobServices</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BlobServiceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, BlobServiceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobServiceClientDiagnostics.CreateScope("BlobServiceResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _blobServiceRestClient.SetServicePropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<BlobServiceResource>(Response.FromValue(new BlobServiceResource(Client, response), response.GetRawResponse()));
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
        /// Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/{BlobServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BlobServices_SetServiceProperties</description>
        /// </item>
        /// <item>
        /// <term>Resource Type</term>
        /// <description>Microsoft.Storage/storageAccounts/blobServices</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BlobServiceResource> CreateOrUpdate(WaitUntil waitUntil, BlobServiceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _blobServiceClientDiagnostics.CreateScope("BlobServiceResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _blobServiceRestClient.SetServiceProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken);
                var operation = new StorageArmOperation<BlobServiceResource>(Response.FromValue(new BlobServiceResource(Client, response), response.GetRawResponse()));
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
    }
}
