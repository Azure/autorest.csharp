// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Encode.Duration.Models
{
    /// <summary> The FloatSecondsDurationProperty. </summary>
    public partial class FloatSecondsDurationProperty
    {
        /// <summary> Initializes a new instance of FloatSecondsDurationProperty. </summary>
        /// <param name="value"></param>
        public FloatSecondsDurationProperty(TimeSpan value)
        {
            Value = value;
        }

        /// <summary> Gets or sets the value. </summary>
        public TimeSpan Value { get; set; }
    }
}
