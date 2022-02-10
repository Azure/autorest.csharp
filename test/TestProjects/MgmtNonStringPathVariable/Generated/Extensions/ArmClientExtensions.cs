// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtNonStringPathVariable
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region Fake
        /// <summary> Gets an object representing a Fake along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Fake" /> object. </returns>
        public static Fake GetFake(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetClient(() =>
            {
                Fake.ValidateResourceId(id);
                return new Fake(client, id);
            }
            );
        }
        #endregion

        #region Bar
        /// <summary> Gets an object representing a Bar along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Bar" /> object. </returns>
        public static Bar GetBar(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetClient(() =>
            {
                Bar.ValidateResourceId(id);
                return new Bar(client, id);
            }
            );
        }
        #endregion
    }
}
