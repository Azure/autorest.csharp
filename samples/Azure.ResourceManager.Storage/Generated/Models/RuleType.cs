// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The valid value is Lifecycle. </summary>
    public readonly partial struct RuleType : IEquatable<RuleType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RuleType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RuleType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LifecycleValue = "Lifecycle";

        /// <summary> Lifecycle. </summary>
        public static RuleType Lifecycle { get; } = new RuleType(LifecycleValue);
        /// <summary> Determines if two <see cref="RuleType"/> values are the same. </summary>
        public static bool operator ==(RuleType left, RuleType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RuleType"/> values are not the same. </summary>
        public static bool operator !=(RuleType left, RuleType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RuleType"/>. </summary>
        public static implicit operator RuleType(string value) => new RuleType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RuleType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RuleType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
