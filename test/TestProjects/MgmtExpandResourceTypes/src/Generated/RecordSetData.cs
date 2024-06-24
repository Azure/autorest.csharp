// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    /// <summary>
    /// A class representing the RecordSet data model.
    /// Describes a DNS record set (a collection of DNS records with the same name and type).
    /// </summary>
    public partial class RecordSetData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="RecordSetData"/>. </summary>
        public RecordSetData()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
            ARecords = new ChangeTrackingList<ARecord>();
            AaaaRecords = new ChangeTrackingList<AaaaRecord>();
            MxRecords = new ChangeTrackingList<MxRecord>();
            NsRecords = new ChangeTrackingList<NsRecord>();
            PtrRecords = new ChangeTrackingList<PtrRecord>();
            SrvRecords = new ChangeTrackingList<SrvRecord>();
            TxtRecords = new ChangeTrackingList<TxtRecord>();
            CaaRecords = new ChangeTrackingList<CaaRecord>();
        }

        /// <summary> Initializes a new instance of <see cref="RecordSetData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="aRecords"> The list of A records in the record set. </param>
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <param name="mxRecords"> The list of MX records in the record set. </param>
        /// <param name="nsRecords"> The list of NS records in the record set. </param>
        /// <param name="ptrRecords"> The list of PTR records in the record set. </param>
        /// <param name="srvRecords"> The list of SRV records in the record set. </param>
        /// <param name="txtRecords"> The list of TXT records in the record set. </param>
        /// <param name="cnameRecord"> The CNAME record in the  record set. </param>
        /// <param name="soaRecord"> The SOA record in the record set. </param>
        /// <param name="caaRecords"> The list of CAA records in the record set. </param>
        internal RecordSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string etag, IDictionary<string, string> metadata, long? ttl, string fqdn, string provisioningState, WritableSubResource targetResource, IList<ARecord> aRecords, IList<AaaaRecord> aaaaRecords, IList<MxRecord> mxRecords, IList<NsRecord> nsRecords, IList<PtrRecord> ptrRecords, IList<SrvRecord> srvRecords, IList<TxtRecord> txtRecords, CnameRecord cnameRecord, SoaRecord soaRecord, IList<CaaRecord> caaRecords) : base(id, name, resourceType, systemData)
        {
            ETag = etag;
            Metadata = metadata;
            TTL = ttl;
            Fqdn = fqdn;
            ProvisioningState = provisioningState;
            TargetResource = targetResource;
            ARecords = aRecords;
            AaaaRecords = aaaaRecords;
            MxRecords = mxRecords;
            NsRecords = nsRecords;
            PtrRecords = ptrRecords;
            SrvRecords = srvRecords;
            TxtRecords = txtRecords;
            CnameRecord = cnameRecord;
            SoaRecord = soaRecord;
            CaaRecords = caaRecords;
        }

        /// <summary> The etag of the record set. </summary>
        public string ETag { get; set; }
        /// <summary> The metadata attached to the record set. </summary>
        public IDictionary<string, string> Metadata { get; }
        /// <summary> The TTL (time-to-live) of the records in the record set. </summary>
        public long? TTL { get; set; }
        /// <summary> Fully qualified domain name of the record set. </summary>
        public string Fqdn { get; }
        /// <summary> provisioning State of the record set. </summary>
        public string ProvisioningState { get; }
        /// <summary> A reference to an azure resource from where the dns resource value is taken. </summary>
        internal WritableSubResource TargetResource { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier TargetResourceId
        {
            get => TargetResource is null ? default : TargetResource.Id;
            set
            {
                if (TargetResource is null)
                    TargetResource = new WritableSubResource();
                TargetResource.Id = value;
            }
        }

        /// <summary> The list of A records in the record set. </summary>
        public IList<ARecord> ARecords { get; }
        /// <summary> The list of AAAA records in the record set. </summary>
        public IList<AaaaRecord> AaaaRecords { get; }
        /// <summary> The list of MX records in the record set. </summary>
        public IList<MxRecord> MxRecords { get; }
        /// <summary> The list of NS records in the record set. </summary>
        public IList<NsRecord> NsRecords { get; }
        /// <summary> The list of PTR records in the record set. </summary>
        public IList<PtrRecord> PtrRecords { get; }
        /// <summary> The list of SRV records in the record set. </summary>
        public IList<SrvRecord> SrvRecords { get; }
        /// <summary> The list of TXT records in the record set. </summary>
        public IList<TxtRecord> TxtRecords { get; }
        /// <summary> The CNAME record in the  record set. </summary>
        internal CnameRecord CnameRecord { get; set; }
        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get => CnameRecord is null ? default : CnameRecord.Cname;
            set
            {
                if (CnameRecord is null)
                    CnameRecord = new CnameRecord();
                CnameRecord.Cname = value;
            }
        }

        /// <summary> The SOA record in the record set. </summary>
        public SoaRecord SoaRecord { get; set; }
        /// <summary> The list of CAA records in the record set. </summary>
        public IList<CaaRecord> CaaRecords { get; }
    }
}
