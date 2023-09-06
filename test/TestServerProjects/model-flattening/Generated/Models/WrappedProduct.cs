// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace model_flattening.Models
{
    /// <summary> The wrapped produc. </summary>
    public partial class WrappedProduct
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="WrappedProduct"/>. </summary>
        public WrappedProduct()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WrappedProduct"/>. </summary>
        /// <param name="value"> the product value. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal WrappedProduct(string value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> the product value. </summary>
        public string Value { get; set; }
    }
}
