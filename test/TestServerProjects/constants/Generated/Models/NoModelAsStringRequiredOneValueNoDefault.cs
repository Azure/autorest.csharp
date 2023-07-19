// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace constants.Models
{
    /// <summary> The NoModelAsStringRequiredOneValueNoDefault. </summary>
    internal partial class NoModelAsStringRequiredOneValueNoDefault
    {
        /// <summary> Initializes a new instance of NoModelAsStringRequiredOneValueNoDefault. </summary>
        internal NoModelAsStringRequiredOneValueNoDefault()
        {
            Parameter = NoModelAsStringRequiredOneValueNoDefaultEnum.Value1;
        }

        /// <summary> Initializes a new instance of NoModelAsStringRequiredOneValueNoDefault. </summary>
        /// <param name="parameter"></param>
        internal NoModelAsStringRequiredOneValueNoDefault(NoModelAsStringRequiredOneValueNoDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Gets the parameter. </summary>
        public NoModelAsStringRequiredOneValueNoDefaultEnum Parameter { get; }
    }
}
