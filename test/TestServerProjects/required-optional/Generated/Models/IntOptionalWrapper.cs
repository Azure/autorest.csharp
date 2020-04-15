// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace required_optional.Models
{
    /// <summary> The IntOptionalWrapper. </summary>
    public partial class IntOptionalWrapper
    {
        /// <summary> Initializes a new instance of IntOptionalWrapper. </summary>
        public IntOptionalWrapper()
        {
        }

        /// <summary> Initializes a new instance of IntOptionalWrapper. </summary>
        /// <param name="value"> . </param>
        internal IntOptionalWrapper(int? value)
        {
            Value = value;
        }

        public int? Value { get; set; }
    }
}
