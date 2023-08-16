// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Encode.Duration.Models
{
    /// <summary> The FloatSecondsDurationProperty. </summary>
    public partial class FloatSecondsDurationProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of FloatSecondsDurationProperty. </summary>
        /// <param name="value"></param>
        public FloatSecondsDurationProperty(TimeSpan value)
        {
            Value = value;
        }

        /// <summary> Initializes a new instance of FloatSecondsDurationProperty. </summary>
        /// <param name="value"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FloatSecondsDurationProperty(TimeSpan value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the value. </summary>
        public TimeSpan Value { get; set; }
    }
}
