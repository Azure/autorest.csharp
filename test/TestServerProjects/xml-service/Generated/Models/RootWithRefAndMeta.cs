// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xml_service.Models
{
    /// <summary> I am root, and I ref a model WITH meta. </summary>
    public partial class RootWithRefAndMeta
    {
        /// <summary> Initializes a new instance of RootWithRefAndMeta. </summary>
        public RootWithRefAndMeta()
        {
        }

        /// <summary> Initializes a new instance of RootWithRefAndMeta. </summary>
        /// <param name="refToModel"> XML will use XMLComplexTypeWithMeta. </param>
        /// <param name="something"> Something else (just to avoid flattening). </param>
        internal RootWithRefAndMeta(ComplexTypeWithMeta refToModel, string something)
        {
            RefToModel = refToModel;
            Something = something;
        }

        /// <summary> XML will use XMLComplexTypeWithMeta. </summary>
        public ComplexTypeWithMeta RefToModel { get; set; }
        /// <summary> Something else (just to avoid flattening). </summary>
        public string Something { get; set; }
    }
}
