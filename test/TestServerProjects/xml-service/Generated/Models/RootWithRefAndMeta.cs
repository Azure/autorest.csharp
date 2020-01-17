// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models
{
    /// <summary> I am root, and I ref a model WITH meta. </summary>
    public partial class RootWithRefAndMeta
    {
        /// <summary> I am a complex type with XML node. </summary>
        public ComplexTypeWithMeta? RefToModel { get; set; }
        /// <summary> Something else (just to avoid flattening). </summary>
        public string? Something { get; set; }
    }
}
