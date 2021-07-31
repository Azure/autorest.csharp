// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Identity for the resource. </summary>
    public partial class Identity
    {
        /// <summary> Initializes a new instance of Identity. </summary>
        public Identity()
        {
            UserAssignedIdentities = new ChangeTrackingDictionary<string, UserAssignedResourceIdentity>();
        }

        /// <summary> Initializes a new instance of Identity. </summary>
        /// <param name="principalId"> The principal ID of resource identity. </param>
        /// <param name="tenantId"> The tenant ID of resource. </param>
        /// <param name="type"> The identity type. </param>
        /// <param name="userAssignedIdentities"> The list of user identities associated with the resource. The user identity dictionary key references will be resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}&apos;. </param>
        internal Identity(string principalId, string tenantId, ResourceIdentityType? type, IDictionary<string, UserAssignedResourceIdentity> userAssignedIdentities)
        {
            PrincipalId = principalId;
            TenantId = tenantId;
            Type = type;
            UserAssignedIdentities = userAssignedIdentities;
        }

        /// <summary> The principal ID of resource identity. </summary>
        public string PrincipalId { get; }
        /// <summary> The tenant ID of resource. </summary>
        public string TenantId { get; }
        /// <summary> The identity type. </summary>
        public ResourceIdentityType? Type { get; set; }
        /// <summary> The list of user identities associated with the resource. The user identity dictionary key references will be resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}&apos;. </summary>
        public IDictionary<string, UserAssignedResourceIdentity> UserAssignedIdentities { get; }
    }
}
