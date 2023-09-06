// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Model with collection bytes properties. </summary>
    public partial class CollectionsByteProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of CollectionsByteProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        internal CollectionsByteProperty(string requiredProperty, IEnumerable<BinaryData> nullableProperty)
        {
            Argument.AssertNotNull(requiredProperty, nameof(requiredProperty));

            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty?.ToList();
        }

        /// <summary> Initializes a new instance of CollectionsByteProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal CollectionsByteProperty(string requiredProperty, IReadOnlyList<BinaryData> nullableProperty, Dictionary<string, BinaryData> rawData)
        {
            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="CollectionsByteProperty"/> for deserialization. </summary>
        internal CollectionsByteProperty()
        {
        }

        /// <summary> Required property. </summary>
        public string RequiredProperty { get; }
        /// <summary>
        /// Property
        /// <para>
        /// To assign a byte[] to the element of this property use <see cref="BinaryData.FromBytes(byte[])"/>.
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
        public IReadOnlyList<BinaryData> NullableProperty { get; }
    }
}
