// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> Identity for the resource. </summary>
    public partial class Identity
    {
        /// <summary> The principal ID of resource identity. </summary>
        public string PrincipalId { get; internal set; }
        /// <summary> The tenant ID of resource. </summary>
        public string TenantId { get; internal set; }
        /// <summary> The identity type. </summary>
        public string Type { get; set; } = "SystemAssigned";
    }
}
