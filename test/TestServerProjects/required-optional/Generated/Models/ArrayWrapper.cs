// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace required_optional.Models
{
    /// <summary> The ArrayWrapper. </summary>
    public partial class ArrayWrapper
    {
        /// <summary> Initializes a new instance of ArrayWrapper. </summary>
        /// <param name="value"> The Value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ArrayWrapper(IEnumerable<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> The Value. </summary>
        public IList<string> Value { get; }
    }
}
