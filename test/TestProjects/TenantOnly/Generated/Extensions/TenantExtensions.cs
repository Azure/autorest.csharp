// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Resources;

namespace TenantOnly
{
    /// <summary> A class to add extension methods to Tenant. </summary>
    public static partial class TenantExtensions
    {
        private static TenantExtensionClient GetExtensionClient(Tenant tenant)
        {
            return tenant.GetCachedClient((client) =>
            {
                return new TenantExtensionClient(client, tenant.Id);
            }
            );
        }

        /// <summary> Gets a collection of BillingAccounts in the BillingAccount. </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of BillingAccounts and their operations over a BillingAccount. </returns>
        public static BillingAccountCollection GetBillingAccounts(this Tenant tenant)
        {
            return GetExtensionClient(tenant).GetBillingAccounts();
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public static async Task<Response<BillingAccount>> GetBillingAccountAsync(this Tenant tenant, string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await tenant.GetBillingAccounts().GetAsync(billingAccountName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountName}
        /// Operation Id: BillingAccounts_Get
        /// </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        public static Response<BillingAccount> GetBillingAccount(this Tenant tenant, string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            return tenant.GetBillingAccounts().Get(billingAccountName, expand, cancellationToken);
        }
    }
}
