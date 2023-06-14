// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Azure.ResourceManager.Resources;
using MgmtConstants.Models;

namespace MgmtConstants
{
    /// <summary>
    /// A Class representing an OptionalMachine along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="OptionalMachineResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetOptionalMachineResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetOptionalMachine method.
    /// </summary>
    public partial class OptionalMachineResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="OptionalMachineResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _optionalMachineOptionalsClientDiagnostics;
        private readonly OptionalsRestOperations _optionalMachineOptionalsRestClient;
        private readonly OptionalMachineData _data;

        /// <summary> Initializes a new instance of the <see cref="OptionalMachineResource"/> class for mocking. </summary>
        protected OptionalMachineResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "OptionalMachineResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal OptionalMachineResource(ArmClient client, OptionalMachineData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="OptionalMachineResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal OptionalMachineResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _optionalMachineOptionalsClientDiagnostics = new ClientDiagnostics("MgmtConstants", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string optionalMachineOptionalsApiVersion);
            _optionalMachineOptionalsRestClient = new OptionalsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, optionalMachineOptionalsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Constant/optionalMachines";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual OptionalMachineData Data
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
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OptionalMachineResource>> GetAsync(OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.Get");
            scope.Start();
            try
            {
                var response = await _optionalMachineOptionalsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OptionalMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the model view or the instance view of a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OptionalMachineResource> Get(OptionalMachineExpand? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.Get");
            scope.Start();
            try
            {
                var response = _optionalMachineOptionalsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OptionalMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to delete a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="forceDeletion"> Optional parameter to force delete virtual machines. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? forceDeletion = null, CancellationToken cancellationToken = default)
        {
            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.Delete");
            scope.Start();
            try
            {
                var response = await _optionalMachineOptionalsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, forceDeletion, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtConstantsArmOperation(_optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, forceDeletion).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to delete a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="forceDeletion"> Optional parameter to force delete virtual machines. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? forceDeletion = null, CancellationToken cancellationToken = default)
        {
            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.Delete");
            scope.Start();
            try
            {
                var response = _optionalMachineOptionalsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, forceDeletion, cancellationToken);
                var operation = new MgmtConstantsArmOperation(_optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, forceDeletion).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to update a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Parameters supplied to the Update Virtual Machine operation. </param>
        /// <param name="optionalIntQuery"> The IntConstant to use. </param>
        /// <param name="optionalFloatQuery"> The FloatConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<OptionalMachineResource>> UpdateAsync(WaitUntil waitUntil, OptionalMachinePatch patch, IntConstant? optionalIntQuery = null, FloatConstant? optionalFloatQuery = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.Update");
            scope.Start();
            try
            {
                var response = await _optionalMachineOptionalsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, optionalIntQuery, optionalFloatQuery, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtConstantsArmOperation<OptionalMachineResource>(new OptionalMachineOperationSource(Client), _optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, optionalIntQuery, optionalFloatQuery).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to update a virtual machine.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Parameters supplied to the Update Virtual Machine operation. </param>
        /// <param name="optionalIntQuery"> The IntConstant to use. </param>
        /// <param name="optionalFloatQuery"> The FloatConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<OptionalMachineResource> Update(WaitUntil waitUntil, OptionalMachinePatch patch, IntConstant? optionalIntQuery = null, FloatConstant? optionalFloatQuery = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.Update");
            scope.Start();
            try
            {
                var response = _optionalMachineOptionalsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, optionalIntQuery, optionalFloatQuery, cancellationToken);
                var operation = new MgmtConstantsArmOperation<OptionalMachineResource>(new OptionalMachineOperationSource(Client), _optionalMachineOptionalsClientDiagnostics, Pipeline, _optionalMachineOptionalsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, optionalIntQuery, optionalFloatQuery).Request, response, OperationFinalStateVia.Location);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<OptionalMachineResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _optionalMachineOptionalsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new OptionalMachineResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new OptionalMachinePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<OptionalMachineResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _optionalMachineOptionalsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                    return Response.FromValue(new OptionalMachineResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new OptionalMachinePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<OptionalMachineResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _optionalMachineOptionalsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new OptionalMachineResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new OptionalMachinePatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<OptionalMachineResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _optionalMachineOptionalsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                    return Response.FromValue(new OptionalMachineResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new OptionalMachinePatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<OptionalMachineResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _optionalMachineOptionalsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new OptionalMachineResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new OptionalMachinePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Constant/optionalMachines/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Optionals_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<OptionalMachineResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _optionalMachineOptionalsClientDiagnostics.CreateScope("OptionalMachineResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _optionalMachineOptionalsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                    return Response.FromValue(new OptionalMachineResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new OptionalMachinePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
