// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredOneValueNoDefault. </summary>
    internal partial class ModelAsStringRequiredOneValueNoDefault
    {
        /// <summary> Initializes a new instance of ModelAsStringRequiredOneValueNoDefault. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredOneValueNoDefault(ModelAsStringRequiredOneValueNoDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringRequiredOneValueNoDefaultEnum Parameter { get; }
    }
}
