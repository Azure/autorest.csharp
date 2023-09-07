// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of string. </summary>
    internal partial class SinglePropertyModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SinglePropertyModel"/>. </summary>
        public SinglePropertyModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SinglePropertyModel"/>. </summary>
        /// <param name="something"> This is a string property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SinglePropertyModel(string something, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Something = something;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> This is a string property. </summary>
        public string Something { get; set; }
    }
}
