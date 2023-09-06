// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelWithConverterUsage.Models
{
    /// <summary> The product documentation. </summary>
    public partial class Product
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Product"/>. </summary>
        public Product()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Product"/>. </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Product(string constProperty, Dictionary<string, BinaryData> rawData)
        {
            ConstProperty = constProperty;
            _rawData = rawData;
        }

        /// <summary> Constant string. </summary>
        public string ConstProperty { get; set; }
    }
}
