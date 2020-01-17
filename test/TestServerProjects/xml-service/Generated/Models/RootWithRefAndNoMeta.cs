// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models
{
    /// <summary> I am root, and I ref a model with no meta. </summary>
    public partial class RootWithRefAndNoMeta
    {
        /// <summary> I am a complex type with no XML node. </summary>
        public ComplexTypeNoMeta? RefToModel { get; set; }
        /// <summary> Something else (just to avoid flattening). </summary>
        public string? Something { get; set; }
    }
}
