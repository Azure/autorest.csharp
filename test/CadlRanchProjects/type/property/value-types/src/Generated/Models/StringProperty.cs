// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with a string property. </summary>
    public partial class StringProperty
    {
        /// <summary> Initializes a new instance of StringProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public StringProperty(string property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary> Property. </summary>
        public string Property { get; set; }
    }
}
