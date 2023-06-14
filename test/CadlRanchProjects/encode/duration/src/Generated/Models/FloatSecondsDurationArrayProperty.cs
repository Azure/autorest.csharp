// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Encode.Duration.Models
{
    /// <summary> The FloatSecondsDurationArrayProperty. </summary>
    public partial class FloatSecondsDurationArrayProperty
    {
        /// <summary> Initializes a new instance of FloatSecondsDurationArrayProperty. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FloatSecondsDurationArrayProperty(IEnumerable<TimeSpan> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of FloatSecondsDurationArrayProperty. </summary>
        /// <param name="value"></param>
        internal FloatSecondsDurationArrayProperty(IList<TimeSpan> value)
        {
            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public IList<TimeSpan> Value { get; }
    }
}
