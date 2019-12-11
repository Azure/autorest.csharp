// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace extensible_enums_swagger.Models.V20160707
{
    public readonly partial struct DaysOfWeekExtensibleEnum : IEquatable<DaysOfWeekExtensibleEnum>
    {
        private readonly string? _value;

        public DaysOfWeekExtensibleEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MondayValue = "Monday";
        private const string TuesdayValue = "Tuesday";
        private const string WednesdayValue = "Wednesday";
        private const string ThursdayValue = "Thursday";
        private const string FridayValue = "Friday";
        private const string SaturdayValue = "Saturday";
        private const string SundayValue = "Sunday";

        public static DaysOfWeekExtensibleEnum Monday { get; } = new DaysOfWeekExtensibleEnum(MondayValue);
        public static DaysOfWeekExtensibleEnum Tuesday { get; } = new DaysOfWeekExtensibleEnum(TuesdayValue);
        public static DaysOfWeekExtensibleEnum Wednesday { get; } = new DaysOfWeekExtensibleEnum(WednesdayValue);
        public static DaysOfWeekExtensibleEnum Thursday { get; } = new DaysOfWeekExtensibleEnum(ThursdayValue);
        public static DaysOfWeekExtensibleEnum Friday { get; } = new DaysOfWeekExtensibleEnum(FridayValue);
        public static DaysOfWeekExtensibleEnum Saturday { get; } = new DaysOfWeekExtensibleEnum(SaturdayValue);
        public static DaysOfWeekExtensibleEnum Sunday { get; } = new DaysOfWeekExtensibleEnum(SundayValue);
        public static bool operator ==(DaysOfWeekExtensibleEnum left, DaysOfWeekExtensibleEnum right) => left.Equals(right);
        public static bool operator !=(DaysOfWeekExtensibleEnum left, DaysOfWeekExtensibleEnum right) => !left.Equals(right);
        public static implicit operator DaysOfWeekExtensibleEnum(string value) => new DaysOfWeekExtensibleEnum(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is DaysOfWeekExtensibleEnum other && Equals(other);
        public bool Equals(DaysOfWeekExtensibleEnum other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
