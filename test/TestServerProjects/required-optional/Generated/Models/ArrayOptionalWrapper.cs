// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace required_optional.Models
{
    /// <summary> The ArrayOptionalWrapper. </summary>
    public partial class ArrayOptionalWrapper
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ArrayOptionalWrapper"/>. </summary>
        public ArrayOptionalWrapper()
        {
            Value = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="ArrayOptionalWrapper"/>. </summary>
        /// <param name="value"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ArrayOptionalWrapper(IList<string> value, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the value. </summary>
        public IList<string> Value { get; }
    }
}
