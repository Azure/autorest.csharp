// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The LongWrapper. </summary>
    public partial class LongWrapper
    {
        /// <summary> Initializes a new instance of LongWrapper. </summary>
        public LongWrapper()
        {
        }

        /// <summary> Initializes a new instance of LongWrapper. </summary>
        /// <param name="field1"></param>
        /// <param name="field2"></param>
        internal LongWrapper(long? field1, long? field2)
        {
            Field1 = field1;
            Field2 = field2;
        }

        /// <summary> Gets or sets the field 1. </summary>
        public long? Field1 { get; set; }
        /// <summary> Gets or sets the field 2. </summary>
        public long? Field2 { get; set; }
    }
}
