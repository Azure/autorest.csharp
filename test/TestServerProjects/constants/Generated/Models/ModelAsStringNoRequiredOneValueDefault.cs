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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::constants.Models.ModelAsStringNoRequiredOneValueDefault
        ///
        /// </summary>
        internal ModelAsStringNoRequiredOneValueDefault()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::constants.Models.ModelAsStringNoRequiredOneValueDefault
        ///
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelAsStringNoRequiredOneValueDefault(ModelAsStringNoRequiredOneValueDefaultEnum? parameter, Dictionary<string, BinaryData> rawData)
        {
            Parameter = parameter;
            _rawData = rawData;
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringNoRequiredOneValueDefaultEnum? Parameter { get; }
    }
}
