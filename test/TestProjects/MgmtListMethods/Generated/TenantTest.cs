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
    /// <summary> A Class representing a TenantTest along with the instance operations that can be performed on it. </summary>
    public partial class TenantTest : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="TenantTest"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string tenantTestName)
        {
            var resourceId = $"/providers/Microsoft.Tenant/tenantTests/{tenantTestName}";
            return new ResourceIdentifier(resourceId);
        }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TenantTestsRestOperations _tenantTestsRestClient;
        private readonly TenantTestData _data;

        /// <summary> Initializes a new instance of the <see cref="TenantTest"/> class for mocking. </summary>
        protected TenantTest()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TenantTest"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal TenantTest(ArmResource options, TenantTestData data) : base(options, data.Id)
        {
            HasData = true;
            _data = data;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(ResourceType, out string apiVersion);
            _tenantTestsRestClient = new TenantTestsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="TenantTest"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TenantTest(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(ResourceType, out string apiVersion);
            _tenantTestsRestClient = new TenantTestsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="TenantTest"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TenantTest(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(ResourceType, out string apiVersion);
            _tenantTestsRestClient = new TenantTestsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Tenant/tenantTests";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual TenantTestData Data
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

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantTests_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<TenantTest>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTest.Get");
            scope.Start();
            try
            {
                var response = await _tenantTestsRestClient.GetAsync(Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TenantTest(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// ContextualPath: /providers/Microsoft.Tenant/tenantTests/{tenantTestName}
        /// OperationId: TenantTests_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TenantTest> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTest.Get");
            scope.Start();
            try
            {
                var response = _tenantTestsRestClient.Get(Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantTest(this, response.Value), response.GetRawResponse());
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
            using var scope = _clientDiagnostics.CreateScope("TenantTest.GetAvailableLocations");
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
            using var scope = _clientDiagnostics.CreateScope("TenantTest.GetAvailableLocations");
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

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public async virtual Task<Response<TenantTest>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTest.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _tenantTestsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TenantTest(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<TenantTest> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTest.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _tenantTestsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new TenantTest(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public async virtual Task<Response<TenantTest>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTest.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _tenantTestsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TenantTest(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public virtual Response<TenantTest> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTest.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _tenantTestsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new TenantTest(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public async virtual Task<Response<TenantTest>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTest.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _tenantTestsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TenantTest(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public virtual Response<TenantTest> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTest.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _tenantTestsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new TenantTest(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #region TenantParentWithNonResChWithLoc

        /// <summary> Gets a collection of TenantParentWithNonResChWithLocs in the TenantTest. </summary>
        /// <returns> An object representing collection of TenantParentWithNonResChWithLocs and their operations over a TenantTest. </returns>
        public virtual TenantParentWithNonResChWithLocCollection GetTenantParentWithNonResChWithLocs()
        {
            return new TenantParentWithNonResChWithLocCollection(this);
        }
        #endregion

        #region TenantParentWithNonResCh

        /// <summary> Gets a collection of TenantParentWithNonResChes in the TenantTest. </summary>
        /// <returns> An object representing collection of TenantParentWithNonResChes and their operations over a TenantTest. </returns>
        public virtual TenantParentWithNonResChCollection GetTenantParentWithNonResChes()
        {
            return new TenantParentWithNonResChCollection(this);
        }
        #endregion

        #region TenantParentWithLoc

        /// <summary> Gets a collection of TenantParentWithLocs in the TenantTest. </summary>
        /// <returns> An object representing collection of TenantParentWithLocs and their operations over a TenantTest. </returns>
        public virtual TenantParentWithLocCollection GetTenantParentWithLocs()
        {
            return new TenantParentWithLocCollection(this);
        }
        #endregion

        #region TenantParent

        /// <summary> Gets a collection of TenantParents in the TenantTest. </summary>
        /// <returns> An object representing collection of TenantParents and their operations over a TenantTest. </returns>
        public virtual TenantParentCollection GetTenantParents()
        {
            return new TenantParentCollection(this);
        }
        #endregion
    }
}
