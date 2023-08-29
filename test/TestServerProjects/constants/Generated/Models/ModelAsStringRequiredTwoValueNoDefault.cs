// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredTwoValueNoDefault. </summary>
    internal partial class ModelAsStringRequiredTwoValueNoDefault
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueNoDefault"/>. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredTwoValueNoDefault(ModelAsStringRequiredTwoValueNoDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueNoDefault"/>. </summary>
        /// <param name="parameter"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelAsStringRequiredTwoValueNoDefault(ModelAsStringRequiredTwoValueNoDefaultEnum parameter, Dictionary<string, BinaryData> rawData)
        {
            Parameter = parameter;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueNoDefault"/> for deserialization. </summary>
        internal ModelAsStringRequiredTwoValueNoDefault()
        {
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringRequiredTwoValueNoDefaultEnum Parameter { get; }
    }
}
