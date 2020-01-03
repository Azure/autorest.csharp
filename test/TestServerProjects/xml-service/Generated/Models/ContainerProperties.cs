// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models.V100
{
    public partial class ContainerProperties
    {
        public DateTimeOffset LastModified { get; set; }
        public string Etag { get; set; }
        public LeaseStatusType? LeaseStatus { get; set; }
        public LeaseStateType? LeaseState { get; set; }
        public LeaseDurationType? LeaseDuration { get; set; }
        public PublicAccessType? PublicAccess { get; set; }
    }
}
