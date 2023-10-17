// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with dictionary string properties. </summary>
    public partial class DictionaryStringProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DictionaryStringProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public DictionaryStringProperty(IDictionary<string, string> property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="DictionaryStringProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DictionaryStringProperty(IDictionary<string, string> property, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Property = property;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DictionaryStringProperty"/> for deserialization. </summary>
        internal DictionaryStringProperty()
        {
        }

        /// <summary> Property. </summary>
        public IDictionary<string, string> Property { get; }
    }
}
