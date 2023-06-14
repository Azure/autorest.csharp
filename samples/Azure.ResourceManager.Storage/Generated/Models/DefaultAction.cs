// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies the default action of allow or deny when no other rules match. </summary>
    public enum DefaultAction
    {
        /// <summary> Allow. </summary>
        Allow,
        /// <summary> Deny. </summary>
        Deny
    }
}
