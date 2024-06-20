// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Scm.Client.Naming.Models
{
    /// <summary> The ExtensibleEnum. </summary>
    public readonly partial struct ExtensibleEnum : IEquatable<ExtensibleEnum>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ExtensibleEnum"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ExtensibleEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ClientEnumValue1Value = "value1";
        private const string ClientEnumValue2Value = "value2";

        /// <summary> value1. </summary>
        public static ExtensibleEnum ClientEnumValue1 { get; } = new ExtensibleEnum(ClientEnumValue1Value);
        /// <summary> value2. </summary>
        public static ExtensibleEnum ClientEnumValue2 { get; } = new ExtensibleEnum(ClientEnumValue2Value);
        /// <summary> Determines if two <see cref="ExtensibleEnum"/> values are the same. </summary>
        public static bool operator ==(ExtensibleEnum left, ExtensibleEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ExtensibleEnum"/> values are not the same. </summary>
        public static bool operator !=(ExtensibleEnum left, ExtensibleEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ExtensibleEnum"/>. </summary>
        public static implicit operator ExtensibleEnum(string value) => new ExtensibleEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ExtensibleEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ExtensibleEnum other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
