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
    /// <summary> A Class representing a FakeParentWithAncestorWithNonResCh along with the instance operations that can be performed on it. </summary>
    public partial class FakeParentWithAncestorWithNonResCh : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FakeParentWithAncestorWithNonResCh"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string fakeName, string fakeParentWithAncestorWithNonResChName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _fakeParentWithAncestorWithNonResChClientDiagnostics;
        private readonly FakeParentWithAncestorWithNonResChesRestOperations _fakeParentWithAncestorWithNonResChRestClient;
        private readonly FakeParentWithAncestorWithNonResChData _data;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithNonResCh"/> class for mocking. </summary>
        protected FakeParentWithAncestorWithNonResCh()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "FakeParentWithAncestorWithNonResCh"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal FakeParentWithAncestorWithNonResCh(ArmClient client, FakeParentWithAncestorWithNonResChData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithNonResCh"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal FakeParentWithAncestorWithNonResCh(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentWithAncestorWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string fakeParentWithAncestorWithNonResChApiVersion);
            _fakeParentWithAncestorWithNonResChRestClient = new FakeParentWithAncestorWithNonResChesRestOperations(_fakeParentWithAncestorWithNonResChClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, fakeParentWithAncestorWithNonResChApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Fake/fakes/fakeParentWithAncestorWithNonResChes";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FakeParentWithAncestorWithNonResChData Data
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FakeParentWithAncestorWithNonResCh>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FakeParentWithAncestorWithNonResCh> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}/nonResourceChild
        /// Operation Id: FakeParentWithAncestorWithNonResChes_ListNonResourceChild
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NonResourceChild> GetNonResourceChildAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NonResourceChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.GetNonResourceChild");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorWithNonResChRestClient.ListNonResourceChildAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        /// <summary>
        /// Lists all.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}/nonResourceChild
        /// Operation Id: FakeParentWithAncestorWithNonResChes_ListNonResourceChild
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NonResourceChild> GetNonResourceChild(CancellationToken cancellationToken = default)
        {
            Page<NonResourceChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.GetNonResourceChild");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorWithNonResChRestClient.ListNonResourceChild(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
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

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorWithNonResCh>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _fakeParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithNonResCh> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _fakeParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorWithNonResCh>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(true, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _fakeParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithNonResCh> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(true, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _fakeParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorWithNonResCh>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _fakeParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithNonResCh> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResCh.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _fakeParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                return Response.FromValue(new FakeParentWithAncestorWithNonResCh(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
