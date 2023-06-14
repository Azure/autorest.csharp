// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Gets the status indicating whether the primary location of the storage account is available or unavailable. </summary>
    public enum AccountStatus
    {
        /// <summary> available. </summary>
        Available,
        /// <summary> unavailable. </summary>
        Unavailable
    }
}
