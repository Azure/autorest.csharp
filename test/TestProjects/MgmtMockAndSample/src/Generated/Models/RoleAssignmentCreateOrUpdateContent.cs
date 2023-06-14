// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Role assignment create parameters. </summary>
    public partial class RoleAssignmentCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of RoleAssignmentCreateOrUpdateContent. </summary>
        public RoleAssignmentCreateOrUpdateContent()
        {
        }

        /// <summary> The role definition ID used in the role assignment. </summary>
        public string RoleDefinitionId { get; set; }
        /// <summary> The principal ID assigned to the role. This maps to the ID inside the Active Directory. It can point to a user, service principal, or security group. </summary>
        public string PrincipalId { get; set; }
        /// <summary> The delegation flag used for creating a role assignment. </summary>
        public bool? CanDelegate { get; set; }
    }
}
