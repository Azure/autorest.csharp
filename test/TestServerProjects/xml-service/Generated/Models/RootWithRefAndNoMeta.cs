// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xml_service.Models
{
    /// <summary> I am root, and I ref a model with no meta. </summary>
    public partial class RootWithRefAndNoMeta
    {
        /// <summary> Initializes a new instance of RootWithRefAndNoMeta. </summary>
        public RootWithRefAndNoMeta()
        {
        }

        /// <summary> Initializes a new instance of RootWithRefAndNoMeta. </summary>
        /// <param name="refToModel"> XML will use RefToModel. </param>
        /// <param name="something"> Something else (just to avoid flattening). </param>
        internal RootWithRefAndNoMeta(ComplexTypeNoMeta refToModel, string something)
        {
            RefToModel = refToModel;
            Something = something;
        }

        /// <summary> XML will use RefToModel. </summary>
        public ComplexTypeNoMeta RefToModel { get; set; }
        /// <summary> Something else (just to avoid flattening). </summary>
        public string Something { get; set; }
    }
}
