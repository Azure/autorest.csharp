// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The StringWrapper. </summary>
    public partial class StringWrapper
    {
        /// <summary> Initializes a new instance of StringWrapper. </summary>
        public StringWrapper()
        {
        }

        /// <summary> Initializes a new instance of StringWrapper. </summary>
        /// <param name="field"></param>
        /// <param name="empty"></param>
        /// <param name="nullProperty"></param>
        internal StringWrapper(string field, string empty, string nullProperty)
        {
            Field = field;
            Empty = empty;
            NullProperty = nullProperty;
        }

        /// <summary> Gets or sets the field. </summary>
        public string Field { get; set; }
        /// <summary> Gets or sets the empty. </summary>
        public string Empty { get; set; }
        /// <summary> Gets or sets the null property. </summary>
        public string NullProperty { get; set; }
    }
}
