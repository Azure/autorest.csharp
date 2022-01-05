// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources;

namespace MgmtSingleton
{
    /// <summary> A class to add extension methods to Tenant. </summary>
    public static partial class TenantExtensions
    {
        #region TenantParentSingleton
        /// <summary> Gets an object representing a TenantParentSingleton along with the instance operations that can be performed on it. </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="TenantParentSingleton" /> object. </returns>
        public static TenantParentSingleton GetTenantParentSingleton(this Tenant tenant)
        {
            return new TenantParentSingleton(tenant, new ResourceIdentifier(tenant.Id + "/providers/Microsoft.Billing/TenantParentSingleton/default"));
        }
        #endregion
    }
}
