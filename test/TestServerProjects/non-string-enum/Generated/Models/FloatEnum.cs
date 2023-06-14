// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace non_string_enum.Models
{
    /// <summary> List of float enums. </summary>
    public readonly partial struct FloatEnum : IEquatable<FloatEnum>
    {
        private readonly float _value;

        /// <summary> Initializes a new instance of <see cref="FloatEnum"/>. </summary>
        public FloatEnum(float value)
        {
            _value = value;
        }

        private const float TwoHundred4Value = 200.4F;
        private const float FourHundredThree4Value = 403.4F;
        private const float FourHundredFive3Value = 405.3F;
        private const float FourHundredSix2Value = 406.2F;
        private const float FourHundredTwentyNine1Value = 429.1F;

        /// <summary> 200.4. </summary>
        public static FloatEnum TwoHundred4 { get; } = new FloatEnum(TwoHundred4Value);
        /// <summary> 403.4. </summary>
        public static FloatEnum FourHundredThree4 { get; } = new FloatEnum(FourHundredThree4Value);
        /// <summary> 405.3. </summary>
        public static FloatEnum FourHundredFive3 { get; } = new FloatEnum(FourHundredFive3Value);
        /// <summary> 406.2. </summary>
        public static FloatEnum FourHundredSix2 { get; } = new FloatEnum(FourHundredSix2Value);
        /// <summary> 429.1. </summary>
        public static FloatEnum FourHundredTwentyNine1 { get; } = new FloatEnum(FourHundredTwentyNine1Value);

        internal float ToSerialSingle() => _value;

        /// <summary> Determines if two <see cref="FloatEnum"/> values are the same. </summary>
        public static bool operator ==(FloatEnum left, FloatEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FloatEnum"/> values are not the same. </summary>
        public static bool operator !=(FloatEnum left, FloatEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FloatEnum"/>. </summary>
        public static implicit operator FloatEnum(float value) => new FloatEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FloatEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FloatEnum other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
