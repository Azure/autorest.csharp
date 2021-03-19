// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the DedicatedHostGroup data model. </summary>
    public partial class DedicatedHostGroupData : TrackedResource
    {
        /// <summary> Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone. </summary>
        public IList<string> Zones { get; }
        /// <summary> Number of fault domains that the host group can span. </summary>
        public int? PlatformFaultDomainCount { get; set; }
        /// <summary> A list of references to all dedicated hosts in the dedicated host group. </summary>
        public IReadOnlyList<SubResourceReadOnly> Hosts { get; }
        /// <summary> The dedicated host group instance view, which has the list of instance view of the dedicated hosts under the dedicated host group. </summary>
        public DedicatedHostGroupInstanceView InstanceView { get; }
        /// <summary> Specifies whether virtual machines or virtual machine scale sets can be placed automatically on the dedicated host group. Automatic placement means resources are allocated on dedicated hosts, that are chosen by Azure, under the dedicated host group. The value is defaulted to &apos;true&apos; when not provided. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01. </summary>
        public bool? SupportAutomaticPlacement { get; set; }
    }
}
