// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtScopeResource.Models
{
    /// <summary> Denotes the state of provisioning. </summary>
    public readonly partial struct ProvisioningState : IEquatable<ProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotSpecifiedValue = "NotSpecified";
        private const string AcceptedValue = "Accepted";
        private const string RunningValue = "Running";
        private const string ReadyValue = "Ready";
        private const string CreatingValue = "Creating";
        private const string CreatedValue = "Created";
        private const string DeletingValue = "Deleting";
        private const string DeletedValue = "Deleted";
        private const string CanceledValue = "Canceled";
        private const string FailedValue = "Failed";
        private const string SucceededValue = "Succeeded";
        private const string UpdatingValue = "Updating";

        /// <summary> NotSpecified. </summary>
        public static ProvisioningState NotSpecified { get; } = new ProvisioningState(NotSpecifiedValue);
        /// <summary> Accepted. </summary>
        public static ProvisioningState Accepted { get; } = new ProvisioningState(AcceptedValue);
        /// <summary> Running. </summary>
        public static ProvisioningState Running { get; } = new ProvisioningState(RunningValue);
        /// <summary> Ready. </summary>
        public static ProvisioningState Ready { get; } = new ProvisioningState(ReadyValue);
        /// <summary> Creating. </summary>
        public static ProvisioningState Creating { get; } = new ProvisioningState(CreatingValue);
        /// <summary> Created. </summary>
        public static ProvisioningState Created { get; } = new ProvisioningState(CreatedValue);
        /// <summary> Deleting. </summary>
        public static ProvisioningState Deleting { get; } = new ProvisioningState(DeletingValue);
        /// <summary> Deleted. </summary>
        public static ProvisioningState Deleted { get; } = new ProvisioningState(DeletedValue);
        /// <summary> Canceled. </summary>
        public static ProvisioningState Canceled { get; } = new ProvisioningState(CanceledValue);
        /// <summary> Failed. </summary>
        public static ProvisioningState Failed { get; } = new ProvisioningState(FailedValue);
        /// <summary> Succeeded. </summary>
        public static ProvisioningState Succeeded { get; } = new ProvisioningState(SucceededValue);
        /// <summary> Updating. </summary>
        public static ProvisioningState Updating { get; } = new ProvisioningState(UpdatingValue);
        /// <summary> Determines if two <see cref="ProvisioningState"/> values are the same. </summary>
        public static bool operator ==(ProvisioningState left, ProvisioningState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(ProvisioningState left, ProvisioningState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ProvisioningState"/>. </summary>
        public static implicit operator ProvisioningState(string value) => new ProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
