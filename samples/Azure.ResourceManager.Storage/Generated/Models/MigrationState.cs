// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> This property denotes the container level immutability to object level immutability migration state. </summary>
    public readonly partial struct MigrationState : IEquatable<MigrationState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MigrationState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MigrationState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InProgressValue = "InProgress";
        private const string CompletedValue = "Completed";

        /// <summary> InProgress. </summary>
        public static MigrationState InProgress { get; } = new MigrationState(InProgressValue);
        /// <summary> Completed. </summary>
        public static MigrationState Completed { get; } = new MigrationState(CompletedValue);
        /// <summary> Determines if two <see cref="MigrationState"/> values are the same. </summary>
        public static bool operator ==(MigrationState left, MigrationState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MigrationState"/> values are not the same. </summary>
        public static bool operator !=(MigrationState left, MigrationState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MigrationState"/>. </summary>
        public static implicit operator MigrationState(string value) => new MigrationState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MigrationState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MigrationState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
