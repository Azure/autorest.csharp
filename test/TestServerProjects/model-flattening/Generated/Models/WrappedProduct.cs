// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace model_flattening.Models
{
    /// <summary> The wrapped produc. </summary>
    public partial class WrappedProduct
    {
        /// <summary> Initializes a new instance of WrappedProduct. </summary>
        internal WrappedProduct()
        {
        }

        /// <summary> Initializes a new instance of WrappedProduct. </summary>
        /// <param name="value"> the product value. </param>
        internal WrappedProduct(string value)
        {
            Value = value;
        }

        /// <summary> the product value. </summary>
        public string Value { get; set; }
    }
}
