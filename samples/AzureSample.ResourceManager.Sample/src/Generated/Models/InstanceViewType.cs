// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// The InstanceViewType.
    /// Serialized Name: InstanceViewTypes
    /// </summary>
    public readonly partial struct InstanceViewType : IEquatable<InstanceViewType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InstanceViewType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InstanceViewType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InstanceViewValue = "instanceView";

        /// <summary>
        /// instanceView
        /// Serialized Name: InstanceViewTypes.instanceView
        /// </summary>
        public static InstanceViewType InstanceView { get; } = new InstanceViewType(InstanceViewValue);
        /// <summary> Determines if two <see cref="InstanceViewType"/> values are the same. </summary>
        public static bool operator ==(InstanceViewType left, InstanceViewType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InstanceViewType"/> values are not the same. </summary>
        public static bool operator !=(InstanceViewType left, InstanceViewType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InstanceViewType"/>. </summary>
        public static implicit operator InstanceViewType(string value) => new InstanceViewType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InstanceViewType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InstanceViewType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
