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

namespace TenantOnly
{
    /// <summary> A class representing collection of Agreement and their operations over its parent. </summary>
    public partial class AgreementCollection : ArmCollection, IEnumerable<Agreement>, IAsyncEnumerable<Agreement>
    {
        private readonly ClientDiagnostics _agreementClientDiagnostics;
        private readonly AgreementsRestOperations _agreementRestClient;

        /// <summary> Initializes a new instance of the <see cref="AgreementCollection"/> class for mocking. </summary>
        protected AgreementCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AgreementCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AgreementCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _agreementClientDiagnostics = new ClientDiagnostics("TenantOnly", Agreement.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(Agreement.ResourceType, out string agreementApiVersion);
            _agreementRestClient = new AgreementsRestOperations(_agreementClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, agreementApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != BillingAccount.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, BillingAccount.ResourceType), nameof(id));
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
        public virtual async Task<Response<Agreement>> GetAsync(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agreementName, nameof(agreementName));

            using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.Get");
            scope.Start();
            try
            {
                var response = await _agreementRestClient.GetAsync(Id.Name, agreementName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Agreement(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual Response<Agreement> Get(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agreementName, nameof(agreementName));

            using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.Get");
            scope.Start();
            try
            {
                var response = _agreementRestClient.Get(Id.Name, agreementName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Agreement(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an agreement by ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements
        /// Operation Id: Agreements_List
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Agreement" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Agreement> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Agreement>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _agreementRestClient.ListAsync(Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Agreement(Client, value)), null, response.GetRawResponse());
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
        /// Gets an agreement by ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements
        /// Operation Id: Agreements_List
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Agreement" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Agreement> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<Agreement> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _agreementRestClient.List(Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Agreement(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// Operation Id: Agreements_Get
        /// </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agreementName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agreementName, nameof(agreementName));

            using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(agreementName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// Operation Id: Agreements_Get
        /// </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agreementName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual Response<bool> Exists(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agreementName, nameof(agreementName));

            using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(agreementName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// Operation Id: Agreements_Get
        /// </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agreementName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual async Task<Response<Agreement>> GetIfExistsAsync(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agreementName, nameof(agreementName));

            using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _agreementRestClient.GetAsync(Id.Name, agreementName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Agreement>(null, response.GetRawResponse());
                return Response.FromValue(new Agreement(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// Operation Id: Agreements_Get
        /// </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agreementName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual Response<Agreement> GetIfExists(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agreementName, nameof(agreementName));

            using var scope = _agreementClientDiagnostics.CreateScope("AgreementCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _agreementRestClient.Get(Id.Name, agreementName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Agreement>(null, response.GetRawResponse());
                return Response.FromValue(new Agreement(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Agreement> IEnumerable<Agreement>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Agreement> IAsyncEnumerable<Agreement>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
