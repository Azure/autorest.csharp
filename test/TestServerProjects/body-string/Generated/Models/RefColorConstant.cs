// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_string.Models
{
    /// <summary> The RefColorConstant. </summary>
    public partial class RefColorConstant
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="RefColorConstant"/>. </summary>
        public RefColorConstant()
        {
            ColorConstant = ColorConstant.GreenColor;
        }

        /// <summary> Initializes a new instance of <see cref="RefColorConstant"/>. </summary>
        /// <param name="colorConstant"> Referenced Color Constant Description. </param>
        /// <param name="field1"> Sample string. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal RefColorConstant(ColorConstant colorConstant, string field1, Dictionary<string, BinaryData> rawData)
        {
            ColorConstant = colorConstant;
            Field1 = field1;
            _rawData = rawData;
        }

        /// <summary> Referenced Color Constant Description. </summary>
        public ColorConstant ColorConstant { get; }
        /// <summary> Sample string. </summary>
        public string Field1 { get; set; }
    }
}
