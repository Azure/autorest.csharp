// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Encode.Datetime.Models
{
    /// <summary> The DefaultDatetimeProperty. </summary>
    public partial class DefaultDatetimeProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of DefaultDatetimeProperty. </summary>
        /// <param name="value"></param>
        public DefaultDatetimeProperty(DateTimeOffset value)
        {
            Value = value;
        }

        /// <summary> Initializes a new instance of DefaultDatetimeProperty. </summary>
        /// <param name="value"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DefaultDatetimeProperty(DateTimeOffset value, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DefaultDatetimeProperty"/> for deserialization. </summary>
        internal DefaultDatetimeProperty()
        {
        }

        /// <summary> Gets or sets the value. </summary>
        public DateTimeOffset Value { get; set; }
    }
}
