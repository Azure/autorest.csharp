// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace constants.Models
{
    /// <summary> The NoModelAsStringRequiredTwoValueDefault. </summary>
    internal partial class NoModelAsStringRequiredTwoValueDefault
    {
        /// <summary> Initializes a new instance of NoModelAsStringRequiredTwoValueDefault. </summary>
        /// <param name="parameter"></param>
        internal NoModelAsStringRequiredTwoValueDefault(NoModelAsStringRequiredTwoValueDefaultEnum parameter = NoModelAsStringRequiredTwoValueDefaultEnum.Value1)
        {
            Parameter = parameter;
        }

        /// <summary> Gets the parameter. </summary>
        public NoModelAsStringRequiredTwoValueDefaultEnum Parameter { get; }
    }
}
