// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtScopeResource
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region FakePolicyAssignment
        /// <summary> Gets an object representing a FakePolicyAssignment along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakePolicyAssignment" /> object. </returns>
        public static FakePolicyAssignment GetFakePolicyAssignment(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetClient(() =>
            {
                FakePolicyAssignment.ValidateResourceId(id);
                return new FakePolicyAssignment(client, id);
            }
            );
        }
        #endregion

        #region DeploymentExtended
        /// <summary> Gets an object representing a DeploymentExtended along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeploymentExtended" /> object. </returns>
        public static DeploymentExtended GetDeploymentExtended(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetClient(() =>
            {
                DeploymentExtended.ValidateResourceId(id);
                return new DeploymentExtended(client, id);
            }
            );
        }
        #endregion

        #region ResourceLink
        /// <summary> Gets an object representing a ResourceLink along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResourceLink" /> object. </returns>
        public static ResourceLink GetResourceLink(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetClient(() =>
            {
                ResourceLink.ValidateResourceId(id);
                return new ResourceLink(client, id);
            }
            );
        }
        #endregion
    }
}
