// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace extensible_enums_swagger.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Pet
    {
        public string? Name { get; set; }
        /// <summary> Type of Pet. </summary>
        public DaysOfWeekExtensibleEnum? DaysOfWeek { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public IntEnum IntEnum { get; set; }
    }
}
