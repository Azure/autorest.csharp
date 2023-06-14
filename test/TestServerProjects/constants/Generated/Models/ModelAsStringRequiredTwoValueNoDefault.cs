// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredTwoValueNoDefault. </summary>
    internal partial class ModelAsStringRequiredTwoValueNoDefault
    {
        /// <summary> Initializes a new instance of ModelAsStringRequiredTwoValueNoDefault. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredTwoValueNoDefault(ModelAsStringRequiredTwoValueNoDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringRequiredTwoValueNoDefaultEnum Parameter { get; }
    }
}
