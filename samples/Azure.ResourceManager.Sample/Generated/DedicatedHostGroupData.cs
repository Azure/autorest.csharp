// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing the DedicatedHostGroup data model.
    /// Specifies information about the dedicated host group that the dedicated hosts should be assigned to. &lt;br&gt;&lt;br&gt; Currently, a dedicated host can only be added to a dedicated host group at creation time. An existing dedicated host cannot be added to another dedicated host group.
    /// Serialized Name: DedicatedHostGroup
    /// </summary>
    public partial class DedicatedHostGroupData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of DedicatedHostGroupData. </summary>
        /// <param name="location"> The location. </param>
        public DedicatedHostGroupData(AzureLocation location) : base(location)
        {
            Zones = new ChangeTrackingList<string>();
            HostUris = new ChangeTrackingList<Uri>();
            Hosts = new ChangeTrackingList<Resources.Models.SubResource>();
        }

        /// <summary> Initializes a new instance of DedicatedHostGroupData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="zones">
        /// Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone.
        /// Serialized Name: DedicatedHostGroup.zones
        /// </param>
        /// <param name="hostUris">
        /// Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone.
        /// Serialized Name: DedicatedHostGroup.hostUris
        /// </param>
        /// <param name="tenantId">
        /// The tenant id of the dedicated host.
        /// Serialized Name: DedicatedHostGroup.tenantId
        /// </param>
        /// <param name="platformFaultDomainCount">
        /// Number of fault domains that the host group can span.
        /// Serialized Name: DedicatedHostGroup.properties.platformFaultDomainCount
        /// </param>
        /// <param name="hosts">
        /// A list of references to all dedicated hosts in the dedicated host group.
        /// Serialized Name: DedicatedHostGroup.properties.hosts
        /// </param>
        /// <param name="instanceView">
        /// The dedicated host group instance view, which has the list of instance view of the dedicated hosts under the dedicated host group.
        /// Serialized Name: DedicatedHostGroup.properties.instanceView
        /// </param>
        /// <param name="supportAutomaticPlacement">
        /// Specifies whether virtual machines or virtual machine scale sets can be placed automatically on the dedicated host group. Automatic placement means resources are allocated on dedicated hosts, that are chosen by Azure, under the dedicated host group. The value is defaulted to 'true' when not provided. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: DedicatedHostGroup.properties.supportAutomaticPlacement
        /// </param>
        internal DedicatedHostGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IList<string> zones, IList<Uri> hostUris, Guid? tenantId, int? platformFaultDomainCount, IReadOnlyList<Resources.Models.SubResource> hosts, DedicatedHostGroupInstanceView instanceView, bool? supportAutomaticPlacement) : base(id, name, resourceType, systemData, tags, location)
        {
            Zones = zones;
            HostUris = hostUris;
            TenantId = tenantId;
            PlatformFaultDomainCount = platformFaultDomainCount;
            Hosts = hosts;
            InstanceView = instanceView;
            SupportAutomaticPlacement = supportAutomaticPlacement;
        }

        /// <summary>
        /// Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone.
        /// Serialized Name: DedicatedHostGroup.zones
        /// </summary>
        public IList<string> Zones { get; }
        /// <summary>
        /// Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone.
        /// Serialized Name: DedicatedHostGroup.hostUris
        /// </summary>
        public IList<Uri> HostUris { get; }
        /// <summary>
        /// The tenant id of the dedicated host.
        /// Serialized Name: DedicatedHostGroup.tenantId
        /// </summary>
        public Guid? TenantId { get; }
        /// <summary>
        /// Number of fault domains that the host group can span.
        /// Serialized Name: DedicatedHostGroup.properties.platformFaultDomainCount
        /// </summary>
        public int? PlatformFaultDomainCount { get; set; }
        /// <summary>
        /// A list of references to all dedicated hosts in the dedicated host group.
        /// Serialized Name: DedicatedHostGroup.properties.hosts
        /// </summary>
        public IReadOnlyList<Resources.Models.SubResource> Hosts { get; }
        /// <summary>
        /// The dedicated host group instance view, which has the list of instance view of the dedicated hosts under the dedicated host group.
        /// Serialized Name: DedicatedHostGroup.properties.instanceView
        /// </summary>
        internal DedicatedHostGroupInstanceView InstanceView { get; }
        /// <summary>
        /// List of instance view of the dedicated hosts under the dedicated host group.
        /// Serialized Name: DedicatedHostGroupInstanceView.hosts
        /// </summary>
        public IReadOnlyList<DedicatedHostInstanceViewWithName> InstanceViewHosts
        {
            get => InstanceView?.Hosts;
        }

        /// <summary>
        /// Specifies whether virtual machines or virtual machine scale sets can be placed automatically on the dedicated host group. Automatic placement means resources are allocated on dedicated hosts, that are chosen by Azure, under the dedicated host group. The value is defaulted to 'true' when not provided. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: DedicatedHostGroup.properties.supportAutomaticPlacement
        /// </summary>
        public bool? SupportAutomaticPlacement { get; set; }
    }
}
