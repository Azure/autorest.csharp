// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    /// <summary> The ModelWithByteProperty. </summary>
    public partial class ModelWithByteProperty
    {
        /// <summary> Initializes a new instance of ModelWithByteProperty. </summary>
        public ModelWithByteProperty()
        {
        }

        /// <summary> Initializes a new instance of ModelWithByteProperty. </summary>
        /// <param name="bytes"></param>
        internal ModelWithByteProperty(byte[] bytes)
        {
            Bytes = bytes;
        }

        /// <summary> Gets or sets the bytes. </summary>
        public byte[] Bytes { get; set; }
    }
}
