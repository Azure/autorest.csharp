// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Metadata pertaining to creation and last modification of the resource. </summary>
    public partial class SystemData
    {
        /// <summary> Initializes a new instance of SystemData. </summary>
        internal SystemData()
        {
        }

        /// <summary> Initializes a new instance of SystemData. </summary>
        /// <param name="createdBy"> The identity that created the resource. </param>
        /// <param name="createdByType"> The type of identity that created the resource. </param>
        /// <param name="createdAt"> The timestamp of resource creation (UTC). </param>
        /// <param name="lastModifiedBy"> The identity that last modified the resource. </param>
        /// <param name="lastModifiedByType"> The type of identity that last modified the resource. </param>
        /// <param name="lastModifiedAt"> The timestamp of resource last modification (UTC). </param>
        internal SystemData(string createdBy, CreatedByType? createdByType, DateTimeOffset? createdAt, string lastModifiedBy, CreatedByType? lastModifiedByType, DateTimeOffset? lastModifiedAt)
        {
            CreatedBy = createdBy;
            CreatedByType = createdByType;
            CreatedAt = createdAt;
            LastModifiedBy = lastModifiedBy;
            LastModifiedByType = lastModifiedByType;
            LastModifiedAt = lastModifiedAt;
        }

        /// <summary> The identity that created the resource. </summary>
        public string CreatedBy { get; }
        /// <summary> The type of identity that created the resource. </summary>
        public CreatedByType? CreatedByType { get; }
        /// <summary> The timestamp of resource creation (UTC). </summary>
        public DateTimeOffset? CreatedAt { get; }
        /// <summary> The identity that last modified the resource. </summary>
        public string LastModifiedBy { get; }
        /// <summary> The type of identity that last modified the resource. </summary>
        public CreatedByType? LastModifiedByType { get; }
        /// <summary> The timestamp of resource last modification (UTC). </summary>
        public DateTimeOffset? LastModifiedAt { get; }
    }
}
