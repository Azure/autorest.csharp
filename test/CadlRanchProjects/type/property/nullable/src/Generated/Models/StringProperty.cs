// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Template type for testing models with nullable property. Pass in the type of the property you are looking for. </summary>
    public partial class StringProperty
    {
        /// <summary> Initializes a new instance of StringProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        internal StringProperty(string requiredProperty, string nullableProperty)
        {
            Argument.AssertNotNull(requiredProperty, nameof(requiredProperty));

            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
        }

        /// <summary> Required property. </summary>
        public string RequiredProperty { get; }
        /// <summary> Property. </summary>
        public string NullableProperty { get; }
    }
}
