// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace NamespaceForEnums
{
    /// <summary> More Letters. </summary>
    internal readonly partial struct NonExtensibleEnumTurnedExtensible : IEquatable<NonExtensibleEnumTurnedExtensible>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NonExtensibleEnumTurnedExtensible"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NonExtensibleEnumTurnedExtensible(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AValue = "A";
        private const string BValue = "B";
        private const string CValue = "C";

        /// <summary> A. </summary>
        public static NonExtensibleEnumTurnedExtensible A { get; } = new NonExtensibleEnumTurnedExtensible(AValue);
        /// <summary> B. </summary>
        public static NonExtensibleEnumTurnedExtensible B { get; } = new NonExtensibleEnumTurnedExtensible(BValue);
        /// <summary> C. </summary>
        public static NonExtensibleEnumTurnedExtensible C { get; } = new NonExtensibleEnumTurnedExtensible(CValue);
        /// <summary> Determines if two <see cref="NonExtensibleEnumTurnedExtensible"/> values are the same. </summary>
        public static bool operator ==(NonExtensibleEnumTurnedExtensible left, NonExtensibleEnumTurnedExtensible right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NonExtensibleEnumTurnedExtensible"/> values are not the same. </summary>
        public static bool operator !=(NonExtensibleEnumTurnedExtensible left, NonExtensibleEnumTurnedExtensible right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NonExtensibleEnumTurnedExtensible"/>. </summary>
        public static implicit operator NonExtensibleEnumTurnedExtensible(string value) => new NonExtensibleEnumTurnedExtensible(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NonExtensibleEnumTurnedExtensible other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NonExtensibleEnumTurnedExtensible other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
