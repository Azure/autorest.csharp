// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace constants.Models
{
    /// <summary> The ModelAsStringRequiredOneValueDefault. </summary>
    internal partial class ModelAsStringRequiredOneValueDefault
    {
        /// <summary> Initializes a new instance of ModelAsStringRequiredOneValueDefault. </summary>
        /// <param name="parameter"></param>
        internal ModelAsStringRequiredOneValueDefault(ModelAsStringRequiredOneValueDefaultEnum? parameter = null)
        {
            Parameter = parameter ?? ModelAsStringRequiredOneValueDefaultEnum.Value1;
        }

        public ModelAsStringRequiredOneValueDefaultEnum Parameter { get; }
    }
}
