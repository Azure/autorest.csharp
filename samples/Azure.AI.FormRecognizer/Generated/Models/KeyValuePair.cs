// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Information about the extracted key-value pair. </summary>
    public partial class KeyValuePair
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="KeyValuePair"/>. </summary>
        /// <param name="key"> Information about the extracted key in a key-value pair. </param>
        /// <param name="value"> Information about the extracted value in a key-value pair. </param>
        /// <param name="confidence"> Confidence value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        internal KeyValuePair(KeyValueElement key, KeyValueElement value, float confidence)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            Confidence = confidence;
        }

        /// <summary> Initializes a new instance of <see cref="KeyValuePair"/>. </summary>
        /// <param name="label"> A user defined label for the key/value pair entry. </param>
        /// <param name="key"> Information about the extracted key in a key-value pair. </param>
        /// <param name="value"> Information about the extracted value in a key-value pair. </param>
        /// <param name="confidence"> Confidence value. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal KeyValuePair(string label, KeyValueElement key, KeyValueElement value, float confidence, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Label = label;
            Key = key;
            Value = value;
            Confidence = confidence;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="KeyValuePair"/> for deserialization. </summary>
        internal KeyValuePair()
        {
        }

        /// <summary> A user defined label for the key/value pair entry. </summary>
        public string Label { get; }
        /// <summary> Information about the extracted key in a key-value pair. </summary>
        public KeyValueElement Key { get; }
        /// <summary> Information about the extracted value in a key-value pair. </summary>
        public KeyValueElement Value { get; }
        /// <summary> Confidence value. </summary>
        public float Confidence { get; }
    }
}
