// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public string Kind { get; internal set; } = "Kind1";
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? PropB1 { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public MyBaseHelperType? Helper { get; set; }
    }
}
