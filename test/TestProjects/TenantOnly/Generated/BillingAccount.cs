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
using TenantOnly.Models;

namespace TenantOnly
{
    /// <summary> A Class representing a BillingAccount along with the instance operations that can be performed on it. </summary>
    public partial class BillingAccount : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BillingAccount"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string billingAccountName)
        {
            var resourceId = $"/providers/Microsoft.Billing/billingAccounts/{billingAccountName}";
            return new ResourceIdentifier(resourceId);
        }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly BillingAccountsRestOperations _billingAccountsRestClient;
        private readonly BillingAccountData _data;

        /// <summary> Initializes a new instance of the <see cref="BillingAccount"/> class for mocking. </summary>
        protected BillingAccount()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BillingAccount"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BillingAccount(ArmResource options, BillingAccountData data) : base(options, data.Id)
        {
            HasData = true;
            _data = data;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(ResourceType, out string apiVersion);
            _billingAccountsRestClient = new BillingAccountsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="BillingAccount"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BillingAccount(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(ResourceType, out string apiVersion);
            _billingAccountsRestClient = new BillingAccountsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="BillingAccount"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BillingAccount(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(ResourceType, out string apiVersion);
            _billingAccountsRestClient = new BillingAccountsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BillingAccountData Data
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

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// OperationId: BillingAccounts_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<BillingAccount>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BillingAccount.Get");
            scope.Start();
            try
            {
                var response = await _billingAccountsRestClient.GetAsync(Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new BillingAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// OperationId: BillingAccounts_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BillingAccount> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BillingAccount.Get");
            scope.Start();
            try
            {
                var response = _billingAccountsRestClient.Get(Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BillingAccount(this, response.Value), response.GetRawResponse());
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
            using var scope = _clientDiagnostics.CreateScope("BillingAccount.GetAvailableLocations");
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
            using var scope = _clientDiagnostics.CreateScope("BillingAccount.GetAvailableLocations");
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public async virtual Task<Response<BillingAccount>> AddTagAsync(bool waitForCompletion, string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("BillingAccount.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(waitForCompletion, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _billingAccountsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BillingAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<BillingAccount> AddTag(bool waitForCompletion, string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("BillingAccount.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(waitForCompletion, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _billingAccountsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new BillingAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public async virtual Task<Response<BillingAccount>> SetTagsAsync(bool waitForCompletion, IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _clientDiagnostics.CreateScope("BillingAccount.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(waitForCompletion, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(waitForCompletion, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _billingAccountsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BillingAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public virtual Response<BillingAccount> SetTags(bool waitForCompletion, IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _clientDiagnostics.CreateScope("BillingAccount.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(waitForCompletion, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(waitForCompletion, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _billingAccountsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new BillingAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public async virtual Task<Response<BillingAccount>> RemoveTagAsync(bool waitForCompletion, string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("BillingAccount.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(waitForCompletion, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _billingAccountsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BillingAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public virtual Response<BillingAccount> RemoveTag(bool waitForCompletion, string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("BillingAccount.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(waitForCompletion, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _billingAccountsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new BillingAccount(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #region Agreement

        /// <summary> Gets a collection of Agreements in the BillingAccount. </summary>
        /// <returns> An object representing collection of Agreements and their operations over a BillingAccount. </returns>
        public virtual AgreementCollection GetAgreements()
        {
            return new AgreementCollection(this);
        }
        #endregion
    }
}
