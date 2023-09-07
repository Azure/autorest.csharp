// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The AccessPolicy. </summary>
    public partial class AccessPolicy
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AccessPolicy"/>. </summary>
        public AccessPolicy()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AccessPolicy"/>. </summary>
        /// <param name="startOn"> Start time of the access policy. </param>
        /// <param name="expiryOn"> Expiry time of the access policy. </param>
        /// <param name="permission"> List of abbreviated permissions. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AccessPolicy(DateTimeOffset? startOn, DateTimeOffset? expiryOn, string permission, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StartOn = startOn;
            ExpiryOn = expiryOn;
            Permission = permission;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Start time of the access policy. </summary>
        public DateTimeOffset? StartOn { get; set; }
        /// <summary> Expiry time of the access policy. </summary>
        public DateTimeOffset? ExpiryOn { get; set; }
        /// <summary> List of abbreviated permissions. </summary>
        public string Permission { get; set; }
    }
}
