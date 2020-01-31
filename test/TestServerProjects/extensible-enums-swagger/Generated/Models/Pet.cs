// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace extensible_enums_swagger.Models
{
    /// <summary> The Pet. </summary>
    public partial class Pet
    {
        public string Name { get; set; }
        /// <summary> Type of Pet. </summary>
        public DaysOfWeekExtensibleEnum? DaysOfWeek { get; set; }
        public IntEnum IntEnum { get; set; }
    }
}
