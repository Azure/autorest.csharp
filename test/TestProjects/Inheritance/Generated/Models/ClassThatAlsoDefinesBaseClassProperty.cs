// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Inheritance.Models
{
    /// <summary> The ClassThatAlsoDefinesBaseClassProperty. </summary>
    internal partial class ClassThatAlsoDefinesBaseClassProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ClassThatAlsoDefinesBaseClassProperty"/>. </summary>
        internal ClassThatAlsoDefinesBaseClassProperty()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ClassThatAlsoDefinesBaseClassProperty"/>. </summary>
        /// <param name="baseClassProperty"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ClassThatAlsoDefinesBaseClassProperty(string baseClassProperty, Dictionary<string, BinaryData> rawData)
        {
            BaseClassProperty = baseClassProperty;
            _rawData = rawData;
        }

        /// <summary> Gets the base class property. </summary>
        public string BaseClassProperty { get; }
    }
}
