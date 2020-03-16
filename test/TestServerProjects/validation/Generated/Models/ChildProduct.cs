// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace validation.Models
{
    /// <summary> The product documentation. </summary>
    public partial class ChildProduct
    {
        /// <summary> Initializes a new instance of ChildProduct. </summary>
        internal ChildProduct()
        {
        }
        /// <summary> Initializes a new instance of ChildProduct. </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="count"> Count. </param>
        internal ChildProduct(string constProperty, int? count)
        {
            ConstProperty = constProperty;
            Count = count;
        }
        /// <summary> Constant string. </summary>
        public string ConstProperty { get; set; } = "constant";
        /// <summary> Count. </summary>
        public int? Count { get; set; }
    }
}
