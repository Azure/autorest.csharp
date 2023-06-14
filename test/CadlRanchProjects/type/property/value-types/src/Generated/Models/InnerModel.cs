// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Inner model. Will be a property type for ModelWithModelProperties. </summary>
    public partial class InnerModel
    {
        /// <summary> Initializes a new instance of InnerModel. </summary>
        /// <param name="property"> Required string property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public InnerModel(string property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary> Required string property. </summary>
        public string Property { get; set; }
    }
}
