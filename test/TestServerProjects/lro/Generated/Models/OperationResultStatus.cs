// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace lro.Models
{
    /// <summary> The status of the request. </summary>
    internal readonly partial struct OperationResultStatus : IEquatable<OperationResultStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OperationResultStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OperationResultStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "canceled";
        private const string AcceptedValue = "Accepted";
        private const string CreatingValue = "Creating";
        private const string CreatedValue = "Created";
        private const string UpdatingValue = "Updating";
        private const string UpdatedValue = "Updated";
        private const string DeletingValue = "Deleting";
        private const string DeletedValue = "Deleted";
        private const string OKValue = "OK";

        /// <summary> Succeeded. </summary>
        public static OperationResultStatus Succeeded { get; } = new OperationResultStatus(SucceededValue);
        /// <summary> Failed. </summary>
        public static OperationResultStatus Failed { get; } = new OperationResultStatus(FailedValue);
        /// <summary> canceled. </summary>
        public static OperationResultStatus Canceled { get; } = new OperationResultStatus(CanceledValue);
        /// <summary> Accepted. </summary>
        public static OperationResultStatus Accepted { get; } = new OperationResultStatus(AcceptedValue);
        /// <summary> Creating. </summary>
        public static OperationResultStatus Creating { get; } = new OperationResultStatus(CreatingValue);
        /// <summary> Created. </summary>
        public static OperationResultStatus Created { get; } = new OperationResultStatus(CreatedValue);
        /// <summary> Updating. </summary>
        public static OperationResultStatus Updating { get; } = new OperationResultStatus(UpdatingValue);
        /// <summary> Updated. </summary>
        public static OperationResultStatus Updated { get; } = new OperationResultStatus(UpdatedValue);
        /// <summary> Deleting. </summary>
        public static OperationResultStatus Deleting { get; } = new OperationResultStatus(DeletingValue);
        /// <summary> Deleted. </summary>
        public static OperationResultStatus Deleted { get; } = new OperationResultStatus(DeletedValue);
        /// <summary> OK. </summary>
        public static OperationResultStatus OK { get; } = new OperationResultStatus(OKValue);
        /// <summary> Determines if two <see cref="OperationResultStatus"/> values are the same. </summary>
        public static bool operator ==(OperationResultStatus left, OperationResultStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OperationResultStatus"/> values are not the same. </summary>
        public static bool operator !=(OperationResultStatus left, OperationResultStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="OperationResultStatus"/>. </summary>
        public static implicit operator OperationResultStatus(string value) => new OperationResultStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OperationResultStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OperationResultStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
