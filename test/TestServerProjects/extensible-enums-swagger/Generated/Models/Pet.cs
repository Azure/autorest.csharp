// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace extensible_enums_swagger.Models
{
    /// <summary> The Pet. </summary>
    public partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="intEnum"></param>
        public Pet(IntEnum intEnum)
        {
            IntEnum = intEnum;
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="name"> name. </param>
        /// <param name="daysOfWeek"> Type of Pet. </param>
        /// <param name="intEnum"></param>
        internal Pet(string name, DaysOfWeekExtensibleEnum? daysOfWeek, IntEnum intEnum)
        {
            Name = name;
            DaysOfWeek = daysOfWeek;
            IntEnum = intEnum;
        }

        /// <summary> name. </summary>
        public string Name { get; set; }
        /// <summary> Type of Pet. </summary>
        public DaysOfWeekExtensibleEnum? DaysOfWeek { get; set; }
        /// <summary> Gets or sets the int enum. </summary>
        public IntEnum IntEnum { get; set; }
    }
}
