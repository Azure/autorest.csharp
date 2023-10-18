// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> This is a model with a property of literal type of numbers. </summary>
    public partial class ModelWithIntegerLiteralTypeProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithIntegerLiteralTypeProperty"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public ModelWithIntegerLiteralTypeProperty(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithIntegerLiteralTypeProperty"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="id"> The id. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithIntegerLiteralTypeProperty(string name, ModelWithIntegerLiteralTypePropertyId id, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Id = id;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithIntegerLiteralTypeProperty"/> for deserialization. </summary>
        internal ModelWithIntegerLiteralTypeProperty()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; }
        /// <summary> The id. </summary>
        public ModelWithIntegerLiteralTypePropertyId Id { get; } = ModelWithIntegerLiteralTypePropertyId._1;
    }
}
