// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with a duration property. </summary>
    public partial class DurationProperty
    {
        /// <summary> Initializes a new instance of DurationProperty. </summary>
        /// <param name="property"> Property. </param>
        public DurationProperty(TimeSpan property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public TimeSpan Property { get; set; }
    }
}
