// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The BooleanWrapper. </summary>
    public partial class BooleanWrapper
    {
        /// <summary> Initializes a new instance of BooleanWrapper. </summary>
        public BooleanWrapper()
        {
        }

        /// <summary> Initializes a new instance of BooleanWrapper. </summary>
        /// <param name="fieldTrue"></param>
        /// <param name="fieldFalse"></param>
        internal BooleanWrapper(bool? fieldTrue, bool? fieldFalse)
        {
            FieldTrue = fieldTrue;
            FieldFalse = fieldFalse;
        }

        /// <summary> Gets or sets the field true. </summary>
        public bool? FieldTrue { get; set; }
        /// <summary> Gets or sets the field false. </summary>
        public bool? FieldFalse { get; set; }
    }
}
