// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The LayerOneTypeName. </summary>
    internal readonly partial struct LayerOneTypeName : IEquatable<LayerOneTypeName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LayerOneTypeName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LayerOneTypeName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LayerOneFooValue = "LayerOneFoo";
        private const string LayerOneBarValue = "LayerOneBar";

        /// <summary> LayerOneFoo. </summary>
        public static LayerOneTypeName LayerOneFoo { get; } = new LayerOneTypeName(LayerOneFooValue);
        /// <summary> LayerOneBar. </summary>
        public static LayerOneTypeName LayerOneBar { get; } = new LayerOneTypeName(LayerOneBarValue);
        /// <summary> Determines if two <see cref="LayerOneTypeName"/> values are the same. </summary>
        public static bool operator ==(LayerOneTypeName left, LayerOneTypeName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LayerOneTypeName"/> values are not the same. </summary>
        public static bool operator !=(LayerOneTypeName left, LayerOneTypeName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LayerOneTypeName"/>. </summary>
        public static implicit operator LayerOneTypeName(string value) => new LayerOneTypeName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LayerOneTypeName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LayerOneTypeName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
