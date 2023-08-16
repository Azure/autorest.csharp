// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> I am root, and I ref a model WITH meta. </summary>
    public partial class RootWithRefAndMeta
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.RootWithRefAndMeta
        ///
        /// </summary>
        public RootWithRefAndMeta()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.RootWithRefAndMeta
        ///
        /// </summary>
        /// <param name="refToModel"> XML will use XMLComplexTypeWithMeta. </param>
        /// <param name="something"> Something else (just to avoid flattening). </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal RootWithRefAndMeta(ComplexTypeWithMeta refToModel, string something, Dictionary<string, BinaryData> rawData)
        {
            RefToModel = refToModel;
            Something = something;
            _rawData = rawData;
        }

        /// <summary> XML will use XMLComplexTypeWithMeta. </summary>
        public ComplexTypeWithMeta RefToModel { get; set; }
        /// <summary> Something else (just to avoid flattening). </summary>
        public string Something { get; set; }
    }
}
