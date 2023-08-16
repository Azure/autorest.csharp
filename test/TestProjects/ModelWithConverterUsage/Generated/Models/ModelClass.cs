// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelWithConverterUsage.Models
{
    /// <summary> . </summary>
    public partial class ModelClass
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::ModelWithConverterUsage.Models.ModelClass
        ///
        /// </summary>
        /// <param name="enumProperty"> More Letters. </param>
        public ModelClass(EnumProperty enumProperty)
        {
            EnumProperty = enumProperty;
        }

        /// <summary>
        /// Initializes a new instance of global::ModelWithConverterUsage.Models.ModelClass
        ///
        /// </summary>
        /// <param name="stringProperty"></param>
        /// <param name="enumProperty"> More Letters. </param>
        /// <param name="objProperty"> The product documentation. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelClass(string stringProperty, EnumProperty enumProperty, Product objProperty, Dictionary<string, BinaryData> rawData)
        {
            StringProperty = stringProperty;
            EnumProperty = enumProperty;
            ObjProperty = objProperty;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the string property. </summary>
        public string StringProperty { get; set; }
        /// <summary> More Letters. </summary>
        public EnumProperty EnumProperty { get; set; }
        /// <summary> The product documentation. </summary>
        public Product ObjProperty { get; set; }
    }
}
