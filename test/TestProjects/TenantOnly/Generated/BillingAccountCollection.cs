// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace TenantOnly
{
    /// <summary>
    /// A class representing a collection of <see cref="BillingAccountResource" /> and their operations.
    /// Each <see cref="BillingAccountResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="BillingAccountCollection" /> instance call the GetBillingAccounts method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class BillingAccountCollection : ArmCollection, IEnumerable<BillingAccountResource>, IAsyncEnumerable<BillingAccountResource>
    {
        private readonly ClientDiagnostics _billingAccountClientDiagnostics;
        private readonly BillingAccountsRestOperations _billingAccountRestClient;

        /// <summary> Initializes a new instance of the <see cref="BillingAccountCollection"/> class for mocking. </summary>
        protected BillingAccountCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BillingAccountCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal BillingAccountCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _billingAccountClientDiagnostics = new ClientDiagnostics("TenantOnly", BillingAccountResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(BillingAccountResource.ResourceType, out string billingAccountApiVersion);
            _billingAccountRestClient = new BillingAccountsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, billingAccountApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="data"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BillingAccountResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string billingAccountName, BillingAccountData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _billingAccountRestClient.CreateAsync(billingAccountName, data, cancellationToken).ConfigureAwait(false);
                var operation = new TenantOnlyArmOperation<BillingAccountResource>(new BillingAccountOperationSource(Client), _billingAccountClientDiagnostics, Pipeline, _billingAccountRestClient.CreateCreateRequest(billingAccountName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="data"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BillingAccountResource> CreateOrUpdate(WaitUntil waitUntil, string billingAccountName, BillingAccountData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _billingAccountRestClient.Create(billingAccountName, data, cancellationToken);
                var operation = new TenantOnlyArmOperation<BillingAccountResource>(new BillingAccountOperationSource(Client), _billingAccountClientDiagnostics, Pipeline, _billingAccountRestClient.CreateCreateRequest(billingAccountName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets a billing account by its ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual async Task<Response<BillingAccountResource>> GetAsync(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.Get");
            scope.Start();
            try
            {
                var response = await _billingAccountRestClient.GetAsync(billingAccountName, expand, cancellationToken).ConfigureAwait(false);
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
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual Response<BillingAccountResource> Get(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.Get");
            scope.Start();
            try
            {
                var response = _billingAccountRestClient.Get(billingAccountName, expand, cancellationToken);
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
        /// Request Path: /providers/Microsoft.Billing/billingAccounts
        /// Operation Id: BillingAccounts_List
        /// </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BillingAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BillingAccountResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<BillingAccountResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _billingAccountRestClient.ListAsync(expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BillingAccountResource(Client, value)), null, response.GetRawResponse());
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
        /// Gets a billing account by its ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts
        /// Operation Id: BillingAccounts_List
        /// </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BillingAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BillingAccountResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<BillingAccountResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _billingAccountRestClient.List(expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BillingAccountResource(Client, value)), null, response.GetRawResponse());
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
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(billingAccountName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual Response<bool> Exists(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(billingAccountName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual async Task<Response<BillingAccountResource>> GetIfExistsAsync(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _billingAccountRestClient.GetAsync(billingAccountName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<BillingAccountResource>(null, response.GetRawResponse());
                return Response.FromValue(new BillingAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual Response<BillingAccountResource> GetIfExists(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _billingAccountRestClient.Get(billingAccountName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<BillingAccountResource>(null, response.GetRawResponse());
                return Response.FromValue(new BillingAccountResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BillingAccountResource> IEnumerable<BillingAccountResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<BillingAccountResource> IAsyncEnumerable<BillingAccountResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
