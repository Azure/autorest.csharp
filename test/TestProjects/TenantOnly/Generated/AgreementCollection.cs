// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace TenantOnly
{
    /// <summary> A class representing collection of Agreement and their operations over its parent. </summary>
    public partial class AgreementCollection : ArmCollection, IEnumerable<Agreement>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AgreementsRestOperations _agreementsRestClient;

        /// <summary> Initializes a new instance of the <see cref="AgreementCollection"/> class for mocking. </summary>
        protected AgreementCollection()
        {
        }

        /// <summary> Initializes a new instance of AgreementCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AgreementCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _agreementsRestClient = new AgreementsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => BillingAccount.ResourceType;

        // Collection level operations.

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// OperationId: Agreements_Get
        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual Response<Agreement> Get(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (agreementName == null)
            {
                throw new ArgumentNullException(nameof(agreementName));
            }

            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.Get");
            scope.Start();
            try
            {
                var response = _agreementsRestClient.Get(Id.Name, agreementName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Agreement(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// OperationId: Agreements_Get
        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public async virtual Task<Response<Agreement>> GetAsync(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (agreementName == null)
            {
                throw new ArgumentNullException(nameof(agreementName));
            }

            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.Get");
            scope.Start();
            try
            {
                var response = await _agreementsRestClient.GetAsync(Id.Name, agreementName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Agreement(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual Response<Agreement> GetIfExists(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (agreementName == null)
            {
                throw new ArgumentNullException(nameof(agreementName));
            }

            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _agreementsRestClient.Get(Id.Name, agreementName, expand, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Agreement>(null, response.GetRawResponse())
                    : Response.FromValue(new Agreement(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public async virtual Task<Response<Agreement>> GetIfExistsAsync(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (agreementName == null)
            {
                throw new ArgumentNullException(nameof(agreementName));
            }

            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _agreementsRestClient.GetAsync(Id.Name, agreementName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Agreement>(null, response.GetRawResponse())
                    : Response.FromValue(new Agreement(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public virtual Response<bool> Exists(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (agreementName == null)
            {
                throw new ArgumentNullException(nameof(agreementName));
            }

            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(agreementName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agreementName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string agreementName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (agreementName == null)
            {
                throw new ArgumentNullException(nameof(agreementName));
            }

            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(agreementName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// OperationId: Agreements_List
        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Agreement>> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.GetAll");
            scope.Start();
            try
            {
                var response = _agreementsRestClient.List(Id.Name, expand, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(value => new Agreement(Parent, value)).ToArray() as IReadOnlyList<Agreement>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// OperationId: Agreements_List
        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<IReadOnlyList<Agreement>>> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AgreementCollection.GetAll");
            scope.Start();
            try
            {
                var response = await _agreementsRestClient.ListAsync(Id.Name, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(value => new Agreement(Parent, value)).ToArray() as IReadOnlyList<Agreement>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Agreement> IEnumerable<Agreement>.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, Agreement, AgreementData> Construct() { }
    }
}
