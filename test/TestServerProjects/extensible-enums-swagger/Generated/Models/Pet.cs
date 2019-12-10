// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace extensible_enums_swagger.Models.V20160707
{
    public partial class Pet
    {
        public string? Name { get; set; }
        public DaysOfWeekExtensibleEnum? DaysOfWeek { get; set; }
        public IntEnum IntEnum { get; set; }
    }
}
