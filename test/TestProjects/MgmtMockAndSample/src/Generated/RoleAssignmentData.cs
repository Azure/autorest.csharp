// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing the RoleAssignment data model.
    /// Role Assignments
    /// </summary>
    public partial class RoleAssignmentData : ResourceData
    {
        /// <summary> Initializes a new instance of RoleAssignmentData. </summary>
        internal RoleAssignmentData()
        {
        }

        /// <summary> Initializes a new instance of RoleAssignmentData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="scope"> The role assignment scope. </param>
        /// <param name="roleDefinitionId"> The role definition ID. </param>
        /// <param name="principalId"> The principal ID. </param>
        /// <param name="canDelegate"> The Delegation flag for the role assignment. </param>
        internal RoleAssignmentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string scope, string roleDefinitionId, string principalId, bool? canDelegate) : base(id, name, resourceType, systemData)
        {
            Scope = scope;
            RoleDefinitionId = roleDefinitionId;
            PrincipalId = principalId;
            CanDelegate = canDelegate;
        }

        /// <summary> The role assignment scope. </summary>
        public string Scope { get; }
        /// <summary> The role definition ID. </summary>
        public string RoleDefinitionId { get; }
        /// <summary> The principal ID. </summary>
        public string PrincipalId { get; }
        /// <summary> The Delegation flag for the role assignment. </summary>
        public bool? CanDelegate { get; }
    }
}
