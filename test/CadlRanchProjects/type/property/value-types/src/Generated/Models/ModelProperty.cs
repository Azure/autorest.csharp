// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with model properties. </summary>
    public partial class ModelProperty
    {
        /// <summary> Initializes a new instance of ModelProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public ModelProperty(InnerModel property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary> Property. </summary>
        public InnerModel Property { get; set; }
    }
}
