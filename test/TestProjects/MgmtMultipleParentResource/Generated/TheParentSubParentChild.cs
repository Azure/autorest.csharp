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
using MgmtMultipleParentResource.Models;

namespace MgmtMultipleParentResource
{
    /// <summary> A Class representing a TheParentSubParentChild along with the instance operations that can be performed on it. </summary>
    public partial class TheParentSubParentChild : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="TheParentSubParentChild"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string theParentName, string instanceId, string childName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _theParentSubParentChildChildrenClientDiagnostics;
        private readonly ChildrenRestOperations _theParentSubParentChildChildrenRestClient;
        private readonly ChildBodyData _data;

        /// <summary> Initializes a new instance of the <see cref="TheParentSubParentChild"/> class for mocking. </summary>
        protected TheParentSubParentChild()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TheParentSubParentChild"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TheParentSubParentChild(ArmClient client, ChildBodyData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="TheParentSubParentChild"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TheParentSubParentChild(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _theParentSubParentChildChildrenClientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ResourceType, out string theParentSubParentChildChildrenApiVersion);
            _theParentSubParentChildChildrenRestClient = new ChildrenRestOperations(_theParentSubParentChildChildrenClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, theParentSubParentChildChildrenApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/theParents/subParents/children";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ChildBodyData Data
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> The operation to get the VMSS VM run command. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<TheParentSubParentChild>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.Get");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _theParentSubParentChildChildrenClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TheParentSubParentChild(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> The operation to get the VMSS VM run command. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TheParentSubParentChild> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.Get");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw _theParentSubParentChildChildrenClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Delete
        /// <summary> The operation to delete the VMSS VM run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<TheParentSubParentChildDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.Delete");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new TheParentSubParentChildDeleteOperation(_theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Delete
        /// <summary> The operation to delete the VMSS VM run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual TheParentSubParentChildDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.Delete");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new TheParentSubParentChildDeleteOperation(_theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Update
        /// <summary> The operation to update the VMSS VM run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="childBody"> Parameters supplied to the Update Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="childBody"/> is null. </exception>
        public async virtual Task<TheParentSubParentChildUpdateOperation> UpdateAsync(bool waitForCompletion, ChildBodyUpdate childBody, CancellationToken cancellationToken = default)
        {
            if (childBody == null)
            {
                throw new ArgumentNullException(nameof(childBody));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.Update");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, childBody, cancellationToken).ConfigureAwait(false);
                var operation = new TheParentSubParentChildUpdateOperation(ArmClient, _theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, childBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Update
        /// <summary> The operation to update the VMSS VM run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="childBody"> Parameters supplied to the Update Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="childBody"/> is null. </exception>
        public virtual TheParentSubParentChildUpdateOperation Update(bool waitForCompletion, ChildBodyUpdate childBody, CancellationToken cancellationToken = default)
        {
            if (childBody == null)
            {
                throw new ArgumentNullException(nameof(childBody));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.Update");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, childBody, cancellationToken);
                var operation = new TheParentSubParentChildUpdateOperation(ArmClient, _theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, childBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public async virtual Task<Response<TheParentSubParentChild>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TheParentSubParentChild(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<TheParentSubParentChild> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken);
                return Response.FromValue(new TheParentSubParentChild(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public async virtual Task<Response<TheParentSubParentChild>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(true, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TheParentSubParentChild(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<TheParentSubParentChild> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(true, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken);
                return Response.FromValue(new TheParentSubParentChild(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async virtual Task<Response<TheParentSubParentChild>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TheParentSubParentChild(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// OperationId: Children_Get
        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<TheParentSubParentChild> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, null, cancellationToken);
                return Response.FromValue(new TheParentSubParentChild(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
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
            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.GetAvailableLocations");
            scope.Start();
            try
            {
                return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
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
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChild.GetAvailableLocations");
            scope.Start();
            try
            {
                return ListAvailableLocations(ResourceType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
