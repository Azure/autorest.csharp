// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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

        public int? Integer { get; set; }
        public string String { get; set; }
    }
}
