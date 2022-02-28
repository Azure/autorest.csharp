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
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A Class representing a FileService along with the instance operations that can be performed on it. </summary>
    public partial class FileService : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FileService"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _fileServiceClientDiagnostics;
        private readonly FileServicesRestOperations _fileServiceRestClient;
        private readonly FileServiceData _data;

        /// <summary> Initializes a new instance of the <see cref="FileService"/> class for mocking. </summary>
        protected FileService()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "FileService"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal FileService(ArmClient client, FileServiceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="FileService"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal FileService(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fileServiceClientDiagnostics = new ClientDiagnostics("Azure.Management.Storage", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string fileServiceApiVersion);
            _fileServiceRestClient = new FileServicesRestOperations(_fileServiceClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, fileServiceApiVersion);
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

        /// <summary> Gets a collection of FileShares in the FileShare. </summary>
        /// <returns> An object representing collection of FileShares and their operations over a FileShare. </returns>
        public virtual FileShareCollection GetFileShares()
        {
            return new FileShareCollection(Client, Id);
        }

        /// <summary>
        /// Gets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default
        /// Operation Id: FileServices_GetServiceProperties
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FileService>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _fileServiceClientDiagnostics.CreateScope("FileService.Get");
            scope.Start();
            try
            {
                var response = await _fileServiceRestClient.GetServicePropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileService(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default
        /// Operation Id: FileServices_GetServiceProperties
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FileService> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _fileServiceClientDiagnostics.CreateScope("FileService.Get");
            scope.Start();
            try
            {
                var response = _fileServiceRestClient.GetServiceProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileService(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules. 
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default
        /// Operation Id: FileServices_SetServiceProperties
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<FileService>> CreateOrUpdateAsync(bool waitForCompletion, FileServiceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _fileServiceClientDiagnostics.CreateScope("FileService.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fileServiceRestClient.SetServicePropertiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<FileService>(Response.FromValue(new FileService(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default
        /// Operation Id: FileServices_SetServiceProperties
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<FileService> CreateOrUpdate(bool waitForCompletion, FileServiceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _fileServiceClientDiagnostics.CreateScope("FileService.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fileServiceRestClient.SetServiceProperties(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, parameters, cancellationToken);
                var operation = new StorageArmOperation<FileService>(Response.FromValue(new FileService(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
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
