// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace ExactMatchFlattenInheritance
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region AzureResourceFlattenModel1
        /// <summary> Gets an object representing a AzureResourceFlattenModel1 along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AzureResourceFlattenModel1" /> object. </returns>
        public static AzureResourceFlattenModel1 GetAzureResourceFlattenModel1(this ArmClient armClient, ResourceIdentifier id)
        {
            AzureResourceFlattenModel1.ValidateResourceId(id);
            return new AzureResourceFlattenModel1(armClient, id);
        }
        #endregion

        #region CustomModel2
        /// <summary> Gets an object representing a CustomModel2 along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CustomModel2" /> object. </returns>
        public static CustomModel2 GetCustomModel2(this ArmClient armClient, ResourceIdentifier id)
        {
            CustomModel2.ValidateResourceId(id);
            return new CustomModel2(armClient, id);
        }
        #endregion

        #region CustomModel3
        /// <summary> Gets an object representing a CustomModel3 along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CustomModel3" /> object. </returns>
        public static CustomModel3 GetCustomModel3(this ArmClient armClient, ResourceIdentifier id)
        {
            CustomModel3.ValidateResourceId(id);
            return new CustomModel3(armClient, id);
        }
        #endregion
    }
}
