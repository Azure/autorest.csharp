// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with a string property. </summary>
    public partial class StringProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="StringProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public StringProperty(string property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="StringProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal StringProperty(string property, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Property = property;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="StringProperty"/> for deserialization. </summary>
        internal StringProperty()
        {
        }

        /// <summary> Property. </summary>
        public string Property { get; set; }
    }
}
