// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace validation.Models
{
    /// <summary> The product documentation. </summary>
    public partial class ConstantProduct
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::validation.Models.ConstantProduct
        ///
        /// </summary>
        public ConstantProduct()
        {
            ConstProperty = ConstantProductConstProperty.Constant;
            ConstProperty2 = ConstantProductConstProperty2.Constant2;
        }

        /// <summary>
        /// Initializes a new instance of global::validation.Models.ConstantProduct
        ///
        /// </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="constProperty2"> Constant string2. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ConstantProduct(ConstantProductConstProperty constProperty, ConstantProductConstProperty2 constProperty2, Dictionary<string, BinaryData> rawData)
        {
            ConstProperty = constProperty;
            ConstProperty2 = constProperty2;
            _rawData = rawData;
        }

        /// <summary> Constant string. </summary>
        public ConstantProductConstProperty ConstProperty { get; }
        /// <summary> Constant string2. </summary>
        public ConstantProductConstProperty2 ConstProperty2 { get; }
    }
}
