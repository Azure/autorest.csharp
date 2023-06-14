// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> A feature for gallery image. </summary>
    public partial class GalleryImageFeature
    {
        /// <summary> Initializes a new instance of GalleryImageFeature. </summary>
        internal GalleryImageFeature()
        {
        }

        /// <summary> Initializes a new instance of GalleryImageFeature. </summary>
        /// <param name="name"> The name of the gallery image feature. </param>
        /// <param name="value"> The value of the gallery image feature. </param>
        internal GalleryImageFeature(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary> The name of the gallery image feature. </summary>
        public string Name { get; }
        /// <summary> The value of the gallery image feature. </summary>
        public string Value { get; }
    }
}
