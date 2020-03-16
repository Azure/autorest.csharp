// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace body_complex.Models
{
    /// <summary> The StringWrapper. </summary>
    public partial class StringWrapper
    {
        /// <summary> Initializes a new instance of StringWrapper. </summary>
        internal StringWrapper()
        {
        }

        /// <summary> Initializes a new instance of StringWrapper. </summary>
        /// <param name="field"> . </param>
        /// <param name="empty"> . </param>
        /// <param name="nullProperty"> . </param>
        internal StringWrapper(string field, string empty, string nullProperty)
        {
            Field = field;
            Empty = empty;
            NullProperty = nullProperty;
        }

        public string Field { get; set; }
        public string Empty { get; set; }
        public string NullProperty { get; set; }
    }
}
