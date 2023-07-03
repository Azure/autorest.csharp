// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtParamOrdering.Models
{
    /// <summary> Specifies information about the dedicated host. Only tags, autoReplaceOnFailure and licenseType may be updated. </summary>
    public partial class DedicatedHostPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of DedicatedHostPatch. </summary>
        public DedicatedHostPatch()
        {
        }

        /// <summary> Fault domain of the dedicated host within a dedicated host group. </summary>
        public int? PlatformFaultDomain { get; set; }
        /// <summary> Specifies whether the dedicated host should be replaced automatically in case of a failure. The value is defaulted to 'true' when not provided. </summary>
        public bool? AutoReplaceOnFailure { get; set; }
        /// <summary> A unique id generated and assigned to the dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not change throughout the lifetime of the host. </summary>
        public string HostId { get; }
        /// <summary> The date when the host was first provisioned. </summary>
        public DateTimeOffset? ProvisioningOn { get; }
        /// <summary> The provisioning state, which only appears in the response. </summary>
        public string ProvisioningState { get; }
    }
}
