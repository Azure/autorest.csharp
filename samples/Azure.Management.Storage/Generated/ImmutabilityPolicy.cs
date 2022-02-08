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
using Azure.Management.Storage.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A Class representing a ImmutabilityPolicy along with the instance operations that can be performed on it. </summary>
    public partial class ImmutabilityPolicy : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ImmutabilityPolicy"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string containerName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _immutabilityPolicyBlobContainersClientDiagnostics;
        private readonly BlobContainersRestOperations _immutabilityPolicyBlobContainersRestClient;
        private readonly ImmutabilityPolicyData _data;

        /// <summary> Initializes a new instance of the <see cref="ImmutabilityPolicy"/> class for mocking. </summary>
        protected ImmutabilityPolicy()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ImmutabilityPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ImmutabilityPolicy(ArmClient client, ImmutabilityPolicyData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ImmutabilityPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ImmutabilityPolicy(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _immutabilityPolicyBlobContainersClientDiagnostics = new ClientDiagnostics("Azure.Management.Storage", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string immutabilityPolicyBlobContainersApiVersion);
            _immutabilityPolicyBlobContainersRestClient = new BlobContainersRestOperations(_immutabilityPolicyBlobContainersClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, immutabilityPolicyBlobContainersApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/blobServices/containers/immutabilityPolicies";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ImmutabilityPolicyData Data
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_GetImmutabilityPolicy
        /// <summary> Gets the existing immutability policy along with the corresponding ETag in response headers and body. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ImmutabilityPolicy>> GetAsync(string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.Get");
            scope.Start();
            try
            {
                var response = await _immutabilityPolicyBlobContainersRestClient.GetImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _immutabilityPolicyBlobContainersClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_GetImmutabilityPolicy
        /// <summary> Gets the existing immutability policy along with the corresponding ETag in response headers and body. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ImmutabilityPolicy> Get(string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.Get");
            scope.Start();
            try
            {
                var response = _immutabilityPolicyBlobContainersRestClient.GetImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
                if (response.Value == null)
                    throw _immutabilityPolicyBlobContainersClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ImmutabilityPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_DeleteImmutabilityPolicy
        /// <summary> Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, the only way is to delete the container after deleting all expired blobs inside the policy locked container. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public async virtual Task<ImmutabilityPolicyDeleteOperation> DeleteAsync(bool waitForCompletion, string ifMatch, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.Delete");
            scope.Start();
            try
            {
                var response = await _immutabilityPolicyBlobContainersRestClient.DeleteImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new ImmutabilityPolicyDeleteOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_DeleteImmutabilityPolicy
        /// <summary> Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, the only way is to delete the container after deleting all expired blobs inside the policy locked container. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual ImmutabilityPolicyDeleteOperation Delete(bool waitForCompletion, string ifMatch, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.Delete");
            scope.Start();
            try
            {
                var response = _immutabilityPolicyBlobContainersRestClient.DeleteImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
                var operation = new ImmutabilityPolicyDeleteOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_CreateOrUpdateImmutabilityPolicy
        /// <summary> Creates or updates an unlocked immutability policy. ETag in If-Match is honored if given but not required for this operation. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be created or updated to a blob container. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ImmutabilityPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, ImmutabilityPolicyData parameters = null, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _immutabilityPolicyBlobContainersRestClient.CreateOrUpdateImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, parameters, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new ImmutabilityPolicyCreateOrUpdateOperation(Client, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_CreateOrUpdateImmutabilityPolicy
        /// <summary> Creates or updates an unlocked immutability policy. ETag in If-Match is honored if given but not required for this operation. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be created or updated to a blob container. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ImmutabilityPolicyCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, ImmutabilityPolicyData parameters = null, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _immutabilityPolicyBlobContainersRestClient.CreateOrUpdateImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, parameters, ifMatch, cancellationToken);
                var operation = new ImmutabilityPolicyCreateOrUpdateOperation(Client, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default/lock
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_LockImmutabilityPolicy
        /// <summary> Sets the ImmutabilityPolicy to Locked state. The only action allowed on a Locked policy is ExtendImmutabilityPolicy action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public async virtual Task<Response<ImmutabilityPolicy>> LockImmutabilityPolicyAsync(string ifMatch, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.LockImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = await _immutabilityPolicyBlobContainersRestClient.LockImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default/lock
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_LockImmutabilityPolicy
        /// <summary> Sets the ImmutabilityPolicy to Locked state. The only action allowed on a Locked policy is ExtendImmutabilityPolicy action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual Response<ImmutabilityPolicy> LockImmutabilityPolicy(string ifMatch, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.LockImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = _immutabilityPolicyBlobContainersRestClient.LockImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
                return Response.FromValue(new ImmutabilityPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default/extend
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_ExtendImmutabilityPolicy
        /// <summary> Extends the immutabilityPeriodSinceCreationInDays of a locked immutabilityPolicy. The only action allowed on a Locked policy will be this action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be extended for a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public async virtual Task<Response<ImmutabilityPolicy>> ExtendImmutabilityPolicyAsync(string ifMatch, ImmutabilityPolicyData parameters = null, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.ExtendImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = await _immutabilityPolicyBlobContainersRestClient.ExtendImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default/extend
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_ExtendImmutabilityPolicy
        /// <summary> Extends the immutabilityPeriodSinceCreationInDays of a locked immutabilityPolicy. The only action allowed on a Locked policy will be this action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be extended for a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual Response<ImmutabilityPolicy> ExtendImmutabilityPolicy(string ifMatch, ImmutabilityPolicyData parameters = null, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _immutabilityPolicyBlobContainersClientDiagnostics.CreateScope("ImmutabilityPolicy.ExtendImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = _immutabilityPolicyBlobContainersRestClient.ExtendImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken);
                return Response.FromValue(new ImmutabilityPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
