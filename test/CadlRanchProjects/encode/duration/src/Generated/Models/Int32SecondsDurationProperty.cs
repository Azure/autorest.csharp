// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Encode.Duration.Models
{
    /// <summary> The Int32SecondsDurationProperty. </summary>
    public partial class Int32SecondsDurationProperty
    {
        /// <summary> Initializes a new instance of Int32SecondsDurationProperty. </summary>
        /// <param name="value"></param>
        public Int32SecondsDurationProperty(TimeSpan value)
        {
            Value = value;
        }

        /// <summary> Gets or sets the value. </summary>
        public TimeSpan Value { get; set; }
    }
}
