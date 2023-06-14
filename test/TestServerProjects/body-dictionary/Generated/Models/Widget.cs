// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_dictionary.Models
{
    /// <summary> The Widget. </summary>
    public partial class Widget
    {
        /// <summary> Initializes a new instance of Widget. </summary>
        public Widget()
        {
        }

        /// <summary> Initializes a new instance of Widget. </summary>
        /// <param name="integer"></param>
        /// <param name="string"></param>
        internal Widget(int? integer, string @string)
        {
            Integer = integer;
            String = @string;
        }

        /// <summary> Gets or sets the integer. </summary>
        public int? Integer { get; set; }
        /// <summary> Gets or sets the string. </summary>
        public string String { get; set; }
    }
}
