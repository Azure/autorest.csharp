// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FloatSecondsDurationArrayProperty(IList<TimeSpan> value, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="FloatSecondsDurationArrayProperty"/> for deserialization. </summary>
        internal FloatSecondsDurationArrayProperty()
        {
        }

        /// <summary> Gets the value. </summary>
        public IList<TimeSpan> Value { get; }
    }
}
