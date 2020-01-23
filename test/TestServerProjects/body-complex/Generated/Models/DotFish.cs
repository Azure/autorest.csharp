// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_complex.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class DotFish
    {
        /// <summary> Initializes a new instance of DotFish. </summary>
        public DotFish()
        {
            FishType = null;
        }
        public string FishType { get; internal set; }
        public string? Species { get; set; }
    }
}
