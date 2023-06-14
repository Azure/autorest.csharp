// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace non_string_enum.Models
{
    /// <summary> List of integer enums. </summary>
    public readonly partial struct IntEnum : IEquatable<IntEnum>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="IntEnum"/>. </summary>
        public IntEnum(int value)
        {
            _value = value;
        }

        private const int TwoHundredValue = 200;
        private const int FourHundredThreeValue = 403;
        private const int FourHundredFiveValue = 405;
        private const int FourHundredSixValue = 406;
        private const int FourHundredTwentyNineValue = 429;

        /// <summary> 200. </summary>
        public static IntEnum TwoHundred { get; } = new IntEnum(TwoHundredValue);
        /// <summary> 403. </summary>
        public static IntEnum FourHundredThree { get; } = new IntEnum(FourHundredThreeValue);
        /// <summary> 405. </summary>
        public static IntEnum FourHundredFive { get; } = new IntEnum(FourHundredFiveValue);
        /// <summary> 406. </summary>
        public static IntEnum FourHundredSix { get; } = new IntEnum(FourHundredSixValue);
        /// <summary> 429. </summary>
        public static IntEnum FourHundredTwentyNine { get; } = new IntEnum(FourHundredTwentyNineValue);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="IntEnum"/> values are the same. </summary>
        public static bool operator ==(IntEnum left, IntEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IntEnum"/> values are not the same. </summary>
        public static bool operator !=(IntEnum left, IntEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="IntEnum"/>. </summary>
        public static implicit operator IntEnum(int value) => new IntEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IntEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IntEnum other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
