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
using Azure.ResourceManager.ManagementGroups;

namespace MgmtListMethods
{
    /// <summary>
    /// A Class representing a MgmtGrpParentWithLoc along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MgmtGrpParentWithLocResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetMgmtGrpParentWithLocResource method.
    /// Otherwise you can get one from its parent resource <see cref="ManagementGroupResource"/> using the GetMgmtGrpParentWithLoc method.
    /// </summary>
    public partial class MgmtGrpParentWithLocResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="MgmtGrpParentWithLocResource"/> instance. </summary>
        /// <param name="groupId"> The groupId. </param>
        /// <param name="mgmtGrpParentWithLocName"> The mgmtGrpParentWithLocName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string groupId, string mgmtGrpParentWithLocName)
        {
            var resourceId = $"/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _mgmtGrpParentWithLocClientDiagnostics;
        private readonly MgmtGrpParentWithLocsRestOperations _mgmtGrpParentWithLocRestClient;
        private readonly MgmtGrpParentWithLocData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Management/managementGroups/mgmtGrpParentWithLocs";

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocResource"/> class for mocking. </summary>
        protected MgmtGrpParentWithLocResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal MgmtGrpParentWithLocResource(ArmClient client, MgmtGrpParentWithLocData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtGrpParentWithLocResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtGrpParentWithLocResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mgmtGrpParentWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string mgmtGrpParentWithLocApiVersion);
            _mgmtGrpParentWithLocRestClient = new MgmtGrpParentWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mgmtGrpParentWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual MgmtGrpParentWithLocData Data
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
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MgmtGrpParentWithLocResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.Get");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocRestClient.GetAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MgmtGrpParentWithLocResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.Get");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocRestClient.Get(Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MgmtGrpParentWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MgmtGrpParentWithLocResource>> UpdateAsync(WaitUntil waitUntil, MgmtGrpParentWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.Update");
            scope.Start();
            try
            {
                var response = await _mgmtGrpParentWithLocRestClient.CreateOrUpdateAsync(Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var uri = _mgmtGrpParentWithLocRestClient.CreateCreateOrUpdateRequestUri(Id.Parent.Name, Id.Name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), NextLinkOperationImplementation.HeaderSource.None.ToString(), null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithLocResource>(Response.FromValue(new MgmtGrpParentWithLocResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MgmtGrpParentWithLocResource> Update(WaitUntil waitUntil, MgmtGrpParentWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.Update");
            scope.Start();
            try
            {
                var response = _mgmtGrpParentWithLocRestClient.CreateOrUpdate(Id.Parent.Name, Id.Name, data, cancellationToken);
                var uri = _mgmtGrpParentWithLocRestClient.CreateCreateOrUpdateRequestUri(Id.Parent.Name, Id.Name, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), NextLinkOperationImplementation.HeaderSource.None.ToString(), null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MgmtListMethodsArmOperation<MgmtGrpParentWithLocResource>(Response.FromValue(new MgmtGrpParentWithLocResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<MgmtGrpParentWithLocResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _mgmtGrpParentWithLocRestClient.GetAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new MgmtGrpParentWithLocResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags[key] = value;
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithLocResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _mgmtGrpParentWithLocRestClient.Get(Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new MgmtGrpParentWithLocResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags[key] = value;
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<MgmtGrpParentWithLocResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _mgmtGrpParentWithLocRestClient.GetAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new MgmtGrpParentWithLocResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithLocResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _mgmtGrpParentWithLocRestClient.Get(Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new MgmtGrpParentWithLocResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<MgmtGrpParentWithLocResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _mgmtGrpParentWithLocRestClient.GetAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new MgmtGrpParentWithLocResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.Remove(key);
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MgmtGrpParentWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<MgmtGrpParentWithLocResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _mgmtGrpParentWithLocClientDiagnostics.CreateScope("MgmtGrpParentWithLocResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _mgmtGrpParentWithLocRestClient.Get(Id.Parent.Name, Id.Name, cancellationToken);
                    return Response.FromValue(new MgmtGrpParentWithLocResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.Remove(key);
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
