// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> KeyPolicy assigned to the storage account. </summary>
    internal partial class KeyPolicy
    {
        /// <summary> Initializes a new instance of KeyPolicy. </summary>
        /// <param name="keyExpirationPeriodInDays"> The key expiration period in days. </param>
        public KeyPolicy(int keyExpirationPeriodInDays)
        {
            KeyExpirationPeriodInDays = keyExpirationPeriodInDays;
        }

        /// <summary> The key expiration period in days. </summary>
        public int KeyExpirationPeriodInDays { get; set; }
    }
}
