// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with a bytes property. </summary>
    public partial class BytesProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of BytesProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public BytesProperty(BinaryData property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary> Initializes a new instance of BytesProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal BytesProperty(BinaryData property, Dictionary<string, BinaryData> rawData)
        {
            Property = property;
            _rawData = rawData;
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
