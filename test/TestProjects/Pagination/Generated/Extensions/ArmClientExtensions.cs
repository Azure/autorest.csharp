// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Pagination
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region PageSizeIntegerModel
        /// <summary> Gets an object representing a PageSizeIntegerModel along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeIntegerModel" /> object. </returns>
        public static PageSizeIntegerModel GetPageSizeIntegerModel(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeIntegerModel.ValidateResourceId(id);
            return new PageSizeIntegerModel(armClient, id);
        }
        #endregion

        #region PageSizeInt64Model
        /// <summary> Gets an object representing a PageSizeInt64Model along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeInt64Model" /> object. </returns>
        public static PageSizeInt64Model GetPageSizeInt64Model(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeInt64Model.ValidateResourceId(id);
            return new PageSizeInt64Model(armClient, id);
        }
        #endregion

        #region PageSizeInt32Model
        /// <summary> Gets an object representing a PageSizeInt32Model along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeInt32Model" /> object. </returns>
        public static PageSizeInt32Model GetPageSizeInt32Model(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeInt32Model.ValidateResourceId(id);
            return new PageSizeInt32Model(armClient, id);
        }
        #endregion

        #region PageSizeNumericModel
        /// <summary> Gets an object representing a PageSizeNumericModel along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeNumericModel" /> object. </returns>
        public static PageSizeNumericModel GetPageSizeNumericModel(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeNumericModel.ValidateResourceId(id);
            return new PageSizeNumericModel(armClient, id);
        }
        #endregion

        #region PageSizeFloatModel
        /// <summary> Gets an object representing a PageSizeFloatModel along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeFloatModel" /> object. </returns>
        public static PageSizeFloatModel GetPageSizeFloatModel(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeFloatModel.ValidateResourceId(id);
            return new PageSizeFloatModel(armClient, id);
        }
        #endregion

        #region PageSizeDoubleModel
        /// <summary> Gets an object representing a PageSizeDoubleModel along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeDoubleModel" /> object. </returns>
        public static PageSizeDoubleModel GetPageSizeDoubleModel(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeDoubleModel.ValidateResourceId(id);
            return new PageSizeDoubleModel(armClient, id);
        }
        #endregion

        #region PageSizeDecimalModel
        /// <summary> Gets an object representing a PageSizeDecimalModel along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeDecimalModel" /> object. </returns>
        public static PageSizeDecimalModel GetPageSizeDecimalModel(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeDecimalModel.ValidateResourceId(id);
            return new PageSizeDecimalModel(armClient, id);
        }
        #endregion

        #region PageSizeStringModel
        /// <summary> Gets an object representing a PageSizeStringModel along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeStringModel" /> object. </returns>
        public static PageSizeStringModel GetPageSizeStringModel(this ArmClient armClient, ResourceIdentifier id)
        {
            PageSizeStringModel.ValidateResourceId(id);
            return new PageSizeStringModel(armClient, id);
        }
        #endregion
    }
}
