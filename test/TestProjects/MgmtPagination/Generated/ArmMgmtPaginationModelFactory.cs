// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtPaginationModelFactory
    {
        /// <summary> Initializes a new instance of PageSizeIntegerModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeIntegerModelData"/> instance for mocking. </returns>
        public static PageSizeIntegerModelData PageSizeIntegerModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeIntegerModelData(id, name, resourceType);
        }

        /// <summary> Initializes a new instance of PageSizeInt64ModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeInt64ModelData"/> instance for mocking. </returns>
        public static PageSizeInt64ModelData PageSizeInt64ModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeInt64ModelData(id, name, resourceType);
        }

        /// <summary> Initializes a new instance of PageSizeInt32ModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeInt32ModelData"/> instance for mocking. </returns>
        public static PageSizeInt32ModelData PageSizeInt32ModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeInt32ModelData(id, name, resourceType);
        }

        /// <summary> Initializes a new instance of PageSizeNumericModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeNumericModelData"/> instance for mocking. </returns>
        public static PageSizeNumericModelData PageSizeNumericModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeNumericModelData(id, name, resourceType);
        }

        /// <summary> Initializes a new instance of PageSizeFloatModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeFloatModelData"/> instance for mocking. </returns>
        public static PageSizeFloatModelData PageSizeFloatModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeFloatModelData(id, name, resourceType);
        }

        /// <summary> Initializes a new instance of PageSizeDoubleModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeDoubleModelData"/> instance for mocking. </returns>
        public static PageSizeDoubleModelData PageSizeDoubleModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeDoubleModelData(id, name, resourceType);
        }

        /// <summary> Initializes a new instance of PageSizeDecimalModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeDecimalModelData"/> instance for mocking. </returns>
        public static PageSizeDecimalModelData PageSizeDecimalModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeDecimalModelData(id, name, resourceType);
        }

        /// <summary> Initializes a new instance of PageSizeStringModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <returns> A new <see cref="MgmtPagination.PageSizeStringModelData"/> instance for mocking. </returns>
        public static PageSizeStringModelData PageSizeStringModelData(string id = null, string name = null, string resourceType = null)
        {
            return new PageSizeStringModelData(id, name, resourceType);
        }
    }
}
