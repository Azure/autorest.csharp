// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtCollectionParent.Models
{
    /// <summary> Stage status. </summary>
    public readonly partial struct StageStatus : IEquatable<StageStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StageStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StageStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string InProgressValue = "InProgress";
        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CancelledValue = "Cancelled";
        private const string CancellingValue = "Cancelling";

        /// <summary> No status available yet. </summary>
        public static StageStatus None { get; } = new StageStatus(NoneValue);
        /// <summary> Stage is in progress. </summary>
        public static StageStatus InProgress { get; } = new StageStatus(InProgressValue);
        /// <summary> Stage has succeeded. </summary>
        public static StageStatus Succeeded { get; } = new StageStatus(SucceededValue);
        /// <summary> Stage has failed. </summary>
        public static StageStatus Failed { get; } = new StageStatus(FailedValue);
        /// <summary> Stage has been cancelled. </summary>
        public static StageStatus Cancelled { get; } = new StageStatus(CancelledValue);
        /// <summary> Stage is cancelling. </summary>
        public static StageStatus Cancelling { get; } = new StageStatus(CancellingValue);
        /// <summary> Determines if two <see cref="StageStatus"/> values are the same. </summary>
        public static bool operator ==(StageStatus left, StageStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StageStatus"/> values are not the same. </summary>
        public static bool operator !=(StageStatus left, StageStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StageStatus"/>. </summary>
        public static implicit operator StageStatus(string value) => new StageStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StageStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StageStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
