// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace required_optional.Models
{
    /// <summary> The ArrayWrapper. </summary>
    public partial class ArrayWrapper
    {
        /// <summary> Initializes a new instance of ArrayWrapper. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ArrayWrapper(IEnumerable<string> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Gets the value. </summary>
        public IList<string> Value { get; }
    }
}
