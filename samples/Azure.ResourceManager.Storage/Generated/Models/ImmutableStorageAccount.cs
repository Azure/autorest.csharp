// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> This property enables and defines account-level immutability. Enabling the feature auto-enables Blob Versioning. </summary>
    public partial class ImmutableStorageAccount
    {
        /// <summary> Initializes a new instance of ImmutableStorageAccount. </summary>
        public ImmutableStorageAccount()
        {
        }

        /// <summary> Initializes a new instance of ImmutableStorageAccount. </summary>
        /// <param name="enabled"> A boolean flag which enables account-level immutability. All the containers under such an account have object-level immutability enabled by default. </param>
        /// <param name="immutabilityPolicy"> Specifies the default account-level immutability policy which is inherited and applied to objects that do not possess an explicit immutability policy at the object level. The object-level immutability policy has higher precedence than the container-level immutability policy, which has a higher precedence than the account-level immutability policy. </param>
        internal ImmutableStorageAccount(bool? enabled, AccountImmutabilityPolicyProperties immutabilityPolicy)
        {
            Enabled = enabled;
            ImmutabilityPolicy = immutabilityPolicy;
        }

        /// <summary> A boolean flag which enables account-level immutability. All the containers under such an account have object-level immutability enabled by default. </summary>
        public bool? Enabled { get; set; }
        /// <summary> Specifies the default account-level immutability policy which is inherited and applied to objects that do not possess an explicit immutability policy at the object level. The object-level immutability policy has higher precedence than the container-level immutability policy, which has a higher precedence than the account-level immutability policy. </summary>
        public AccountImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }
    }
}
