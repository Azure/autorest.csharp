// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using TenantOnly.Mock;

namespace TenantOnly
{
    /// <summary> A class to add extension methods to TenantOnly. </summary>
    public static partial class TenantOnlyExtensions
    {
        private static TenantResourceExtensionClient GetTenantResourceExtensionClient(TenantResource tenantResource)
        {
            return tenantResource.GetCachedClient((client) =>
            {
                return new TenantResourceExtensionClient(client, tenantResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of BillingAccountResources in the TenantResource. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of BillingAccountResources and their operations over a BillingAccountResource. </returns>
        public static BillingAccountCollection GetBillingAccounts(this TenantResource tenantResource)
        {
            return GetTenantResourceExtensionClient(tenantResource).GetBillingAccounts();
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingAccounts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<BillingAccountResource>> GetBillingAccountAsync(this TenantResource tenantResource, string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await tenantResource.GetBillingAccounts().GetAsync(billingAccountName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a billing account by its ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingAccounts_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<BillingAccountResource> GetBillingAccount(this TenantResource tenantResource, string billingAccountName, string expand = null, CancellationToken cancellationToken = default)
        {
            return tenantResource.GetBillingAccounts().Get(billingAccountName, expand, cancellationToken);
        }

        #region BillingAccountResource
        /// <summary>
        /// Gets an object representing a <see cref="BillingAccountResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BillingAccountResource.CreateResourceIdentifier" /> to create a <see cref="BillingAccountResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BillingAccountResource" /> object. </returns>
        public static BillingAccountResource GetBillingAccountResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                BillingAccountResource.ValidateResourceId(id);
                return new BillingAccountResource(client, id);
            }
            );
        }
        #endregion

        #region AgreementResource
        /// <summary>
        /// Gets an object representing an <see cref="AgreementResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="AgreementResource.CreateResourceIdentifier" /> to create an <see cref="AgreementResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AgreementResource" /> object. </returns>
        public static AgreementResource GetAgreementResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                AgreementResource.ValidateResourceId(id);
                return new AgreementResource(client, id);
            }
            );
        }
        #endregion
    }
}
