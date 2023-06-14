// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The unit used by the width, height and boundingBox properties. For images, the unit is "pixel". For PDF, the unit is "inch". </summary>
    public enum LengthUnit
    {
        /// <summary> pixel. </summary>
        Pixel,
        /// <summary> inch. </summary>
        Inch
    }
}
