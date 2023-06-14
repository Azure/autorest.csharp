// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies the lease action. Can be one of the available actions. </summary>
    public readonly partial struct LeaseContainerRequestAction : IEquatable<LeaseContainerRequestAction>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LeaseContainerRequestAction"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LeaseContainerRequestAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AcquireValue = "Acquire";
        private const string RenewValue = "Renew";
        private const string ChangeValue = "Change";
        private const string ReleaseValue = "Release";
        private const string BreakValue = "Break";

        /// <summary> Acquire. </summary>
        public static LeaseContainerRequestAction Acquire { get; } = new LeaseContainerRequestAction(AcquireValue);
        /// <summary> Renew. </summary>
        public static LeaseContainerRequestAction Renew { get; } = new LeaseContainerRequestAction(RenewValue);
        /// <summary> Change. </summary>
        public static LeaseContainerRequestAction Change { get; } = new LeaseContainerRequestAction(ChangeValue);
        /// <summary> Release. </summary>
        public static LeaseContainerRequestAction Release { get; } = new LeaseContainerRequestAction(ReleaseValue);
        /// <summary> Break. </summary>
        public static LeaseContainerRequestAction Break { get; } = new LeaseContainerRequestAction(BreakValue);
        /// <summary> Determines if two <see cref="LeaseContainerRequestAction"/> values are the same. </summary>
        public static bool operator ==(LeaseContainerRequestAction left, LeaseContainerRequestAction right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LeaseContainerRequestAction"/> values are not the same. </summary>
        public static bool operator !=(LeaseContainerRequestAction left, LeaseContainerRequestAction right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LeaseContainerRequestAction"/>. </summary>
        public static implicit operator LeaseContainerRequestAction(string value) => new LeaseContainerRequestAction(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LeaseContainerRequestAction other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LeaseContainerRequestAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
