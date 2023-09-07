// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with a property never. (This property should not be included). </summary>
    public partial class NeverProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of NeverProperty. </summary>
        public NeverProperty()
        {
        }

        /// <summary> Initializes a new instance of NeverProperty. </summary>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NeverProperty(Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
