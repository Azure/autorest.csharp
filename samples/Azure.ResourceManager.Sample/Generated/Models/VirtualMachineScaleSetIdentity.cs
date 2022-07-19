// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Identity for the virtual machine scale set.
    /// Serialized Name: VirtualMachineScaleSetIdentity
    /// </summary>
    public partial class VirtualMachineScaleSetIdentity
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetIdentity. </summary>
        public VirtualMachineScaleSetIdentity()
        {
            UserAssignedIdentities = new ChangeTrackingDictionary<string, UserAssignedIdentity>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetIdentity. </summary>
        /// <param name="principalId">
        /// The principal id of virtual machine scale set identity. This property will only be provided for a system assigned identity.
        /// Serialized Name: VirtualMachineScaleSetIdentity.principalId
        /// </param>
        /// <param name="tenantId">
        /// The tenant id associated with the virtual machine scale set. This property will only be provided for a system assigned identity.
        /// Serialized Name: VirtualMachineScaleSetIdentity.tenantId
        /// </param>
        /// <param name="resourceIdentityType">
        /// The type of identity used for the virtual machine scale set. The type &apos;SystemAssigned, UserAssigned&apos; includes both an implicitly created identity and a set of user assigned identities. The type &apos;None&apos; will remove any identities from the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetIdentity.type
        /// </param>
        /// <param name="userAssignedIdentities">
        /// The list of user identities associated with the virtual machine scale set. The user identity dictionary key references will be ARM resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}&apos;.
        /// Serialized Name: VirtualMachineScaleSetIdentity.userAssignedIdentities
        /// </param>
        internal VirtualMachineScaleSetIdentity(string principalId, Guid? tenantId, ResourceIdentityType? resourceIdentityType, IDictionary<string, UserAssignedIdentity> userAssignedIdentities)
        {
            PrincipalId = principalId;
            TenantId = tenantId;
            ResourceIdentityType = resourceIdentityType;
            UserAssignedIdentities = userAssignedIdentities;
        }

        /// <summary>
        /// The principal id of virtual machine scale set identity. This property will only be provided for a system assigned identity.
        /// Serialized Name: VirtualMachineScaleSetIdentity.principalId
        /// </summary>
        public string PrincipalId { get; }
        /// <summary>
        /// The tenant id associated with the virtual machine scale set. This property will only be provided for a system assigned identity.
        /// Serialized Name: VirtualMachineScaleSetIdentity.tenantId
        /// </summary>
        public Guid? TenantId { get; }
        /// <summary>
        /// The type of identity used for the virtual machine scale set. The type &apos;SystemAssigned, UserAssigned&apos; includes both an implicitly created identity and a set of user assigned identities. The type &apos;None&apos; will remove any identities from the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetIdentity.type
        /// </summary>
        public ResourceIdentityType? ResourceIdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the virtual machine scale set. The user identity dictionary key references will be ARM resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}&apos;.
        /// Serialized Name: VirtualMachineScaleSetIdentity.userAssignedIdentities
        /// </summary>
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}
