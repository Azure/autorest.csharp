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
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A Class representing a SubParentWithNonResChWithLoc along with the instance operations that can be performed on it. </summary>
    public partial class SubParentWithNonResChWithLoc : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SubParentWithNonResChWithLoc"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string subParentWithNonResChWithLocName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _subParentWithNonResChWithLocClientDiagnostics;
        private readonly SubParentWithNonResChWithLocsRestOperations _subParentWithNonResChWithLocRestClient;
        private readonly SubParentWithNonResChWithLocData _data;

        /// <summary> Initializes a new instance of the <see cref="SubParentWithNonResChWithLoc"/> class for mocking. </summary>
        protected SubParentWithNonResChWithLoc()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SubParentWithNonResChWithLoc"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SubParentWithNonResChWithLoc(ArmClient client, SubParentWithNonResChWithLocData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SubParentWithNonResChWithLoc"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubParentWithNonResChWithLoc(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subParentWithNonResChWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string subParentWithNonResChWithLocApiVersion);
            _subParentWithNonResChWithLocRestClient = new SubParentWithNonResChWithLocsRestOperations(_subParentWithNonResChWithLocClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subParentWithNonResChWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.MgmtListMethods/subParentWithNonResChWithLocs";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SubParentWithNonResChWithLocData Data
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SubParentWithNonResChWithLoc>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.Get");
            scope.Start();
            try
            {
                var response = await _subParentWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _subParentWithNonResChWithLocClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SubParentWithNonResChWithLoc> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.Get");
            scope.Start();
            try
            {
                var response = _subParentWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _subParentWithNonResChWithLocClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}/nonResourceChild
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_ListNonResourceChild
        /// <summary> Lists all. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NonResourceChild> GetNonResourceChildAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NonResourceChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.GetNonResourceChild");
                scope.Start();
                try
                {
                    var response = await _subParentWithNonResChWithLocRestClient.ListNonResourceChildAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}/nonResourceChild
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_ListNonResourceChild
        /// <summary> Lists all. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NonResourceChild> GetNonResourceChild(CancellationToken cancellationToken = default)
        {
            Page<NonResourceChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.GetNonResourceChild");
                scope.Start();
                try
                {
                    var response = _subParentWithNonResChWithLocRestClient.ListNonResourceChild(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public async virtual Task<Response<SubParentWithNonResChWithLoc>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _subParentWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<SubParentWithNonResChWithLoc> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _subParentWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.Name, cancellationToken);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public async virtual Task<Response<SubParentWithNonResChWithLoc>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(true, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _subParentWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<SubParentWithNonResChWithLoc> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(true, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _subParentWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.Name, cancellationToken);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async virtual Task<Response<SubParentWithNonResChWithLoc>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _subParentWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/subParentWithNonResChWithLocs/{subParentWithNonResChWithLocName}
        /// OperationId: SubParentWithNonResChWithLocs_Get
        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<SubParentWithNonResChWithLoc> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _subParentWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.Name, cancellationToken);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Client, originalResponse.Value), originalResponse.GetRawResponse());
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
            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.GetAvailableLocations");
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
            using var scope = _subParentWithNonResChWithLocClientDiagnostics.CreateScope("SubParentWithNonResChWithLoc.GetAvailableLocations");
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
