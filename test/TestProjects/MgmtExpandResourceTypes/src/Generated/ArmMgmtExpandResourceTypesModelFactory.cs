// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtExpandResourceTypesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="MgmtExpandResourceTypes.RecordSetData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResourceId"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="aRecords"> The list of A records in the record set. </param>
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <param name="mxRecords"> The list of MX records in the record set. </param>
        /// <param name="nsRecords"> The list of NS records in the record set. </param>
        /// <param name="ptrRecords"> The list of PTR records in the record set. </param>
        /// <param name="srvRecords"> The list of SRV records in the record set. </param>
        /// <param name="txtRecords"> The list of TXT records in the record set. </param>
        /// <param name="cname"> The CNAME record in the  record set. </param>
        /// <param name="soaRecord"> The SOA record in the record set. </param>
        /// <param name="caaRecords"> The list of CAA records in the record set. </param>
        /// <returns> A new <see cref="MgmtExpandResourceTypes.RecordSetData"/> instance for mocking. </returns>
        public static RecordSetData RecordSetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string etag = null, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, ResourceIdentifier targetResourceId = null, IEnumerable<ARecord> aRecords = null, IEnumerable<AaaaRecord> aaaaRecords = null, IEnumerable<MxRecord> mxRecords = null, IEnumerable<NsRecord> nsRecords = null, IEnumerable<PtrRecord> ptrRecords = null, IEnumerable<SrvRecord> srvRecords = null, IEnumerable<TxtRecord> txtRecords = null, string cname = null, SoaRecord soaRecord = null, IEnumerable<CaaRecord> caaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            aRecords ??= new List<ARecord>();
            aaaaRecords ??= new List<AaaaRecord>();
            mxRecords ??= new List<MxRecord>();
            nsRecords ??= new List<NsRecord>();
            ptrRecords ??= new List<PtrRecord>();
            srvRecords ??= new List<SrvRecord>();
            txtRecords ??= new List<TxtRecord>();
            caaRecords ??= new List<CaaRecord>();

            return new RecordSetData(
                id,
                name,
                resourceType,
                systemData,
                etag,
                metadata,
                ttl,
                fqdn,
                provisioningState,
                targetResourceId != null ? ResourceManagerModelFactory.WritableSubResource(targetResourceId) : null,
                aRecords?.ToList(),
                aaaaRecords?.ToList(),
                mxRecords?.ToList(),
                nsRecords?.ToList(),
                ptrRecords?.ToList(),
                srvRecords?.ToList(),
                txtRecords?.ToList(),
                cname != null ? new CnameRecord(cname) : null,
                soaRecord,
                caaRecords?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="MgmtExpandResourceTypes.ZoneData"/>. </summary>
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
        /// <returns> A new <see cref="MgmtExpandResourceTypes.ZoneData"/> instance for mocking. </returns>
        public static ZoneData ZoneData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string etag = null, long? maxNumberOfRecordSets = null, long? maxNumberOfRecordsPerRecordSet = null, long? numberOfRecordSets = null, IEnumerable<string> nameServers = null, ZoneType? zoneType = null, MachineType? machineType = null, StorageType? storageType = null, MemoryType? memoryType = null, IEnumerable<WritableSubResource> registrationVirtualNetworks = null, IEnumerable<WritableSubResource> resolutionVirtualNetworks = null)
        {
            tags ??= new Dictionary<string, string>();
            nameServers ??= new List<string>();
            registrationVirtualNetworks ??= new List<WritableSubResource>();
            resolutionVirtualNetworks ??= new List<WritableSubResource>();

            return new ZoneData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                etag,
                maxNumberOfRecordSets,
                maxNumberOfRecordsPerRecordSet,
                numberOfRecordSets,
                nameServers?.ToList(),
                zoneType,
                machineType,
                storageType,
                memoryType,
                registrationVirtualNetworks?.ToList(),
                resolutionVirtualNetworks?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.DnsResourceReferenceResult"/>. </summary>
        /// <param name="dnsResourceReferences"> The result of dns resource reference request. A list of dns resource references for each of the azure resource in the request. </param>
        /// <returns> A new <see cref="Models.DnsResourceReferenceResult"/> instance for mocking. </returns>
        public static DnsResourceReferenceResult DnsResourceReferenceResult(IEnumerable<DnsResourceReference> dnsResourceReferences = null)
        {
            dnsResourceReferences ??= new List<DnsResourceReference>();

            return new DnsResourceReferenceResult(dnsResourceReferences?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.DnsResourceReference"/>. </summary>
        /// <param name="dnsResources"> A list of dns Records. </param>
        /// <param name="targetResourceId"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <returns> A new <see cref="Models.DnsResourceReference"/> instance for mocking. </returns>
        public static DnsResourceReference DnsResourceReference(IEnumerable<WritableSubResource> dnsResources = null, ResourceIdentifier targetResourceId = null)
        {
            dnsResources ??= new List<WritableSubResource>();

            return new DnsResourceReference(dnsResources?.ToList(), targetResourceId != null ? ResourceManagerModelFactory.WritableSubResource(targetResourceId) : null);
        }
    }
}
