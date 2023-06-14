// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace validation.Models
{
    /// <summary> The product documentation. </summary>
    public partial class ChildProduct
    {
        /// <summary> Initializes a new instance of ChildProduct. </summary>
        public ChildProduct()
        {
            ConstProperty = ChildProductConstProperty.Constant;
        }

        /// <summary> Initializes a new instance of ChildProduct. </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="count"> Count. </param>
        internal ChildProduct(ChildProductConstProperty constProperty, int? count)
        {
            ConstProperty = constProperty;
            Count = count;
        }

        /// <summary> Constant string. </summary>
        public ChildProductConstProperty ConstProperty { get; }
        /// <summary> Count. </summary>
        public int? Count { get; set; }
    }
}
