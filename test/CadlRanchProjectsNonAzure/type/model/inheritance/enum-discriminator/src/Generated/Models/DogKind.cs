// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Scm._Type.Model.Inheritance.EnumDiscriminator.Models
{
    /// <summary> extensible enum type for discriminator. </summary>
    internal readonly partial struct DogKind : IEquatable<DogKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DogKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DogKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string GoldenValue = "golden";

        /// <summary> Species golden. </summary>
        public static DogKind Golden { get; } = new DogKind(GoldenValue);
        /// <summary> Determines if two <see cref="DogKind"/> values are the same. </summary>
        public static bool operator ==(DogKind left, DogKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DogKind"/> values are not the same. </summary>
        public static bool operator !=(DogKind left, DogKind right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="DogKind"/>. </summary>
        public static implicit operator DogKind(string value) => new DogKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DogKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DogKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
