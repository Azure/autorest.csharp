// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Encode.Duration.Models
{
    /// <summary> The ISO8601DurationProperty. </summary>
    public partial class ISO8601DurationProperty
    {
        /// <summary> Initializes a new instance of ISO8601DurationProperty. </summary>
        /// <param name="value"></param>
        public ISO8601DurationProperty(TimeSpan value)
        {
            Value = value;
        }

        /// <summary> Gets or sets the value. </summary>
        public TimeSpan Value { get; set; }
    }
}
