// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace compute.Models
{
    /// <summary> Specifies information about the dedicated host group that the dedicated hosts should be assigned to. &lt;br&gt;&lt;br&gt; Currently, a dedicated host can only be added to a dedicated host group at creation time. An existing dedicated host cannot be added to another dedicated host group. </summary>
    public partial class DedicatedHostGroup : Resource
    {
        /// <summary> Initializes a new instance of DedicatedHostGroup. </summary>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public DedicatedHostGroup(string location) : base(location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            Zones = new ChangeTrackingList<string>();
            Hosts = new ChangeTrackingList<SubResourceReadOnly>();
        }

        /// <summary> Initializes a new instance of DedicatedHostGroup. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="zones"> Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone. </param>
        /// <param name="platformFaultDomainCount"> Number of fault domains that the host group can span. </param>
        /// <param name="hosts"> A list of references to all dedicated hosts in the dedicated host group. </param>
        /// <param name="instanceView"> The dedicated host group instance view, which has the list of instance view of the dedicated hosts under the dedicated host group. </param>
        /// <param name="supportAutomaticPlacement"> Specifies whether virtual machines or virtual machine scale sets can be placed automatically on the dedicated host group. Automatic placement means resources are allocated on dedicated hosts, that are chosen by Azure, under the dedicated host group. The value is defaulted to &apos;true&apos; when not provided. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01. </param>
        internal DedicatedHostGroup(string id, string name, string type, string location, IDictionary<string, string> tags, IList<string> zones, int? platformFaultDomainCount, IReadOnlyList<SubResourceReadOnly> hosts, DedicatedHostGroupInstanceView instanceView, bool? supportAutomaticPlacement) : base(id, name, type, location, tags)
        {
            Zones = zones;
            PlatformFaultDomainCount = platformFaultDomainCount;
            Hosts = hosts;
            InstanceView = instanceView;
            SupportAutomaticPlacement = supportAutomaticPlacement;
        }

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
