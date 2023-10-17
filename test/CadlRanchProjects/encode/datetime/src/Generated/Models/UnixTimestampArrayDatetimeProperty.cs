// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Encode.Datetime.Models
{
    /// <summary> The UnixTimestampArrayDatetimeProperty. </summary>
    public partial class UnixTimestampArrayDatetimeProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="UnixTimestampArrayDatetimeProperty"/>. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public UnixTimestampArrayDatetimeProperty(IEnumerable<DateTimeOffset> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="UnixTimestampArrayDatetimeProperty"/>. </summary>
        /// <param name="value"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnixTimestampArrayDatetimeProperty(IList<DateTimeOffset> value, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="UnixTimestampArrayDatetimeProperty"/> for deserialization. </summary>
        internal UnixTimestampArrayDatetimeProperty()
        {
        }

        /// <summary> Gets the value. </summary>
        public IList<DateTimeOffset> Value { get; }
    }
}
