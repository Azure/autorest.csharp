// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> The current provisioning state. </summary>
    public readonly partial struct ProvisioningState : IEquatable<ProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ProvisioningState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string UpdatingValue = "Updating";
        private const string DeletingValue = "Deleting";
        private const string FailedValue = "Failed";
        private const string ProvisioningValue = "Provisioning";
        private const string ActivatedValue = "Activated";
        private const string SecurityDomainRestoreValue = "SecurityDomainRestore";
        private const string RestoringValue = "Restoring";
        private const string CanceledValue = "Canceled";
        private const string CreatedValue = "Created";

        /// <summary> Succeeded. </summary>
        public static ProvisioningState Succeeded { get; } = new ProvisioningState(SucceededValue);
        /// <summary> Updating. </summary>
        public static ProvisioningState Updating { get; } = new ProvisioningState(UpdatingValue);
        /// <summary> Deleting. </summary>
        public static ProvisioningState Deleting { get; } = new ProvisioningState(DeletingValue);
        /// <summary> Failed. </summary>
        public static ProvisioningState Failed { get; } = new ProvisioningState(FailedValue);
        /// <summary> Provisioning. </summary>
        public static ProvisioningState Provisioning { get; } = new ProvisioningState(ProvisioningValue);
        /// <summary> Activated. </summary>
        public static ProvisioningState Activated { get; } = new ProvisioningState(ActivatedValue);
        /// <summary> SecurityDomainRestore. </summary>
        public static ProvisioningState SecurityDomainRestore { get; } = new ProvisioningState(SecurityDomainRestoreValue);
        /// <summary> Restoring. </summary>
        public static ProvisioningState Restoring { get; } = new ProvisioningState(RestoringValue);
        /// <summary> Canceled. </summary>
        public static ProvisioningState Canceled { get; } = new ProvisioningState(CanceledValue);
        /// <summary> Created. </summary>
        public static ProvisioningState Created { get; } = new ProvisioningState(CreatedValue);
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
