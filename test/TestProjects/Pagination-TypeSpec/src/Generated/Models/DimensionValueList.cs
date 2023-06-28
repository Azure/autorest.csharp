// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Pagination.Models
{
    /// <summary> The DimensionValueList. </summary>
    public partial class DimensionValueList
    {
        /// <summary> Initializes a new instance of DimensionValueList. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal DimensionValueList(IEnumerable<string> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of DimensionValueList. </summary>
        /// <param name="value"></param>
        internal DimensionValueList(IReadOnlyList<string> value)
        {
            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<string> Value { get; }
    }
}
