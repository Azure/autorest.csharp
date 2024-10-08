// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace NamespaceForEnums
{
    /// <summary> Day of week. </summary>
    internal readonly partial struct CustomDaysOfWeek : IEquatable<CustomDaysOfWeek>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CustomDaysOfWeek"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CustomDaysOfWeek(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FancyMondayValue = "Monday";
        private const string FancyTuesdayValue = "Tuesday";
        private const string WednesdayValue = "Wednesday";
        private const string ThursdayValue = "Thursday";
        private const string FridayValue = "Friday";
        private const string SaturdayValue = "Saturday";
        private const string SundayValue = "Sunday";
        /// <summary> Wednesday. </summary>
        public static CustomDaysOfWeek Wednesday { get; } = new CustomDaysOfWeek(WednesdayValue);
        /// <summary> Thursday. </summary>
        public static CustomDaysOfWeek Thursday { get; } = new CustomDaysOfWeek(ThursdayValue);
        /// <summary> Friday. </summary>
        public static CustomDaysOfWeek Friday { get; } = new CustomDaysOfWeek(FridayValue);
        /// <summary> Saturday. </summary>
        public static CustomDaysOfWeek Saturday { get; } = new CustomDaysOfWeek(SaturdayValue);
        /// <summary> Sunday. </summary>
        public static CustomDaysOfWeek Sunday { get; } = new CustomDaysOfWeek(SundayValue);
        /// <summary> Determines if two <see cref="CustomDaysOfWeek"/> values are the same. </summary>
        public static bool operator ==(CustomDaysOfWeek left, CustomDaysOfWeek right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CustomDaysOfWeek"/> values are not the same. </summary>
        public static bool operator !=(CustomDaysOfWeek left, CustomDaysOfWeek right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="CustomDaysOfWeek"/>. </summary>
        public static implicit operator CustomDaysOfWeek(string value) => new CustomDaysOfWeek(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CustomDaysOfWeek other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CustomDaysOfWeek other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
    }
}
