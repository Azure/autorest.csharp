// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    /// <summary> Properties of a container. </summary>
    public partial class ContainerProperties
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset LastModified { get; set; }
        public string Etag { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public LeaseStatusType? LeaseStatus { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public LeaseStateType? LeaseState { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public LeaseDurationType? LeaseDuration { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public PublicAccessType? PublicAccess { get; set; }
    }
}
