// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Resources;

namespace MgmtParamOrdering
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        #region AvailabilitySet
        /// <summary> Gets an object representing a AvailabilitySetCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="AvailabilitySetCollection" /> object. </returns>
        public static AvailabilitySetCollection GetAvailabilitySets(this ResourceGroup resourceGroup)
        {
            return new AvailabilitySetCollection(resourceGroup);
        }
        #endregion

        #region DedicatedHostGroup
        /// <summary> Gets an object representing a DedicatedHostGroupCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="DedicatedHostGroupCollection" /> object. </returns>
        public static DedicatedHostGroupCollection GetDedicatedHostGroups(this ResourceGroup resourceGroup)
        {
            return new DedicatedHostGroupCollection(resourceGroup);
        }
        #endregion

        #region Workspace
        /// <summary> Gets an object representing a WorkspaceCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="WorkspaceCollection" /> object. </returns>
        public static WorkspaceCollection GetWorkspaces(this ResourceGroup resourceGroup)
        {
            return new WorkspaceCollection(resourceGroup);
        }
        #endregion
    }
}
