// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes the outcome of an install operation for a given patch.
    /// Serialized Name: PatchAssessmentState
    /// </summary>
    public readonly partial struct PatchAssessmentState : IEquatable<PatchAssessmentState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="PatchAssessmentState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PatchAssessmentState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InstalledValue = "Installed";
        private const string FailedValue = "Failed";
        private const string ExcludedValue = "Excluded";
        private const string NotSelectedValue = "NotSelected";
        private const string PendingValue = "Pending";
        private const string AvailableValue = "Available";

        /// <summary>
        /// Installed
        /// Serialized Name: PatchAssessmentState.Installed
        /// </summary>
        public static PatchAssessmentState Installed { get; } = new PatchAssessmentState(InstalledValue);
        /// <summary>
        /// Failed
        /// Serialized Name: PatchAssessmentState.Failed
        /// </summary>
        public static PatchAssessmentState Failed { get; } = new PatchAssessmentState(FailedValue);
        /// <summary>
        /// Excluded
        /// Serialized Name: PatchAssessmentState.Excluded
        /// </summary>
        public static PatchAssessmentState Excluded { get; } = new PatchAssessmentState(ExcludedValue);
        /// <summary>
        /// NotSelected
        /// Serialized Name: PatchAssessmentState.NotSelected
        /// </summary>
        public static PatchAssessmentState NotSelected { get; } = new PatchAssessmentState(NotSelectedValue);
        /// <summary>
        /// Pending
        /// Serialized Name: PatchAssessmentState.Pending
        /// </summary>
        public static PatchAssessmentState Pending { get; } = new PatchAssessmentState(PendingValue);
        /// <summary>
        /// Available
        /// Serialized Name: PatchAssessmentState.Available
        /// </summary>
        public static PatchAssessmentState Available { get; } = new PatchAssessmentState(AvailableValue);
        /// <summary> Determines if two <see cref="PatchAssessmentState"/> values are the same. </summary>
        public static bool operator ==(PatchAssessmentState left, PatchAssessmentState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PatchAssessmentState"/> values are not the same. </summary>
        public static bool operator !=(PatchAssessmentState left, PatchAssessmentState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="PatchAssessmentState"/>. </summary>
        public static implicit operator PatchAssessmentState(string value) => new PatchAssessmentState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PatchAssessmentState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PatchAssessmentState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
