// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace UnbrandedTypeSpec.Models
{
    /// <summary> The Thing_requiredLiteralInt. </summary>
    public readonly partial struct ThingRequiredLiteralInt : IEquatable<ThingRequiredLiteralInt>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="ThingRequiredLiteralInt"/>. </summary>
        public ThingRequiredLiteralInt(int value)
        {
            _value = value;
        }

        private const int _123Value = 123;

        /// <summary> 123. </summary>
        public static ThingRequiredLiteralInt _123 { get; } = new ThingRequiredLiteralInt(_123Value);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="ThingRequiredLiteralInt"/> values are the same. </summary>
        public static bool operator ==(ThingRequiredLiteralInt left, ThingRequiredLiteralInt right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ThingRequiredLiteralInt"/> values are not the same. </summary>
        public static bool operator !=(ThingRequiredLiteralInt left, ThingRequiredLiteralInt right) => !left.Equals(right);
        /// <summary> Converts a <see cref="int"/> to a <see cref="ThingRequiredLiteralInt"/>. </summary>
        public static implicit operator ThingRequiredLiteralInt(int value) => new ThingRequiredLiteralInt(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ThingRequiredLiteralInt other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ThingRequiredLiteralInt other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
