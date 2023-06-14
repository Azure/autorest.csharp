// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace validation.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AutoRestValidationTestModelFactory
    {
        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="displayNames"> Non required array of unique items from 0 to 6 elements. </param>
        /// <param name="capacity"> Non required int betwen 0 and 100 exclusive. </param>
        /// <param name="image"> Image URL representing the product. </param>
        /// <param name="child"> The product documentation. </param>
        /// <param name="constChild"> The product documentation. </param>
        /// <param name="constInt"> Constant int. </param>
        /// <param name="constString"> Constant string. </param>
        /// <param name="constStringAsEnum"> Constant string as Enum. </param>
        /// <returns> A new <see cref="Models.Product"/> instance for mocking. </returns>
        public static Product Product(IEnumerable<string> displayNames = null, int? capacity = null, string image = null, ChildProduct child = null, ConstantProduct constChild = null, ProductConstInt constInt = default, ProductConstString constString = default, EnumConst? constStringAsEnum = null)
        {
            displayNames ??= new List<string>();

            return new Product(displayNames?.ToList(), capacity, image, child, constChild, constInt, constString, constStringAsEnum);
        }

        /// <summary> Initializes a new instance of ChildProduct. </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="count"> Count. </param>
        /// <returns> A new <see cref="Models.ChildProduct"/> instance for mocking. </returns>
        public static ChildProduct ChildProduct(ChildProductConstProperty constProperty = default, int? count = null)
        {
            return new ChildProduct(constProperty, count);
        }

        /// <summary> Initializes a new instance of ConstantProduct. </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="constProperty2"> Constant string2. </param>
        /// <returns> A new <see cref="Models.ConstantProduct"/> instance for mocking. </returns>
        public static ConstantProduct ConstantProduct(ConstantProductConstProperty constProperty = default, ConstantProductConstProperty2 constProperty2 = default)
        {
            return new ConstantProduct(constProperty, constProperty2);
        }
    }
}
