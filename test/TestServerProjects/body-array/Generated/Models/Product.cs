// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_array.Models
{
    /// <summary> The Product. </summary>
    public partial class Product
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Product"/>. </summary>
        public Product()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Product"/>. </summary>
        /// <param name="integer"></param>
        /// <param name="string"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Product(int? integer, string @string, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Integer = integer;
            String = @string;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the integer. </summary>
        public int? Integer { get; set; }
        /// <summary> Gets or sets the string. </summary>
        public string String { get; set; }
    }
}
