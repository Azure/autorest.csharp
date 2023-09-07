// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace constants.Models
{
    /// <summary> The ModelAsStringNoRequiredOneValueDefault. </summary>
    internal partial class ModelAsStringNoRequiredOneValueDefault
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredOneValueDefault"/>. </summary>
        internal ModelAsStringNoRequiredOneValueDefault()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ModelAsStringNoRequiredOneValueDefault"/>. </summary>
        /// <param name="parameter"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelAsStringNoRequiredOneValueDefault(ModelAsStringNoRequiredOneValueDefaultEnum? parameter, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Parameter = parameter;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringNoRequiredOneValueDefaultEnum? Parameter { get; }
    }
}
