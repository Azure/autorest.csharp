// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Model with a duration property. </summary>
    public partial class DurationProperty
    {
        /// <summary> Initializes a new instance of DurationProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        internal DurationProperty(string requiredProperty, TimeSpan? nullableProperty)
        {
            Argument.AssertNotNull(requiredProperty, nameof(requiredProperty));

            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
        }

        /// <summary> Required property. </summary>
        public string RequiredProperty { get; }
        /// <summary> Property. </summary>
        public TimeSpan? NullableProperty { get; }
    }
}
