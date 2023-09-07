// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The SeparateClass. </summary>
    public partial class SeparateClass
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SeparateClass"/>. </summary>
        public SeparateClass()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SeparateClass"/>. </summary>
        /// <param name="stringProperty"></param>
        /// <param name="modelProperty"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SeparateClass(string stringProperty, ExactMatchModel10 modelProperty, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StringProperty = stringProperty;
            ModelProperty = modelProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the string property. </summary>
        public string StringProperty { get; set; }
        /// <summary> Gets or sets the model property. </summary>
        public ExactMatchModel10 ModelProperty { get; set; }
    }
}
