// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtPropertyChooser.Models
{
    /// <summary> The InstanceViewTypes. </summary>
    public readonly partial struct InstanceViewTypes : IEquatable<InstanceViewTypes>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InstanceViewTypes"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InstanceViewTypes(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InstanceViewValue = "instanceView";

        /// <summary> instanceView. </summary>
        public static InstanceViewTypes InstanceView { get; } = new InstanceViewTypes(InstanceViewValue);
        /// <summary> Determines if two <see cref="InstanceViewTypes"/> values are the same. </summary>
        public static bool operator ==(InstanceViewTypes left, InstanceViewTypes right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InstanceViewTypes"/> values are not the same. </summary>
        public static bool operator !=(InstanceViewTypes left, InstanceViewTypes right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InstanceViewTypes"/>. </summary>
        public static implicit operator InstanceViewTypes(string value) => new InstanceViewTypes(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InstanceViewTypes other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InstanceViewTypes other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
