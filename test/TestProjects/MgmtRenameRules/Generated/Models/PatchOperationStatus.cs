// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
    /// Serialized Name: PatchOperationStatus
    /// </summary>
    public readonly partial struct PatchOperationStatus : IEquatable<PatchOperationStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PatchOperationStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PatchOperationStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InProgressValue = "InProgress";
        private const string FailedValue = "Failed";
        private const string SucceededValue = "Succeeded";
        private const string CompletedWithWarningsValue = "CompletedWithWarnings";

        /// <summary>
        /// InProgress
        /// Serialized Name: PatchOperationStatus.InProgress
        /// </summary>
        public static PatchOperationStatus InProgress { get; } = new PatchOperationStatus(InProgressValue);
        /// <summary>
        /// Failed
        /// Serialized Name: PatchOperationStatus.Failed
        /// </summary>
        public static PatchOperationStatus Failed { get; } = new PatchOperationStatus(FailedValue);
        /// <summary>
        /// Succeeded
        /// Serialized Name: PatchOperationStatus.Succeeded
        /// </summary>
        public static PatchOperationStatus Succeeded { get; } = new PatchOperationStatus(SucceededValue);
        /// <summary>
        /// CompletedWithWarnings
        /// Serialized Name: PatchOperationStatus.CompletedWithWarnings
        /// </summary>
        public static PatchOperationStatus CompletedWithWarnings { get; } = new PatchOperationStatus(CompletedWithWarningsValue);
        /// <summary> Determines if two <see cref="PatchOperationStatus"/> values are the same. </summary>
        public static bool operator ==(PatchOperationStatus left, PatchOperationStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PatchOperationStatus"/> values are not the same. </summary>
        public static bool operator !=(PatchOperationStatus left, PatchOperationStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PatchOperationStatus"/>. </summary>
        public static implicit operator PatchOperationStatus(string value) => new PatchOperationStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PatchOperationStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PatchOperationStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
