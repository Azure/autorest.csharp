// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false. </summary>
    public enum Reason
    {
        /// <summary> AccountNameInvalid. </summary>
        AccountNameInvalid,
        /// <summary> AlreadyExists. </summary>
        AlreadyExists
    }
}
