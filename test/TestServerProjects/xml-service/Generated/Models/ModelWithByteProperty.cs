// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> The ModelWithByteProperty. </summary>
    public partial class ModelWithByteProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithByteProperty"/>. </summary>
        public ModelWithByteProperty()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithByteProperty"/>. </summary>
        /// <param name="bytes"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithByteProperty(byte[] bytes, Dictionary<string, BinaryData> rawData)
        {
            Bytes = bytes;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the bytes. </summary>
        public byte[] Bytes { get; set; }
    }
}
