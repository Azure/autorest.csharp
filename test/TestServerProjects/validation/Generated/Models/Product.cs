// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace validation.Models.V100
{
    /// <summary> The product documentation. </summary>
    public partial class Product
    {
        /// <summary> Non required array of unique items from 0 to 6 elements. </summary>
        public ICollection<string>? DisplayNames { get; set; }
        /// <summary> Non required int betwen 0 and 100 exclusive. </summary>
        public int? Capacity { get; set; }
        /// <summary> Image URL representing the product. </summary>
        public string? Image { get; set; }
        /// <summary> The product documentation. </summary>
        public ChildProduct Child { get; set; } = new ChildProduct();
        /// <summary> The product documentation. </summary>
        public ConstantProduct ConstChild { get; set; } = new ConstantProduct();
        /// <summary> Constant int. </summary>
        public float ConstInt { get; set; } = 0F;
        /// <summary> Constant string. </summary>
        public string ConstString { get; set; } = "constant";
        /// <summary> Constant string as Enum. </summary>
        public string ConstStringAsEnum { get; set; } = "constant_string_as_enum";
    }
}
