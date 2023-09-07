// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Inner model used in collections model property. </summary>
    public partial class InnerModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of InnerModel. </summary>
        /// <param name="property"> Inner model property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        internal InnerModel(string property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary> Initializes a new instance of InnerModel. </summary>
        /// <param name="property"> Inner model property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InnerModel(string property, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Property = property;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InnerModel"/> for deserialization. </summary>
        internal InnerModel()
        {
        }

        /// <summary> Inner model property. </summary>
        public string Property { get; }
    }
}
