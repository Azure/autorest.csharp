// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The StringWrapper. </summary>
    public partial class StringWrapper
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="StringWrapper"/>. </summary>
        public StringWrapper()
        {
        }

        /// <summary> Initializes a new instance of <see cref="StringWrapper"/>. </summary>
        /// <param name="field"></param>
        /// <param name="empty"></param>
        /// <param name="nullProperty"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal StringWrapper(string field, string empty, string nullProperty, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Field = field;
            Empty = empty;
            NullProperty = nullProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the field. </summary>
        public string Field { get; set; }
        /// <summary> Gets or sets the empty. </summary>
        public string Empty { get; set; }
        /// <summary> Gets or sets the null property. </summary>
        public string NullProperty { get; set; }
    }
}
