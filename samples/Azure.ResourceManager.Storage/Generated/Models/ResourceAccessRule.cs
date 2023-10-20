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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ResourceAccessRule"/>. </summary>
        public ResourceAccessRule()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ResourceAccessRule"/>. </summary>
        /// <param name="tenantId"> Tenant Id. </param>
        /// <param name="resourceId"> Resource Id. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ResourceAccessRule(Guid? tenantId, string resourceId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TenantId = tenantId;
            ResourceId = resourceId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Tenant Id. </summary>
        public Guid? TenantId { get; set; }
        /// <summary> Resource Id. </summary>
        public string ResourceId { get; set; }
    }
}
