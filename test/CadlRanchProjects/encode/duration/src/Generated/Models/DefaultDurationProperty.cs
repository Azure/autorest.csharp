// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Encode.Duration.Models
{
    /// <summary> The DefaultDurationProperty. </summary>
    public partial class DefaultDurationProperty
    {
        /// <summary> Initializes a new instance of DefaultDurationProperty. </summary>
        /// <param name="value"></param>
        public DefaultDurationProperty(TimeSpan value)
        {
            Value = value;
        }

        /// <summary> Gets or sets the value. </summary>
        public TimeSpan Value { get; set; }
    }
}
