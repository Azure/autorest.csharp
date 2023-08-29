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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefault"/>. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredTwoValueDefault(ModelAsStringRequiredTwoValueDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefault"/>. </summary>
        /// <param name="parameter"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelAsStringRequiredTwoValueDefault(ModelAsStringRequiredTwoValueDefaultEnum parameter, Dictionary<string, BinaryData> rawData)
        {
            Parameter = parameter;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredTwoValueDefault"/> for deserialization. </summary>
        internal ModelAsStringRequiredTwoValueDefault()
        {
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringRequiredTwoValueDefaultEnum Parameter { get; }
    }
}
