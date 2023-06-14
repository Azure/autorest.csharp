// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    /// <summary>
    /// A class representing the Zone data model.
    /// Describes a DNS zone.
    /// </summary>
    public partial class ZoneData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ZoneData. </summary>
        /// <param name="location"> The location. </param>
        public ZoneData(AzureLocation location) : base(location)
        {
            NameServers = new ChangeTrackingList<string>();
            RegistrationVirtualNetworks = new ChangeTrackingList<WritableSubResource>();
            ResolutionVirtualNetworks = new ChangeTrackingList<WritableSubResource>();
        }

        /// <summary> Initializes a new instance of ZoneData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> The etag of the zone. </param>
        /// <param name="maxNumberOfRecordSets"> The maximum number of record sets that can be created in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="maxNumberOfRecordsPerRecordSet"> The maximum number of records per record set that can be created in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="numberOfRecordSets"> The current number of record sets in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="nameServers"> The name servers for this DNS zone. This is a read-only property and any attempt to set this value will be ignored. </param>
        /// <param name="zoneType"> The type of this DNS zone (Public or Private). </param>
        /// <param name="machineType"></param>
        /// <param name="storageType"></param>
        /// <param name="memoryType"></param>
        /// <param name="registrationVirtualNetworks"> A list of references to virtual networks that register hostnames in this DNS zone. This is a only when ZoneType is Private. </param>
        /// <param name="resolutionVirtualNetworks"> A list of references to virtual networks that resolve records in this DNS zone. This is a only when ZoneType is Private. </param>
        internal ZoneData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string etag, long? maxNumberOfRecordSets, long? maxNumberOfRecordsPerRecordSet, long? numberOfRecordSets, IReadOnlyList<string> nameServers, ZoneType? zoneType, MachineType? machineType, StorageType? storageType, MemoryType? memoryType, IList<WritableSubResource> registrationVirtualNetworks, IList<WritableSubResource> resolutionVirtualNetworks) : base(id, name, resourceType, systemData, tags, location)
        {
            Etag = etag;
            MaxNumberOfRecordSets = maxNumberOfRecordSets;
            MaxNumberOfRecordsPerRecordSet = maxNumberOfRecordsPerRecordSet;
            NumberOfRecordSets = numberOfRecordSets;
            NameServers = nameServers;
            ZoneType = zoneType;
            MachineType = machineType;
            StorageType = storageType;
            MemoryType = memoryType;
            RegistrationVirtualNetworks = registrationVirtualNetworks;
            ResolutionVirtualNetworks = resolutionVirtualNetworks;
        }

        /// <summary> The etag of the zone. </summary>
        public string Etag { get; set; }
        /// <summary> The maximum number of record sets that can be created in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </summary>
        public long? MaxNumberOfRecordSets { get; }
        /// <summary> The maximum number of records per record set that can be created in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </summary>
        public long? MaxNumberOfRecordsPerRecordSet { get; }
        /// <summary> The current number of record sets in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </summary>
        public long? NumberOfRecordSets { get; }
        /// <summary> The name servers for this DNS zone. This is a read-only property and any attempt to set this value will be ignored. </summary>
        public IReadOnlyList<string> NameServers { get; }
        /// <summary> The type of this DNS zone (Public or Private). </summary>
        public ZoneType? ZoneType { get; set; }
        /// <summary> Gets or sets the machine type. </summary>
        public MachineType? MachineType { get; set; }
        /// <summary> Gets or sets the storage type. </summary>
        public StorageType? StorageType { get; set; }
        /// <summary> Gets or sets the memory type. </summary>
        public MemoryType? MemoryType { get; set; }
        /// <summary> A list of references to virtual networks that register hostnames in this DNS zone. This is a only when ZoneType is Private. </summary>
        public IList<WritableSubResource> RegistrationVirtualNetworks { get; }
        /// <summary> A list of references to virtual networks that resolve records in this DNS zone. This is a only when ZoneType is Private. </summary>
        public IList<WritableSubResource> ResolutionVirtualNetworks { get; }
    }
}
