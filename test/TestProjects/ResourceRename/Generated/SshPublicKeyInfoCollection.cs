// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using ResourceRename.Models;

namespace ResourceRename
{
    /// <summary> A class representing collection of SshPublicKeyInfo and their operations over its parent. </summary>
    public partial class SshPublicKeyInfoCollection : ArmCollection, IEnumerable<SshPublicKeyInfoResource>, IAsyncEnumerable<SshPublicKeyInfoResource>
    {
        private readonly ClientDiagnostics _sshPublicKeyInfoSshPublicKeysClientDiagnostics;
        private readonly SshPublicKeysRestOperations _sshPublicKeyInfoSshPublicKeysRestClient;

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyInfoCollection"/> class for mocking. </summary>
        protected SshPublicKeyInfoCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyInfoCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SshPublicKeyInfoCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sshPublicKeyInfoSshPublicKeysClientDiagnostics = new ClientDiagnostics("ResourceRename", SshPublicKeyInfoResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SshPublicKeyInfoResource.ResourceType, out string sshPublicKeyInfoSshPublicKeysApiVersion);
            _sshPublicKeyInfoSshPublicKeysRestClient = new SshPublicKeysRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, sshPublicKeyInfoSshPublicKeysApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new SSH public key resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="properties"> Contains information about SSH certificate public key and the path on the Linux VM where the public key is placed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual async Task<ArmOperation<SshPublicKeyInfoResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sshPublicKeyName, SshPublicKeyProperties properties = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyInfoSshPublicKeysRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, properties, cancellationToken).ConfigureAwait(false);
                var operation = new ResourceRenameArmOperation<SshPublicKeyInfoResource>(Response.FromValue(new SshPublicKeyInfoResource(Client, response), response.GetRawResponse()));
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
        /// Creates a new SSH public key resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="properties"> Contains information about SSH certificate public key and the path on the Linux VM where the public key is placed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual ArmOperation<SshPublicKeyInfoResource> CreateOrUpdate(WaitUntil waitUntil, string sshPublicKeyName, SshPublicKeyProperties properties = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _sshPublicKeyInfoSshPublicKeysRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, properties, cancellationToken);
                var operation = new ResourceRenameArmOperation<SshPublicKeyInfoResource>(Response.FromValue(new SshPublicKeyInfoResource(Client, response), response.GetRawResponse()));
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
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual async Task<Response<SshPublicKeyInfoResource>> GetAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.Get");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyInfoSshPublicKeysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyInfoResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<SshPublicKeyInfoResource> Get(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.Get");
            scope.Start();
            try
            {
                var response = _sshPublicKeyInfoSshPublicKeysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyInfoResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the SSH public keys in the specified resource group. Use the nextLink property in the response to get the next page of SSH public keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys
        /// Operation Id: SshPublicKeys_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SshPublicKeyInfoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SshPublicKeyInfoResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SshPublicKeyInfoResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sshPublicKeyInfoSshPublicKeysRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyInfoResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SshPublicKeyInfoResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sshPublicKeyInfoSshPublicKeysRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyInfoResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all of the SSH public keys in the specified resource group. Use the nextLink property in the response to get the next page of SSH public keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys
        /// Operation Id: SshPublicKeys_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SshPublicKeyInfoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SshPublicKeyInfoResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SshPublicKeyInfoResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sshPublicKeyInfoSshPublicKeysRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyInfoResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SshPublicKeyInfoResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sshPublicKeyInfoSshPublicKeysRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyInfoResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(sshPublicKeyName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<bool> Exists(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(sshPublicKeyName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual async Task<Response<SshPublicKeyInfoResource>> GetIfExistsAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyInfoSshPublicKeysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SshPublicKeyInfoResource>(null, response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyInfoResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<SshPublicKeyInfoResource> GetIfExists(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfoCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sshPublicKeyInfoSshPublicKeysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SshPublicKeyInfoResource>(null, response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyInfoResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SshPublicKeyInfoResource> IEnumerable<SshPublicKeyInfoResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SshPublicKeyInfoResource> IAsyncEnumerable<SshPublicKeyInfoResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
