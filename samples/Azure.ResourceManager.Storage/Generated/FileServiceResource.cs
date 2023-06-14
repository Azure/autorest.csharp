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

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A Class representing a FileService along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="FileServiceResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetFileServiceResource method.
    /// Otherwise you can get one from its parent resource <see cref="StorageAccountResource" /> using the GetFileService method.
    /// </summary>
    public partial class FileServiceResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FileServiceResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _fileServiceClientDiagnostics;
        private readonly FileServicesRestOperations _fileServiceRestClient;
        private readonly FileServiceData _data;

        /// <summary> Initializes a new instance of the <see cref="FileServiceResource"/> class for mocking. </summary>
        protected FileServiceResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "FileServiceResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal FileServiceResource(ArmClient client, FileServiceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="FileServiceResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal FileServiceResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fileServiceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string fileServiceApiVersion);
            _fileServiceRestClient = new FileServicesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fileServiceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/fileServices";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FileServiceData Data
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

        /// <summary> Gets a collection of FileShareResources in the FileService. </summary>
        /// <returns> An object representing collection of FileShareResources and their operations over a FileShareResource. </returns>
        public virtual FileShareCollection GetFileShares()
        {
            return GetCachedClient(Client => new FileShareCollection(Client, Id));
        }

        /// <summary>
        /// Gets properties of a specified share.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FileShareResource>> GetFileShareAsync(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            return await GetFileShares().GetAsync(shareName, expand, xMsSnapshot, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets properties of a specified share.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FileShareResource> GetFileShare(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            return GetFileShares().Get(shareName, expand, xMsSnapshot, cancellationToken);
        }

        /// <summary>
        /// Gets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/{FileServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileServices_GetServiceProperties</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FileServiceResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _fileServiceClientDiagnostics.CreateScope("FileServiceResource.Get");
            scope.Start();
            try
            {
                var response = await _fileServiceRestClient.GetServicePropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileServiceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/{FileServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileServices_GetServiceProperties</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FileServiceResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _fileServiceClientDiagnostics.CreateScope("FileServiceResource.Get");
            scope.Start();
            try
            {
                var response = _fileServiceRestClient.GetServiceProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileServiceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/{FileServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileServices_SetServiceProperties</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FileServiceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, FileServiceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fileServiceClientDiagnostics.CreateScope("FileServiceResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fileServiceRestClient.SetServicePropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<FileServiceResource>(Response.FromValue(new FileServiceResource(Client, response), response.GetRawResponse()));
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
        /// Sets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/{FileServicesName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileServices_SetServiceProperties</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FileServiceResource> CreateOrUpdate(WaitUntil waitUntil, FileServiceData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fileServiceClientDiagnostics.CreateScope("FileServiceResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fileServiceRestClient.SetServiceProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken);
                var operation = new StorageArmOperation<FileServiceResource>(Response.FromValue(new FileServiceResource(Client, response), response.GetRawResponse()));
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
