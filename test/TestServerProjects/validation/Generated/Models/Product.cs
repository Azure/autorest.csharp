// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace validation.Models
{
    /// <summary> The product documentation. </summary>
    public partial class Product
    {
        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="child"> The product documentation. </param>
        /// <param name="constChild"> The product documentation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="child"/> or <paramref name="constChild"/> is null. </exception>
        public Product(ChildProduct child, ConstantProduct constChild)
        {
            Argument.AssertNotNull(child, nameof(child));
            Argument.AssertNotNull(constChild, nameof(constChild));

            DisplayNames = new ChangeTrackingList<string>();
            Child = child;
            ConstChild = constChild;
            ConstInt = ProductConstInt._0;
            ConstString = ProductConstString.Constant;
        }

        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="displayNames"> Non required array of unique items from 0 to 6 elements. </param>
        /// <param name="capacity"> Non required int betwen 0 and 100 exclusive. </param>
        /// <param name="image"> Image URL representing the product. </param>
        /// <param name="child"> The product documentation. </param>
        /// <param name="constChild"> The product documentation. </param>
        /// <param name="constInt"> Constant int. </param>
        /// <param name="constString"> Constant string. </param>
        /// <param name="constStringAsEnum"> Constant string as Enum. </param>
        internal Product(IList<string> displayNames, int? capacity, string image, ChildProduct child, ConstantProduct constChild, ProductConstInt constInt, ProductConstString constString, EnumConst? constStringAsEnum)
        {
            DisplayNames = displayNames;
            Capacity = capacity;
            Image = image;
            Child = child;
            ConstChild = constChild;
            ConstInt = constInt;
            ConstString = constString;
            ConstStringAsEnum = constStringAsEnum;
        }

        /// <summary> Non required array of unique items from 0 to 6 elements. </summary>
        public IList<string> DisplayNames { get; }
        /// <summary> Non required int betwen 0 and 100 exclusive. </summary>
        public int? Capacity { get; set; }
        /// <summary> Image URL representing the product. </summary>
        public string Image { get; set; }
        /// <summary> The product documentation. </summary>
        public ChildProduct Child { get; set; }
        /// <summary> The product documentation. </summary>
        public ConstantProduct ConstChild { get; set; }
        /// <summary> Constant int. </summary>
        public ProductConstInt ConstInt { get; }
        /// <summary> Constant string. </summary>
        public ProductConstString ConstString { get; }
        /// <summary> Constant string as Enum. </summary>
        public EnumConst? ConstStringAsEnum { get; set; }
    }
}
