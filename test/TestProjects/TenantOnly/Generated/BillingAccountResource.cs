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

namespace TenantOnly
{
    /// <summary> A Class representing a BillingAccountResource along with the instance operations that can be performed on it. </summary>
    public partial class BillingAccountResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BillingAccountResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string billingAccountName)
        {
            var resourceId = $"/providers/Microsoft.Billing/billingAccounts/{billingAccountName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _billingAccountResourceBillingAccountsClientDiagnostics;
        private readonly BillingAccountsRestOperations _billingAccountResourceBillingAccountsRestClient;
        private readonly BillingAccountResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="BillingAccountResource"/> class for mocking. </summary>
        protected BillingAccountResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BillingAccountResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BillingAccountResource(ArmClient client, BillingAccountResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="BillingAccountResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BillingAccountResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _billingAccountResourceBillingAccountsClientDiagnostics = new ClientDiagnostics("TenantOnly", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string billingAccountResourceBillingAccountsApiVersion);
            _billingAccountResourceBillingAccountsRestClient = new BillingAccountsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, billingAccountResourceBillingAccountsApiVersion);
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
        public virtual BillingAccountResourceData Data
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

        /// <summary> Gets a collection of AgreementResources in the AgreementResource. </summary>
        /// <returns> An object representing collection of AgreementResources and their operations over a AgreementResource. </returns>
        public virtual AgreementCollection GetAgreementResources()
        {
            return GetCachedClient(Client => new AgreementCollection(Client, Id));
        }

        /// <summary>
        /// Gets an agreement by ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// Operation Id: Agreements_Get
        /// </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agreementName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual async Task<Response<AgreementResource>> GetAgreementResourceAsync(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetAgreementResources().GetAsync(agreementName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an agreement by ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// Operation Id: Agreements_Get
        /// </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agreementName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual Response<AgreementResource> GetAgreementResource(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetAgreementResources().Get(agreementName, expand, cancellationToken);
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BillingAccountResource>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.Get");
            scope.Start();
            try
            {
                var response = await _billingAccountResourceBillingAccountsRestClient.GetAsync(Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BillingAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BillingAccountResource> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.Get");
            scope.Start();
            try
            {
                var response = _billingAccountResourceBillingAccountsRestClient.Get(Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BillingAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<BillingAccountResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _billingAccountResourceBillingAccountsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BillingAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<BillingAccountResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _billingAccountResourceBillingAccountsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new BillingAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<BillingAccountResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _billingAccountResourceBillingAccountsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BillingAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<BillingAccountResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _billingAccountResourceBillingAccountsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new BillingAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<BillingAccountResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await TagResource.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _billingAccountResourceBillingAccountsRestClient.GetAsync(Id.Name, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BillingAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<BillingAccountResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _billingAccountResourceBillingAccountsClientDiagnostics.CreateScope("BillingAccountResource.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                TagResource.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _billingAccountResourceBillingAccountsRestClient.Get(Id.Name, null, cancellationToken);
                return Response.FromValue(new BillingAccountResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
