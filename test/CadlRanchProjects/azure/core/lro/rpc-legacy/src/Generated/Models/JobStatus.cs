// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace _Azure.Lro.RpcLegacy.Models
{
    /// <summary> The status of the processing job. </summary>
    public readonly partial struct JobStatus : IEquatable<JobStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="JobStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public JobStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotStartedValue = "notStarted";
        private const string RunningValue = "running";
        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "canceled";
        private const string PartiallyCompletedValue = "partiallyCompleted";

        /// <summary> The operation is not started. </summary>
        public static JobStatus NotStarted { get; } = new JobStatus(NotStartedValue);
        /// <summary> The operation is in progress. </summary>
        public static JobStatus Running { get; } = new JobStatus(RunningValue);
        /// <summary> The operation has completed successfully. </summary>
        public static JobStatus Succeeded { get; } = new JobStatus(SucceededValue);
        /// <summary> The operation has failed. </summary>
        public static JobStatus Failed { get; } = new JobStatus(FailedValue);
        /// <summary> The operation has been canceled by the user. </summary>
        public static JobStatus Canceled { get; } = new JobStatus(CanceledValue);
        /// <summary> The operation has partially completed. </summary>
        public static JobStatus PartiallyCompleted { get; } = new JobStatus(PartiallyCompletedValue);
        /// <summary> Determines if two <see cref="JobStatus"/> values are the same. </summary>
        public static bool operator ==(JobStatus left, JobStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="JobStatus"/> values are not the same. </summary>
        public static bool operator !=(JobStatus left, JobStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="JobStatus"/>. </summary>
        public static implicit operator JobStatus(string value) => new JobStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is JobStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(JobStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
