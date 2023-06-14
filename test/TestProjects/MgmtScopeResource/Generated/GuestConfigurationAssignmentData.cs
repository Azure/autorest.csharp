// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing the GuestConfigurationAssignment data model.
    /// Guest configuration assignment is an association between a machine and guest configuration.
    /// </summary>
    public partial class GuestConfigurationAssignmentData : GuestConfigurationBaseResource
    {
        /// <summary> Initializes a new instance of GuestConfigurationAssignmentData. </summary>
        public GuestConfigurationAssignmentData()
        {
        }

        /// <summary> Initializes a new instance of GuestConfigurationAssignmentData. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="properties"> Properties of the Guest configuration assignment. </param>
        internal GuestConfigurationAssignmentData(string id, string name, string location, string resourceType, GuestConfigurationAssignmentProperties properties) : base(id, name, location, resourceType)
        {
            Properties = properties;
        }

        /// <summary> Properties of the Guest configuration assignment. </summary>
        public GuestConfigurationAssignmentProperties Properties { get; set; }
    }
}
