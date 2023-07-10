// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Encode.Datetime.Models
{
    /// <summary> The Rfc3339DatetimeProperty. </summary>
    public partial class Rfc3339DatetimeProperty
    {
        /// <summary> Initializes a new instance of Rfc3339DatetimeProperty. </summary>
        /// <param name="value"></param>
        public Rfc3339DatetimeProperty(DateTimeOffset value)
        {
            Value = value;
        }

        /// <summary> Gets or sets the value. </summary>
        public DateTimeOffset Value { get; set; }
    }
}
