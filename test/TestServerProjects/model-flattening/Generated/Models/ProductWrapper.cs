// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace model_flattening.Models
{
    /// <summary> The wrapped produc. </summary>
    public partial class ProductWrapper
    {
        /// <summary> Initializes a new instance of ProductWrapper. </summary>
        internal ProductWrapper()
        {
        }

        /// <summary> Initializes a new instance of ProductWrapper. </summary>
        /// <param name="value"> the product value. </param>
        internal ProductWrapper(string value)
        {
            Value = value;
        }

        /// <summary> the product value. </summary>
        public string Value { get; }
    }
}
