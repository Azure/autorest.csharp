// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace validation.Models
{
    /// <summary> The product documentation. </summary>
    public partial class ChildProduct
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ChildProduct"/>. </summary>
        public ChildProduct()
        {
            ConstProperty = ChildProductConstProperty.Constant;
        }

        /// <summary> Initializes a new instance of <see cref="ChildProduct"/>. </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="count"> Count. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ChildProduct(ChildProductConstProperty constProperty, int? count, Dictionary<string, BinaryData> rawData)
        {
            ConstProperty = constProperty;
            Count = count;
            _rawData = rawData;
        }

        /// <summary> Constant string. </summary>
        public ChildProductConstProperty ConstProperty { get; }
        /// <summary> Count. </summary>
        public int? Count { get; set; }
    }
}
