// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Management.Storage.Models
{
    /// <summary> This defines account-level immutability policy properties. </summary>
    public partial class AccountImmutabilityPolicyProperties
    {
        /// <summary> Initializes a new instance of AccountImmutabilityPolicyProperties. </summary>
        public AccountImmutabilityPolicyProperties()
        {
        }

        /// <summary> Initializes a new instance of AccountImmutabilityPolicyProperties. </summary>
        /// <param name="immutabilityPeriodSinceCreationInDays"> The immutability period for the blobs in the container since the policy creation, in days. </param>
        /// <param name="state"> The ImmutabilityPolicy state defines the mode of the policy. Disabled state disables the policy, Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property, Locked state only allows the increase of the immutability retention time. A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states. Only a policy in an Unlocked state can transition to a Locked state which cannot be reverted. </param>
        /// <param name="allowProtectedAppendWrites"> This property can only be changed for disabled and unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. </param>
        internal AccountImmutabilityPolicyProperties(int? immutabilityPeriodSinceCreationInDays, AccountImmutabilityPolicyState? state, bool? allowProtectedAppendWrites)
        {
            ImmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            State = state;
            AllowProtectedAppendWrites = allowProtectedAppendWrites;
        }

        /// <summary> The immutability period for the blobs in the container since the policy creation, in days. </summary>
        public int? ImmutabilityPeriodSinceCreationInDays { get; set; }
        /// <summary> The ImmutabilityPolicy state defines the mode of the policy. Disabled state disables the policy, Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property, Locked state only allows the increase of the immutability retention time. A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states. Only a policy in an Unlocked state can transition to a Locked state which cannot be reverted. </summary>
        public AccountImmutabilityPolicyState? State { get; set; }
        /// <summary> This property can only be changed for disabled and unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. </summary>
        public bool? AllowProtectedAppendWrites { get; set; }
    }
}
