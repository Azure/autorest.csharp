// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Scm._Type.Property.AdditionalProperties.Models
{
    /// <summary> The WidgetData0Kind. </summary>
    public readonly partial struct WidgetData0Kind : IEquatable<WidgetData0Kind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="WidgetData0Kind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public WidgetData0Kind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Kind0Value = "kind0";

        /// <summary> kind0. </summary>
        public static WidgetData0Kind Kind0 { get; } = new WidgetData0Kind(Kind0Value);
        /// <summary> Determines if two <see cref="WidgetData0Kind"/> values are the same. </summary>
        public static bool operator ==(WidgetData0Kind left, WidgetData0Kind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="WidgetData0Kind"/> values are not the same. </summary>
        public static bool operator !=(WidgetData0Kind left, WidgetData0Kind right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="WidgetData0Kind"/>. </summary>
        public static implicit operator WidgetData0Kind(string value) => new WidgetData0Kind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is WidgetData0Kind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(WidgetData0Kind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
