// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Encode.Duration.Models
{
    /// <summary> The Int32SecondsDurationProperty. </summary>
    public partial class Int32SecondsDurationProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Int32SecondsDurationProperty. </summary>
        /// <param name="value"></param>
        public Int32SecondsDurationProperty(TimeSpan value)
        {
            Value = value;
        }

        /// <summary> Initializes a new instance of Int32SecondsDurationProperty. </summary>
        /// <param name="value"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Int32SecondsDurationProperty(TimeSpan value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the value. </summary>
        public TimeSpan Value { get; set; }
    }
}
