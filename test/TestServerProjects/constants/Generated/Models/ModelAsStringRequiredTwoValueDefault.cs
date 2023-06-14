// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredTwoValueDefault. </summary>
    internal partial class ModelAsStringRequiredTwoValueDefault
    {
        /// <summary> Initializes a new instance of ModelAsStringRequiredTwoValueDefault. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredTwoValueDefault(ModelAsStringRequiredTwoValueDefaultEnum? parameter = null)
        {
            Parameter = parameter ?? ModelAsStringRequiredTwoValueDefaultEnum.Value1;
        }

        /// <summary> Gets the parameter. </summary>
        public ModelAsStringRequiredTwoValueDefaultEnum Parameter { get; }
    }
}
