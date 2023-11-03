// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> I am root, and I ref a model with no meta. </summary>
    public partial class RootWithRefAndNoMeta
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="RootWithRefAndNoMeta"/>. </summary>
        public RootWithRefAndNoMeta()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RootWithRefAndNoMeta"/>. </summary>
        /// <param name="refToModel"> XML will use RefToModel. </param>
        /// <param name="something"> Something else (just to avoid flattening). </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RootWithRefAndNoMeta(ComplexTypeNoMeta refToModel, string something, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RefToModel = refToModel;
            Something = something;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> XML will use RefToModel. </summary>
        public ComplexTypeNoMeta RefToModel { get; set; }
        /// <summary> Something else (just to avoid flattening). </summary>
        public string Something { get; set; }
    }
}
