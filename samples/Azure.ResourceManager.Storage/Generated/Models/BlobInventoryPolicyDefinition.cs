// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An object that defines the blob inventory rule. </summary>
    public partial class BlobInventoryPolicyDefinition
    {
        /// <summary> Initializes a new instance of BlobInventoryPolicyDefinition. </summary>
        /// <param name="format"> This is a required field, it specifies the format for the inventory files. </param>
        /// <param name="schedule"> This is a required field. This field is used to schedule an inventory formation. </param>
        /// <param name="objectType"> This is a required field. This field specifies the scope of the inventory created either at the blob or container level. </param>
        /// <param name="schemaFields"> This is a required field. This field specifies the fields and properties of the object to be included in the inventory. The Schema field value 'Name' is always required. The valid values for this field for the 'Blob' definition.objectType include 'Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, AccessTierInferred, Tags, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Snapshot, VersionId, IsCurrentVersion, Metadata, LastAccessTime'. The valid values for 'Container' definition.objectType include 'Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold'. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for Hns enabled accounts.'Tags' field is only valid for non Hns accounts. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaFields"/> is null. </exception>
        public BlobInventoryPolicyDefinition(Format format, Schedule schedule, ObjectType objectType, IEnumerable<string> schemaFields)
        {
            Argument.AssertNotNull(schemaFields, nameof(schemaFields));

            Format = format;
            Schedule = schedule;
            ObjectType = objectType;
            SchemaFields = schemaFields.ToList();
        }

        /// <summary> Initializes a new instance of BlobInventoryPolicyDefinition. </summary>
        /// <param name="filters"> An object that defines the filter set. </param>
        /// <param name="format"> This is a required field, it specifies the format for the inventory files. </param>
        /// <param name="schedule"> This is a required field. This field is used to schedule an inventory formation. </param>
        /// <param name="objectType"> This is a required field. This field specifies the scope of the inventory created either at the blob or container level. </param>
        /// <param name="schemaFields"> This is a required field. This field specifies the fields and properties of the object to be included in the inventory. The Schema field value 'Name' is always required. The valid values for this field for the 'Blob' definition.objectType include 'Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, AccessTierInferred, Tags, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Snapshot, VersionId, IsCurrentVersion, Metadata, LastAccessTime'. The valid values for 'Container' definition.objectType include 'Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold'. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for Hns enabled accounts.'Tags' field is only valid for non Hns accounts. </param>
        internal BlobInventoryPolicyDefinition(BlobInventoryPolicyFilter filters, Format format, Schedule schedule, ObjectType objectType, IList<string> schemaFields)
        {
            Filters = filters;
            Format = format;
            Schedule = schedule;
            ObjectType = objectType;
            SchemaFields = schemaFields;
        }

        /// <summary> An object that defines the filter set. </summary>
        public BlobInventoryPolicyFilter Filters { get; set; }
        /// <summary> This is a required field, it specifies the format for the inventory files. </summary>
        public Format Format { get; set; }
        /// <summary> This is a required field. This field is used to schedule an inventory formation. </summary>
        public Schedule Schedule { get; set; }
        /// <summary> This is a required field. This field specifies the scope of the inventory created either at the blob or container level. </summary>
        public ObjectType ObjectType { get; set; }
        /// <summary> This is a required field. This field specifies the fields and properties of the object to be included in the inventory. The Schema field value 'Name' is always required. The valid values for this field for the 'Blob' definition.objectType include 'Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, AccessTierInferred, Tags, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Snapshot, VersionId, IsCurrentVersion, Metadata, LastAccessTime'. The valid values for 'Container' definition.objectType include 'Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold'. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for Hns enabled accounts.'Tags' field is only valid for non Hns accounts. </summary>
        public IList<string> SchemaFields { get; }
    }
}
