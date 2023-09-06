// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Encode.Datetime.Models
{
    /// <summary> The UnixTimestampDatetimeProperty. </summary>
    public partial class UnixTimestampDatetimeProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of UnixTimestampDatetimeProperty. </summary>
        /// <param name="value"></param>
        public UnixTimestampDatetimeProperty(DateTimeOffset value)
        {
            Value = value;
        }

        /// <summary> Initializes a new instance of UnixTimestampDatetimeProperty. </summary>
        /// <param name="value"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnixTimestampDatetimeProperty(DateTimeOffset value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="UnixTimestampDatetimeProperty"/> for deserialization. </summary>
        internal UnixTimestampDatetimeProperty()
        {
        }

        /// <summary> Gets or sets the value. </summary>
        public DateTimeOffset Value { get; set; }
    }
}
