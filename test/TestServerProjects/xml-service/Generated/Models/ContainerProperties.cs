// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> Properties of a container. </summary>
    public partial class ContainerProperties
    {
        /// <summary> Initializes a new instance of ContainerProperties. </summary>
        /// <param name="lastModified"></param>
        /// <param name="etag"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="etag"/> is null. </exception>
        internal ContainerProperties(DateTimeOffset lastModified, string etag)
        {
            Argument.AssertNotNull(etag, nameof(etag));

            LastModified = lastModified;
            Etag = etag;
        }

        /// <summary> Initializes a new instance of ContainerProperties. </summary>
        /// <param name="lastModified"></param>
        /// <param name="etag"></param>
        /// <param name="leaseStatus"></param>
        /// <param name="leaseState"></param>
        /// <param name="leaseDuration"></param>
        /// <param name="publicAccess"></param>
        internal ContainerProperties(DateTimeOffset lastModified, string etag, LeaseStatusType? leaseStatus, LeaseStateType? leaseState, LeaseDurationType? leaseDuration, PublicAccessType? publicAccess)
        {
            LastModified = lastModified;
            Etag = etag;
            LeaseStatus = leaseStatus;
            LeaseState = leaseState;
            LeaseDuration = leaseDuration;
            PublicAccess = publicAccess;
        }

        /// <summary> Gets the last modified. </summary>
        public DateTimeOffset LastModified { get; }
        /// <summary> Gets the etag. </summary>
        public string Etag { get; }
        /// <summary> Gets the lease status. </summary>
        public LeaseStatusType? LeaseStatus { get; }
        /// <summary> Gets the lease state. </summary>
        public LeaseStateType? LeaseState { get; }
        /// <summary> Gets the lease duration. </summary>
        public LeaseDurationType? LeaseDuration { get; }
        /// <summary> Gets the public access. </summary>
        public PublicAccessType? PublicAccess { get; }
    }
}
