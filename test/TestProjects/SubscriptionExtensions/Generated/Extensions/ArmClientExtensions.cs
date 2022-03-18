// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace SubscriptionExtensions
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region Toaster
        /// <summary> Gets an object representing a Toaster along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Toaster" /> object. </returns>
        public static Toaster GetToaster(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                Toaster.ValidateResourceId(id);
                return new Toaster(client, id);
            }
            );
        }
        #endregion

        #region Oven
        /// <summary> Gets an object representing a Oven along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Oven" /> object. </returns>
        public static Oven GetOven(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                Oven.ValidateResourceId(id);
                return new Oven(client, id);
            }
            );
        }
        #endregion
    }
}
