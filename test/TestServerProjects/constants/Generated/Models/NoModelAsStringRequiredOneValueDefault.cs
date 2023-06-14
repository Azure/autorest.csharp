// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace constants.Models
{
    /// <summary> The NoModelAsStringRequiredOneValueDefault. </summary>
    internal partial class NoModelAsStringRequiredOneValueDefault
    {
        /// <summary> Initializes a new instance of NoModelAsStringRequiredOneValueDefault. </summary>
        internal NoModelAsStringRequiredOneValueDefault()
        {
            Parameter = NoModelAsStringRequiredOneValueDefaultEnum.Value1;
        }

        /// <summary> Gets the parameter. </summary>
        public NoModelAsStringRequiredOneValueDefaultEnum Parameter { get; }
    }
}
