// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies the lease action. Can be one of the available actions. </summary>
    public readonly partial struct LeaseShareAction : IEquatable<LeaseShareAction>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LeaseShareAction"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LeaseShareAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AcquireValue = "Acquire";
        private const string RenewValue = "Renew";
        private const string ChangeValue = "Change";
        private const string ReleaseValue = "Release";
        private const string BreakValue = "Break";

        /// <summary> Acquire. </summary>
        public static LeaseShareAction Acquire { get; } = new LeaseShareAction(AcquireValue);
        /// <summary> Renew. </summary>
        public static LeaseShareAction Renew { get; } = new LeaseShareAction(RenewValue);
        /// <summary> Change. </summary>
        public static LeaseShareAction Change { get; } = new LeaseShareAction(ChangeValue);
        /// <summary> Release. </summary>
        public static LeaseShareAction Release { get; } = new LeaseShareAction(ReleaseValue);
        /// <summary> Break. </summary>
        public static LeaseShareAction Break { get; } = new LeaseShareAction(BreakValue);
        /// <summary> Determines if two <see cref="LeaseShareAction"/> values are the same. </summary>
        public static bool operator ==(LeaseShareAction left, LeaseShareAction right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LeaseShareAction"/> values are not the same. </summary>
        public static bool operator !=(LeaseShareAction left, LeaseShareAction right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LeaseShareAction"/>. </summary>
        public static implicit operator LeaseShareAction(string value) => new LeaseShareAction(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LeaseShareAction other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LeaseShareAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
