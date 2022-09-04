// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Types
{
    /// <summary> Model with model properties. </summary>
    public partial class ModelProperty
    {
        /// <summary> Initializes a new instance of ModelProperty. </summary>
        /// <param name="property"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public ModelProperty(InnerModel property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        public InnerModel Property { get; set; }
    }
}
