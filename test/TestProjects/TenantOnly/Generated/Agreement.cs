// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
    /// <summary> A Class representing a Agreement along with the instance operations that can be performed on it. </summary>
    public partial class Agreement : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Agreement"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string agreementName)
        {
            var resourceId = $"/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _agreementClientDiagnostics;
        private readonly AgreementsRestOperations _agreementRestClient;
        private readonly AgreementData _data;

        /// <summary> Initializes a new instance of the <see cref="Agreement"/> class for mocking. </summary>
        protected Agreement()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Agreement"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Agreement(ArmClient client, AgreementData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Agreement"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Agreement(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _agreementClientDiagnostics = new ClientDiagnostics("TenantOnly", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string agreementApiVersion);
            _agreementRestClient = new AgreementsRestOperations(_agreementClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, agreementApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts/agreements";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual AgreementData Data
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

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// OperationId: Agreements_Get
        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<Agreement>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _agreementClientDiagnostics.CreateScope("Agreement.Get");
            scope.Start();
            try
            {
                var response = await _agreementRestClient.GetAsync(Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _agreementClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Agreement(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// ContextualPath: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/agreements/{agreementName}
        /// OperationId: Agreements_Get
        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Agreement> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _agreementClientDiagnostics.CreateScope("Agreement.Get");
            scope.Start();
            try
            {
                var response = _agreementRestClient.Get(Id.Parent.Name, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw _agreementClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Agreement(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
