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

namespace AzureSample.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="FileShareResource"/> and their operations.
    /// Each <see cref="FileShareResource"/> in the collection will belong to the same instance of <see cref="FileServiceResource"/>.
    /// To get a <see cref="FileShareCollection"/> instance call the GetFileShares method from an instance of <see cref="FileServiceResource"/>.
    /// </summary>
    public partial class FileShareCollection : ArmCollection, IEnumerable<FileShareResource>, IAsyncEnumerable<FileShareResource>
    {
        private readonly ClientDiagnostics _fileShareClientDiagnostics;
        private readonly FileSharesRestOperations _fileShareRestClient;

        /// <summary> Initializes a new instance of the <see cref="FileShareCollection"/> class for mocking. </summary>
        protected FileShareCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FileShareCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FileShareCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fileShareClientDiagnostics = new ClientDiagnostics("AzureSample.ResourceManager.Storage", FileShareResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FileShareResource.ResourceType, out string fileShareApiVersion);
            _fileShareRestClient = new FileSharesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fileShareApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != FileServiceResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, FileServiceResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new share under the specified account as described by request body. The share resource includes metadata and properties for that share. It does not include a list of the files contained by the share.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="data"> Properties of the file share to create. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FileShareResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string shareName, FileShareData data, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, data, expand, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<FileShareResource>(Response.FromValue(new FileShareResource(Client, response), response.GetRawResponse()));
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
        /// Creates a new share under the specified account as described by request body. The share resource includes metadata and properties for that share. It does not include a list of the files contained by the share.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="data"> Properties of the file share to create. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FileShareResource> CreateOrUpdate(WaitUntil waitUntil, string shareName, FileShareData data, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, data, expand, cancellationToken);
                var operation = new StorageArmOperation<FileShareResource>(Response.FromValue(new FileShareResource(Client, response), response.GetRawResponse()));
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        public virtual async Task<Response<FileShareResource>> GetAsync(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.Get");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, expand, xMsSnapshot, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        public virtual Response<FileShareResource> Get(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.Get");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, expand, xMsSnapshot, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all shares.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FileShareResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FileShareResource> GetAllAsync(int? maxpagesize = null, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fileShareRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fileShareRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FileShareResource(Client, FileShareData.DeserializeFileShareData(e)), _fileShareClientDiagnostics, Pipeline, "FileShareCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all shares.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter ','. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FileShareResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FileShareResource> GetAll(int? maxpagesize = null, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fileShareRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fileShareRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, pageSizeHint, filter, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FileShareResource(Client, FileShareData.DeserializeFileShareData(e)), _fileShareClientDiagnostics, Pipeline, "FileShareCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, expand, xMsSnapshot, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        public virtual Response<bool> Exists(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.Exists");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, expand, xMsSnapshot, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        public virtual async Task<NullableResponse<FileShareResource>> GetIfExistsAsync(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fileShareRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, expand, xMsSnapshot, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<FileShareResource>(response.GetRawResponse());
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares/{shareName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FileShares_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FileShareResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shareName"> The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number. </param>
        /// <param name="expand"> Optional, used to expand the properties within share's properties. Valid values are: stats. Should be passed as a string with delimiter ','. </param>
        /// <param name="xMsSnapshot"> Optional, used to retrieve properties of a snapshot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="shareName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="shareName"/> is null. </exception>
        public virtual NullableResponse<FileShareResource> GetIfExists(string shareName, string expand = null, string xMsSnapshot = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(shareName, nameof(shareName));

            using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fileShareRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, shareName, expand, xMsSnapshot, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<FileShareResource>(response.GetRawResponse());
                return Response.FromValue(new FileShareResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FileShareResource> IEnumerable<FileShareResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FileShareResource> IAsyncEnumerable<FileShareResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}