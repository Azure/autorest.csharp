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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace TenantOnly
{
    /// <summary> A class representing collection of BillingAccount and their operations over its parent. </summary>
    public partial class BillingAccountCollection : ArmCollection, IEnumerable<BillingAccount>, IAsyncEnumerable<BillingAccount>
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
            _billingAccountClientDiagnostics = new ClientDiagnostics("TenantOnly", BillingAccount.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(BillingAccount.ResourceType, out string billingAccountApiVersion);
            _billingAccountRestClient = new BillingAccountsRestOperations(_billingAccountClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, billingAccountApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Tenant.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Tenant.ResourceType), nameof(id));
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Create
        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<BillingAccount>> CreateOrUpdateAsync(bool waitForCompletion, string billingAccountName, BillingAccountData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _billingAccountRestClient.CreateAsync(billingAccountName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TenantOnlyArmOperation<BillingAccount>(new BillingAccountSource(Client), _billingAccountClientDiagnostics, Pipeline, _billingAccountRestClient.CreateCreateRequest(billingAccountName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Create
        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<BillingAccount> CreateOrUpdate(bool waitForCompletion, string billingAccountName, BillingAccountData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _billingAccountRestClient.Create(billingAccountName, parameters, cancellationToken);
                var operation = new TenantOnlyArmOperation<BillingAccount>(new BillingAccountSource(Client), _billingAccountClientDiagnostics, Pipeline, _billingAccountRestClient.CreateCreateRequest(billingAccountName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public async virtual Task<Response<BillingAccount>> GetAsync(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.Get");
            scope.Start();
            try
            {
                var response = await _billingAccountRestClient.GetAsync(billingAccountName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _billingAccountClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new BillingAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Get
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual Response<BillingAccount> Get(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.Get");
            scope.Start();
            try
            {
                var response = _billingAccountRestClient.Get(billingAccountName, expand, cancellationToken);
                if (response.Value == null)
                    throw _billingAccountClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BillingAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts
        /// ContextualPath: /
        /// OperationId: BillingAccounts_List
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BillingAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BillingAccount> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<BillingAccount>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _billingAccountRestClient.ListAsync(expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BillingAccount(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts
        /// ContextualPath: /
        /// OperationId: BillingAccounts_List
        /// <summary> Gets a billing account by its ID. </summary>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BillingAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BillingAccount> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<BillingAccount> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _billingAccountRestClient.List(expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BillingAccount(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
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

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
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

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public async virtual Task<Response<BillingAccount>> GetIfExistsAsync(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _billingAccountRestClient.GetAsync(billingAccountName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<BillingAccount>(null, response.GetRawResponse());
                return Response.FromValue(new BillingAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// ContextualPath: /
        /// OperationId: BillingAccounts_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public virtual Response<BillingAccount> GetIfExists(string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));

            using var scope = _billingAccountClientDiagnostics.CreateScope("BillingAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _billingAccountRestClient.Get(billingAccountName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<BillingAccount>(null, response.GetRawResponse());
                return Response.FromValue(new BillingAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BillingAccount> IEnumerable<BillingAccount>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<BillingAccount> IAsyncEnumerable<BillingAccount>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
