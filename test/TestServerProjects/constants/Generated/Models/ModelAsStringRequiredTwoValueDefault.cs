// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredTwoValueDefault. </summary>
    internal partial class ModelAsStringRequiredTwoValueDefault
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefault"/>. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredTwoValueDefault(ModelAsStringRequiredTwoValueDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefault"/>. </summary>
        /// <param name="parameter"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelAsStringRequiredTwoValueDefault(ModelAsStringRequiredTwoValueDefaultEnum parameter, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Parameter = parameter;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefault"/> for deserialization. </summary>
        internal ModelAsStringRequiredTwoValueDefault()
        {
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringRequiredTwoValueDefaultEnum Parameter { get; }
    }
}
