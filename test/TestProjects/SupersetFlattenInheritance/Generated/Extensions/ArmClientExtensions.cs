// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace SupersetFlattenInheritance
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region ResourceModel1
        /// <summary> Gets an object representing a ResourceModel1 along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResourceModel1" /> object. </returns>
        public static ResourceModel1 GetResourceModel1(this ArmClient armClient, ResourceIdentifier id)
        {
            ResourceModel1.ValidateResourceId(id);
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new ResourceModel1(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region TrackedResourceModel1
        /// <summary> Gets an object representing a TrackedResourceModel1 along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TrackedResourceModel1" /> object. </returns>
        public static TrackedResourceModel1 GetTrackedResourceModel1(this ArmClient armClient, ResourceIdentifier id)
        {
            TrackedResourceModel1.ValidateResourceId(id);
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new TrackedResourceModel1(clientOptions, credential, uri, pipeline, id));
        }
        #endregion
    }
}
