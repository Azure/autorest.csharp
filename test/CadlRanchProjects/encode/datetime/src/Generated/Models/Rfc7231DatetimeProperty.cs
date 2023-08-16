// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Encode.Datetime.Models
{
    /// <summary> The Rfc7231DatetimeProperty. </summary>
    public partial class Rfc7231DatetimeProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Rfc7231DatetimeProperty. </summary>
        /// <param name="value"></param>
        public Rfc7231DatetimeProperty(DateTimeOffset value)
        {
            Value = value;
        }

        /// <summary> Initializes a new instance of Rfc7231DatetimeProperty. </summary>
        /// <param name="value"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Rfc7231DatetimeProperty(DateTimeOffset value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the value. </summary>
        public DateTimeOffset Value { get; set; }
    }
}
