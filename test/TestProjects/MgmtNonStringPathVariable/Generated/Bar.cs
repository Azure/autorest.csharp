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
using MgmtNonStringPathVariable.Models;

namespace MgmtNonStringPathVariable
{
    /// <summary> A Class representing a Bar along with the instance operations that can be performed on it. </summary>
    public partial class Bar : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Bar"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string barName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _barClientDiagnostics;
        private readonly BarsRestOperations _barRestClient;
        private readonly BarData _data;

        /// <summary> Initializes a new instance of the <see cref="Bar"/> class for mocking. </summary>
        protected Bar()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Bar"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Bar(ArmClient client, BarData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Bar"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Bar(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _barClientDiagnostics = new ClientDiagnostics("MgmtNonStringPathVariable", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string barApiVersion);
            _barRestClient = new BarsRestOperations(_barClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, barApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Fake/bars";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BarData Data
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
        /// Retrieves information about an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<Bar>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("Bar.Get");
            scope.Start();
            try
            {
                var response = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _barClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Bar(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Bar> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("Bar.Get");
            scope.Start();
            try
            {
                var response = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken);
                if (response.Value == null)
                    throw _barClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Bar(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("Bar.Delete");
            scope.Start();
            try
            {
                var response = await _barRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken).ConfigureAwait(false);
                var operation = new MgmtNonStringPathVariableArmOperation(_barClientDiagnostics, Pipeline, _barRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name)), response, OperationFinalStateVia.Location);
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
        /// Retrieves information about an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("Bar.Delete");
            scope.Start();
            try
            {
                var response = _barRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken);
                var operation = new MgmtNonStringPathVariableArmOperation(_barClientDiagnostics, Pipeline, _barRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name)), response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Update an Bars.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Update
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="options"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public async virtual Task<ArmOperation<Bar>> UpdateAsync(bool waitForCompletion, BarUpdateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _barClientDiagnostics.CreateScope("Bar.Update");
            scope.Start();
            try
            {
                var response = await _barRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), options, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtNonStringPathVariableArmOperation<Bar>(new BarOperationSource(Client), _barClientDiagnostics, Pipeline, _barRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), options), response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Update an Bars.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Update
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="options"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual ArmOperation<Bar> Update(bool waitForCompletion, BarUpdateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _barClientDiagnostics.CreateScope("Bar.Update");
            scope.Start();
            try
            {
                var response = _barRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), options, cancellationToken);
                var operation = new MgmtNonStringPathVariableArmOperation<Bar>(new BarOperationSource(Client), _barClientDiagnostics, Pipeline, _barRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), options), response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public async virtual Task<Response<Bar>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _barClientDiagnostics.CreateScope("Bar.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Bar(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<Bar> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _barClientDiagnostics.CreateScope("Bar.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken);
                return Response.FromValue(new Bar(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public async virtual Task<Response<Bar>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _barClientDiagnostics.CreateScope("Bar.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(true, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Bar(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<Bar> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _barClientDiagnostics.CreateScope("Bar.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(true, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken);
                return Response.FromValue(new Bar(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async virtual Task<Response<Bar>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _barClientDiagnostics.CreateScope("Bar.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Bar(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// Operation Id: Bars_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<Bar> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _barClientDiagnostics.CreateScope("Bar.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, int.Parse(Id.Name), cancellationToken);
                return Response.FromValue(new Bar(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
