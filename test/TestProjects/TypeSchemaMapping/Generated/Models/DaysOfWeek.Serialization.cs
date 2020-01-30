// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace TypeSchemaMapping.Models
{
    internal static class DaysOfWeekExtensions
    {
        public static string ToSerialString(this DaysOfWeek value) => value switch
        {
            DaysOfWeek.Monday => "Monday",
            DaysOfWeek.Tuesday => "Tuesday",
            DaysOfWeek.Wednesday => "Wednesday",
            DaysOfWeek.Thursday => "Thursday",
            DaysOfWeek.Friday => "Friday",
            DaysOfWeek.Saturday => "Saturday",
            DaysOfWeek.Sunday => "Sunday",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DaysOfWeek value.")
        };

        public static DaysOfWeek ToDaysOfWeek(this string value) => value switch
        {
            "Monday" => DaysOfWeek.Monday,
            "Tuesday" => DaysOfWeek.Tuesday,
            "Wednesday" => DaysOfWeek.Wednesday,
            "Thursday" => DaysOfWeek.Thursday,
            "Friday" => DaysOfWeek.Friday,
            "Saturday" => DaysOfWeek.Saturday,
            "Sunday" => DaysOfWeek.Sunday,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DaysOfWeek value.")
        };
    }
}
