// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtOperations
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region AvailabilitySet
        /// <summary> Gets an object representing a AvailabilitySet along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySet" /> object. </returns>
        public static AvailabilitySet GetAvailabilitySet(this ArmClient armClient, ResourceIdentifier id)
        {
            AvailabilitySet.ValidateResourceId(id);
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new AvailabilitySet(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region AvailabilitySetChild
        /// <summary> Gets an object representing a AvailabilitySetChild along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetChild" /> object. </returns>
        public static AvailabilitySetChild GetAvailabilitySetChild(this ArmClient armClient, ResourceIdentifier id)
        {
            AvailabilitySetChild.ValidateResourceId(id);
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new AvailabilitySetChild(clientOptions, credential, uri, pipeline, id));
        }
        #endregion

        #region AvailabilitySetGrandChild
        /// <summary> Gets an object representing a AvailabilitySetGrandChild along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AvailabilitySetGrandChild" /> object. </returns>
        public static AvailabilitySetGrandChild GetAvailabilitySetGrandChild(this ArmClient armClient, ResourceIdentifier id)
        {
            AvailabilitySetGrandChild.ValidateResourceId(id);
            return armClient.UseClientContext((uri, credential, clientOptions, pipeline) => new AvailabilitySetGrandChild(clientOptions, credential, uri, pipeline, id));
        }
        #endregion
    }
}
