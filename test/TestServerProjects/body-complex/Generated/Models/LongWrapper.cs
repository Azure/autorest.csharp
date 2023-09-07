// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The LongWrapper. </summary>
    public partial class LongWrapper
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="LongWrapper"/>. </summary>
        public LongWrapper()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LongWrapper"/>. </summary>
        /// <param name="field1"></param>
        /// <param name="field2"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal LongWrapper(long? field1, long? field2, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Field1 = field1;
            Field2 = field2;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the field 1. </summary>
        public long? Field1 { get; set; }
        /// <summary> Gets or sets the field 2. </summary>
        public long? Field2 { get; set; }
    }
}
