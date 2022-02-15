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

namespace ResourceRename
{
    /// <summary> A Class representing a SshPublicKeyInfo along with the instance operations that can be performed on it. </summary>
    public partial class SshPublicKeyInfo : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SshPublicKeyInfo"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sshPublicKeyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _sshPublicKeyInfoSshPublicKeysClientDiagnostics;
        private readonly SshPublicKeysRestOperations _sshPublicKeyInfoSshPublicKeysRestClient;
        private readonly SshPublicKeyInfoData _data;

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyInfo"/> class for mocking. </summary>
        protected SshPublicKeyInfo()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SshPublicKeyInfo"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SshPublicKeyInfo(ArmClient client, SshPublicKeyInfoData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyInfo"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SshPublicKeyInfo(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sshPublicKeyInfoSshPublicKeysClientDiagnostics = new ClientDiagnostics("ResourceRename", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string sshPublicKeyInfoSshPublicKeysApiVersion);
            _sshPublicKeyInfoSshPublicKeysRestClient = new SshPublicKeysRestOperations(_sshPublicKeyInfoSshPublicKeysClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, sshPublicKeyInfoSshPublicKeysApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/sshPublicKeys";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SshPublicKeyInfoData Data
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

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SshPublicKeyInfo>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfo.Get");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyInfoSshPublicKeysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SshPublicKeyInfo(Client, response.Value), response.GetRawResponse());
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SshPublicKeyInfo> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfo.Get");
            scope.Start();
            try
            {
                var response = _sshPublicKeyInfoSshPublicKeysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyInfo(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfo.Delete");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyInfoSshPublicKeysRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ResourceRenameArmOperation(response);
                if (waitForCompletion)
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
        /// Delete an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _sshPublicKeyInfoSshPublicKeysClientDiagnostics.CreateScope("SshPublicKeyInfo.Delete");
            scope.Start();
            try
            {
                var response = _sshPublicKeyInfoSshPublicKeysRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new ResourceRenameArmOperation(response);
                if (waitForCompletion)
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
