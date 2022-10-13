// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Models.Property.Optional
{
    /// <summary> Template type for testing models with optional property. Pass in the type of the property you are looking for. </summary>
    public partial class BytesProperty
    {
        /// <summary> Initializes a new instance of BytesProperty. </summary>
        public BytesProperty()
        {
        }
        /// <summary> Initializes a new instance of BytesProperty. </summary>
        /// <param name="property"></param>
        internal BytesProperty(BinaryData property)
        {
            Property = property;
        }

        public BinaryData Property { get; set; }
    }
}
