// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace _Type.Property.Optional.Models
{
    /// <summary> Template type for testing models with optional property. Pass in the type of the property you are looking for. </summary>
    public partial class BytesProperty
    {
        /// <summary> Initializes a new instance of BytesProperty. </summary>
        public BytesProperty()
        {
        }

        /// <summary> Initializes a new instance of BytesProperty. </summary>
        /// <param name="property"> Property. </param>
        internal BytesProperty(BinaryData property)
        {
            Property = property;
        }

        /// <summary>
        /// Property
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData Property { get; set; }
    }
}
