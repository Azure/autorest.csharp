// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the ephemeral disk option for operating system disk.
    /// Serialized Name: DiffDiskOptions
    /// </summary>
    public readonly partial struct DiffDiskOption : IEquatable<DiffDiskOption>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DiffDiskOption"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DiffDiskOption(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LocalValue = "Local";

        /// <summary>
        /// Local
        /// Serialized Name: DiffDiskOptions.Local
        /// </summary>
        public static DiffDiskOption Local { get; } = new DiffDiskOption(LocalValue);
        /// <summary> Determines if two <see cref="DiffDiskOption"/> values are the same. </summary>
        public static bool operator ==(DiffDiskOption left, DiffDiskOption right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DiffDiskOption"/> values are not the same. </summary>
        public static bool operator !=(DiffDiskOption left, DiffDiskOption right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DiffDiskOption"/>. </summary>
        public static implicit operator DiffDiskOption(string value) => new DiffDiskOption(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DiffDiskOption other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DiffDiskOption other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
