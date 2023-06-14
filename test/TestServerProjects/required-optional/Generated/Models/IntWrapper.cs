// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace required_optional.Models
{
    /// <summary> The IntWrapper. </summary>
    public partial class IntWrapper
    {
        /// <summary> Initializes a new instance of IntWrapper. </summary>
        /// <param name="value"></param>
        public IntWrapper(int value)
        {
            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public int Value { get; }
    }
}
