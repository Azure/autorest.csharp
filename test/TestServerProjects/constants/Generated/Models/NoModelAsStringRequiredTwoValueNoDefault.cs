// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace constants.Models
{
    /// <summary> The NoModelAsStringRequiredTwoValueNoDefault. </summary>
    internal partial class NoModelAsStringRequiredTwoValueNoDefault
    {
        /// <summary> Initializes a new instance of NoModelAsStringRequiredTwoValueNoDefault. </summary>
        /// <param name="parameter"></param>
        internal NoModelAsStringRequiredTwoValueNoDefault(NoModelAsStringRequiredTwoValueNoDefaultEnum parameter)
        {
            Parameter = parameter;
        }

        /// <summary> Gets the parameter. </summary>
        public NoModelAsStringRequiredTwoValueNoDefaultEnum Parameter { get; }
    }
}
