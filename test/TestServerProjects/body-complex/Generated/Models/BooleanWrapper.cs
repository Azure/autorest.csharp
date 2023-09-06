// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The BooleanWrapper. </summary>
    public partial class BooleanWrapper
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="BooleanWrapper"/>. </summary>
        public BooleanWrapper()
        {
        }

        /// <summary> Initializes a new instance of <see cref="BooleanWrapper"/>. </summary>
        /// <param name="fieldTrue"></param>
        /// <param name="fieldFalse"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal BooleanWrapper(bool? fieldTrue, bool? fieldFalse, Dictionary<string, BinaryData> rawData)
        {
            FieldTrue = fieldTrue;
            FieldFalse = fieldFalse;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the field true. </summary>
        public bool? FieldTrue { get; set; }
        /// <summary> Gets or sets the field false. </summary>
        public bool? FieldFalse { get; set; }
    }
}
