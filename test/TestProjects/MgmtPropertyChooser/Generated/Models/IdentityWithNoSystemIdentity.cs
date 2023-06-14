// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtPropertyChooser.Models
{
    /// <summary> Identity for the virtual machine. </summary>
    public partial class IdentityWithNoSystemIdentity
    {
        /// <summary> Initializes a new instance of IdentityWithNoSystemIdentity. </summary>
        public IdentityWithNoSystemIdentity()
        {
            UserAssignedIdentities = new ChangeTrackingDictionary<string, UserAssignedIdentity>();
        }

        /// <summary> Initializes a new instance of IdentityWithNoSystemIdentity. </summary>
        /// <param name="resourceIdentityType"> The type of identity used for the virtual machine. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine. </param>
        /// <param name="userAssignedIdentities"> The list of user identities associated with the Virtual Machine. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'. </param>
        internal IdentityWithNoSystemIdentity(ResourceIdentityType? resourceIdentityType, IDictionary<string, UserAssignedIdentity> userAssignedIdentities)
        {
            ResourceIdentityType = resourceIdentityType;
            UserAssignedIdentities = userAssignedIdentities;
        }

        /// <summary> The type of identity used for the virtual machine. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine. </summary>
        public ResourceIdentityType? ResourceIdentityType { get; set; }
        /// <summary> The list of user identities associated with the Virtual Machine. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'. </summary>
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}
