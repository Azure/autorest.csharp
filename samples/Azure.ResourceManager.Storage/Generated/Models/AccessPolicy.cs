// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The AccessPolicy. </summary>
    public partial class AccessPolicy
    {
        /// <summary> Initializes a new instance of AccessPolicy. </summary>
        public AccessPolicy()
        {
        }

        /// <summary> Initializes a new instance of AccessPolicy. </summary>
        /// <param name="startOn"> Start time of the access policy. </param>
        /// <param name="expiryOn"> Expiry time of the access policy. </param>
        /// <param name="permission"> List of abbreviated permissions. </param>
        internal AccessPolicy(DateTimeOffset? startOn, DateTimeOffset? expiryOn, string permission)
        {
            StartOn = startOn;
            ExpiryOn = expiryOn;
            Permission = permission;
        }

        /// <summary> Start time of the access policy. </summary>
        public DateTimeOffset? StartOn { get; set; }
        /// <summary> Expiry time of the access policy. </summary>
        public DateTimeOffset? ExpiryOn { get; set; }
        /// <summary> List of abbreviated permissions. </summary>
        public string Permission { get; set; }
    }
}
