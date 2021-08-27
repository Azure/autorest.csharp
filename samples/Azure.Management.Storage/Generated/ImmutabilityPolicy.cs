// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Management.Storage.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.Management.Storage
{
    /// <summary> A Class representing a ImmutabilityPolicy along with the instance operations that can be performed on it. </summary>
    public partial class ImmutabilityPolicy : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ImmutabilityPoliciesRestOperations _restClient;
        private readonly ImmutabilityPolicyData _data;

        /// <summary> Initializes a new instance of the <see cref="ImmutabilityPolicy"/> class for mocking. </summary>
        protected ImmutabilityPolicy()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ImmutabilityPolicy"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal ImmutabilityPolicy(ArmResource options, ImmutabilityPolicyData resource) : base(options, resource.Id)
        {
            HasData = true;
            _data = resource;
            Parent = options;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ImmutabilityPoliciesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="ImmutabilityPolicy"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ImmutabilityPolicy(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            Parent = options;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ImmutabilityPoliciesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/blobServices/containers/immutabilityPolicies";

        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

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

        /// <summary> Gets the parent resource of this resource. </summary>
        public ArmResource Parent { get; }

        /// <summary> Gets the existing immutability policy along with the corresponding ETag in response headers and body. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ImmutabilityPolicy>> GetAsync(string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Get");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
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

        /// <summary> Gets the existing immutability policy along with the corresponding ETag in response headers and body. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ImmutabilityPolicy> Get(string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Get");
            scope.Start();
            try
            {
                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
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
        public async virtual Task<IEnumerable<Location>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<Location> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// <summary> Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, only way is to delete the container after deleting all blobs inside the container. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public async virtual Task<ImmutabilityPolicyDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Delete");
            scope.Start();
            try
            {
                var response = await _restClient.DeleteAsync(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
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

        /// <summary> Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, only way is to delete the container after deleting all blobs inside the container. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual ImmutabilityPolicyDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Delete");
            scope.Start();
            try
            {
                var response = _restClient.Delete(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
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
        /// <summary> Creates or updates an unlocked immutability policy. ETag in If-Match is honored if given but not required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be created or updated to a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ImmutabilityPolicy>> CreateOrUpdateAsync(string ifMatch = null, ImmutabilityPolicyData parameters = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates an unlocked immutability policy. ETag in If-Match is honored if given but not required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be created or updated to a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ImmutabilityPolicy> CreateOrUpdate(string ifMatch = null, ImmutabilityPolicyData parameters = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sets the ImmutabilityPolicy to Locked state. The only action allowed on a Locked policy is ExtendImmutabilityPolicy action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual async Task<Response<ImmutabilityPolicy>> LockAsync(string ifMatch, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Lock");
            scope.Start();
            try
            {
                var response = await _restClient.LockAsync(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sets the ImmutabilityPolicy to Locked state. The only action allowed on a Locked policy is ExtendImmutabilityPolicy action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual Response<ImmutabilityPolicy> Lock(string ifMatch, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Lock");
            scope.Start();
            try
            {
                var response = _restClient.Lock(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, cancellationToken);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Extends the immutabilityPeriodSinceCreationInDays of a locked immutabilityPolicy. The only action allowed on a Locked policy will be this action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be extended for a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual async Task<Response<ImmutabilityPolicy>> ExtendAsync(string ifMatch, ImmutabilityPolicyData parameters = null, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Extend");
            scope.Start();
            try
            {
                var response = await _restClient.ExtendAsync(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ImmutabilityPolicy(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Extends the immutabilityPeriodSinceCreationInDays of a locked immutabilityPolicy. The only action allowed on a Locked policy will be this action. ETag in If-Match is required for this operation. </summary>
        /// <param name="ifMatch"> The entity state (ETag) version of the immutability policy to update. A value of &quot;*&quot; can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied. </param>
        /// <param name="parameters"> The ImmutabilityPolicy Properties that will be extended for a blob container. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual Response<ImmutabilityPolicy> Extend(string ifMatch, ImmutabilityPolicyData parameters = null, CancellationToken cancellationToken = default)
        {
            if (ifMatch == null)
            {
                throw new ArgumentNullException(nameof(ifMatch));
            }

            using var scope = _clientDiagnostics.CreateScope("ImmutabilityPolicy.Extend");
            scope.Start();
            try
            {
                var response = _restClient.Extend(Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Name, ifMatch, parameters, cancellationToken);
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
