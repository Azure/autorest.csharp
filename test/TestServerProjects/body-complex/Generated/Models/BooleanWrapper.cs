// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace body_complex.Models
{
    /// <summary> The BooleanWrapper. </summary>
    public partial class BooleanWrapper
    {
        /// <summary> Initializes a new instance of BooleanWrapper. </summary>
        internal BooleanWrapper()
        {
        }
        /// <summary> Initializes a new instance of BooleanWrapper. </summary>
        internal BooleanWrapper(bool? fieldTrue, bool? fieldFalse)
        {
            FieldTrue = fieldTrue;
            FieldFalse = fieldFalse;
        }
        public bool? FieldTrue { get; set; }
        public bool? FieldFalse { get; set; }
    }
}
