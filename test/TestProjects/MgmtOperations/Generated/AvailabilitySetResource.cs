// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> A Class representing a AvailabilitySetResource along with the instance operations that can be performed on it. </summary>
    public partial class AvailabilitySetResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="AvailabilitySetResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string availabilitySetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _availabilitySetResourceAvailabilitySetsClientDiagnostics;
        private readonly AvailabilitySetsRestOperations _availabilitySetResourceAvailabilitySetsRestClient;
        private readonly AvailabilitySetResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetResource"/> class for mocking. </summary>
        protected AvailabilitySetResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "AvailabilitySetResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal AvailabilitySetResource(ArmClient client, AvailabilitySetResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal AvailabilitySetResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _availabilitySetResourceAvailabilitySetsClientDiagnostics = new ClientDiagnostics("MgmtOperations", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string availabilitySetResourceAvailabilitySetsApiVersion);
            _availabilitySetResourceAvailabilitySetsRestClient = new AvailabilitySetsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, availabilitySetResourceAvailabilitySetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/availabilitySets";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual AvailabilitySetResourceData Data
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

        /// <summary> Gets a collection of AvailabilitySetChildResources in the AvailabilitySetChildResource. </summary>
        /// <returns> An object representing collection of AvailabilitySetChildResources and their operations over a AvailabilitySetChildResource. </returns>
        public virtual AvailabilitySetChildCollection GetAvailabilitySetChildResources()
        {
            return GetCachedClient(Client => new AvailabilitySetChildCollection(Client, Id));
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// Operation Id: availabilitySetChild_Get
        /// </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetChildResource>> GetAvailabilitySetChildResourceAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            return await GetAvailabilitySetChildResources().GetAsync(availabilitySetChildName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}
        /// Operation Id: availabilitySetChild_Get
        /// </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual Response<AvailabilitySetChildResource> GetAvailabilitySetChildResource(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            return GetAvailabilitySetChildResources().Get(availabilitySetChildName, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AvailabilitySetResource>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.Get");
            scope.Start();
            try
            {
                var response = await _availabilitySetResourceAvailabilitySetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AvailabilitySetResource> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.Get");
            scope.Start();
            try
            {
                var response = _availabilitySetResourceAvailabilitySetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.Delete");
            scope.Start();
            try
            {
                var response = await _availabilitySetResourceAvailabilitySetsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation(response);
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
        /// Delete an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.Delete");
            scope.Start();
            try
            {
                var response = _availabilitySetResourceAvailabilitySetsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new MgmtOperationsArmOperation(response);
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
        /// Update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Update
        /// </summary>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetResource>> UpdateAsync(AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.Update");
            scope.Start();
            try
            {
                var response = await _availabilitySetResourceAvailabilitySetsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Update
        /// </summary>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response<AvailabilitySetResource> Update(AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.Update");
            scope.Start();
            try
            {
                var response = _availabilitySetResourceAvailabilitySetsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken);
                return Response.FromValue(new AvailabilitySetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Testing description.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/sharedkey
        /// Operation Id: AvailabilitySets_TestSetSharedKey
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parameters"> Parameters supplied to the Begin Set Virtual Network Gateway connection Shared key operation throughNetwork resource provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ConnectionSharedKey>> TestSetSharedKeyAsync(WaitUntil waitUntil, ConnectionSharedKey parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.TestSetSharedKey");
            scope.Start();
            try
            {
                var response = await _availabilitySetResourceAvailabilitySetsRestClient.TestSetSharedKeyAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation<ConnectionSharedKey>(new ConnectionSharedKeyOperationSource(), _availabilitySetResourceAvailabilitySetsClientDiagnostics, Pipeline, _availabilitySetResourceAvailabilitySetsRestClient.CreateTestSetSharedKeyRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Testing description.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/sharedkey
        /// Operation Id: AvailabilitySets_TestSetSharedKey
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parameters"> Parameters supplied to the Begin Set Virtual Network Gateway connection Shared key operation throughNetwork resource provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ConnectionSharedKey> TestSetSharedKey(WaitUntil waitUntil, ConnectionSharedKey parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.TestSetSharedKey");
            scope.Start();
            try
            {
                var response = _availabilitySetResourceAvailabilitySetsRestClient.TestSetSharedKey(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken);
                var operation = new MgmtOperationsArmOperation<ConnectionSharedKey>(new ConnectionSharedKeyOperationSource(), _availabilitySetResourceAvailabilitySetsClientDiagnostics, Pipeline, _availabilitySetResourceAvailabilitySetsRestClient.CreateTestSetSharedKeyRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _availabilitySetResourceAvailabilitySetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<AvailabilitySetResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _availabilitySetResourceAvailabilitySetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                return Response.FromValue(new AvailabilitySetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _availabilitySetResourceAvailabilitySetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<AvailabilitySetResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _availabilitySetResourceAvailabilitySetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                return Response.FromValue(new AvailabilitySetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _availabilitySetResourceAvailabilitySetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<AvailabilitySetResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _availabilitySetResourceAvailabilitySetsClientDiagnostics.CreateScope("AvailabilitySetResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _availabilitySetResourceAvailabilitySetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                return Response.FromValue(new AvailabilitySetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
