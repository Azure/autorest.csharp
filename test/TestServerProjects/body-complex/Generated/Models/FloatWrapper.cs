// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The FloatWrapper. </summary>
    public partial class FloatWrapper
    {
        /// <summary> Initializes a new instance of FloatWrapper. </summary>
        public FloatWrapper()
        {
        }

        /// <summary> Initializes a new instance of FloatWrapper. </summary>
        /// <param name="field1"></param>
        /// <param name="field2"></param>
        internal FloatWrapper(float? field1, float? field2)
        {
            Field1 = field1;
            Field2 = field2;
        }

        /// <summary> Gets or sets the field 1. </summary>
        public float? Field1 { get; set; }
        /// <summary> Gets or sets the field 2. </summary>
        public float? Field2 { get; set; }
    }
}
