// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class VisualFeatureExtensions
    {
        public static string ToSerialString(this VisualFeature value) => value switch
        {
            VisualFeature.Adult => "adult",
            VisualFeature.Brands => "brands",
            VisualFeature.Categories => "categories",
            VisualFeature.Description => "description",
            VisualFeature.Faces => "faces",
            VisualFeature.Objects => "objects",
            VisualFeature.Tags => "tags",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VisualFeature value.")
        };

        public static VisualFeature ToVisualFeature(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "adult")) return VisualFeature.Adult;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "brands")) return VisualFeature.Brands;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "categories")) return VisualFeature.Categories;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "description")) return VisualFeature.Description;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "faces")) return VisualFeature.Faces;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "objects")) return VisualFeature.Objects;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "tags")) return VisualFeature.Tags;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VisualFeature value.");
        }
    }
}
