// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The DoubleWrapper. </summary>
    public partial class DoubleWrapper
    {
        /// <summary> Initializes a new instance of DoubleWrapper. </summary>
        public DoubleWrapper()
        {
        }

        /// <summary> Initializes a new instance of DoubleWrapper. </summary>
        /// <param name="field1"></param>
        /// <param name="field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose"></param>
        internal DoubleWrapper(double? field1, double? field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose)
        {
            Field1 = field1;
            Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose = field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose;
        }

        /// <summary> Gets or sets the field 1. </summary>
        public double? Field1 { get; set; }
        /// <summary> Gets or sets the field 56 zeros after the dot and negative zero before dot and this is a long field name on purpose. </summary>
        public double? Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose { get; set; }
    }
}
