// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with enum properties. </summary>
    public partial class EnumProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of EnumProperty. </summary>
        /// <param name="property"> Property. </param>
        public EnumProperty(FixedInnerEnum property)
        {
            Property = property;
        }

        /// <summary> Initializes a new instance of EnumProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal EnumProperty(FixedInnerEnum property, Dictionary<string, BinaryData> rawData)
        {
            Property = property;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="EnumProperty"/> for deserialization. </summary>
        internal EnumProperty()
        {
        }

        /// <summary> Property. </summary>
        public FixedInnerEnum Property { get; set; }
    }
}
