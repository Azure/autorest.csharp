// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Resource Access Rule. </summary>
    public partial class ResourceAccessRule
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ResourceAccessRule
        ///
        /// </summary>
        public ResourceAccessRule()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ResourceAccessRule
        ///
        /// </summary>
        /// <param name="tenantId"> Tenant Id. </param>
        /// <param name="resourceId"> Resource Id. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ResourceAccessRule(Guid? tenantId, string resourceId, Dictionary<string, BinaryData> rawData)
        {
            TenantId = tenantId;
            ResourceId = resourceId;
            _rawData = rawData;
        }

        /// <summary> Tenant Id. </summary>
        public Guid? TenantId { get; set; }
        /// <summary> Resource Id. </summary>
        public string ResourceId { get; set; }
    }
}
