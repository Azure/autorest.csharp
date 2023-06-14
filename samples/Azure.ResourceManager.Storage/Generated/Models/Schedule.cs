// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> This is a required field. This field is used to schedule an inventory formation. </summary>
    public readonly partial struct Schedule : IEquatable<Schedule>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Schedule"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Schedule(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DailyValue = "Daily";
        private const string WeeklyValue = "Weekly";

        /// <summary> Daily. </summary>
        public static Schedule Daily { get; } = new Schedule(DailyValue);
        /// <summary> Weekly. </summary>
        public static Schedule Weekly { get; } = new Schedule(WeeklyValue);
        /// <summary> Determines if two <see cref="Schedule"/> values are the same. </summary>
        public static bool operator ==(Schedule left, Schedule right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Schedule"/> values are not the same. </summary>
        public static bool operator !=(Schedule left, Schedule right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Schedule"/>. </summary>
        public static implicit operator Schedule(string value) => new Schedule(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Schedule other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Schedule other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
