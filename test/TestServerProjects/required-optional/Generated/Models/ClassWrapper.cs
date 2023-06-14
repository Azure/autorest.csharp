// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace required_optional.Models
{
    /// <summary> The ClassWrapper. </summary>
    public partial class ClassWrapper
    {
        /// <summary> Initializes a new instance of ClassWrapper. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ClassWrapper(Product value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public Product Value { get; }
    }
}
