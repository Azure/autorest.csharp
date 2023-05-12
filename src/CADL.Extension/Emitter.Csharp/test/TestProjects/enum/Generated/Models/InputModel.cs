// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace TypeSpec.EnumPropertiesBasic.Models
{
    /// <summary> Input model with enum properties. </summary>
    public partial class InputModel
    {
        /// <summary> Initializes a new instance of InputModel. </summary>
        /// <param name="day"> Required standard enum value. </param>
        /// <param name="fixedDay"> Required fixed enum value. </param>
        /// <param name="language"></param>
        /// <param name="title"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/> is null. </exception>
        public InputModel(DayOfTheWeek day, FixedDayOfTheWeek fixedDay, string language, EnumWithStringValue title)
        {
            Argument.AssertNotNull(language, nameof(language));

            Day = day;
            FixedDay = fixedDay;
            Language = language;
            Title = title;
        }

        /// <summary> Required standard enum value. </summary>
        public DayOfTheWeek Day { get; }
        /// <summary> Required fixed enum value. </summary>
        public FixedDayOfTheWeek FixedDay { get; }
        /// <summary> Gets the language. </summary>
        public string Language { get; }
        /// <summary> Gets the title. </summary>
        public EnumWithStringValue Title { get; }
    }
}
