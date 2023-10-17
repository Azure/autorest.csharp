// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> The base model. </summary>
    internal partial class BaseModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="BaseModel"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal BaseModel(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="BaseModel"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="size"> The size. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BaseModel(string name, double? size, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Size = size;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="BaseModel"/> for deserialization. </summary>
        internal BaseModel()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; }
        /// <summary> The size. </summary>
        public double? Size { get; }
    }
}
