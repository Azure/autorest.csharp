// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
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
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly BlobContainersRestOperations _blobContainersRestClient;
        private readonly ImmutabilityPolicyData _data;

        /// <summary> Initializes a new instance of the <see cref="ImmutabilityPolicy"/> class for mocking. </summary>
        protected ImmutabilityPolicy()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ImmutabilityPolicy"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ImmutabilityPolicy(ArmResource options, ImmutabilityPolicyData data) : base(options, data.Id)
        {
            HasData = true;
            _data = data;
            Parent = options;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _blobContainersRestClient = new BlobContainersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="ImmutabilityPolicy"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ImmutabilityPolicy(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            Parent = options;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _blobContainersRestClient = new BlobContainersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="ImmutabilityPolicy"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ImmutabilityPolicy(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _blobContainersRestClient = new BlobContainersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
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
                throw new ArgumentException(nameof(id), string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType));
        }

        /// <summary> Gets the parent resource of this resource. </summary>
        public ArmResource Parent { get; }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_GetImmutabilityPolicy
        /// <summary> Gets the existing immutability policy along with the corresponding ETag in response headers and body. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ImmutabilityPolicy>> GetAsync(string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Get");
            scope.Start();
            try
            {
                var response = await _blobContainersRestClient.GetImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_GetImmutabilityPolicy
        /// <summary> Gets the existing immutability policy along with the corresponding ETag in response headers and body. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ImmutabilityPolicy> Get(string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Get");
            scope.Start();
            try
            {
                var response = _blobContainersRestClient.GetImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async virtual Task<IEnumerable<AzureLocation>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_DeleteImmutabilityPolicy
        /// <summary> Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, the only way is to delete the container after deleting all expired blobs inside the policy locked container. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public async virtual Task<BlobContainerDeleteImmutabilityPolicyOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Delete");
            scope.Start();
            try
            {
                var response = await _blobContainersRestClient.DeleteImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new BlobContainerDeleteImmutabilityPolicyOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_DeleteImmutabilityPolicy
        /// <summary> Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, the only way is to delete the container after deleting all expired blobs inside the policy locked container. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual BlobContainerDeleteImmutabilityPolicyOperation Delete(string ifMatch, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Delete");
            scope.Start();
            try
            {
                var response = _blobContainersRestClient.DeleteImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
                var operation = new BlobContainerDeleteImmutabilityPolicyOperation(response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_CreateOrUpdateImmutabilityPolicy
        /// <summary> Creates or updates an unlocked immutability policy. ETag in If-Match is honored if given but not required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be created or updated to a blob container. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<BlobContainerCreateOrUpdateImmutabilityPolicyOperation> CreateOrUpdateAsync(string ifMatch = null, ImmutabilityPolicyData parameters = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _blobContainersRestClient.CreateOrUpdateImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new BlobContainerCreateOrUpdateImmutabilityPolicyOperation(this, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}
        /// OperationId: BlobContainers_CreateOrUpdateImmutabilityPolicy
        /// <summary> Creates or updates an unlocked immutability policy. ETag in If-Match is honored if given but not required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be created or updated to a blob container. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual BlobContainerCreateOrUpdateImmutabilityPolicyOperation CreateOrUpdate(string ifMatch = null, ImmutabilityPolicyData parameters = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _blobContainersRestClient.CreateOrUpdateImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken);
                var operation = new BlobContainerCreateOrUpdateImmutabilityPolicyOperation(this, response);
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

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.LockImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = await _blobContainersRestClient.LockImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
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

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.LockImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = _blobContainersRestClient.LockImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
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

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.ExtendImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = await _blobContainersRestClient.ExtendImmutabilityPolicyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
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

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.ExtendImmutabilityPolicy");
            scope.Start();
            try
            {
                var response = _blobContainersRestClient.ExtendImmutabilityPolicy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
