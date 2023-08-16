// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtPropertyChooser.Models
{
    /// <summary> Identity for the virtual machine. </summary>
    public partial class IdentityWithDifferentPropertyType
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtPropertyChooser.Models.IdentityWithDifferentPropertyType
        ///
        /// </summary>
        public IdentityWithDifferentPropertyType()
        {
            UserAssignedIdentities = new ChangeTrackingDictionary<string, UserAssignedIdentity>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtPropertyChooser.Models.IdentityWithDifferentPropertyType
        ///
        /// </summary>
        /// <param name="principalId"> The principal id of virtual machine identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="tenantId"> The tenant id associated with the virtual machine. This property will only be provided for a system assigned identity. </param>
        /// <param name="resourceIdentityType"> The type of identity used for the virtual machine. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine. </param>
        /// <param name="userAssignedIdentities"> The list of user identities associated with the Virtual Machine. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal IdentityWithDifferentPropertyType(string principalId, int? tenantId, ResourceIdentityType? resourceIdentityType, IDictionary<string, UserAssignedIdentity> userAssignedIdentities, Dictionary<string, BinaryData> rawData)
        {
            PrincipalId = principalId;
            TenantId = tenantId;
            ResourceIdentityType = resourceIdentityType;
            UserAssignedIdentities = userAssignedIdentities;
            _rawData = rawData;
        }

        /// <summary> The principal id of virtual machine identity. This property will only be provided for a system assigned identity. </summary>
        public string PrincipalId { get; }
        /// <summary> The tenant id associated with the virtual machine. This property will only be provided for a system assigned identity. </summary>
        public int? TenantId { get; }
        /// <summary> The type of identity used for the virtual machine. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine. </summary>
        public ResourceIdentityType? ResourceIdentityType { get; set; }
        /// <summary> The list of user identities associated with the Virtual Machine. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'. </summary>
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}
