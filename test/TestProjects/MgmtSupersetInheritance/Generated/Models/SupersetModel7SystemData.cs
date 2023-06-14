// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtSupersetInheritance.Models
{
    /// <summary> Metadata pertaining to creation and last modification of the resource. </summary>
    public partial class SupersetModel7SystemData
    {
        /// <summary> Initializes a new instance of SupersetModel7SystemData. </summary>
        internal SupersetModel7SystemData()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel7SystemData. </summary>
        /// <param name="createdBy"> The identity that created the resource. </param>
        /// <param name="createdOn"> The timestamp of resource creation (UTC). </param>
        /// <param name="lastModifiedBy"> The identity that last modified the resource. </param>
        internal SupersetModel7SystemData(string createdBy, DateTimeOffset? createdOn, string lastModifiedBy)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            LastModifiedBy = lastModifiedBy;
        }

        /// <summary> The identity that created the resource. </summary>
        public string CreatedBy { get; }
        /// <summary> The timestamp of resource creation (UTC). </summary>
        public DateTimeOffset? CreatedOn { get; }
        /// <summary> The identity that last modified the resource. </summary>
        public string LastModifiedBy { get; }
    }
}
