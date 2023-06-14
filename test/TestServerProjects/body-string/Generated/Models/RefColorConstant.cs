// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_string.Models
{
    /// <summary> The RefColorConstant. </summary>
    public partial class RefColorConstant
    {
        /// <summary> Initializes a new instance of RefColorConstant. </summary>
        public RefColorConstant()
        {
            ColorConstant = ColorConstant.GreenColor;
        }

        /// <summary> Initializes a new instance of RefColorConstant. </summary>
        /// <param name="colorConstant"> Referenced Color Constant Description. </param>
        /// <param name="field1"> Sample string. </param>
        internal RefColorConstant(ColorConstant colorConstant, string field1)
        {
            ColorConstant = colorConstant;
            Field1 = field1;
        }

        /// <summary> Referenced Color Constant Description. </summary>
        public ColorConstant ColorConstant { get; }
        /// <summary> Sample string. </summary>
        public string Field1 { get; set; }
    }
}
