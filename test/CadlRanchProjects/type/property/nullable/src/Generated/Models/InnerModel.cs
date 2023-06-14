// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Inner model used in collections model property. </summary>
    public partial class InnerModel
    {
        /// <summary> Initializes a new instance of InnerModel. </summary>
        /// <param name="property"> Inner model property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        internal InnerModel(string property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary> Inner model property. </summary>
        public string Property { get; }
    }
}
