// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Property.Optionality.Models
{
    /// <summary> Model with a duration property. </summary>
    public partial class DurationProperty
    {
        /// <summary> Initializes a new instance of <see cref="DurationProperty"/>. </summary>
        public DurationProperty()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DurationProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        internal DurationProperty(TimeSpan? property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public TimeSpan? Property { get; set; }
    }
}
