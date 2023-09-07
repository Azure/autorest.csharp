// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredOneValueNoDefault. </summary>
    internal partial class ModelAsStringNoRequiredOneValueNoDefault
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredOneValueNoDefault"/>. </summary>
        internal ModelAsStringNoRequiredOneValueNoDefault()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredOneValueNoDefault"/>. </summary>
        /// <param name="parameter"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelAsStringNoRequiredOneValueNoDefault(ModelAsStringNoRequiredOneValueNoDefaultEnum? parameter, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Parameter = parameter;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringNoRequiredOneValueNoDefaultEnum? Parameter { get; }
    }
}
