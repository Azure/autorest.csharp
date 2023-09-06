// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Property.Optionality.Models
{
    /// <summary> Template type for testing models with optional property. Pass in the type of the property you are looking for. </summary>
    public partial class StringProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of StringProperty. </summary>
        public StringProperty()
        {
        }

        /// <summary> Initializes a new instance of StringProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StringProperty(string property, Dictionary<string, BinaryData> rawData)
        {
            Property = property;
            _rawData = rawData;
        }

        /// <summary> Property. </summary>
        public string Property { get; set; }
    }
}
