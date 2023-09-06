// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredOneValueDefault. </summary>
    internal partial class ModelAsStringRequiredOneValueDefault
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredOneValueDefault"/>. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredOneValueDefault(ModelAsStringRequiredOneValueDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredOneValueDefault"/>. </summary>
        /// <param name="parameter"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelAsStringRequiredOneValueDefault(ModelAsStringRequiredOneValueDefaultEnum parameter, Dictionary<string, BinaryData> rawData)
        {
            Parameter = parameter;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringRequiredOneValueDefault"/> for deserialization. </summary>
        internal ModelAsStringRequiredOneValueDefault()
        {
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringRequiredOneValueDefaultEnum Parameter { get; }
    }
}
