// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The SubResourceWithColocationStatus.
    /// Serialized Name: SubResourceWithColocationStatus
    /// </summary>
    public partial class SubResourceWithColocationStatus : SubResource
    {
        /// <summary> Initializes a new instance of SubResourceWithColocationStatus. </summary>
        public SubResourceWithColocationStatus()
        {
        }

        /// <summary> Initializes a new instance of SubResourceWithColocationStatus. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="colocationStatus">
        /// Describes colocation status of a resource in the Proximity Placement Group.
        /// Serialized Name: SubResourceWithColocationStatus.colocationStatus
        /// </param>
        internal SubResourceWithColocationStatus(string id, InstanceViewStatus colocationStatus) : base(id)
        {
            ColocationStatus = colocationStatus;
        }

        /// <summary>
        /// Describes colocation status of a resource in the Proximity Placement Group.
        /// Serialized Name: SubResourceWithColocationStatus.colocationStatus
        /// </summary>
        public InstanceViewStatus ColocationStatus { get; set; }
    }
}
