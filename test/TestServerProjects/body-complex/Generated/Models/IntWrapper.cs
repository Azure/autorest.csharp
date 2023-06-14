// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The IntWrapper. </summary>
    public partial class IntWrapper
    {
        /// <summary> Initializes a new instance of IntWrapper. </summary>
        public IntWrapper()
        {
        }

        /// <summary> Initializes a new instance of IntWrapper. </summary>
        /// <param name="field1"></param>
        /// <param name="field2"></param>
        internal IntWrapper(int? field1, int? field2)
        {
            Field1 = field1;
            Field2 = field2;
        }

        /// <summary> Gets or sets the field 1. </summary>
        public int? Field1 { get; set; }
        /// <summary> Gets or sets the field 2. </summary>
        public int? Field2 { get; set; }
    }
}
