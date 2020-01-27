// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class MyBaseType
    {
        /// <summary> Initializes a new instance of MyBaseType. </summary>
        public MyBaseType()
        {
            Kind = null;
        }
        /// <summary> The constant value Kind1. </summary>
        public string Kind { get; internal set; } = "Kind1";
        public string PropB1 { get; set; }
        public string? PropBH1 { get; set; }
    }
}
