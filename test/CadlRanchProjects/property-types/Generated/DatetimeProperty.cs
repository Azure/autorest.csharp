// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Types
{
    /// <summary> Model with a datetime property. </summary>
    public partial class DatetimeProperty
    {
        /// <summary> Initializes a new instance of DatetimeProperty. </summary>
        /// <param name="property"></param>
        public DatetimeProperty(DateTimeOffset property)
        {
            Property = property;
        }

        public DateTimeOffset Property { get; set; }
    }
}
