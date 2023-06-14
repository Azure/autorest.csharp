// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
    public enum ProvisioningState
    {
        /// <summary> Creating. </summary>
        Creating,
        /// <summary> ResolvingDNS. </summary>
        ResolvingDNS,
        /// <summary> Succeeded. </summary>
        Succeeded
    }
}
